using CommonProject.Business;
using CommonProject.Loading.LoadingClass;
using CommonProject.MsgBox_AQ;
using OverTime.Business;
using OverTime.MsgBox_AQ;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormHistoryRegistration : Form
    {
        private string _dept = "";
        private bool defaultTextReplaced = false;

        public FormHistoryRegistration()
        {
            InitializeComponent();
            Init();
            dtTimeRegisted.Format = DateTimePickerFormat.Custom;
            dtTimeRegisted.CustomFormat = "dd-MM-yyyy";
        }

        private void Init()
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
            cbUserRegister.Text = $"Tìm theo {Common.UserLogin.UserName} đã đăng ký";
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            FormRegister frm = new FormRegister();
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string UserRegister = Common.UserLogin.UserName;
            DateTime DateSelect = dtTimeRegisted.Value.Date;
            if (string.IsNullOrEmpty(cbbDept.Text) && string.IsNullOrEmpty(txbCode.Text))
            {
                CommonProject.MsgBox_AQ.RJMessageBox.Show("Vui lòng chọn bộ phận trước!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(UserRegister))
            {
                CommonProject.MsgBox_AQ.RJMessageBox.Show("Phiên đăng nhập hết hiệu lực, Vui lòng đăng nhập lại!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            btnSearch.Image = global::OverTime.Properties.Resources.Spinner_1s_20px;
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(false);
        }

        private void RequestCompleted(DataTable dt)
        {
            btnSearch.Image = global::OverTime.Properties.Resources.icons8_search_book_20;
            dgvHistoryRegisted.DataSource = dt;
            lbPerson.Text = $@"Số Người: {dt.AsEnumerable()
                            .Select(r => r.Field<string>("Mã NV"))
                            .Distinct()
                            .Count().ToString()}";
            lbTime.Text = $@"Số Giờ ĐK: {dt.AsEnumerable()
                            .Sum(r => r.Field<float>("Giờ ĐK"))
                            .ToString()}";
            lblActual.Text = $@"Số Giờ Thực tế: {dt.AsEnumerable()
                            .Sum(r => r.Field<float>("Thực tế"))
                            .ToString()}";
            dgvHistoryRegisted.FitContent();
        }

        private DataTable GetData()
        {
            return OverTimeHelper.GetListUserOverTime(dtTimeRegisted.Value.Date, _dept,txbCode.Text,chkAllMonth.Checked,cbUserRegister.Checked);
        }


        private void FormHistoryRegistration_Load(object sender, EventArgs e)
        {
            CheckRule();
        }

        private void CheckRule()
        {
            if (Common.UserLogin.UserName == "View")
            {
                btnNew.Enabled = false;
            }
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dept = cbbDept.Text.Trim();
        }
    }
}
