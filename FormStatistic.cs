using CommonProject.Loading.LoadingClass;
using NPOI.SS.Formula.Functions;
using OverTime.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormStatistic : Form
    {
        public FormStatistic()
        {
            InitializeComponent();
            lblMonth.Text = DateTime.Now.Month.ToString();
            lblYear.Text = DateTime.Now.Year.ToString();
            cbbDept.Font= new Font("Times New Roman",12,FontStyle.Bold);
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
        private void FormStatistic_Load(object sender, EventArgs e)
        {
            InitDatatable();
        }

        private DataTable InitDatatable()
        {
            try
            {
                dgv.ColumnHeadersVisible = false;
                DataTable table = new DataTable();
                int numberDayInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                int month = DateTime.Now.Month - 1; // trừ 1 vì cột tháng hiện tại là: Thực tế tăng ca

                int totalColumns = 7 + month + 1 + numberDayInMonth; // +1 là vì bên trên trừ mất nó rồi:))
                for (int col = 1; col <= totalColumns; col++)
                {
                    table.Columns.Add(new DataColumn("A" + col));
                }


                table.Rows.Add(new object[] { "", "", "", "", "", "", "", "Tổng dự toán theo ngày" });
                table.Rows.Add(new object[] { "", "", "", "", "", "", "", "Tổng thực tế theo ngày" });
                table.Rows.Add(new object[] { "", "", "", "", "", "", "", "Chênh lệch theo ngày" });
                var objectHeader = new List<object> { "STT", "Code", "Họ tên", "Bộ phận", "Khách hàng", "Trực tiếp/ Gián tiếp", "Năm", "Tổng tăng ca thực tế" };

                if (month > 1)
                {
                    for (int i = 0; i < month - 1; i++)
                    {
                        objectHeader.Add("");
                    }
                    objectHeader.Add("Thực tế");
                }

                for (int i = 1; i <= numberDayInMonth; i++)
                {
                    if (i < 10)
                    {
                        objectHeader.Add(i.ToString().PadLeft(2, '0'));
                    }
                    else
                    {
                        objectHeader.Add(i.ToString());
                    }
                }


                table.Rows.Add(objectHeader.ToArray());


                var objectDayMonthHeader = new List<object> { "", "", "", "", "", "", "" };
                for (int i = 1; i <= month; i++)
                {
                    string sortMonth = new DateTime(DateTime.Now.Year, i, 1).Date.ToString("MMM");
                    objectDayMonthHeader.Add(sortMonth);
                }
                objectDayMonthHeader.Add("tăng ca");
                for (int i = 1; i <= numberDayInMonth; i++)
                {
                    string day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).Date.ToString("ddd");
                    objectDayMonthHeader.Add(day);
                }
                table.Rows.Add(objectDayMonthHeader.ToArray());

                this.BeginInvoke(new Action(() =>
                {
                    dgv.DataSource = table;


                    dgv.Columns[7].Width = 160;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgv.Columns[6 + DateTime.Now.Month].Frozen = true;
                    dgv.Rows[3].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    dgv.Rows[4].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    dgv.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 0);
                    dgv.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 0);


                    dgv.Columns[0].Width = 50;
                    dgv.Columns[1].Width = 60;
                    dgv.Columns[2].Width = 140;
                    dgv.Columns[3].Width = 70;
                    dgv.Columns[4].Width = 80;
                    dgv.Columns[5].Width = 110;
                    dgv.Columns[6].Width = 60;


                    for (int row = 0; row < 5; row++)
                    {
                        dgv.Rows[row].Height = 27;
                        dgv.Rows[row].DefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Bold);
                    }

                    for (int i = 1; i < month + numberDayInMonth + 1; i++)
                    {
                        dgv.Columns[7 + i].Width = 60;
                    }
                    dgv.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    dgv.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    // Enable double buffering for the DataGridView
                    typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                        BindingFlags.Instance | BindingFlags.SetProperty, null, dgv, new object[] { true });

                }));

                return table;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int month = DateTime.Now.Month-1;
            for (int i = 1; i <= month; i++)
            {
                if (e.RowIndex == 0 && (e.ColumnIndex == 6 + i) || (e.RowIndex == 1 && (e.ColumnIndex == 6 + i) || (e.RowIndex == 2 && e.ColumnIndex == 6 + i)))
                {
                    e.CellStyle.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                    e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                }
                if (i < month)
                {
                    if (e.RowIndex == 3 && (e.ColumnIndex == 6 + i))
                    {
                        e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
                if (i == month)
                {
                    if (e.RowIndex == 3 && (e.ColumnIndex == 6 + i + 1))
                    {
                        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                    }
                }
            }

            if (e.RowIndex == 0 && e.ColumnIndex <= 6 || e.RowIndex == 1 && e.ColumnIndex <= 6 || e.RowIndex == 2 && e.ColumnIndex <= 6)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            }
            if (e.RowIndex == 0 && e.ColumnIndex < 6 || e.RowIndex == 1 && e.ColumnIndex < 6 || e.RowIndex == 2 && e.ColumnIndex < 6)
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
            if (e.RowIndex == 3 && e.ColumnIndex <= 6)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                e.CellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            }
            if (e.RowIndex == 2 && e.ColumnIndex <= 6)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string dept = cbbDept.SelectedItem as string;
                if (string.IsNullOrEmpty(dept))
                {
                    MsgBox_AQ.RJMessageBox.Show("Chưa chọn bộ phận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                RequestData(dept);
                //BackgroundLoading.PerformTask(RequestData, dept);      
            }
            catch (Exception)
            {
               return;
            }

        }

        private void RequestData(string dept)
        {
            try
            {
                DataTable datatable = InitDatatable();

                datatable = StatisticOvertimeHelper.GetDataOverTime(datatable, dept, Common.UserLogin.TypeUser, Common.UserLogin.Dept.Split('|').ToArray(), DateTime.Now.Date);
                this.BeginInvoke(new Action(() =>
                {
                    dgv.DataSource = datatable;
                    dgv.Rows[4].Frozen = true;
                    // tô màu T7, CN
                    for (int columnIndex = 0; columnIndex < dgv.Columns.Count; columnIndex++)
                    {
                        if (dgv.Rows[4].Cells[columnIndex].Value != null && dgv.Rows[4].Cells[columnIndex].Value.ToString().Contains("Sat"))
                        {
                            for (int rowIndex = 5; rowIndex < dgv.Rows.Count; rowIndex++)
                            {
                                dgv.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.FromArgb(217, 217, 217);
                            }
                        }
                        if (dgv.Rows[4].Cells[columnIndex].Value != null && dgv.Rows[4].Cells[columnIndex].Value.ToString().Contains("Sun"))
                        {
                            for (int rowIndex = 5; rowIndex < dgv.Rows.Count; rowIndex++)
                            {
                                dgv.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.FromArgb(227, 62, 48);
                            }
                        }
                    }                    
                }));
                this.BeginInvoke((Action)(() =>
                {
                    if (dgv.RowCount > 5)
                    {
                        for (int row = 5; row < dgv.Rows.Count; row++)
                        {
                            dgv.Rows[row].Height = 27;
                            dgv.Rows[row].DefaultCellStyle.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                        }
                    }
                }));
            }
            catch (Exception)
            {
                throw;
            }      
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string dept = cbbDept.SelectedItem as string;
            if (dept != null)
            {
                if(dept == "ALL")
                {
                    if (Common.UserLogin.TypeUser == "Salary")
                    {
                        dept = "ALL";
                    }
                    else
                    {
                        dept = Common.UserLogin.Dept;
                    }                 
                }                
            } 
            if(dgv.RowCount > 5)
            {
                if (StatisticOvertimeHelper.ExportData(dgv, dept))
                {
                    MsgBox_AQ.RJMessageBox.Show("Đã xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
