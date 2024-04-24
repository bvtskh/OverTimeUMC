using CommonProject.Entities;
using FontAwesome.Sharp;
using NPOI.SS.Formula.Functions;
using OverTime.Business;
using PI_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OverTime.Business.LogHelper;

namespace OverTime
{
    public partial class FormPreferentialDaysOff : Form
    {
        public FormPreferentialDaysOff()
        {
            InitializeComponent();
        }

        private void FormPreferentialDaysOff_Load(object sender, EventArgs e)
        {
            //var deptList = MankichiHelper.GetAllStaffWorking().Select(s=>s.Dept).Distinct().ToList();
            //if(deptList.Count > 0)
            //{
            //    cbDept.Items.AddRange(deptList.ToArray());
            //    cbDept.SelectedIndex =0;
            //}
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            if (ArrDept.Length > 0)
            {
                foreach (var item in ArrDept)
                {
                    cbDept.Items.Add(item);
                }
                cbDept.SelectedIndex = 0;
            }
           
            
            lbDate.Text = $"Tháng: {DateTime.Now.Month} - Năm: {DateTime.Now.Year}";
            try
            {
                SQLHelper.ConnectString(new OvertimeConfig());
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        private void ShowData(string conn, string staffcode, string dept)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object for your stored procedure
                    using (SqlCommand command = new SqlCommand("GetDayOff", connection))
                    {
                        // Specify that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the stored procedure
                        if (string.IsNullOrEmpty(dept)) { dept = null;}
                        if (string.IsNullOrEmpty(staffcode)) { staffcode = null; }
                        command.Parameters.AddWithValue("staffCode", staffcode);
                        command.Parameters.AddWithValue("@dept", dept);

                        // Execute the command (you can use ExecuteNonQuery, ExecuteScalar, ExecuteReader based on your requirement)
                        //command.ExecuteNonQuery();
                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable with the results of the stored procedure
                            adapter.Fill(dataTable);
                        }
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                LogHelper.GetDataLog("FormPreferentialDaysOff", ModuleLog.FindDaysOff, txtStaffCode.Text, cbDept.Text);
            }
            catch (SqlException)
            {
                MessageBox.Show("Truy vấn quá lâu, vui lòng chọn mã nhân viên, phòng ban cụ thể hơn!", "Hết thời gian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dept = cbDept.Text;
            string code = txtStaffCode.Text;
            if(string.IsNullOrEmpty(dept))
            {
                MessageBox.Show("Vui lòng chọn bộ phận");
                return;
            }
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            if (!ArrDept.Contains(cbDept.Text))
            {
                MessageBox.Show("Bạn chỉ có thể tìm kiếm bộ phận do phòng ban quản lý!"); return;
            }
            ShowData(SQLHelper.CONNECTION_STRINGS, code, dept);          
        }

        private void txtStaffCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ShowData(SQLHelper.CONNECTION_STRINGS, txtStaffCode.Text, cbDept.Text);
            }
        }

        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
