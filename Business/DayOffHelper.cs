using CommonProject.Entities;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OverTime.Business.LogHelper;
using System.Windows.Forms;
using OverTime.DataBase;

namespace OverTime.Business
{
    internal class DayOffHelper
    {
        internal void UpdateDayOff()
        {
            try
            {
                SQLHelper.ConnectString(new GAConfig());
                using (SqlConnection connection = new SqlConnection(SQLHelper.CONNECTION_STRINGS))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand object for your stored procedure
                    using (SqlCommand command = new SqlCommand("DX_GetCurrentDayOffs", connection))
                    {
                        // Specify that the command is a stored procedure
                        command.CommandType = CommandType.StoredProcedure;
                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();

                        // Create a SqlDataAdapter to fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable with the results of the stored procedure
                            adapter.Fill(dataTable);
                        }
                        InsertDayOffs(dataTable);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InsertDayOffs(DataTable dataTable)
        {
            //if (DateTime.Now.Day == 28 || DateTime.Now.Day == 29 || DateTime.Now.Day == 30 || DateTime.Now.Day == 31
            //    || DateTime.Now.Day == 1 || DateTime.Now.Day == 2 || DateTime.Now.Day == 3) // những ngày này GA sẽ cập nhật lại ngày nghỉ
            //{
                List<DAYOFF> dayOffList = new List<DAYOFF>();
                using (var context = new DBContext())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DAYOFF dAYOFF = new DAYOFF();
                        string staffCode = row.Field<string>("StaffCode");
                        int month = row.Field<int>("mMonth");
                        int year = row.Field<int>("mYear");

                        var dataExist = context.DAYOFFs.Where(w => w.StaffCode == staffCode && w.Month == month && w.Year == year).FirstOrDefault();
                        if (dataExist != null)
                        {
                            dataExist.AnnualLeave = (double)row.Field<object>("Annual_Leave");
                            dataExist.SpecialLeave= (double)row.Field<object>("Special_Leave");
                            dataExist.CompanyHoliday = (int)row.Field<object>("Company_Holiday");
                            dataExist.NonPaidLeave = (double)row.Field<object>("Non_Paid_Leave");
                            dataExist.AccruedVacationDays = (double)row.Field<object>("Annual_Days");
                            dataExist.UpdateTime = DateTime.Now;
                            dataExist.HostName = Environment.MachineName;
                            context.Entry(dataExist).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            // chưa có thì thêm mới
                            dAYOFF.StaffCode = (string)row.Field<object>("StaffCode");
                            dAYOFF.FullName = (string)row.Field<object>("FullName");
                            dAYOFF.Dept = (string)row.Field<object>("DeptCode");
                            dAYOFF.Month = (int)row.Field<object>("mMonth");
                            dAYOFF.Year = (int)row.Field<object>("mYear");
                            dAYOFF.AnnualLeave = (double)row.Field<object>("Annual_Leave");
                            dAYOFF.SpecialLeave = (double)row.Field<object>("Special_Leave");
                            dAYOFF.CompanyHoliday = (int)row.Field<object>("Company_Holiday");
                            dAYOFF.NonPaidLeave = (double)row.Field<object>("Non_Paid_Leave");
                            dAYOFF.AccruedVacationDays = (double)row.Field<object>("Annual_Days");
                            dAYOFF.UpdateTime = DateTime.Now;
                            dAYOFF.HostName = Environment.MachineName;
                            dayOffList.Add(dAYOFF);
                        }
                    }
                    context.DAYOFFs.AddRange(dayOffList);
                    context.SaveChanges();
                }
            //}
        }

        private bool IsExistDayOff(DataRow row)
        {
            string staffCode = row.Field<string>("StaffCode");
            int month = row.Field<int>("mMonth");
            int year = row.Field<int>("mYear");
            using(var context = new DBContext())
            {
                var dataExist = context.DAYOFFs.Where(w=>w.StaffCode == staffCode && w.Month == month && w.Year == year).FirstOrDefault();
                if(dataExist !=null) return true;
                return false;
            }
        }
    }
}
