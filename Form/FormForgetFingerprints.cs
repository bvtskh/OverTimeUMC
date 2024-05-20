using CommonProject.Loading.LoadingClass;
using Org.BouncyCastle.Asn1.Cms;
using OverTime.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormForgetFingerprints : Form
    {

        FingerPrintsHelper _fingerPrintsHelper = new FingerPrintsHelper();
        private DataTable datatable;

        public FormForgetFingerprints()
        {
            InitializeComponent();
            CustomDatetimePicker();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(true);
        }

        private void CustomDatetimePicker()
        {
            dateFrom.Format = DateTimePickerFormat.Custom;
            dateFrom.CustomFormat = "dd-MM-yyyy";
            dateTo.Format = DateTimePickerFormat.Custom;
            dateTo.CustomFormat = "dd-MM-yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindForgetFinger();
        }

        private void FindForgetFinger()
        {
            try
            {
                string dept = cbbDept.SelectedItem as string;
                DateTime selectDateFrom = dateFrom.Value.Date;
                DateTime selectDateTo = dateTo.Value.Date;
                if (!_fingerPrintsHelper.IsHaveFinger(selectDateFrom))
                {
                    lbRowNumber.Text = "Không có dữ liệu vân tay!";
                    dgvForgetFinger.DataSource = null;
                    dgvForgetFinger.Refresh();
                    return;
                }
                if (string.IsNullOrEmpty(dept))
                {
                    MessageBox.Show("Chưa chọn bộ phận!"); return;
                }
                datatable = _fingerPrintsHelper.GetDataForgetPrintList(dept, selectDateFrom, selectDateTo, Common.UserLogin.TypeUser, Common.UserLogin.Dept.Split('|').ToArray());
                this.bindingFinger.DataSource = datatable;
                dgvForgetFinger.DataSource = this.bindingFinger.DataSource;
                lbRowNumber.Text = datatable.Rows.Count + " Rows";
                dgvForgetFinger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvForgetFinger.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                LogHelper.GetDataLog("FormForgetFingerprints", LogHelper.ModuleLog.FindForgetFinger, dateFrom.Value.ToString(), cbbDept.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormForgetFingerprints_Shown(object sender, EventArgs e)
        {
            cbbDept.Focus();
        }

        private void dgvForgetFinger_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            this.bindingFinger.Filter = dgvForgetFinger.FilterString;
        }

        private void dgvForgetFinger_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            this.bindingFinger.Sort = dgvForgetFinger.SortString;
        }

        private void txtStaffCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindForgetFinger();
            }
        }

        private void FormForgetFingerprints_Load(object sender, EventArgs e)
        {

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

        private void Init()
        {
            try
            {
                if (Common.UserLogin.TypeUser == "Salary")
                {
                    cbbDept.Items.Add("ALL");
                    cbbDept.Items.AddRange(GAMankuchiAll.Instance()._listAllStaff.Where(x => x.QuitJob == null).ToList().GroupBy(g => g.Dept).Select(s => s.First().Dept).ToArray());
                }
                else
                {
                    cbbDept.Items.Add("ALL");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //// Use SecurityProtocolType.Ssl3 if needed for compatibility reasons
            //var values = new Dictionary<string, string>
            //{
            //    { "access_token", "8952-ELSFTVQGD9VBABYC65PWNPZRHQ6CPYZN6V4J9N9S678GY6V5QE6G53GQNZKZVZBY-JPH5S686MXFB4H5QPGQ34WUA3ZYHDEK68MS5RP5HF2PF97GHWF3VQHXYH68TLH4R" },
            //    { "username", "common" },
            //    { "name", "Bất thường chất lượng sản phẩm" },
            //    { "approvers", "quyetpv" },
            //    { "content", "Phát hiện mạch chạy lại FCT NG" },
            //};

            //var content = new FormUrlEncodedContent(values);

            //var response = await client.PostAsync("https://request.base.vn/extapi/v1/request/direct/create", content);

            //var responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseString);
            //Console.ReadKey();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if(datatable != null  && datatable.Rows.Count > 0)
                {
                    if (_fingerPrintsHelper.ExportFingerPrint(datatable))
                    {
                        MessageBox.Show("Đã xuất file thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: "+ex.Message);
            }
        }
    }
}
