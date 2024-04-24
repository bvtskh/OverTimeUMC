using CommonProject.Loading.LoadingClass;
using NPOI.HSSF.Record.Chart;
using NPOI.SS.Formula.Functions;
using OverTime.Business;
using OverTime.DataBase;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormGAWorkSpace : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanInfo = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<Tbl_DailyOverTime> lstOverTime = new List<Tbl_DailyOverTime>();
        private List<Tbl_DailyOverTime> lstOTDailySearch = new List<Tbl_DailyOverTime>();
        public FormGAWorkSpace()
        {
            InitializeComponent();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(true);
        }

        private void Init()
        {

            if (Common.UserLogin.TypeUser == "Salary")
            {
                lstHumanInfo = GAMankuchiAll.Instance()._listAllStaff;
                cbbDept.Items.AddRange(lstHumanInfo.Where(x => x.QuitJob == null).ToList().GroupBy(g=>g.Dept).Select(s=>s.First().Dept).ToArray());
                cbbDept.Items.Add("ALL");
            }
            else
            {
                string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
                foreach (var item in ArrDept)
                {
                    cbbDept.Items.Add(item);
                }
                if(ArrDept.Length == 1)
                {
                    cbbDept.SelectedIndex = 0;
                }
            }

        }


        private void WriteDeptNpotAppToDataBase(List<string> res)
        {
            using (var db = new DBContext())
            {
                List<Tbl_Approve> lstDeptNoAppr = new List<Tbl_Approve>();
                foreach (var item in res)
                {
                    var findItem = db.Tbl_Approve.FirstOrDefault(x => x.DateOT == dtDateOverTime.Value.Date && x.Dept == item);
                    if (findItem == null)
                    {
                        Tbl_Approve ItemDeptNoAppr = new Tbl_Approve();
                        ItemDeptNoAppr.DateOT = dtDateOverTime.Value.Date;
                        ItemDeptNoAppr.Dept = item;
                        lstDeptNoAppr.Add(ItemDeptNoAppr);
                    }
                }
                db.Tbl_Approve.AddRange(lstDeptNoAppr);
                db.SaveChanges();
            }
        }

        private List<DeptNotApprove> LoadAllDeptAndAllDayNotApprove()
        {
            List<DeptNotApprove> lstResult = new List<DeptNotApprove>();
            using (var db = new DBContext())
            {
                var lstTotalNotAppr = db.Tbl_Approve.Where(x => x.Approve == null).ToList().Where(w => w.DateOT.Date < DateTime.Now.Date).ToList();
                lstTotalNotAppr = lstTotalNotAppr.OrderBy(x => x.DateOT).ToList();
                var lstGroup = lstTotalNotAppr.GroupBy(x => new { x.Dept }).Select(x => new
                {
                    Dept = x.Key.Dept
                }).ToList();
                foreach (var item in lstGroup)
                {
                    DeptNotApprove d = new DeptNotApprove();
                    var findlistDept = lstTotalNotAppr.Where(x => x.Dept == item.Dept).ToList();
                    d.Dept = item.Dept;
                    foreach (var itemDept in findlistDept)
                    {
                        d.DateNotApprove += itemDept.DateOT.ToString("dd/MMM") + " | ";
                    }
                    lstResult.Add(d);
                }
            }
            return lstResult;
        }



        private void btnCheck_Click(object sender, EventArgs e)
        {
            var res = CheckDeptApprove();
            WriteDeptNpotAppToDataBase(res);
            if (res.Count > 0)
            {
                MessageBox.Show("Vẫn còn bộ phận chưa phê duyệt tăng ca\nChi tiết xem list bên dưới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Add Thêm load list và ngày
                var specialOTWaitingApprove = GetOTSpecial();
                var lstDeptNotApprove = LoadAllDeptAndAllDayNotApprove();

                var mergedList1 = (from t1 in lstDeptNotApprove
                                 join t2 in specialOTWaitingApprove on t1.Dept equals t2.Dept into temp
                                 from t2 in temp.DefaultIfEmpty()
                                 select new DeptNotApprove
                                 {
                                     Dept = t1.Dept,
                                     DateNotApprove = t1 != null ? t1.DateNotApprove : null,
                                     DateSpecialApprove = t2 != null ? t2.DateSpecialApprove : null,
                                 }).ToList();
                var mergedList2 = (from t1 in specialOTWaitingApprove
                                  join t2 in lstDeptNotApprove on t1.Dept equals t2.Dept into temp
                                  from t2 in temp.DefaultIfEmpty()
                                  select new DeptNotApprove
                                  {
                                      Dept = t1.Dept,
                                      DateNotApprove = t2 != null ? t2.DateNotApprove : null,
                                      DateSpecialApprove = t1 != null ? t1.DateSpecialApprove : null,
                                  }).ToList();
                mergedList1.AddRange(mergedList2);
                var resultList = mergedList1.GroupBy(g => g.Dept).Select(s => s.First()).ToList();


                dgvNotApprove.DataSource = null;
                dgvNotApprove.DataSource = resultList;
                dgvNotApprove.Columns["Dept"].HeaderText = "Bộ phận";
                dgvNotApprove.Columns["DateNotApprove"].HeaderText = "Ngày chưa phê duyệt";
                dgvNotApprove.Columns["DateSpecialApprove"].HeaderText = "Ngày chưa phê duyệt tăng ca đặc biệt";

                dgvOverTime.DataSource = resultList;
                dgvOverTime.Columns["Dept"].HeaderText = "Bộ phận";
                dgvOverTime.Columns["DateNotApprove"].HeaderText = "Ngày chưa phê duyệt";
                dgvOverTime.Columns["DateSpecialApprove"].HeaderText = "Ngày chưa phê duyệt tăng ca đặc biệt";
                dgvOverTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvOverTime.Columns[0].Frozen = true;
                dgvOverTime.Columns[1].Frozen = true;
                //dgvOverTime.DataSource = res.Select(x => new { Dept = x }).ToList();
                dgvOverTime.Refresh();
                btnSendEmail.Enabled = true;
                return;
            }
            else
            {
                lstOTDailySearch = lstOverTime;
                dgvOverTime.DataSource = null;
                dgvOverTime.DataSource = lstOTDailySearch.OrderBy(r => r.Code).ToList();
                dgvOverTime.Columns[0].Visible = false;
                dgvOverTime.Columns[1].HeaderText = "Date";
                dgvOverTime.Columns[3].HeaderText = "Full Name";
                dgvOverTime.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvOverTime.Columns[4].HeaderText = "Shift";
                dgvOverTime.Refresh();
            }
        }

        private string GetSpecialDateOTList(string dept, List<Tbl_HistoryUpdateOT> waitingApproveSpecial)
        {
            string dateStr = "";
            foreach (var item in waitingApproveSpecial.GroupBy(g=> new {g.Dept,g.TimeUpdate.Value.Date}).Select(s=>s.First()).ToList())
            {
                if(item.Dept == dept) dateStr = dateStr + item.TimeUpdate.Value.Date.ToString("dd/MMM") + " | ";
            }
            return dateStr;
        }

        private List<DeptNotApprove> GetOTSpecial()
        {
            using(var context = new DBContext())
            {
                var waitingApproveSpecial =  context.Tbl_HistoryUpdateOT.Where(w => w.Status == "Chờ phê duyệt").ToList();
                var newList = waitingApproveSpecial.Where(w => w.TimeUpdate.Value.Date < DateTime.Now.Date).ToList();
                return newList.GroupBy(g => new { g.Dept, g.TimeUpdate.Value.Date}).Select(g => new DeptNotApprove
                {                   
                    Dept = g.Key.Dept,
                    DateSpecialApprove = GetSpecialDateOTList(g.Key.Dept, newList)
                }).ToList().OrderBy(o=>o.Dept).ToList().GroupBy(g=>g.Dept).Select(s=>s.First()).ToList();
            }
        }

        private List<string> CheckDeptApprove()
        {
            List<string> lstWaitApprove = new List<string>();
            DateTime today = DateTime.Now.Date;
            DateTime dateSelect = dtDateOverTime.Value.Date;
            int Year = dateSelect.Year;
            int Month = dateSelect.Month;

            var lstHumanInfoWorking = lstHumanInfo.Where(x => x.QuitJob == null || (x.QuitJob != null && x.QuitJob.Value.Year >= Year && x.QuitJob.Value.Month >= Month)).ToList();

            using (var db = new DBContext())
            {
                lstOverTime = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();
                var lstNotApprove = lstOverTime.Where(x => (x.TotalOT != 0) || (x.TimeOTDept != null && x.TimeOTDept != 0)).ToList();
                var lstDeptNotApprove = (from a in lstNotApprove
                                         join h in lstHumanInfoWorking on a.Code equals h.AltCode
                                         select new
                                         {
                                             Code = h.Code,
                                             Dept = h.Dept.ToUpper(),
                                             Position = h.Position,
                                         }).ToList();
                //Xóa tăng ca Manager
                lstDeptNotApprove = lstDeptNotApprove.Where(x => !x.Position.Contains("Manager")).ToList();
                var lstGroupDeptNotApprove = lstDeptNotApprove.GroupBy(o => new { o.Dept }).Select(o => new
                {
                    Dept = o.Key.Dept,
                }).ToList();

                var lstDeptApproved = db.Tbl_Approve.Where(x => x.DateOT == dateSelect && !string.IsNullOrEmpty(x.Approve)).ToList();
                foreach (var item in lstDeptApproved)
                {
                    var findApproved = lstGroupDeptNotApprove.FirstOrDefault(x => x.Dept == item.Dept);
                    if (findApproved != null)
                    {
                        lstGroupDeptNotApprove.Remove(findApproved);
                    }
                }
                // Xóa FM1 và FM2
                var findFM = lstGroupDeptNotApprove.Where(x => x.Dept == "FM1" || x.Dept == "FM2").ToList();
                foreach (var itemfm in findFM)
                {
                    lstGroupDeptNotApprove.Remove(itemfm);
                }

                foreach (var item in lstGroupDeptNotApprove)
                {
                    lstWaitApprove.Add(item.Dept);
                }
                return lstWaitApprove;
            }
        }



        private void FormGAWorkSpace_Load(object sender, EventArgs e)
        {

            btnSendEmail.Enabled = false;
            CheckUserAndRule();

            //Task.Run(() => FetchAndPopulateComboBox());
        }

        private void RequestCompleted(DataTable dt)
        {
            Init();
        }

        private DataTable GetData()
        {
            var init  = GAMankuchiAll.Instance()._listAllStaff;
            return new DataTable();
        }


        //private void FetchAndPopulateComboBox()
        //{
        //    Invoke((MethodInvoker)delegate{
        //        Init();
        //    });
        //}

        private void CheckUserAndRule()
        {
            if (Common.UserLogin.UserName == "View")
            {
                btnSendEmail.Enabled = false;
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                if (cbbDept.Text != "ALL")
                {
                    if (CheckDeptApproved())
                    {
                        DateTime dateSelect = dtDateOverTime.Value.Date;
                        using (var db = new DBContext())
                        {
                            Common.RunProcess("LoadTitle.exe");
                            lstOverTime.Clear();
                            lstOverTime = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();
                            // var t1 = lstOverTime.FirstOrDefault(r => r.Code == "34228");
                            if (!string.IsNullOrEmpty(cbbDept.Text))
                            {
                                var lstMankichi = GAMankuchiAll.Instance()._listAllStaff;
                                //var t2 = lstMankichi.FirstOrDefault(r => r.AltCode == "34228");
                                var lstMankichiDept = lstMankichi.Where(x => x.Dept == cbbDept.Text).ToList();
                                lstOTDailySearch = (from o in lstOverTime
                                                    join k in lstMankichiDept on o.Code equals k.AltCode
                                                    select o).OrderBy(r => r.Code).ToList();
                                // var t3 = lstOverTime.FirstOrDefault(r => r.Code == "34228");
                            }
                            dgvOverTime.DataSource = null;
                            dgvOverTime.DataSource = lstOTDailySearch;
                            EditViewDgvOverTime();
                            dgvOverTime.Refresh();
                            Common.KillProcess("LoadTitle");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bộ phận chưa được phê duyệt tăng ca", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (cbbDept.Text == "ALL")
                {
                    CheckDeptApprove();
                    LoadAllDataOverTime();
                }
            }
        }

        private void LoadAllDataOverTime()
        {
            lstOTDailySearch = lstOverTime;
            dgvOverTime.DataSource = null;
            dgvOverTime.DataSource = lstOTDailySearch;
            dgvOverTime.Refresh();
        }

        private void EditViewDgvOverTime()
        {
            dgvOverTime.Columns["CaLV"].HeaderText = "Shift Code";
            dgvOverTime.Columns["Id"].Visible = false;

            dgvOverTime.Columns["OTDayShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["AdjustOTDayShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["OTNightShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["AdjustOTNightShift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["TimeOTFinger"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["TimeRegisted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["TimeOTPreshift"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["TotalOT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["TimeOTDept"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvOverTime.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvOverTime.Columns["OTDayShift"].HeaderText = "Tăng Ca Ngày";
            dgvOverTime.Columns["AdjustOTDayShift"].HeaderText = "ĐiềuChỉnh TC Ngày";
            dgvOverTime.Columns["OTNightShift"].HeaderText = "Tăng Ca Đêm";
            dgvOverTime.Columns["AdjustOTNightShift"].HeaderText = "ĐiềuChỉnh TC Đêm";
            dgvOverTime.Columns["TimeRegisted"].HeaderText = "Giờ Đăng Ký";
            dgvOverTime.Columns["TimeOTPreshift"].HeaderText = "Tăng Ca TrướcGiờ";
            dgvOverTime.Columns["TimeOTDept"].HeaderText = "Giờ BộPhận";
            dgvOverTime.Columns["Balance"].HeaderText = "ChênhLệch";
            dgvOverTime.Columns["TimeOTFinger"].HeaderText = "Giờ VânTay";
            dgvOverTime.Columns["DateOverTime"].HeaderText = "Ngày";
            dgvOverTime.Columns["Code"].HeaderText = "Mã NV";
            dgvOverTime.Columns["FullName"].HeaderText = "Họ Tên";
            dgvOverTime.Columns["CaLV"].HeaderText = "Ca LàmViệc";
            dgvOverTime.Columns["Reason"].HeaderText = "Lý do TăngCa";
            dgvOverTime.Columns["TimeIn"].HeaderText = "Giờ Vào";
            dgvOverTime.Columns["TimeOut"].HeaderText = "Giờ Ra";
            dgvOverTime.Columns["UserRegister"].Visible = false;
            dgvOverTime.Columns["Approve"].Visible = false;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            //Load List Dept chưa phê duyệt
            if (dgvNotApprove.Rows.Count > 0)
            {
                string DeptSendEmail = string.Empty;
                foreach (DataGridViewRow r in dgvNotApprove.Rows)
                {
                    string Dept = r.Cells[0].Value.ToString();
                    DeptSendEmail += Dept + "|";
                }

                if (DeptSendEmail.EndsWith("|"))
                {
                    DeptSendEmail = DeptSendEmail.Remove(DeptSendEmail.Length - 1, 1).Trim();
                }

                var html = Common.GetContentFromDataGrid(dgvNotApprove);

                var subject = string.Format("[OVER TIME] Các bộ phận chưa phê Duyệt Tăng ca");
                string PathRunPara = string.Format("{0}", Common.PathAppRun);
                var content = string.Format("Dear All, </br> Các bộ phận dưới đây chưa hoàn thành phê duyệt tăng ca </br> {0} </br></br><a href=\"{1}\">[CLICK HERE TO OPEN SOFTWARE]</a></br></br>Thanks!", html, PathRunPara);
                MailProcess.SendEmailAlarm(DeptSendEmail, subject, content);
                MessageBox.Show("Send Email", "Thông Báo");
            }
        }

        private void btnExcelDaily_Click(object sender, EventArgs e)
        {
            if(lstOTDailySearch.Count == 0)
            {
                MessageBox.Show("Click Load dữ liệu trước!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                //sfd.InitialDirectory = "C:\\";
                sfd.Title = "Save Excel Files";
                //sfd.CheckFileExists = true;
                sfd.CheckPathExists = true;
                sfd.DefaultExt = "xls";
                //sfd.Filter = "Text files (.txt)|*.txt|All files (.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;
                sfd.FileName = DateTime.Now.ToString("yyyyMMdd");
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Common.RunProcess("LoadTitle.exe");
                    ExcelFileProcess.ExportExceDaiLyOverTime(lstOTDailySearch, sfd.FileName);
                    Common.KillProcess("LoadTitle");
                }
            }
        }

        private bool CheckDeptApproved()
        {
            bool res = false;
            DateTime dateselect = dtDateOverTime.Value.Date;
            using (var db = new DBContext())
            {
                var FindDeptApproved = db.Tbl_Approve.FirstOrDefault(x => x.DateOT == dateselect && !string.IsNullOrEmpty(x.Approve) && x.Dept == cbbDept.Text);
                if (FindDeptApproved != null)
                {
                    res = true;
                }
                else res = false;
            }
            return res;
        }

        private void btnExcelFileTotal_Click(object sender, EventArgs e)
        {
            DateTime dateselect = dtDateOverTime.Value.Date;

            if (!string.IsNullOrEmpty(cbbDept.Text))
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
                {
                    sfd.Title = "Save Excel Files";
                    sfd.CheckPathExists = true;
                    sfd.DefaultExt = "xls";
                    sfd.FilterIndex = 2;
                    sfd.RestoreDirectory = true;
                    sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        btnExcelFileTotal.Text = "Waiting...";
                        bgwExportExcel.RunWorkerAsync(sfd.FileName);
                    }
                }
            }
        }

        private void bgwExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateselect = DateTime.Now;
            string deptSelect = "";
            this.Invoke(new Action(() =>
            {
                 dateselect = dtDateOverTime.Value.Date;
                 deptSelect = cbbDept.Text;
            }));
          
            var sfd = (string)e.Argument;
            var lstDetaiOT = SummaryHelper.GetListSummaryDetailOverTime(dateselect, deptSelect);
            var result = ExcelFileProcess.ExportExcelTotalSummaryOT(lstDetaiOT, sfd, dateselect);
            e.Result = result;
        }

        private void bgwExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExcelFileTotal.Text = "Xuất File Tổng hợp";
            var result = (string)e.Result;
            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class DeptNotApprove
    {
        public string Dept { get; set; }

        public string DateNotApprove { get; set; }

        public string DateSpecialApprove { get; set; }

    }
}
