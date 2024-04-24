﻿using CommonProject;
using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using OverTime.DataBase;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormMain : Form
    {
        private string _version;
        private string para;
        public string USERNAME { get; set; }
        BackgroundWorker workerUpdateDayOff;
        BackgroundWorker workerInstance;
        public FormMain(string para)
        {
            InitializeComponent();
            InitBackgroundWorker();
            this.para = para;
            if (para.Length > 0)
            {
                string[] info = para.Split('|').ToArray();
                Common.UserLogin.UserName = info[0];
                this.USERNAME = info[0];
                Common.UserLogin.PassWord = info[1];
                if (info.Length > 2) { Common.UserLogin.Action = info[2]; }
                if (info.Length > 3) { Common.DateApprove = info[3]; }
                if (info.Length > 4) { Common.ReqNoAppr = info[4]; }

                Task.Factory.StartNew(() =>
                {
                    using (var db = new DBContext())
                    {
                        var findUser = db.Tbl_User.FirstOrDefault(x => x.UserCode == Common.UserLogin.UserName);
                        if (findUser != null)
                        {
                            Common.UserLogin.FullName = findUser.FullName;
                            Common.UserLogin.Role = findUser.Role;
                            Common.UserLogin.Email = findUser.Email;
                            Common.UserLogin.Dept = findUser.Dept;
                            Common.UserLogin.TypeUser = findUser.TypeUser;
                            lbUser.Text = $"Hi! {Common.UserLogin.FullName}\nBộ phận: {Common.UserLogin.Dept}"; /*string.Format("{0}_{1}_{2}", Common.UserLogin.UserName, Common.UserLogin.FullName, Common.UserLogin.Dept);*/
                        }
                        else
                        {
                            lbUser.Text = "Read Only";
                            Common.UserLogin.UserName = "View";
                            Common.UserLogin.Dept = "";
                        }
                    }
                });


                var lstfindDept = GAMankuchi.Instance()._listCurrentStaff;
                var lstDept = lstfindDept.GroupBy(x => new { x.Dept }).Select(x => new
                {
                    Dept = x.Key.Dept,
                    DeptNonSpec = x.Key.Dept.Replace(" ", ""),
                }).ToList();
                var findDept = lstDept.FirstOrDefault(x => x.DeptNonSpec == Common.DeptApprove);
                if (findDept != null)
                {
                    Common.DeptApprove = findDept.Dept;
                }

                if (Common.UserLogin.Action != null)
                {
                    if (Common.UserLogin.Action.ToLower() == "approve" || (Common.UserLogin.Action.ToLower()) == "specialapprove")
                    {
                        btnCheck_Click(null, null);
                    }
                    else
                    {
                        btnRegister_Click(btnRegister, null);
                    }
                }
                else
                {
                    btnRegister_Click(btnRegister, null);
                }

                var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                _version = assemblyName.Version.ToString();

                using (var ctx = new DBContext())
                {
                    var vers = ctx.Tbl_Version.ToList();
                    vers = vers.OrderBy(x => x.Id).ToList();
                    var VersionInfo = vers.LastOrDefault();
                    this.Text = "Over Time System Management Ver:" + _version.ToString();
                    Common.PathAppRun = string.Format(VersionInfo.Path, VersionInfo.Version);
                    if (VersionInfo == null) return;
                    if (VersionInfo.Version != _version)
                    {
                        string msg = string.Format("Đã lên version {0}. Hãy vào đường dẫn  {1}", VersionInfo.Version, Common.PathAppRun);
                        MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                        return;
                    }
                }
            }
        }

        private void InitBackgroundWorker()
        {
            workerUpdateDayOff = new BackgroundWorker();
            workerUpdateDayOff.DoWork += new DoWorkEventHandler(DoWork_UpdateDayOff);
            workerUpdateDayOff.RunWorkerAsync();
        }

        private void DoWork_UpdateDayOff(object sender, DoWorkEventArgs e)
        {
            DayOffHelper dayOffHelper = new DayOffHelper();
            dayOffHelper.UpdateDayOff();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                //ChangeLocation(button);
                ChangeColorButton(button);
            }

            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormHistoryRegistration());
            this.Focus();
        }

        private void ChangeColorButton(Button button)
        {
            button.BackColor= Color.White;
            this.panelFunction.Controls.OfType<Button>().Where(w=>w != button).ForEach(f=>f.BackColor = Color.Gray);
        }

        Button originButton;
        private void ChangeLocation(Button button)
        {
            if(originButton == null)
            {
                originButton = btnRegister;// button gốc.
            }

            Point originPoint = new Point(10,15);// tọa độ gốc

            //tọa độ button đang chọn để đẩy lên đầu.
            Point buttonSelectPoint = button.Location;

            // gán tọa độ button đang chọn cho tọa độ gốc.
            button.Location = new Point(originPoint.X, originPoint.Y);

            // gán tọa độ cho button gốc vào vị trí button được chọn
            originButton.Location = new Point(buttonSelectPoint.X, buttonSelectPoint.Y);
            // button gốc lúc này sẽ là button được chọn;
            originButton = button;

        }

        private void LoadFormControll(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            panelMain.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
            if (form.Text == "FormEditOverTime" || form.Text == "FormInputFingerPrint")
            {
                Common.flagWait = false;
            }
            else { Common.flagWait = true; }

        }

        private void btnInputTime_Click(object sender, EventArgs e)
        {

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Font = new Font("Arial", 12, FontStyle.Bold);
            // Create menu options as labels
            ToolStripMenuItem option1 = new ToolStripMenuItem("Nhập dữ liệu vân tay");
            ToolStripMenuItem option2 = new ToolStripMenuItem("Cập nhật Shift ca");
            option1.Image = Properties.Resources.finger;
            option2.Image = Properties.Resources.excel;
           
            menu.Items.Add(option1);
            menu.Items.Add(option2);

            // Handle option selection
            option1.Click += Option1_Click;
            option2.Click += Option2_Click;

            // Show the context menu
            menu.Show(btnInputTime, new Point(0, btnInputTime.Height));


            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }         
        }

        private void Option2_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var destinationPath = $@"\\172.28.10.12\DX Center\ThanhDX\ShiftCa_{DateTime.Now.ToString("ddMMyyyy hhmmss")}.xlsx";
                    ATCommon.ATCommon.CopyExcelFile(FileDlg.FileName, destinationPath);
                    if (!File.Exists(FileDlg.FileName)) return;
                    DataTable dataTable = ExcelFileProcess.GetShiftCaData(FileDlg.FileName);
                    object dateTimeApprove = dataTable.Rows[2].Field<object>(0);
                    if (dateTimeApprove != null)
                    {
                        try
                        {
                            string dateTime = dateTimeApprove.ToString().Split(':').Last();
                            int month = dateTime.Split('/').First().ToInt();
                            int year = dateTime.Split('/').Last().ToInt();
                            //if(OverTimeHelper.ShiftCaExist(month, year))
                            //{
                            //    if (CommonProject.MsgBox_AQ.RJMessageBox.Show($"Shift ca: {dateTime} đã cập nhật trước đó rồi, Chọn Yes để tiếp tục, No để hủy bỏ", "Cập nhật shift ca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            //    {
                            //        OverTimeHelper.UpdateShiftCa(dataTable, month, year);
                            //        CommonProject.MsgBox_AQ.RJMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //}
                            //else
                            //{
                            if (CommonProject.MsgBox_AQ.RJMessageBox.Show($"Bạn đang cập nhật Shift ca: {dateTime}, Chọn Yes để tiếp tục, No để hủy bỏ", "Cập nhật shift ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                OverTimeHelper.UpdateShiftCa(dataTable, month, year);
                                CommonProject.MsgBox_AQ.RJMessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //}
                        }
                        catch (Exception)
                        {
                            CommonProject.MsgBox_AQ.RJMessageBox.Show("File sai định dạng", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        CommonProject.MsgBox_AQ.RJMessageBox.Show("File sai định dạng", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return ;
                    }
                }
                catch (IOException)
                {
                    CommonProject.MsgBox_AQ.RJMessageBox.Show("Vui lòng đóng file trước khi cập nhật!", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                catch (Exception)
                {
                    CommonProject.MsgBox_AQ.RJMessageBox.Show("Có lỗi xảy ra:", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void Option1_Click(object sender, EventArgs e)
        {
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormInputFingerPrint());
            this.Focus();
        }

        private void btnEditOverTime_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormEditOverTime());
            this.Focus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormCheckAndApprove());
            this.Focus();
        }

        private void btnGAWorkSpace_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormGAWorkSpace());
            this.Focus();
        }

        private void btnSpecialAdjust_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormSepcialAdjustOT());
            this.Focus();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            CheckSpecialApprove();
            workerUpdateDayOff = new BackgroundWorker();
            workerUpdateDayOff.DoWork += new DoWorkEventHandler(DoWork_InitInstance);
            workerUpdateDayOff.RunWorkerAsync();
        }

        private void DoWork_InitInstance(object sender, DoWorkEventArgs e)
        {
             GAMankuchiAll.Instance();
        }

        private void CheckSpecialApprove()
        {
            if (!string.IsNullOrEmpty(Common.UserLogin.Action) && (Common.UserLogin.Action.ToLower()) == "specialapprove")
            {
                FormHistoryAdjustOT frmAppr = new FormHistoryAdjustOT(int.Parse(Common.ReqNoAppr), "Approve");
                frmAppr.ShowDialog();
            }
        }
        private void nhậpDựToánTăngCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFCOT frmBudget = new FormFCOT();
            frmBudget.Show();
        }

        private void hạnChếTăngCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRetrictOT frm = new FormRetrictOT();
            frm.Show();
        }

        private void updateLineCôngĐoạnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                var findUser = db.Tbl_User.FirstOrDefault(x => x.UserCode == Common.UserLogin.UserName);
                if (findUser != null)
                {
                    if (findUser.TypeUser == "PDJob")
                    {
                        FormAddJobPC frmUpdateLine = new FormAddJobPC();
                        frmUpdateLine.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền truy cập nội dung này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void đăngKýTăngCaTrướcGiờToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOTBeforeShift frm = new FormOTBeforeShift();
            frm.Show();
        }

        private void nhậpNhânSựTăngCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHumanOT frm = new FormHumanOT();
            frm.Show();
        }

        private void btnEarlyOvertime_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                ChangeColorButton(button);
            }
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormOTBeforeShift());
            this.Focus();
        }

        private void theoDõiTăngCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBalanceFCOT frm = new FormBalanceFCOT();
            frm.Show();
        }

        private void ngàyNghỉƯuĐãiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FormPreferentialDaysOff().Show();
        }

        private void danhSáchQuênVânTayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormForgetFingerprints().Show();
        }

        private void ngàyNghỉCóLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormApplyForLeave().Show();
        }

        private void ThốngkêtăngcatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormStatistic().Show();
        }
    }
}