using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using OverTime.DataBase;
using OverTime.MsgBox_AQ;
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
    public partial class FormEditOverTime : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichiOrigin = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichiWorking = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<AdjustOverTime> lstAdjustSearch = new List<AdjustOverTime>();
        private List<AdjustOverTime> lstDifferentSearch = new List<AdjustOverTime>();
        List<Tbl_SummaryOverTime> lstSummary = new List<Tbl_SummaryOverTime>();
        public FormEditOverTime()
        {
            InitializeComponent();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start();
        }

        private void FormEditOverTime_Load(object sender, EventArgs e)
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
        }

        private DataTable GetData()
        {
            LoadInfoMasterData();
            return new DataTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Dept = cbbDept.Text;
            string Customer = cbbCustomer.Text;
            string Shift = cbbShift.Text; if (Shift == "ALL") { Shift = ""; }
            if (string.IsNullOrEmpty(Dept))
            {
                RJMessageBox.Show("Chưa chọn bộ phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckHaveDataTimeFinger() == false)
            {
                RJMessageBox.Show("Chưa có dữ liệu vân tay\nKhông thể điều chỉnh tăng ca\nLiên hệ với GA upload dữ liệu giờ vân tay", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (OverTimeHelper.IsApprove(cbbDept.Text.Trim(), dtDateOverTime.Value.Date))
            {
                dgvAdjustOverTime.Columns["Col_TimeDept"].ReadOnly = true;
            }
            else
            {
                dgvAdjustOverTime.Columns["Col_TimeDept"].ReadOnly = false;
            }
            lstAdjustSearch.Clear();
            lstAdjustSearch = OverTimeHelper.LoadAllListToAdjustOverTime(dtDateOverTime.Value.Date, cbbDept.Text, cbbCustomer.Text, cbbLine.Text).OrderBy(o => o.Code).ToList();
            lstDifferentSearch = lstAdjustSearch.Where(x => x.Balance != 0 || x.Comment != null).OrderBy(o => o.Code).ToList();
            AddListAdjustToDgv(lstAdjustSearch);
            cbbStatus_SelectedIndexChanged(null, null);
            cbbStatus.SelectedIndex = 2;
            UpdateRateConfirm();
            AlarmYellowRowLuyKe();
        }
        private void AlarmYellowRowLuyKe()
        {
            dgvAdjustOverTime.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Col_Direct"].Value.ToString().Contains("Gián") && ConvertDouble(w.Cells["Col_Accumulated"].Value) >= (int)AlarmYellow.GianTiep).ToList().ForEach(f => f.Cells["Col_Accumulated"].Style.BackColor = Color.Yellow);
            dgvAdjustOverTime.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Col_Direct"].Value.ToString().Contains("Trực") && ConvertDouble(w.Cells["Col_Accumulated"].Value) >= (int)AlarmYellow.TrucTiep).ToList().ForEach(f => f.Cells["Col_Accumulated"].Style.BackColor = Color.Yellow);
        }
        private void AddListAdjustToDgv(List<AdjustOverTime> lstItem)
        {
            dgvAdjustOverTime.Rows.Clear();
            foreach (var item in lstItem)
            {
                int rowId = dgvAdjustOverTime.Rows.Add();
                DataGridViewRow row = dgvAdjustOverTime.Rows[rowId];
                row.Cells["Col_Code"].Value = item.Code;
                row.Cells["Col_FullName"].Value = item.FullName;
                row.Cells["Col_Dept"].Value = item.Dept;
                row.Cells["Col_Direct"].Value = item.Direct;
                row.Cells["Col_Customer"].Value = item.Customer;
                row.Cells["Col_Shift"].Value = item.Shift;
                row.Cells["Col_TimeIn"].Value = item.TimeIn;
                row.Cells["Col_TimeOut"].Value = item.TimeOut;
                row.Cells["Col_OTPreShift"].Value = item.TimeOTPreShift;
                row.Cells["Col_TimeFinger"].Value = item.TimeFinger;
                row.Cells["Col_TotalOT"].Value = item.TotalOT;
                row.Cells["Col_Regis"].Value = item.RegisOT;
                row.Cells["Col_Balance"].Value = item.Balance;
                row.Cells["Col_Accumulated"].Value = item.Accumulated;
                row.Cells["Col_Comment"].Value = item.Comment;
                if(item.TimeDept == 0)
                {
                    if (item.Balance != 0 && string.IsNullOrEmpty(item.Comment))
                    {
                        row.Cells["Col_TimeDept"].Value = "";
                    }
                    else
                    {
                        row.Cells["Col_TimeDept"].Value = item.TimeDept;
                    }
                }
                else
                {
                    row.Cells["Col_TimeDept"].Value = item.TimeDept;
                }
            } 
        }

        private void UpdateRateConfirm()
        {
            double totalItem = lstAdjustSearch.Count;
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

        private bool CheckHaveDataTimeFinger()
        {
            DateTime Select = dtDateOverTime.Value.Date;
            using (var db = new DBContext())
            {
               return db.Tbl_DailyOverTime.Where(x => x.DateOverTime == Select && x.TimeIn != null).Count() > 1;               
            }
        }


        private void LoadInfoMasterData()
        {
            lstMankichiOrigin = GAMankuchiAll.Instance()._listAllStaff;
            lstMankichiWorking = GAMankuchi.Instance()._listCurrentStaff;
           
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var lstCustomer = lstMankichiWorking.Where(x => x.Dept == cbbDept.Text).ToList();
            var lstCustomerGroup = lstCustomer.GroupBy(x => new { x.Customer }).Select(x => new
            {
                Customer = x.Key.Customer,
            }).ToList();
            cbbCustomer.Items.Clear();
            foreach (var item in lstCustomerGroup)
            {
                if (!string.IsNullOrEmpty(item.Customer))
                {
                    cbbCustomer.Items.Add(item.Customer);
                }
            }

            if(cbbDept.Text == "PD")
            {
                cbbCustomer.Enabled = true;
                cbbLine.Enabled = true;
            }
            else
            {
                cbbLine.Enabled = cbbCustomer.Enabled = false;
                cbbLine.Text = cbbCustomer.Text = null;
            }
        }

        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lstLine = lstMankichiWorking.Where(x => x.Dept == cbbDept.Text && x.Customer == cbbCustomer.Text).ToList();
            var lstLineGroup = lstLine.GroupBy(x => new { x.GroupProcess }).Select(x => new
            {
                Group = x.Key.GroupProcess,
            }).ToList();
            cbbLine.Items.Clear();
            foreach (var item in lstLineGroup)
            {
                if (!string.IsNullOrEmpty(item.Group))
                    cbbLine.Items.Add(item.Group);
            }
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] s = cbbStatus.Text.Split('.').ToArray();
            string Status = s[0];
            List<AdjustOverTime> lstFindAdjust = new List<AdjustOverTime>();
            if (Status == "3")
            {
                lstFindAdjust = lstAdjustSearch;
            }
            else
            {
                if (Status == "1")
                {
                    lstFindAdjust = lstAdjustSearch.Where(x => x.Balance == 0).ToList();
                }
                else if (Status == "2")
                {
                    lstFindAdjust = lstDifferentSearch;
                }
            }
            AddListAdjustToDgv(lstFindAdjust);
            
        }

        private void dgvAdjustOverTime_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (OverTimeHelper.IsApprove(cbbDept.Text.Trim(), dtDateOverTime.Value.Date)) return;
            DataGridViewCell curCell = dgvAdjustOverTime.CurrentCell;
            DataGridViewRow curRow = dgvAdjustOverTime.CurrentRow;
            if (curCell.ColumnIndex == 12)
            {
                string mainStr = dgvAdjustOverTime.CurrentCell.Value.ToString();
                if(!string.IsNullOrEmpty(mainStr))
                {
                    for (int scan = 0; scan < mainStr.Length; scan++)
                    {
                        if (Char.IsDigit(mainStr[scan]) || mainStr[scan] == '.')
                        {
                            string Code = curRow.Cells["Col_Code"].Value.ToString();
                            double TimeDept = Convert.ToDouble(curRow.Cells["Col_TimeDept"].Value);
                            //UpdateListAdjustHourseOverTime(Code, TimeDept);
                            string STotalOT = curRow.Cells["Col_TotalOT"].Value != null ? curRow.Cells["Col_TotalOT"].Value.ToString() : "";
                            double TotalOT = 0;
                            double.TryParse(STotalOT, out TotalOT);
                            double Balance = TotalOT - TimeDept;
                            curRow.Cells["Col_Balance"].Value = Balance;

                        }
                        else
                        {
                            MessageBox.Show("Chỉ được nhập số, và phải >= 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgvAdjustOverTime.CurrentCell.Value = "";
                            dgvAdjustOverTime.ClearSelection();
                            dgvAdjustOverTime.CurrentCell = curCell;
                            dgvAdjustOverTime.CurrentCell.Selected = true;
                            break;
                        }
                    }
                }
            }
            if (curCell.ColumnIndex == 15)
            {
                string Comment = string.Empty;
                string Code = curRow.Cells["Col_Code"].Value.ToString();
                if(curRow.Cells["Col_Comment"].Value != null)
                { Comment = curRow.Cells["Col_Comment"].Value.ToString(); }
                string tDept = curRow.Cells["Col_TimeDept"].Value.ToString();
                if(!string.IsNullOrEmpty(tDept) && !string.IsNullOrEmpty(Comment))
                {
                    double TimeDept = Convert.ToDouble(tDept);
                    string Fullname = curRow.Cells["Col_FullName"].Value.ToString();
                    string Dept = curRow.Cells["Col_Dept"].Value.ToString();
                    string Direct = curRow.Cells["Col_Direct"].Value.ToString();
                    try { UpdateAndSaveItemAfterEdit(Code, TimeDept, Comment, Dept, Fullname, Direct); }
                    catch { MessageBox.Show("Lỗi Lưu Data", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    
                }
                else
                {
                    if(Comment.Length > 0)
                    {
                        MessageBox.Show("Phải nhập giờ tăng ca bộ phận trước\nKhông được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        curRow.Cells["Col_Comment"].Value = "";
                        return;
                    }   
                }
            }
            dgvAdjustOverTime.Refresh();
        }

        private void dgvAdjustOverTime_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewCell curCell = dgvAdjustOverTime.CurrentCell;
            DataGridViewRow curRow = dgvAdjustOverTime.CurrentRow;
            if (curCell.ColumnIndex == 14)
            {
                dgvAdjustOverTime.Rows[e.RowIndex].ErrorText = "";
                double newDouble;
                if (dgvAdjustOverTime.Rows[e.RowIndex].IsNewRow) { return; }
                if (!double.TryParse(e.FormattedValue.ToString(),
                    out newDouble) || newDouble < 0)
                {
                    e.Cancel = true;
                    dgvAdjustOverTime.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
                    MessageBox.Show("Chỉ được nhập vào là số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateAndSaveItemAfterEdit(string Code, double TimeDept, string Comment, string Dept, string FullName, string Direct_InDirect)
        {
            using (var db = new DBContext())
            {
                // Update Daily OverTime
                Cursor.Current = Cursors.WaitCursor;
                DateTime DateSelect = dtDateOverTime.Value.Date;
                DateTime MonthOfYear = new DateTime(DateSelect.Year, DateSelect.Month, 1, 0, 0, 0);
                var findItem = db.Tbl_DailyOverTime.FirstOrDefault(x => x.DateOverTime == DateSelect && x.Code == Code);
                if(findItem != null)
                {
                    findItem.TimeOTDept = TimeDept;
                    findItem.Comment = Comment;
                    findItem.Balance = findItem.TotalOT - TimeDept;
                    db.Entry<Tbl_DailyOverTime>(findItem).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                //Update Summary Data
                if (findItem != null)
                {
                    int Day = DateSelect.Day;
                    var lstDetaiOT = GetDetailSummaryOverTime(MonthOfYear, Code);
                    var findSumItem = lstDetaiOT.FirstOrDefault(x => x.Day == Day && x.Code == Code);
                    if (findSumItem != null)
                    {
                        findSumItem.ActualOT = TimeDept;
                        findSumItem.Dept = Dept;
                    }
                    else
                    {
                        HistoryDetailOverTime d = new HistoryDetailOverTime();
                        d.Code = Code;
                        d.Name = FullName;
                        d.Dept = Dept;
                        d.Direct = Direct_InDirect;
                        d.Day = Day;
                        d.ActualOT = TimeDept;
                        lstDetaiOT.Add(d);
                    }
                    ConvertListDetilSummaryAndSaveToDB(lstDetaiOT);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        public static List<HistoryDetailOverTime> GetDetailSummaryOverTime(DateTime dateSelect, string Code)
        {
            List<HistoryDetailOverTime> lstHistoryOT = new List<HistoryDetailOverTime>();
            int Month = dateSelect.Month;
            int Year = dateSelect.Year;
            using (var db = new DBContext())
            {
                var findItemSummary = db.Tbl_SummaryOverTime.FirstOrDefault(x => x.MonthOfYear.Value.Year == Year && x.MonthOfYear.Value.Month == Month && x.Code == Code);

                if (findItemSummary != null)
                {
                    if (!string.IsNullOrEmpty(findItemSummary.Actual))
                    {
                        string[] ot = findItemSummary.Actual.Split('|');
                        for (int i = 0; i < ot.Length; i++)
                        {
                            string[] s = ot[i].Split(':');
                            HistoryDetailOverTime h = new HistoryDetailOverTime();
                            h.Code = findItemSummary.Code;
                            h.Name = findItemSummary.FullName;
                            h.Dept = findItemSummary.Dept;
                            h.Day = Convert.ToInt16(s[0]);
                            h.ActualOT = Convert.ToDouble(s[1]);
                            lstHistoryOT.Add(h);
                        }
                    }
                }
            }
            return lstHistoryOT;
        }
    
        private void ConvertListDetilSummaryAndSaveToDB(List<HistoryDetailOverTime> lstItem)
        {
            List<Tbl_SummaryOverTime> lstResult = new List<Tbl_SummaryOverTime>();
            using (var db = new DBContext())
            {
                DateTime dateSelect = dtDateOverTime.Value.Date;
                lstResult = db.Tbl_SummaryOverTime.Where(x => x.MonthOfYear.Value.Year == dateSelect.Year && x.MonthOfYear.Value.Month == dateSelect.Month).ToList();
                var lstGroup = lstItem.GroupBy(o => new { o.Code }).Select(o => new
                {
                    Code = o.Key.Code,
                }).ToList();
                if (lstGroup.Count > 0)
                {
                    foreach (var item in lstGroup)
                    {
                        var findList = lstItem.Where(x => x.Code == item.Code).ToList();
                        if (findList.Count > 0)
                        {
                            string Detail = string.Empty;
                            double SumOT = 0;
                            foreach (var itemDetail in findList)
                            {
                                Detail += itemDetail.Day.ToString() + ":" + itemDetail.ActualOT.ToString() + "|";
                                SumOT += itemDetail.ActualOT;
                            }
                            if (Detail.EndsWith("|"))
                            { Detail = Detail.Remove(Detail.Length - 1, 1).Trim(); }
                            var ExitedItem = lstResult.FirstOrDefault(x => x.Code == item.Code);
                            if(ExitedItem != null)
                            {
                                ExitedItem.Actual = Detail;
                                ExitedItem.TotalOverTime = SumOT;
                                ExitedItem.Dept = findList[0].Dept;
                                if (ExitedItem.TotalOverTime > ExitedItem.MaxOverTime)
                                {
                                    DateTime NowDay = DateTime.Now.Date;
                                    DateTime DateBlock = new DateTime(2023, 12, 1, 0, 0, 0);
                                    if(NowDay >= DateBlock)
                                    {
                                        ExitedItem.Status = "BLOCK";
                                    }
                                }
                                else { ExitedItem.Status = "OK";}
                                db.Entry<Tbl_SummaryOverTime>(ExitedItem).State = System.Data.Entity.EntityState.Modified;
                            }
                            else
                            {
                                Tbl_SummaryOverTime s = new Tbl_SummaryOverTime();
                                DateTime d = new DateTime(dateSelect.Year, dateSelect.Month, 1, 0, 0, 0);
                                s.MonthOfYear = d;
                                s.Code = item.Code;
                                s.FullName = findList[0].Name;
                                s.Dept = findList[0].Dept;
                                s.Direct_InDirect = findList[0].Direct;
                                s.PlanOverTime = 0;
                                s.TotalOverTime = (double)SumOT;
                                s.Actual = Detail;
                                if(s.TotalOverTime > s.MaxOverTime)
                                {
                                    DateTime NowDay = DateTime.Now.Date;
                                    DateTime DateBlock = new DateTime(2023, 12, 1, 0, 0, 0);
                                    if (NowDay >= DateBlock)
                                    {
                                        s.Status = "BLOCK";
                                    }
                                }
                                else { s.Status = "OK"; }
                                db.Tbl_SummaryOverTime.Add(s);
                            } 
                        }
                    }
                    db.SaveChanges();
                }
            }
            
        }

        private void dgvAdjustOverTime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvAdjustOverTime.Rows[e.RowIndex];
            string STotalOT = row.Cells["Col_TotalOT"].Value != null ? row.Cells["Col_TotalOT"].Value.ToString() : "";
            string SRegisOT = row.Cells["Col_Regis"].Value != null ? row.Cells["Col_Regis"].Value.ToString() : "";
            string Comment = row.Cells["Col_Comment"].Value != null ? row.Cells["Col_Comment"].Value.ToString() : "";
            double TotalOT = 0; double RegisOT = 0;
            double.TryParse(STotalOT, out TotalOT);
            double.TryParse(SRegisOT, out RegisOT);
            double balance = TotalOT - RegisOT;
            if (balance != 0)
            {
                if (Comment == "")
                {
                    row.Cells["Col_Comment"].Style.BackColor = Color.Yellow;
                }
                else
                {
                    row.Cells["Col_Comment"].Style.BackColor = Color.Moccasin;
                }
            }
        }

        private double ConvertDouble(object value)
        {
            if (value != null)
            {
                return double.Parse(value.ToString());
            }
            return 0;
        }
    }
}
