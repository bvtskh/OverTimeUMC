using CommonProject.Business;
using CommonProject.Loading.LoadingClass;
using OverTime.Business;
using OverTime.Class;
using OverTime.DataBase;
using OverTime.MsgBox_AQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormFCOT : Form
    {
        List<Tbl_ForecastOT> lstChange = new List<Tbl_ForecastOT>();
        string _customer = "";
        string _dept = "";
        public FormFCOT()
        {
            InitializeComponent();
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            LoadInfoMasterData();
        }


        private void LoadInfoMasterData()
        {
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            foreach (var item in ArrDept)
            {
                cbbDept.Items.Add(item);
            }
            if (ArrDept.Length == 1)
            {
                cbbDept.SelectedIndex = 0;
            }
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lstCustomerGroup = GAMankuchi.Instance()._listCurrentStaff
                .Where(x => x.Dept == cbbDept.Text)
                .GroupBy(x => new { x.Customer }).Select(x => new
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
            if (cbbCustomer.Items.Count == 1) cbbCustomer.SelectedIndex = 0;
            _dept = cbbDept.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDept.Text))
            {
                var result = RJMessageBox.Show("Chưa chọn bộ phận đăng ký tăng ca.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cbbCustomer.Text))
            {
                var result = RJMessageBox.Show("Chưa chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CheckUserSaveData();
            btnSearch.Image = global::OverTime.Properties.Resources.Spinner_1s_20px;
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(false);
        }

        private void RequestCompleted(DataTable dt)
        {
            btnSearch.Image = global::OverTime.Properties.Resources.icons8_search_book_20;
            dgvMain.DataSource = dt;
            dgvMain.Columns["Công việc"].Frozen = true;
            dgvMain.Columns["Tổng giờ"].Frozen = true;
            dgvMain.Columns["Công việc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //foreach(DataGridViewRow row in dgvMain.Rows)
            //{
            //    foreach(DataGridViewCell cell in row.Cells)
            //    {
            //        string columnName = dgvMain.Columns[cell.ColumnIndex].Name;
            //        if(columnName.Contains("Sat") || columnName.Contains("Sun"))
            //        {
            //            row.DefaultCellStyle.BackColor = 
            //        }
            //    }
            //}
        }

        private DataTable GetData()
        {
            return OverTimeHelper.GetAllLineInCustomer(_customer, _dept, dtDateOverTime.Value.Date);
        }

        private void CheckUserSaveData()
        {
            if (lstChange.Count > 0)
            {
                var result = RJMessageBox.Show("Bạn có muốn lưu lại dữ liệu trước khi thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
                else
                {
                    lstChange.Clear();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstChange.Count == 0)
            {
                RJMessageBox.Show("Bạn chưa có sửa đổi gì để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var result = OverTimeHelper.SaveForecastOT(lstChange);
            if (string.IsNullOrEmpty(result))
            {
                RJMessageBox.Show($"Đăng ký thành công cho {lstChange.Count} jobs", "Thông Báo", MessageBoxButtons.OK);
                lstChange.Clear();
            }
            else
            {
                RJMessageBox.Show("Đăng ký thất bại, vui lòng liên hệ bộ phận DX.", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }
        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dgvMain.CurrentCell;
            DataGridViewRow curRow = dgvMain.CurrentRow;
            if (curCell.ColumnIndex != 0)
            {
                string mainStr = dgvMain.CurrentCell.Value != null ? dgvMain.CurrentCell.Value.ToString() : "";
                double NumberInput = 0;
                double.TryParse(mainStr, out NumberInput);

                if (NumberInput > 0)
                {
                    double t = NumberInput / 0.5;
                    t = Math.Floor(t);
                    double t2 = t * 0.5;
                    if (t2 != NumberInput)
                    {
                        RJMessageBox.Show("Giờ đăng ký tăng ca phải làm tròn đến 0.5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvMain.CurrentCell.Value = 0;
                        return;
                    }

                }

                for (int scan = 0; scan < mainStr.Length; scan++)
                {
                    if (!Char.IsDigit(mainStr[scan]) && mainStr[scan] != '.')
                    {
                        RJMessageBox.Show("Chỉ được nhập số, và phải >= 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvMain.CurrentCell.Value = 0;
                        dgvMain.ClearSelection();
                        dgvMain.CurrentCell = curCell;
                        dgvMain.CurrentCell.Selected = true;
                        return;
                    }
                }
                curRow.Cells[1].Value = TotalOTInJob(curRow);
                lbTotalHours.Text = TotalOTInDept().ToString();
                AddListChange(curCell);
            }
        }
        private double TotalOTInJob(DataGridViewRow rows)
        {
            double total = 0;
            foreach (DataGridViewCell cell in rows.Cells)
            {
                if (cell.ColumnIndex > 1 && cell.Value != null)
                {
                    double NumberInput = 0;
                    double.TryParse(cell.Value.ToString(), out NumberInput);
                    total += NumberInput;
                }
            }
            return total;
        }

        private double TotalOTInDept()
        {
            var dt = (DataTable)dgvMain.DataSource;
            return dt.AsEnumerable().Sum(row => row.Field<double>("Tổng giờ"));
        }
        private void AddListChange(DataGridViewCell curCell)
        {
            if (curCell.Value == null) return;
            if (string.IsNullOrEmpty(dgvMain.Columns[curCell.ColumnIndex].Name)) return;
            string job = dgvMain.Rows[curCell.RowIndex].Cells[0].Value.ToString();
            string columnName = dgvMain.Columns[curCell.ColumnIndex].Name;
            var date = new DateTime(dtDateOverTime.Value.Year, dtDateOverTime.Value.Month, int.Parse(columnName.Split(' ')[1]));
            double NumberInput = 0;
            double.TryParse(curCell.Value.ToString(), out NumberInput);
            var isExist = lstChange.Where(m => m.DAY == date && m.JOB == job).FirstOrDefault();
            if (isExist == null)
            {
                lstChange.Add(new Tbl_ForecastOT()
                {
                    DAY = date,
                    JOB = job,
                    TIME_OT = NumberInput,
                    CUSTOMER = cbbCustomer.Text,
                    DEPT = cbbDept.Text
                });
            }
            else
            {
                isExist.TIME_OT = NumberInput;
            }
        }

        private void FormFCOT_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckUserSaveData();
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _customer = cbbCustomer.Text;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToXLSX((DataTable)dgvMain.DataSource);
        }

        private void dgvMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var name = dgvMain.Columns[e.ColumnIndex].Name;
            if (name.Contains("Sun"))
            {
                e.CellStyle.ForeColor = Color.Red;
            }
            if (name.Contains("Sat"))
            {
                e.CellStyle.ForeColor = Color.Orange;
            }
        }
    }
}
