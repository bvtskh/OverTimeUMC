using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class Form1 : Form
    {
        private string _version;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string para): this()
        {
            if(para.Length > 0)
            {
                string[] info = para.Split('|').ToArray();
                Common.UserLogin.UserName = info[0];
                Common.UserLogin.PassWord = info[1];
                if(info.Length > 2) { Common.DeptApprove = info[2]; }
                if(info.Length > 3) { Common.UserLogin.Action = info[3]; }
                if(info.Length > 4) { Common.DateApprove = info[4]; }
                if(info.Length > 5) { Common.ReqNoAppr = info[5]; }
                             
                using (var db = new DBContext())
                {
                    var findUser = db.Tbl_User.FirstOrDefault(x => x.UserCode == Common.UserLogin.UserName);
                    if(findUser!= null)
                    {
                        Common.UserLogin.FullName = findUser.FullName;
                        Common.UserLogin.Role = findUser.Role;
                        Common.UserLogin.Email = findUser.Email;
                        Common.UserLogin.Dept = findUser.Dept;
                        Common.UserLogin.TypeUser = findUser.TypeUser;
                        lbUser.Text = string.Format("{0}_{1}_{2}", Common.UserLogin.UserName, Common.UserLogin.FullName, Common.UserLogin.Dept);
                    }
                    else
                    {
                        lbUser.Text = "Read Only";
                        Common.UserLogin.UserName = "View";
                        Common.UserLogin.Dept = "";
                    }
                }

                var lstfindDept = PI_Lib.MankichiHelper.GetAllStaffWorking();
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


                CheckUserRule();
                
                //FormTest frmTest = new FormTest();
                //frmTest.Show();
            }
        }

        private void CheckUserRule()
        {
            if (Common.UserLogin.UserName == "View")
            {
                BudgetOT.Visible = User.Visible = RegisterOTPreShift.Visible = btnRetrictOT.Visible = false;
            }
            else
            {
                if(Common.UserLogin.TypeUser == "Salary")
                {
                    BudgetOT.Visible = RegisterOTPreShift.Visible = btnRetrictOT.Visible = true;
                    User.Visible = false;
                }
                else
                {
                    BudgetOT.Visible = true;
                    RegisterOTPreShift.Visible = btnRetrictOT.Visible = false;
                    User.Visible = false;
                }
            }
            if(Common.UserLogin.TypeUser == "Admin")
            {
                BudgetOT.Visible = User.Visible = RegisterOTPreShift.Visible = btnRetrictOT.Visible = true;
            }
            
        }


        private void CheckSpecialApprove()
        {
            if (!string.IsNullOrEmpty(Common.UserLogin.Action) && (Common.UserLogin.Action.ToLower()) == "specialapprove")
            {
                FormHistoryAdjustOT frmHistory = (FormHistoryAdjustOT)Application.OpenForms["FormHistoryAdjustOT"];
                if (frmHistory == null)
                {
                    frmHistory = new FormHistoryAdjustOT();
                    tabMain.TabPages.Add(frmHistory);
                }
                else
                {
                    try { tabMain.TabPages[frmHistory].Select(); }
                    catch { tabMain.TabPages.Add(frmHistory); }
                }
            }
        }
      //  WaitWnd.WaitForm fWait = new WaitWnd.WaitForm();
        private void Form1_Load(object sender, EventArgs e)
        {
          //  fWait.Show(this);

            //check kết nối server

            if (!Common.IsServerConnected("172.28.6.96", 3000))
            {
                Common.KillProcess("LoadTitle");
                MessageBox.Show("Can't Connect to Server.\nKhông truy cập được mạng nội bộ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
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
                //\\vn-file\LCA Department\34. Factory Horenso System\Factory Horenso System\Factory Horenso System Ver{0}\Factory Horenso System Ver{0}.exe
                if (VersionInfo == null) return;
                if (VersionInfo.Version != _version)
                {
                    string msg = string.Format("Đã lên version {0}. Hãy vào đường dẫn  {1}", VersionInfo.Version, Common.PathAppRun);
                    MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    return;
                }
            }
            //Common.RunProcess("LoadTitle.exe");
            ribPanelInput_Click(null, null);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //Common.KillProcess("LoadTitle");
            CheckSpecialApprove();
            //fWait.Close();
        }




        private void ribPanelInput_Click(object sender, EventArgs e)
        {
            FormInput frmInput = (FormInput)Application.OpenForms["FormInput"];
            if(frmInput == null)
            {
                frmInput = new FormInput();
                tabMain.TabPages.Add(frmInput);
            }
            else
            {
                try { tabMain.TabPages[frmInput].Select(); }
                catch { tabMain.TabPages.Add(frmInput); }
            }
        }

        private void BudgetOT_Click(object sender, EventArgs e)
        {
            FormBudgetOT frmBudget = new FormBudgetOT();
            frmBudget.Show();
        }

        private void User_Click(object sender, EventArgs e)
        {
            FormUser frmUser = new FormUser();
            frmUser.Show();
        }

        private void RegisterOTPreShift_Click(object sender, EventArgs e)
        {
            FormOTBeforeShift frm = new FormOTBeforeShift();
            frm.Show();
        }

        private void btnRetrictOT_Click(object sender, EventArgs e)
        {
            FormRetrictOT frm = new FormRetrictOT();
            frm.Show();
        }

        private void ribBtnUpdateLineProcess_Click(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Common.flagWait == false)
            {
                Application.Exit();
            }
            else
            {
                this.Hide();
               // Thread.Sleep(10000);
                Application.Exit();
            }

        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }
    }
}
