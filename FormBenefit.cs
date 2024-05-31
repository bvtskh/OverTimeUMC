using CommonProject.Loading.LoadingClass;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Cms;
using OverTime.Business;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormBenefit : Form
    {
        DateTime selectDate;
        public FormBenefit()
        {
            InitializeComponent();
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start(true);
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
                cbDept.Items.Add("ALL");
                if (Common.UserLogin.TypeUser == "Salary")
                {                  
                    cbDept.Items.AddRange(GAMankuchiAll.Instance()._listAllStaff.Where(x => x.QuitJob == null).ToList().GroupBy(g => g.Dept).Select(s => s.First().Dept).ToArray());
                }
                else
                {
                    string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
                    foreach (var item in ArrDept)
                    {
                        cbDept.Items.Add(item);
                    }                  
                }
                if(cbDept.Items.Count > 0)
                {
                    cbDept.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormBenefit_Load(object sender, EventArgs e)
        {          
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
            selectDate = DateTime.Now;
        }

        private void CreateBaseTable(DateTime date, string dept, string staffCode)
        {
            int month = date.Month;
            int year = date.Year;
            int numberDay = DateTime.DaysInMonth(year,month);

            int totalColum = 3 + (numberDay * 2) + 6;
            dgvbenefit.ColumnHeadersVisible = false;

            DataTable table = new DataTable();

            for (int col = 1; col <= totalColum; col++)
            {
                table.Columns.Add(new DataColumn("A" + col));
            }
            var monthRow = table.Rows.Add();
            monthRow[numberDay+1] = new DateTime(year, month, 1).Date.ToString("MMM");
            monthRow[numberDay*2 + 7] = "Tổng";

            var dayRow = table.Rows.Add("STT","Mã nhân viên","Họ tên");
            var subDay = table.Rows.Add();
            int index = 1;
            for(int i = 3; i<= numberDay*2; i++)
            {

                if (i % 2 == 1)
                {
                    subDay[i] = "Ngày";
                    dayRow[i] = index;
                    index++;
                    if (index == numberDay)
                    {
                        subDay[i + 1] = "Đêm";
                        dayRow[i + 2] = index;
                        subDay[i + 2] = "Ngày";
                        subDay[i + 3] = "Đêm";

                        subDay[i + 4] = "Ngày";
                        subDay[i + 5] = "Đêm";
                        subDay[i + 6] = "Ngày";
                        subDay[i + 7] = "Đêm";
                        break;
                    }
                }
                else
                {
                    subDay[i] = "Đêm";
                }
            }
            dayRow[3 + numberDay * 2] = "Phút";
            dayRow[5 + numberDay * 2] = "Giờ";
            dayRow[7 + numberDay * 2] = "Tổng Phút";
            dayRow[8 + numberDay * 2] = "Tổng giờ";

            // lấy dữ liệu từ DB
            var data = BenefitOTHelper.GetDetailBenefit(table, date, dept, staffCode, Common.UserLogin.TypeUser, Common.UserLogin.Dept.Split('|').ToArray());


            dgvbenefit.DataSource = data;


            // setting row
            dgvbenefit.Columns[0].Width = 40;
            dgvbenefit.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvbenefit.Columns[1].Width = 100;
            dgvbenefit.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvbenefit.Columns[2].Width = 160;
            dgvbenefit.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvbenefit.ReadOnly = true;
            for (int row = 0; row < 3; row++)
            {
                dgvbenefit.Rows[row].DefaultCellStyle.BackColor=Color.FromArgb(64,64,64);
                dgvbenefit.Rows[row].DefaultCellStyle.ForeColor = Color.White;
                dgvbenefit.Rows[row].DefaultCellStyle.Font = new Font("Calibri",10,FontStyle.Bold);
                for (int i = 3; i <= numberDay * 2 + 6; i++)
                {
                    dgvbenefit.Columns[i].Width = 40;
                    dgvbenefit.Rows[row].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dgvbenefit.Columns[totalColum - 1].Width = 100;
            dgvbenefit.Columns[totalColum - 2].Width = 100;

            dgvbenefit.Rows[2].Frozen=true;
            dgvbenefit.Columns[2].Frozen = true;
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                      BindingFlags.Instance | BindingFlags.SetProperty, null, dgvbenefit, new object[] { true });

            // tô màu T7 CN
            for(int i = 3;i < numberDay *2+3; i+=2)
            {
                string day = dgvbenefit.Rows[1].Cells[i].Value?.ToString();
                if (!string.IsNullOrEmpty(day))
                {
                    if (ISsunday(day, date))
                    {
                        for (int j = 3; j < dgvbenefit.RowCount; j++)
                        {
                            dgvbenefit.Rows[j].Cells[i].Style.BackColor = Color.Yellow;
                            dgvbenefit.Rows[j].Cells[i+1].Style.BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }

        private bool ISsunday(string day, DateTime date)
        {
            return new DateTime(date.Year,date.Month,Int16.Parse(day)).DayOfWeek == DayOfWeek.Sunday;
        }

        private void dgvbenefit_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int numberDay = DateTime.DaysInMonth(selectDate.Year, selectDate.Month);

            if ((e.ColumnIndex == 0 && e.RowIndex == 0) || (e.ColumnIndex == 1 && e.RowIndex == 0) || (e.ColumnIndex == 2 && e.RowIndex == 0))
            {            
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            if ((e.ColumnIndex == 0 && e.RowIndex ==1) ||( e.ColumnIndex == 1 && e.RowIndex == 1) || (e.ColumnIndex == 2 && e.RowIndex == 1))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            if((e.RowIndex == 0 && e.ColumnIndex <= numberDay * 2+1 && e.ColumnIndex>=3) || e.RowIndex == 0 && e.ColumnIndex > numberDay * 2+2)
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }

            if((e.RowIndex ==1 && e.ColumnIndex > 2 && e.ColumnIndex <= numberDay * 2 + 1 && e.ColumnIndex % 2 == 1) || (e.RowIndex == 1 &&  e.ColumnIndex > numberDay * 2 + 2 && e.ColumnIndex < numberDay * 2 + 6 && e.ColumnIndex % 2 == 1))
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            selectDate = ConvertDate(txtMonth.Text, txtYear.Text);
            if (selectDate == DateTime.MinValue)
            {
                UIMessageTip.ShowError("Thời gian không đúng!");
                return;
            }
            CreateBaseTable(selectDate, cbDept.SelectedItem as string, txtCode.Text);
        }

        private DateTime ConvertDate(string month, string year)
        {
            try
            {
                string temp = $@"{month}/01/{year}";
                DateTime dateTime;
                if(DateTime.TryParse(temp, out dateTime))
                { 
                    return dateTime;
                }
                return DateTime.MinValue;
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                selectDate = ConvertDate(txtMonth.Text, txtYear.Text);
                if (selectDate == DateTime.MinValue)
                {
                    UIMessageTip.ShowError("Thời gian không đúng!");
                    return;
                }
                CreateBaseTable(selectDate, cbDept.SelectedItem as string, txtCode.Text);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
