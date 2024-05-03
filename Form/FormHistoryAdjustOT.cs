using OverTime.Business;
using OverTime.Class;
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
    public partial class FormHistoryAdjustOT : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichi = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<Tbl_HistoryUpdateOT> lstSpecicalAdjustOT = new List<Tbl_HistoryUpdateOT>();
        long ReqNoEdit = 0;
        public string Mode;
        public FormHistoryAdjustOT()
        {
            InitializeComponent();
            lbstt.Text = "ĐIỀU CHỈNH TĂNG CA ĐẶC BIỆT - TẠO MỚI";
            Init();
        }
        private void LoadListUser()
        {
            IList<Info> infoList = new List<Info>();
            var list = GAMankuchiAll.Instance()._listAllStaff.Where(m => m.Dept == cbbDept.Text).ToList();
            foreach (var item in list)
            {
                infoList.Add(new Info() { Id = item.AltCode, Name = item.Name + "-" + item.AltCode });
            }

            cbbCode.ValueMember = "Id";
            cbbCode.DisplayMember = "Name";
            cbbCode.DataSource = infoList;

        }
        public FormHistoryAdjustOT(long ReqNo, string mode):this()
        {
            lbstt.Text = "ĐIỀU CHỈNH TĂNG CA ĐẶC BIỆT - PHÊ DUYỆT";
            ReqNoEdit = ReqNo;
            Mode = mode;
            using(var context = new DBContext())
            {
                var data = context.Tbl_HistoryUpdateOT.Where(w=>w.RequestNo == ReqNo).ToList();
                dgvHistory.DataSource = data;
                EditViewDgvHistoryAdjust(dgvHistory);
            }
        }

        private void Init()
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            lstMankichi = GAMankuchiAll.Instance()._listAllStaff;
            var lstHumanInfo = lstMankichi.Where(x => x.QuitJob == null).ToList();
            if(Common.UserLogin.Dept == "ALL")
            {
                var lstDept = lstHumanInfo.GroupBy(x => new { x.Dept }).Select(x => new
                {
                    Dept = x.Key.Dept,
                }).ToList();
                lstDept = lstDept.OrderBy(x => x.Dept).ToList();
                foreach (var item in lstDept)
                {
                    cbbDept.Items.Add(item.Dept);
                }
            }
            else
            {
                string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
                foreach (var item in ArrDept)
                {
                    cbbDept.Items.Add(item);
                }
            }
        }
        private void cbbCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbCode.SelectedValue == null) return;
            var findItem = GAMankuchiAll.Instance()._listAllStaff.Where(m => m.AltCode == cbbCode.SelectedValue.ToString()).FirstOrDefault();
            if (findItem == null) return;
            txtCode.Text = findItem.AltCode;
            txtName.Text = findItem.Name;
            LoadTimeInOutTimeRegisted(txtCode.Text);
        }

        private void ClearAllTextBox()
        {
            txtCode.Text = null;
            txtName.Text = null;
            txtTimeIn.Text = txtTimeOut.Text = null;
            txtTimeRegisted.Text = txtTimeAdjust.Text = null;
            txtReason.Text = null;
        }

        private void cbbHuman_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
        }

        private void LoadTimeInOutTimeRegisted(string Code)
        {
            using (var db = new DBContext())
            {
                var findRegisOT = db.Tbl_DailyOverTime.FirstOrDefault(x => x.Code == Code && x.DateOverTime == dateAdjustPicker.Value.Date);
                if (findRegisOT != null)
                {
                    txtTimeIn.Text = findRegisOT.TimeIn.ToString();
                    txtTimeOut.Text = findRegisOT.TimeOut.ToString();
                    txtTimeRegisted.Text = findRegisOT.TimeRegisted.ToString();
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbDept.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn bộ phận!");
                    return;
                }
                using (var db = new DBContext())
                {                 
                    lstSpecicalAdjustOT = db.Tbl_HistoryUpdateOT.Where(x => x.DateAdjust == dateAdjustPicker.Value.Date && x.Dept == cbbDept.Text && x.Status == "Đang điều chỉnh").ToList();
                    dgvHistory.DataSource = lstSpecicalAdjustOT;
                    EditViewDgvHistoryAdjust(dgvHistory);
                    lbReqNo.Text = lstSpecicalAdjustOT[0].RequestNo.ToString();
                }
            }
            catch (Exception)
            {
                return;             
            }           
        }

        private void EditViewDgvHistoryAdjust( DataGridView dgv)
        {
            try
            {
                if (dgv.DataSource == null) return;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Approve"].Visible = false;
                dgv.Columns["UserUpdate"].Visible = false;
                dgv.Columns["TimeOTRegisted"].Width = 50;

                dgv.Columns["TimeOTUpdate"].Width = 80;
                dgv.Columns["Code"].Width = 60;
                dgv.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns["TimeUpdate"].Width = 90;
                dgv.Columns["DateAdjust"].Width = 90;
                dgv.Columns["Status"].Width = 130;

                dgv.Columns["TimeUpdate"].HeaderText = "Ngày tạo yêu cầu";
                dgv.Columns["DateAdjust"].HeaderText = "Ngày Cần Điều chỉnh";
                dgv.Columns["TimeOTRegisted"].HeaderText = "Giờ ĐK";
                dgv.Columns["TimeOTUpdate"].HeaderText = "Giờ Báo lại";
                dgv.Columns["DateAdjust"].HeaderText = "Ngày ĐiềuChỉnh";
                dgv.Columns["Code"].HeaderText = "Mã NV";
                dgv.Columns["FullName"].HeaderText = "Họ và Tên";
                dgv.Columns["Status"].HeaderText = "Trạng thái";
                dgv.Columns["TimeIn"].HeaderText = "Giờ vào";
                dgv.Columns["TimeOut"].HeaderText = "Giờ ra";
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private Tbl_HistoryUpdateOT GetItemHistoryAdjust()
        {
            long RequestNo = 0;
            Tbl_HistoryUpdateOT result = new Tbl_HistoryUpdateOT();
            if (string.IsNullOrEmpty(lbReqNo.Text))
            {
                RequestNo = GetNumberRequest();
            }
            else
            {
                long.TryParse(lbReqNo.Text, out RequestNo);
            }
            if(RequestNo > 0)
            {
                result.TimeUpdate = DateTime.Now;
                result.DateAdjust = dateAdjustPicker.Value.Date;
                result.Code = txtCode.Text;
                result.FullName = txtName.Text;
                result.Dept = cbbDept.Text;
                result.TimeIn = txtTimeIn.Text;
                result.TimeOut = txtTimeOut.Text;
                result.TimeOTRegisted = Convert.ToDouble(txtTimeRegisted.Text);
                result.TimeOTUpdate = Convert.ToDouble(txtTimeAdjust.Text);
                result.Reason = txtReason.Text.ToString();
                result.RequestNo = RequestNo;
                if (!string.IsNullOrEmpty(Common.UserLogin.UserName))
                {
                    result.UserUpdate = Common.UserLogin.UserName;
                }
                result.Status = "Đang điều chỉnh";
            }
            
            return result;
        }


        private bool ValidateItemHistoryUpdate(Tbl_HistoryUpdateOT item)
        {
            return (!string.IsNullOrEmpty(item.Code)
                && !string.IsNullOrEmpty(item.FullName)
                && !string.IsNullOrEmpty(item.Dept)
                && item.TimeOTRegisted >= 0
                && item.TimeOTUpdate >= 0
                && !string.IsNullOrEmpty(item.Reason));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CovertDouble(txtTimeRegisted.Text) <=0 && CovertDouble(txtTimeAdjust.Text) <= 0)
            {
                MessageBox.Show("Thời gian điều chỉnh không hợp lệ!"); return;
            }
            if(!string.IsNullOrEmpty(txtCode.Text))
            {
                using (var db = new DBContext())
                {
                    var ItemUpdate = GetItemHistoryAdjust();
                    var ReqNo = ItemUpdate.RequestNo;
                    if(ValidateItemHistoryUpdate(ItemUpdate))
                    {
                        var findExitItem = db.Tbl_HistoryUpdateOT.FirstOrDefault(x => x.Code == ItemUpdate.Code && x.DateAdjust == dateAdjustPicker.Value.Date);
                        if(findExitItem != null)
                        {
                            string mes = string.Format("Mã nhân viên này đã tồn tại trong danh sách điều chỉnh\nBạn có muốn update lại không?");
                            DialogResult dlr = MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(dlr == DialogResult.Yes)
                            {
                                findExitItem.RequestNo = ReqNo;
                                findExitItem.TimeOTUpdate = ItemUpdate.TimeOTUpdate;
                                findExitItem.Reason = ItemUpdate.Reason;
                                db.Entry<Tbl_HistoryUpdateOT>(findExitItem).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearAllTextBox();
                            }
                        }
                        else
                        {
                            db.Tbl_HistoryUpdateOT.Add(ItemUpdate);
                            db.SaveChanges();
                            MessageBox.Show("Save Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAllTextBox();
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    lstSpecicalAdjustOT.Clear();
                    lstSpecicalAdjustOT = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    if(string.IsNullOrEmpty(lbReqNo.Text) && lstSpecicalAdjustOT.Count > 0)
                    {
                        lbReqNo.Text = lstSpecicalAdjustOT[0].RequestNo.ToString();
                    }
                    dgvHistory.DataSource = lstSpecicalAdjustOT;
                    EditViewDgvHistoryAdjust(dgvHistory);                  
                }
            }
        }

        private double CovertDouble(string text)
        {
            double temp;
            if(double.TryParse(text, out temp))
            {
                return temp;
            }
            return 0f;
        }

        private long GetNumberRequest()
        {
            long res = 0;
            using (var db = new DBContext())
            {
                var lstRequested = db.Tbl_HistoryUpdateOT.ToList();
                lstRequested = lstRequested.OrderBy(x => x.RequestNo).ToList();
                var findlast = lstRequested.LastOrDefault();
                if(findlast != null)
                {
                    long lastNum = (long)findlast.RequestNo;
                    res = lastNum + 1;
                }
                else
                {
                    res = 1;
                }
            }
                return res;
        }


        private void UpdateTimeAdjustToSummaryTableOT(Tbl_HistoryUpdateOT ItemUpdate)
        {
            using (var db = new DBContext())
            {
                int Month = ItemUpdate.DateAdjust.Month;
                int Year = ItemUpdate.DateAdjust.Year;
                int Day = ItemUpdate.DateAdjust.Day;
                List<HistoryDetailOverTime> lstDetailSumOT = new List<HistoryDetailOverTime>();
                var findSumItem = db.Tbl_SummaryOverTime.FirstOrDefault(x => x.Code == ItemUpdate.Code && x.MonthOfYear.Value.Year == Year && x.MonthOfYear.Value.Month == Month);
                if (findSumItem != null)
                {
                    string[] ot = findSumItem.Actual.Split('|');
                    for (int i = 0; i < ot.Length; i++)
                    {
                        string[] s = ot[i].Split(':');
                        HistoryDetailOverTime h = new HistoryDetailOverTime();
                        h.Code = findSumItem.Code;
                        h.Name = findSumItem.FullName;
                        h.Dept = findSumItem.Dept;
                        h.Day = Convert.ToInt16(s[0]);
                        h.ActualOT = Convert.ToDouble(s[1]);
                        lstDetailSumOT.Add(h);
                    }
                    var findDayAdjust = lstDetailSumOT.FirstOrDefault(x => x.Day == ItemUpdate.DateAdjust.Day);
                    if (findDayAdjust != null)
                    {
                        findDayAdjust.ActualOT = (double)ItemUpdate.TimeOTUpdate;
                    }
                    string Detail = string.Empty;
                    double SumOT = 0;
                    foreach (var itemDetail in lstDetailSumOT)
                    {
                        Detail += itemDetail.Day.ToString() + ":" + itemDetail.ActualOT.ToString() + "|";
                        SumOT += itemDetail.ActualOT;
                    }
                    if (Detail.EndsWith("|"))
                    { Detail = Detail.Remove(Detail.Length - 1, 1).Trim(); }
                    findSumItem.Actual = Detail;
                    findSumItem.TotalOverTime = SumOT;
                    if (SumOT > findSumItem.MaxOverTime)
                    {
                        findSumItem.Status = "ALARM";
                    }
                    else { findSumItem.Status = "OK"; }
                    db.Entry<Tbl_SummaryOverTime>(findSumItem).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    //MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(findSumItem == null)
                {
                    Tbl_SummaryOverTime s = new Tbl_SummaryOverTime();
                    DateTime d = new DateTime(Year, Month, 1, 0, 0, 0);

                    s.MonthOfYear = d;
                    s.Code = ItemUpdate.Code;
                    s.FullName = ItemUpdate.FullName;
                    s.Dept = ItemUpdate.Dept;
                    s.MaxOverTime = 30;
                    s.PlanOverTime = 0;
                    string Detail = Day.ToString() + ":" + ItemUpdate.TimeOTUpdate.ToString();
                    double SumOT = (double)ItemUpdate.TimeOTUpdate;
                    s.TotalOverTime = (double)SumOT;
                    s.Actual = Detail;
                    if (s.TotalOverTime > s.MaxOverTime)
                    {
                        s.Status = "ALARM";
                    }
                    else { s.Status = "OK"; }
                    db.Tbl_SummaryOverTime.Add(s);
                    db.SaveChanges();
                }
            } 
        }


        private void FormHistoryAdjustOT_Load(object sender, EventArgs e)
        {
            if(Common.UserLogin.Role == "Approve")
            {
                btnApproveOne.Enabled = true;
                groupBox1.Enabled = false;
                btnSendEmail.Enabled = false;
                btnRejectOne.Enabled = true;
                btnApproveAll.Enabled = true;
            }
            else
            {
                btnApproveOne.Enabled = false;
                btnRejectOne.Enabled = false;
                btnSendEmail.Enabled = true;
                groupBox1.Enabled = true;
                btnApproveAll.Enabled = false;
            }
            if(Common.UserLogin.Action == "SpecialApprove")
            {
                if(!string.IsNullOrEmpty(Common.ReqNoAppr))
                {
                    tabControl1.SelectedTab = tabApprove;
                    tabControl1.TabPages.Remove(tabAdjust);
                    cbbReqNo.Items.Clear();
                    lbDept.Visible = cbbDeptAppr.Visible = false;
                    cbbReqNo.Items.Add(Common.ReqNoAppr);
                    cbbReqNo.Text = Common.ReqNoAppr;
                }
            }
            if(Mode == "Edit")
            {
                lbstt.Text = "ĐIỀU CHỈNH TĂNG CA ĐẶC BIỆT - CHỈNH SỬA";
                tabControl1.SelectedTab = tabAdjust;
                tabControl1.TabPages.Remove(tabApprove);
                lbReqNo.Text = ReqNoEdit.ToString();
            }
            if(Mode == "Approve")
            {
                tabControl1.SelectedTab = tabApprove;
                tabControl1.TabPages.Remove(tabAdjust);
                InitApprove();
            }

            // Test code       
        }



        private void InitApprove()
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            lstMankichi = GAMankuchiAll.Instance()._listAllStaff;
            var lstHumanInfo = lstMankichi.Where(x => x.QuitJob == null).ToList();
            //if (Common.UserLogin.Dept == "ALL" || Common.UserLogin.TypeUser == "Salary")
            //{
            //    var lstDept = lstHumanInfo.GroupBy(x => new { x.Dept }).Select(x => new
            //    {
            //        Dept = x.Key.Dept,
            //    }).ToList();
            //    lstDept = lstDept.OrderBy(x => x.Dept).ToList();
            //    foreach (var item in lstDept)
            //    {
            //        cbbDeptAppr.Items.Add(item.Dept);
            //    }
            //    cbbDeptAppr.Items.Add("ALL");
            //}
            //else
            //{
                string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
                foreach (var item in ArrDept)
                {
                    cbbDeptAppr.Items.Add(item);
                }
            //}
        }

        private void txtTimeRegisted_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] s = txtTimeRegisted.Text.Split('.');
            CheckKeyPress(sender,e);
        }

        private void txtTimeAdjust_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] s = txtTimeAdjust.Text.Split('.');
            CheckKeyPress(sender,e);
        }
        private void CheckKeyPress(object sender,KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void cbbHuman_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => LoadListUser()));
           // LoadListUser();
        }

        private void dateAdjustPicker_ValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCode.Text))
            {
                LoadTimeInOutTimeRegisted(txtCode.Text);
            }
            
        }

        private void SendEmailApprove(long RequestNo)
        {
            var Dept = cbbDept.Text;
            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Phê Duyệt Điều chỉnh tăng ca đặc biệt {0}", cbbDept.Text);
                string DateSelect = DateTime.Now.ToString("dd/MMM/yyyy");
                string PathRunPara = string.Format("{0}|{1} {2} {3}", Common.PathAppRun, "SpecialApprove", DateSelect, RequestNo);
                var content = string.Format("Dear Trưởng BP {3} </br> Vui lòng vào phê duyệt điều chỉnh tăng ca đặc biệt: {0} ngày {1}  số Request: {4} </br></br><a href=\"{2}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, DateSelect, PathRunPara, Dept, RequestNo);
                MailProcess.SendEmail(Dept, subject, content);
                MessageBox.Show("Send Email", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDept.Text))
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            long RequestNo = 0;
            long.TryParse(lbReqNo.Text, out RequestNo);
            if(RequestNo > 0)
            {
                string mes = string.Format("Bạn chắc chắn đã chọn đúng số yêu cầu cần xin phê duyệt điều chỉnh tăng ca:{0}", RequestNo);
                DialogResult dlr = MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlr == DialogResult.Yes)
                {
                    using (var db = new DBContext())
                    {
                        var lstReq = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == RequestNo).ToList();
                        if(lstReq.Count > 0)
                        {
                            foreach (var item in lstReq)
                            {
                                item.Status = "Chờ phê duyệt";
                                db.Entry<Tbl_HistoryUpdateOT>(item).State = System.Data.Entity.EntityState.Modified;
                            }
                            db.SaveChanges();
                            SendEmailApprove(RequestNo);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không đúng, không thể gửi mail!");
            }
        }


        private void SendEmailConfirmApproved(long RequestNo)
        {
            string Dept = string.Empty;
            if(dgvApprove.Rows.Count > 0)
            {
                Dept = dgvApprove.Rows[0].Cells["Dept"].Value.ToString();
            }  
            if (!string.IsNullOrEmpty(Dept))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Hoàn thành Phê Duyệt Điều chỉnh tăng ca đặc biệt {0}", cbbDept.Text);
                string DateSelect = DateTime.Now.ToString("dd/MMM/yyyy");
                string PathRunPara = string.Format($"{Common.PathAppRun} | Special Approve {DateSelect} {RequestNo}");
                var content = string.Format("Dear GA </br> Bộ phận {3} đã hoàn thành phê duyệt điều chỉnh tăng ca đặc biệt: {0} ngày {1} số Request: {4} </br></br><a href=\"{2}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, DateSelect, PathRunPara, Dept, RequestNo);
                MailProcess.SendEmailConfirm(Dept, subject, content);
                MessageBox.Show("Send Email Confirm", "Thông Báo");
            }
        }


        private void SendEmailConfirmApprovedAllRequest()
        {
            string Dept = string.Empty;
            Dept = cbbDeptAppr.Text;
            if (!string.IsNullOrEmpty(Dept))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Hoàn thành Phê Duyệt Điều chỉnh tăng ca đặc biệt {0}", cbbDept.Text);
                string DateSelect = DateTime.Now.ToString("dd/MMM/yyyy");
                string PathRunPara = string.Format("{0}", Common.PathAppRun);
                var content = string.Format("Dear GA </br> Bộ phận {0} đã hoàn thành phê duyệt tất cả điều chỉnh tăng ca đặc biệt </br></br><a href=\"{1}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", Dept, PathRunPara);
                MailProcess.SendEmailConfirm(Dept, subject, content);
                MessageBox.Show("Send Email Confirm", "Thông Báo");
            }
        }



        private void SendEmailRejectedSpecialOT(long RequestNo)
        {
            string Dept = string.Empty;
            if (dgvApprove.Rows.Count > 0)
            {
                Dept = dgvApprove.Rows[0].Cells["Dept"].Value.ToString();
            }
            if (!string.IsNullOrEmpty(Dept))
            {
                var DeptPara = Dept.Replace(" ", "");
                var subject = string.Format("[OVER TIME] Từ chối Phê Duyệt Điều chỉnh tăng ca đặc biệt {0}", cbbDept.Text);
                string DateSelect = DateTime.Now.ToString("dd/MMM/yyyy");
                string PathRunPara = string.Format("{0}|{1} {2} {3} {4}", Common.PathAppRun, DeptPara, "SpecialApprove", DateSelect, RequestNo);
                var content = string.Format("Bộ phận {3} đã Từ chối phê duyệt điều chỉnh tăng ca đặc biệt: {0} ngày {1} số Request: {4} </br></br><a href=\"{2}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", cbbDept.Text, DateSelect, PathRunPara, Dept, RequestNo);
                MailProcess.SendEmailReject(Dept, subject, content);
                MessageBox.Show("Send Email Confirm", "Thông Báo");
            }
        }


        private void dgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvHistory.Rows[e.RowIndex];
            string Status = row.Cells["Status"].Value != null ? row.Cells["Status"].Value.ToString() : "";
            if(Status == "Đã phê duyệt")
            {
                row.DefaultCellStyle.BackColor = Color.ForestGreen;
            }
        }

        private void dgvHistory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            labelID.Text = dgvHistory.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IdSelect = 0;
            int.TryParse(labelID.Text, out IdSelect);
            if(IdSelect < 0 ) { return; }
            using (var db = new DBContext())
            {
                var findDelItem = db.Tbl_HistoryUpdateOT.FirstOrDefault(x => x.Id == IdSelect);
                if(findDelItem != null)
                {
                    string mes = string.Format("Bạn chắc chắn muốn xóa yêu cầu điều chỉnh tăng ca của {0}", findDelItem.FullName);
                    DialogResult dlr = MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(dlr == DialogResult.Yes)
                    {
                        if(Common.CheckPassword("umcvn","Nhập pass để xóa"))
                        {
                            db.Tbl_HistoryUpdateOT.Remove(findDelItem);
                            db.SaveChanges();
                            MessageBox.Show("Delete Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSearch_Click(null, null);
                        }
                    }
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                long ReqNo = 0;
                long.TryParse(lbReqNo.Text, out ReqNo);
                if (ReqNo > 0)
                {
                    var lstApprove = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    if (lstApprove.Count > 0)
                    {
                        string sign = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                        foreach (var item in lstApprove)
                        {
                            item.Approve = sign;
                            item.Status = "Rejected";
                            db.Entry<Tbl_HistoryUpdateOT>(item).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }

                        dgvApprove.DataSource = lstApprove;
                        EditViewDgvHistoryAdjust(dgvApprove);
                        SendEmailRejectedSpecialOT(ReqNo);
                        MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void cbbDeptAppr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbReqNo.Items.Clear();
            if(!string.IsNullOrEmpty(cbbDeptAppr.Text))
            {
                using (var db = new DBContext())
                {
                    var lstWaitAppr = db.Tbl_HistoryUpdateOT.Where(x => x.Dept == cbbDeptAppr.Text && x.Status == "Chờ phê duyệt").ToList();
                    var lstWaitGroup = lstWaitAppr.GroupBy(x => new { x.RequestNo }).Select(grp => grp.FirstOrDefault()).ToList();
                    lstWaitGroup = lstWaitGroup.OrderBy(x => x.RequestNo).ToList();
                    string waitappr = string.Empty;
                    lbReqWaitAppr.Text = null;
                    foreach (var item in lstWaitGroup)
                    {
                        cbbReqNo.Items.Add(item.RequestNo);
                        waitappr += item.RequestNo.ToString() + " | ";
                    }
                    waitappr = waitappr.TrimEnd();
                    if(waitappr.EndsWith("|"))
                    {
                        waitappr.Remove(waitappr.Length-1, 1);
                    }
                    lbReqWaitAppr.Text = waitappr.ToString();
                }
            }
        }

        private void cbbReqNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cbbReqNo.Text))
            {
                using (var db = new DBContext())
                {
                    long ReqNo = Convert.ToInt64(cbbReqNo.Text);
                    var lstRequest = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    if(lstRequest.Count > 0)
                    {
                        lbStatus.Text = lstRequest[0].Status;
                    }
                    dgvApprove.DataSource = lstRequest;
                    EditViewDgvHistoryAdjust(dgvApprove);
                }
            }
        }

        private void btnApproveOne_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbbReqNo.SelectedIndex ==-1)
                {
                    MessageBox.Show("Chưa chọn Request No!"); return;
                }
                using (var db = new DBContext())
                {
                    long ReqNo = 0;
                    long.TryParse(cbbReqNo.Text, out ReqNo);
                    if (ReqNo > 0)
                    {
                        var lstApprove = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                        if (lstApprove.Count > 0)
                        {
                            string sign = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                            foreach (var item in lstApprove)
                            {
                                item.Approve = sign;
                                item.Status = "Đã phê duyệt";
                                db.Entry<Tbl_HistoryUpdateOT>(item).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                UpdateTimeAdjustToSummaryTableOT(item);
                            }

                            dgvApprove.DataSource = null;
                            dgvApprove.Refresh();
                            cbbReqNo.SelectedIndex = -1;
                           // EditViewDgvHistoryAdjust(dgvApprove);
                            SendEmailConfirmApproved(ReqNo);
                            MessageBox.Show("Approve Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " +ex.Message);
            }            
        }

        private void btnRejectOne_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                long ReqNo = 0;
                long.TryParse(cbbReqNo.Text, out ReqNo);
                if (ReqNo > 0)
                {
                    var lstApprove = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    if (lstApprove.Count > 0)
                    {
                        string sign = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                        foreach (var item in lstApprove)
                        {
                            item.Approve = sign;
                            item.Status = "Rejected";
                            db.Entry<Tbl_HistoryUpdateOT>(item).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }

                        MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvApprove.DataSource = lstApprove;
                        EditViewDgvHistoryAdjust(dgvApprove);
                        SendEmailRejectedSpecialOT(ReqNo);
                    }
                }
            }
        }

        private void btnApproveAll_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn đồng ý phê duyệt tất cả các yêu cầu đang chờ của bộ phận?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dlr == DialogResult.Yes)
            {
                using (var db = new DBContext())
                {
                    if (!string.IsNullOrEmpty(cbbDeptAppr.Text))
                    {
                        var lstWaitAppr = db.Tbl_HistoryUpdateOT.Where(x => x.Dept == cbbDeptAppr.Text && x.Status == "Chờ phê duyệt").ToList();
                        if (lstWaitAppr.Count > 0)
                        {
                            string sign = Common.UserLogin.UserName + "_" + DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                            foreach (var item in lstWaitAppr)
                            {
                                item.Approve = sign;
                                item.Status = "Đã phê duyệt";
                                db.Entry<Tbl_HistoryUpdateOT>(item).State = System.Data.Entity.EntityState.Modified;
                                UpdateTimeAdjustToSummaryTableOT(item);
                            }
                            db.SaveChanges();
                            dgvApprove.DataSource = null;
                            dgvApprove.Refresh();
                            cbbReqNo.SelectedIndex = -1;
                            SendEmailConfirmApprovedAllRequest();
                            MessageBox.Show("Update Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
