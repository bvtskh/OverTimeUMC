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
    public partial class FormHumanOT : Form
    {
        List<Tbl_FCHumanOT> lstChange = new List<Tbl_FCHumanOT>();
        string _customer = "";
        string _dept = "";
        public FormHumanOT()
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
            dgvMain.Columns["Công việc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable GetData()
        {
            return OverTimeHelper.GetAllLineInCustomerByWeek(_customer, _dept, dtDateOverTime.Value.Date);
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
            var result = OverTimeHelper.SaveHummanOT(lstChange);
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
                AddListChange(curCell);
            }
        }

        private void AddListChange(DataGridViewCell curCell)
        {
            if (curCell.Value == null) return;
            string job = dgvMain.Rows[curCell.RowIndex].Cells[0].Value.ToString();
            string columnName = dgvMain.Columns[curCell.ColumnIndex].Name;
            var date = DateTime.ParseExact(columnName, "ddd dd", new System.Globalization.CultureInfo("en-US"), DateTimeStyles.None);
            double NumberInput = 0;
            double.TryParse(curCell.Value.ToString(), out NumberInput);
            var isExist = lstChange.Where(m => m.DAY == date && m.JOB == job).FirstOrDefault();
            if (isExist == null)
            {
                lstChange.Add(new Tbl_FCHumanOT()
                {
                    DAY = date,
                    JOB = job,
                    HUMAN_OT = NumberInput,
                    CUSTOMER = cbbCustomer.Text,
                    DEPT = cbbDept.Text
                });
            }
            else
            {
                isExist.HUMAN_OT = NumberInput;
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
    }
}
