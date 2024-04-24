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
    public partial class FormSepcialAdjustOT : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstMankichi = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        public FormSepcialAdjustOT()
        {
            InitializeComponent();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start();
        }

        private void Init()
        {
            int Month = DateTime.Now.Month;
            int Year = DateTime.Now.Year;
            lstMankichi = GAMankuchiAll.Instance()._listAllStaff;
            var lstHumanInfo = lstMankichi.Where(x => x.QuitJob == null).ToList();
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            foreach (var item in ArrDept)
            {
                cbbDept.Items.Add(item);
            }
            if (ArrDept.Length == 1) cbbDept.SelectedIndex = 0;
        }

        private void FormSepcialAdjustOT_Load(object sender, EventArgs e)
        {
            dgvRequest.ColumnHeadersDefaultCellStyle.Font = new Font("Arial",11,FontStyle.Bold);
            dgvRequest.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular);        
        }

        private void RequestCompleted(DataTable dt)
        {
            Init();
        }

        private DataTable GetData()
        {
            var init = GAMankuchiAll.Instance()._listAllStaff;
            return new DataTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvRequest.Rows.Clear();
            string Status = cbbStatus.Text;
            if (Status == "All") Status = "";
            string Dept = cbbDept.Text;
            using (var db = new DBContext())
            {
                List<Tbl_HistoryUpdateOT> lstRequest = new List<Tbl_HistoryUpdateOT>();
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    if(Dept == "ALL")
                    {
                        lstRequest = db.Tbl_HistoryUpdateOT.Where(x => x.Status.Contains(Status)).ToList();
                    }
                    else
                    {
                        lstRequest = db.Tbl_HistoryUpdateOT.Where(x => x.Dept == cbbDept.Text && x.Status.Contains(Status)).ToList();
                    }
                }
                else
                {
                    long ReqNo = 0;
                    long.TryParse(txtSearch.Text, out ReqNo);
                    if(ReqNo > 0)
                    {
                        lstRequest = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    }
                }
                foreach (var item in lstRequest)
                {
                    item.TimeUpdate = item.TimeUpdate.Value.Date;
                }
                var lstReqGroup = lstRequest.GroupBy(o => new { o.RequestNo, o.TimeUpdate,o.Dept,o.Status}). Select(o => new
                    {
                        RequestNo = o.Key.RequestNo,
                        TimeRequest = o.Key.TimeUpdate,
                        Dept = o.Key.Dept,
                        Status = o.Key.Status,
                    }).ToList();
                foreach (var item in lstReqGroup)
                {
                    int rowId = dgvRequest.Rows.Add();
                    DataGridViewRow row = dgvRequest.Rows[rowId];
                    row.Cells["Col_ReqNo"].Value = item.RequestNo;
                    row.Cells["Col_RequestDate"].Value = item.TimeRequest.Value.ToString("MM/dd/yyyy");
                    row.Cells["Col_Dept"].Value = item.Dept;
                    row.Cells["Col_Status"].Value = item.Status;
                }
                
            }

        }


        private void btnCreat_Click(object sender, EventArgs e)
        {
            FormHistoryAdjustOT frmCreate = new FormHistoryAdjustOT();
            frmCreate.Show();
        }

        private void dgvRequest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            lbRequestNo.Text = dgvRequest.Rows[e.RowIndex].Cells["Col_ReqNo"].Value.ToString();
            long ReqNo = 0;
            long.TryParse(lbRequestNo.Text, out ReqNo);
            if(ReqNo > 0)
            {
                using (var db = new DBContext())
                {
                    var lstRequest = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                    dgvDetailRequest.DataSource = null;
                    dgvDetailRequest.DataSource = lstRequest;
                    EditViewDgvHistoryAdjust();
                    dgvDetailRequest.Refresh();
                }
            }
            
        }


        private void EditViewDgvHistoryAdjust()
        {
            dgvDetailRequest.Columns["Id"].Visible = false;
            dgvDetailRequest.Columns["Approve"].Visible = false;
            dgvDetailRequest.Columns["UserUpdate"].Visible = false;
            dgvDetailRequest.Columns["TimeOTRegisted"].Width = 50;

            dgvDetailRequest.Columns["TimeOTUpdate"].Width = 80;
            dgvDetailRequest.Columns["Code"].Width = 60;
            dgvDetailRequest.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetailRequest.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetailRequest.Columns["TimeUpdate"].Width = 90;
            dgvDetailRequest.Columns["DateAdjust"].Width = 90;
            dgvDetailRequest.Columns["Status"].Width = 130;

            dgvDetailRequest.Columns["TimeUpdate"].HeaderText = "Ngày tạo yêu cầu";
            dgvDetailRequest.Columns["DateAdjust"].HeaderText = "Ngày Cần Điều chỉnh";
            dgvDetailRequest.Columns["TimeOTRegisted"].HeaderText = "Giờ ĐK";
            dgvDetailRequest.Columns["TimeOTUpdate"].HeaderText = "Giờ Báo lại";
            dgvDetailRequest.Columns["DateAdjust"].HeaderText = "Ngày ĐiềuChỉnh";
            dgvDetailRequest.Columns["Code"].HeaderText = "Mã NV";
            dgvDetailRequest.Columns["FullName"].HeaderText = "Họ và Tên";
            dgvDetailRequest.Columns["Status"].HeaderText = "Trạng thái";
            dgvDetailRequest.Columns["TimeIn"].HeaderText = "Giờ vào";
            dgvDetailRequest.Columns["TimeOut"].HeaderText = "Giờ ra";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            long ReqNo = 0;
            long.TryParse(lbRequestNo.Text, out ReqNo);
            if(ReqNo > 0)
            {
                using (var db = new DBContext())
                {
                    var findItem = db.Tbl_HistoryUpdateOT.FirstOrDefault(x => x.RequestNo == ReqNo);
                    if(findItem != null)
                    {
                        if(findItem.Status == "Đang điều chỉnh")
                        {
                            FormHistoryAdjustOT frmEdit = new FormHistoryAdjustOT(ReqNo, "Edit");
                            frmEdit.Show();
                        }
                        else
                        {
                            string mes = string.Format("Số yêu cầu này {0} nên không thể chỉnh sửa", findItem.Status);
                            MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            long ReqNo = 0;
            long.TryParse(lbRequestNo.Text, out ReqNo);
            using (var db = new DBContext())
            {
                var findRequest = db.Tbl_HistoryUpdateOT.Where(x => x.RequestNo == ReqNo).ToList();
                if(findRequest.Count > 0)
                {
                    string Status = findRequest[0].Status.ToString();
                    if(Status == "Đang điều chỉnh")
                    {
                        DialogResult dlr =  MessageBox.Show("Bạn chắc chắn muốn xóa yêu cầu điều chỉnh tăng ca này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(dlr == DialogResult.Yes)
                        {
                            if(Common.CheckPassword("umcvn", "Nhập password để xóa"))
                            {
                                db.Tbl_HistoryUpdateOT.RemoveRange(findRequest);
                                db.SaveChanges();
                                MessageBox.Show("Delete Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnSearch_Click(null, null);
                                dgvDetailRequest.DataSource = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        string mes = string.Format("Số yêu cầu này {0} nên không thể xóa",Status);
                        MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            FormHistoryAdjustOT frmAppr = new FormHistoryAdjustOT(0, "Approve");
            frmAppr.Show();
        }
    }
}
