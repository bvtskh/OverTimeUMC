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
    public partial class FormBalanceFCOT : Form
    {
        List<Tbl_ForecastOT> lstChange = new List<Tbl_ForecastOT>();
        string _customer = "";
        string _dept = "";
        public FormBalanceFCOT()
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
            //btnSearch.Image = global::OverTime.Properties.Resources.Spinner_1s_20px;
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(true);
        }

        private void RequestCompleted(DataTable dt)
        {
            //btnSearch.Image = global::OverTime.Properties.Resources.icons8_search_book_20;
            dgvMain.DataSource = dt;
            dgvMain.Columns["Công việc"].Frozen = true;
            dgvMain.Columns[1].Frozen = true;
            dgvMain.Columns["Công việc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private DataTable GetData()
        {
            return OverTimeHelper.GetBalanceOTInCustomer(_customer, _dept, dtDateOverTime.Value.Date);
        }


        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _customer = cbbCustomer.Text;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToXLSX((DataTable)dgvMain.DataSource);
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex == 0)
            {
                dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                var row = dgvMain.Rows[e.RowIndex - 1];
                var oldColor = row.DefaultCellStyle.BackColor;
                string oldPart = row.Cells["Công việc"].Value.ToString();
                string newPart = dgvMain.Rows[e.RowIndex].Cells["Công việc"].Value.ToString();
                if (oldPart != newPart)
                {
                    dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = oldColor == Color.White ? Color.DarkKhaki : Color.White;
                }
                else
                {
                    dgvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = oldColor;
                }

            }
        }

    }
}
