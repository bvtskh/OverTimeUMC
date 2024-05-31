using CommonProject.Business;
using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormCheckAndApprove : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichiOrigin = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<Tbl_Setting> lstSetting = new List<Tbl_Setting>();
        private List<AdjustOverTime> lstAdjustOTFull = new List<AdjustOverTime>();
        private List<AdjustOverTime> lstAdjustSearch = new List<AdjustOverTime>();
        public FormCheckAndApprove()
        {
            InitializeComponent();
            lbWaitApprove.Text = lbListWait.Text = null;
            lbWaitApprove.Visible = picApproved.Visible = false;
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start();
        }

        private void FormCheckAndApprove_Load(object sender, EventArgs e)
        {
            
        }

        private void RequestCompleted(DataTable dt)
        {
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            foreach (var item in ArrDept)
            {
                cbbDept.Items.Add(item);
            }
            if (ArrDept.Length == 1) cbbDept.SelectedIndex = 0;
            LoadSetting();
            LoadDataApprove();
            if (Common.UserLogin.Role != "Approve")
            {
                btnApprove.Enabled = false;
                btnApproveALL.Enabled = false;
                btnFeedback.Enabled = false;
                button3.Enabled = true;
            }
            else
            {
                btnApprove.Enabled = true;
                btnApproveALL.Enabled = true;
                btnFeedback.Enabled = true;
                button3.Enabled = false;
            }
            CheckUserAndRule();
        }

        private DataTable GetData()
        {
            LoadInfoMasterData();
            return new DataTable();
        }

        private void CheckUserAndRule()
        {
            if (Common.UserLogin.UserName == "View")
            {
                button3.Enabled = false;
                btnApprove.Enabled = false;
            }
        }

        private void LoadDataApprove()
        {
            if (Common.UserLogin.Action == "Approve")
            {
                if (!string.IsNullOrEmpty(Common.DateApprove) && !string.IsNullOrEmpty(Common.DeptApprove))
                {
                    dtDateOverTime.Value = Convert.ToDateTime(Common.DateApprove);
                    cbbDept.Text = Common.DeptApprove;
                    btnSearch_Click(null, null);
                    cbViewAll.Checked = true;
                }
            }
        }


        private void LoadInfoMasterData()
        {
            lstMankichiOrigin = GAMankuchiAll.Instance()._listAllStaff;

        }


        private void LoadSetting()
        {
            using (var db = new DBContext())
            {
                lstSetting = db.Tbl_Setting.ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Dept = cbbDept.Text;
            if (string.IsNullOrEmpty(Dept))
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lstAdjustOTFull.Clear();
            lstAdjustSearch.Clear();
            lstAdjustOTFull = OverTimeHelper.LoadAllListToAdjustOverTime(dtDateOverTime.Value.Date, Dept);
            ClearOverTimePositionManager();
            lstAdjustSearch = lstAdjustOTFull.Where(x => x.Dept == Dept).OrderBy(o=>o.Code).ToList();
            var lstNotConfirm = lstAdjustSearch.Where(x => x.Balance != 0 && string.IsNullOrEmpty(x.Comment)).OrderBy(o => o.Code).ToList();
            dgvConfirmOT.DataSource = null;
            if (cbViewAll.Checked == false)
            {
                AddListAdjustToDgv(lstNotConfirm);
            }
            else { AddListAdjustToDgv(lstAdjustSearch); }           
            dgvConfirmOT.Refresh();
            UpdateRateConfirm();
            CheckDateApprove();
            CalculatorTotalHoursAndHumanOverTime(lstAdjustSearch);
            AlarmYellowRowLuyKe();
        }

        private void AlarmYellowRowLuyKe()
        {
            dgvConfirmOT.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Direct"].Value.ToString().Contains("Gián") && ConvertDouble(w.Cells["Accumulated"].Value) >= (int)AlarmYellow.GianTiep).ToList().ForEach(f => f.Cells["Accumulated"].Style.BackColor = Color.Yellow);
            dgvConfirmOT.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Direct"].Value.ToString().Contains("Trực") && ConvertDouble(w.Cells["Accumulated"].Value) >= (int)AlarmYellow.TrucTiep).ToList().ForEach(f => f.Cells["Accumulated"].Style.BackColor = Color.Yellow);
        }

        private void AddListAdjustToDgv(List<AdjustOverTime> lstItem)
        {
            dgvConfirmOT.Rows.Clear();
            foreach (var item in lstItem)
            {
                int rowId = dgvConfirmOT.Rows.Add();
                DataGridViewRow row = dgvConfirmOT.Rows[rowId];
                row.Cells["Code"].Value = item.Code;
                row.Cells["FullName"].Value = item.FullName;
                row.Cells["Dept"].Value = item.Dept;
                row.Cells["Direct"].Value = item.Direct;
                row.Cells["Customer"].Value = item.Customer;
                row.Cells["Shift"].Value = item.Shift;
                row.Cells["TimeIn"].Value = item.TimeIn;
                row.Cells["TimeOut"].Value = item.TimeOut;
                row.Cells["TimeOTPreShift"].Value = item.TimeOTPreShift;
                row.Cells["TimeFinger"].Value = item.TimeFinger;
                row.Cells["TotalOT"].Value = item.TotalOT;
                row.Cells["RegisOT"].Value = item.RegisOT;
                row.Cells["Balance"].Value = item.Balance;
                row.Cells["Accumulated"].Value = item.Accumulated;
                row.Cells["Comment"].Value = item.Comment;
                row.Cells["TimeDept"].Value = item.TimeDept;
            }
        }

        private void ClearOverTimePositionManager()
        {
            var lstManager = lstAdjustOTFull.Where(x => x.Position.Contains("Manager")).ToList();
            foreach (var item in lstManager)
            {
                item.TotalOT = 0;
                item.TimeFinger = 0;
                item.Balance = 0;
                item.RegisOT = 0;
            }
        }

        private void CalculatorTotalHoursAndHumanOverTime(List<AdjustOverTime> lstItem)
        {
            var lstOT = lstItem.Where(x => x.TimeDept > 0).ToList();
            var TotalHours = lstOT.Aggregate<AdjustOverTime, double>(0, (total, s) => total += (double)(s.TimeDept));
            lbTotalHuman.Text = lstOT.Count.ToString();
            lbTotalHours.Text = TotalHours.ToString();
        }


        private void CheckDateApprove()
        {
            // Kiểm tra xem còn ngày nào chưa phê duyệt
            DateTime DateSelect = dtDateOverTime.Value.Date;
            using (var db = new DBContext())
            {
                if (!string.IsNullOrEmpty(cbbDept.Text))
                {
                    lbListWait.Text = null;
                    lbWaitApprove.Text = "---";
                    lbWaitApprove.Visible = true;
                    picApproved.Visible = false;
                    // Tìm list danh sách ngày đang chờ approve của bộ phận
                    var findListWaitApprove = db.Tbl_Approve.Where(x => x.Dept == cbbDept.Text && string.IsNullOrEmpty(x.Approve)).ToList();
                    if (findListWaitApprove.Count > 0)
                    {
                        string DateWaitAppr = string.Empty;
                        foreach (var item in findListWaitApprove)
                        {
                            DateWaitAppr += item.DateOT.ToString("dd/MMM") + " | ";
                        }
                        if (DateWaitAppr.EndsWith("| "))
                        {
                            DateWaitAppr = DateWaitAppr.Remove(DateWaitAppr.Length - 1, 1);
                        }
                        lbListWait.Text = DateWaitAppr.ToString();
                    }
                    // TÌm ngày đã chọn đang chờ approve
                    var findDateWaitApprove = db.Tbl_Approve.FirstOrDefault(x => x.DateOT == DateSelect && x.Dept == cbbDept.Text);
                    if (findDateWaitApprove != null)
                    {
                        if (string.IsNullOrEmpty(findDateWaitApprove.Approve))
                        {
                            lbWaitApprove.Text = "CHỜ PHÊ DUYỆT TĂNG CA";
                            lbWaitApprove.Visible = true;
                            picApproved.Visible = false;
                        }
                        else
                        {
                            lbWaitApprove.Text = "ĐÃ PHÊ DUYỆT";
                            lbWaitApprove.Visible = false;
                            picApproved.Visible = true;
                        }
                    }
                    else
                    {
                        lbWaitApprove.Text = "---";
                        lbWaitApprove.Visible = true;
                        picApproved.Visible = false;
                    }
                }

            }

        }



        private void EditViewDgvConfirm()
        {
            dgvConfirmOT.Columns["TimeOTPreShift"].HeaderText = "OT TrướcCa";
            dgvConfirmOT.Columns["RegisOT"].HeaderText = "Đăng Ký";
            dgvConfirmOT.Columns["TimeFinger"].HeaderText = "Giờ VânTay";
            dgvConfirmOT.Columns["TimeDept"].HeaderText = "Giờ BP";
            dgvConfirmOT.Columns["Balance"].HeaderText = "Chênh Lệch";
            dgvConfirmOT.Columns["Comment"].HeaderText = "Comment";
            dgvConfirmOT.Columns["Accumulated"].HeaderText = "Lũy kế";
            dgvConfirmOT.Columns["Direct"].HeaderText = "Công việc";
            dgvConfirmOT.Columns["Code"].HeaderText = "Mã NV";
            dgvConfirmOT.Columns["FullName"].HeaderText = "Họ Tên";
            dgvConfirmOT.Columns["Dept"].HeaderText = "Bộ phận";
            dgvConfirmOT.Columns["Customer"].HeaderText = "Khách hàng";

            dgvConfirmOT.Columns["TimeOTPreShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConfirmOT.Columns["RegisOT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConfirmOT.Columns["TimeFinger"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConfirmOT.Columns["TimeDept"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConfirmOT.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvConfirmOT.Columns["TotalOT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvConfirmOT.Columns["Position"].Visible = false;
            dgvConfirmOT.Columns["Line"].Visible = false;
            dgvConfirmOT.Columns["Shift"].Visible = false;
            dgvConfirmOT.Columns["Process"].Visible = false;
            dgvConfirmOT.Columns["TimeOTPreShift"].Visible = false;
            dgvConfirmOT.Columns["TimeFinger"].Visible = false;
            dgvConfirmOT.FitContent();
        }



        private void UpdateRateConfirm()
        {
            int TotalNeedConfirm = OverTimeHelper.CounTotalNeedConfirm(lstAdjustSearch);
            int TotalConfirmed = OverTimeHelper.CountConfirmed(lstAdjustSearch);
            lbConfirm.Text = TotalConfirmed.ToString() + "/" + TotalNeedConfirm.ToString();
            if (TotalNeedConfirm != 0)
            {
                double rate = ((double)TotalConfirmed / (double)TotalNeedConfirm) * 100;
                rate = Math.Round(rate, 2);
                lbRate.Text = rate.ToString() + "%";
            }
        }


        private void cbViewAll_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private bool CheckHaveDataTimeFinger()
        {
            bool Result = false;
            DateTime Select = dtDateOverTime.Value.Date;
            using (var db = new DBContext())
            {
                var lstOTDateSelect = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == Select).ToList();
                var lstOTDateSelectGroup = lstOTDateSelect.GroupBy(x => new { x.TimeIn }).Select(x => new
                {
                    TimeIn = x.Key.TimeIn,
                }).ToList();
                if (lstOTDateSelectGroup.Count > 1)
                {
                    Result = true;
                }
            }
            return Result;
        }


        
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDept.Text))
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckHaveDataTimeFinger() == false)
            {
                MessageBox.Show("Chưa có dữ liệu vân tay\nKhông thể xin phê duyệt tăng ca\nXem lại ngày cần xin phê duyệt\nChỉ xin phê duyệt khi đã điều chỉnh tăng ca xong", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string mes = string.Format("Bạn chắc chắn đã chọn đúng ngày cần xin phê duyệt tăng ca:{0}", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
            DialogResult dlr = MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Yes)
            {
                if (lstAdjustSearch.Count > 0)
                {
                    if (OverTimeHelper.CountWaitConfirm(lstAdjustSearch) > 0)
                    {
                        MessageBox.Show("Chưa xác nhận hết các trường hợp chênh lệch\nCác trường hợp chênh lệch bắt buộc phải có lý do", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    else
                    {
                        // Ghi dữ liệu đã xin phê duyệt tăng ca
                        using (var db = new DBContext())
                        {
                            DateTime DateSelected = dtDateOverTime.Value.Date;
                            var findExitSendApprove = db.Tbl_Approve.FirstOrDefault(x => x.DateOT == DateSelected && x.Dept == cbbDept.Text);
                            if (findExitSendApprove != null)
                            {
                                if (findExitSendApprove.EmailApprove != null)
                                {
                                    string mesappr = string.Format("Đã gửi email xin phê duyệt ngày {0} rồi.\nBạn có muốn gửi lại không", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
                                    DialogResult dlra = MessageBox.Show(mesappr, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (dlra == DialogResult.Yes)
                                    {
                                        SendEmailApprove();
                                    }
                                }
                                else
                                {
                                    findExitSendApprove.EmailApprove = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                                    db.Entry<Tbl_Approve>(findExitSendApprove).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                    SendEmailApprove();
                                }
                            }
                            else
                            {
                                Tbl_Approve sendAppr = new Tbl_Approve();
                                sendAppr.DateOT = DateSelected;
                                sendAppr.Dept = cbbDept.Text;
                                sendAppr.EmailApprove = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                                db.Tbl_Approve.Add(sendAppr);
                                db.SaveChanges();
                                SendEmailApprove();
                            }

                        }
                    }
                    //return;
                }
                else
                {
                    MessageBox.Show("Kiểm tra (Check) trước khi gửi email xin phê duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }


        private void SendEmailApprove()
        {
            var Dept = cbbDept.Text;
            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Phê Duyệt Tăng ca bộ phận {0}", cbbDept.Text);
                string PathRunPara = string.Format("{0}|{1} {2} ", Common.PathAppRun, "Approve", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
                var content = string.Format("Dear Trưởng BP {3} </br> Vui lòng vào phê duyệt tăng ca của bộ phận: {0} ngày {1} </br></br><a href=\"{2}\">{4}[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"), PathRunPara, DeptPara, PathRunPara);             
                MailProcess.SendEmail(Dept, subject, content);
                MessageBox.Show("Send Email", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SendEmailConfirmApproved()
        {
            var Dept = cbbDept.Text;
            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Hoàn thành phê duyệt Tăng ca bộ phận {0}", cbbDept.Text);
                string PathRunPara = string.Format("{0}|{1} {2}", Common.PathAppRun, "Approve", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
                var content = string.Format("Dear GA </br> Bộ phận: {0} đã hoàn thành phê duyệt tăng ca ngày {1} </br></br><a href=\"{2}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"), PathRunPara);
                MailProcess.SendEmailConfirm(Dept, subject, content);
                // MessageBox.Show("Send Email Confirm", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        private void SendEmailConfirmApprovedAllDay()
        {
            var Dept = cbbDept.Text;
            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Hoàn thành phê duyệt Tăng ca bộ phận {0}", cbbDept.Text);
                string PathRunPara = string.Format("{0}|{1} {2}", Common.PathAppRun, "Approve", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
                var content = string.Format("Dear GA </br> Bộ phận: {0} đã hoàn thành phê duyệt tăng ca tất cả các ngày </br></br><a href=\"{1}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, PathRunPara);
                MailProcess.SendEmailConfirm(Dept, subject, content);
                MessageBox.Show("Send Email Confirm", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }



        private void btnFeedback_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFeedback.Text))
            {
                var Dept = cbbDept.Text;
                var DeptPara = Dept.Replace(" ", "");
                string Pic = string.Format("Quản Lý Ca {0}", Dept);
                string PathRunPara = string.Format("{0}|{1} {2} {3}", Common.PathAppRun, DeptPara, "Approve", dtDateOverTime.Value.Date.ToString("dd/MMM/yyyy"));
                var subject = string.Format("[OVER TIME] Phê Duyệt Tăng ca bộ phận {0}", cbbDept.Text);
                var content = string.Format("Dear {2} </br> {0} </br></br><a href=\"{1}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", txtFeedback.Text, Common.PathAppRun, Pic);
                MailProcess.SendEmail(Dept, subject, content);
                MessageBox.Show("Send Email", "Thông Báo");
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveDailyOverTimeNewMethod();
        }


        private void ApproveOTBackup()
        {
            DateTime dateSelect = dtDateOverTime.Value.Date;
            List<Tbl_DailyOverTime> lstApprove = new List<Tbl_DailyOverTime>();
            //var ItemNotConfirm = lstAdjustSearch.Where(x => x.Balance != 0 && string.IsNullOrEmpty(x.Comment)).ToList().Count;
            //if (ItemNotConfirm != 0)
            //{
            //    MessageBox.Show("Chưa xác nhận hết các trường hợp chênh lệch", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            using (var db = new DBContext())
            {
                Common.RunProcess("LoadTitle.exe");
                var lstAllDailyOT = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();
                lstApprove = (from d in lstAllDailyOT
                              join a in lstAdjustSearch on d.Code equals a.Code
                              select d).ToList();

                foreach (var item in lstApprove)
                {
                    string TimeApprove = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                    item.Approve = Common.UserLogin.UserName + "_" + TimeApprove;
                    db.Entry<Tbl_DailyOverTime>(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                Common.KillProcess("LoadTitle");
                MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void ApproveDailyOverTimeNewMethod()
        {
            try
            {
                using (var db = new DBContext())
                {
                    if (!string.IsNullOrEmpty(cbbDept.Text))
                    {
                        DateTime DateSelect = dtDateOverTime.Value.Date;
                        var findWaitApprove = db.Tbl_Approve.FirstOrDefault(x => x.DateOT == DateSelect && x.Dept == cbbDept.Text && x.EmailApprove != null);
                        if (findWaitApprove != null)
                        {
                            string TimeApprove = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                            findWaitApprove.Approve = Common.UserLogin.UserName + "_" + TimeApprove;
                            db.Entry<Tbl_Approve>(findWaitApprove).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Approve Success!", "Thông Báo");
                            CheckDateApprove();
                            SendEmailConfirmApproved();
                        }
                        else
                        {
                            MessageBox.Show("Chưa hoàn thành điều chỉnh tăng ca hoặc chưa xin phê duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }
            catch
            {
                MessageBox.Show("Lỗi dhi dữ liệu Database", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConfirmOT.DataSource = null;
            lstAdjustSearch.Clear();
        }

        private void cbbDateOverTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConfirmOT.DataSource = null;
            lstAdjustSearch.Clear();
        }

        private void dgvConfirmOT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private double ConvertDouble(object value)
        {
            if (value != null)
            {
                return double.Parse(value.ToString());
            }
            return 0;
        }
        private void btnApproveALL_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn phê duyệt toàn bộ các ngày đang chờ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Yes)
            {
                try
                {
                    using (var db = new DBContext())
                    {
                        if (!string.IsNullOrEmpty(cbbDept.Text))
                        {
                            //DateTime DateSelect = dtDateOverTime.Value.Date;
                            var lstfindWaitApprove = db.Tbl_Approve.Where(x => x.Dept == cbbDept.Text && x.EmailApprove != null).ToList();
                            if (lstfindWaitApprove.Count > 0)
                            {
                                string TimeApprove = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                                foreach (var item in lstfindWaitApprove)
                                {
                                    item.Approve = Common.UserLogin.UserName + "_" + TimeApprove;
                                    db.Entry<Tbl_Approve>(item).State = System.Data.Entity.EntityState.Modified;
                                }
                                db.SaveChanges();
                                MessageBox.Show("Approve Success!", "Thông Báo");
                                CheckDateApprove();
                                SendEmailConfirmApprovedAllDay();
                            }
                            else
                            {
                                MessageBox.Show("Chưa hoàn thành điều chỉnh tăng ca hoặc chưa xin phê duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi dhi dữ liệu Database", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
