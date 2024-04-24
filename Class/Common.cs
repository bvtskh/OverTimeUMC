using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public class Common
    {

        public static Tbl_Version VersionInfo = new Tbl_Version();
        public static string PathAppRun;
        public static UserInfo UserLogin = new UserInfo();
        public static string DeptApprove;
        public static string DateApprove;
        public static string ReqNoAppr;
        public static bool flagWait = true;
        /* Kiểm tra kết nối server*/
        public static bool IsServerConnected(string host, int timeout_ms)
        {
            Ping p = new Ping();
            try
            {
                PingReply pr = p.Send(host, timeout_ms);
                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
        /* Chạy 1 chương trình exe khác*/
        public static void RunProcess(string runFileName)
        {
            string ExePath = Path.Combine(Application.StartupPath, runFileName);
            System.Diagnostics.Process.Start(ExePath);
        }
        /* Tắt 1 chương trình đang chạy*/
        public static void KillProcess(string processName)
        {
            try
            {
                System.Diagnostics.Process[] pros = System.Diagnostics.Process.GetProcessesByName((processName));
                foreach (System.Diagnostics.Process pro in pros) pro.Kill();
            }
            catch { }          
        }

        /*Check password*/
        private static string ShowMessage_Password(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            textBox.PasswordChar = '*';
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK) return textBox.Text;
            else return "";
        }
        public static bool CheckPassword(string Password, string comment)
        {
            bool result = false;

            if (Common.ShowMessage_Password("Login", comment) == Password) result = true;
            else
            {
                MessageBox.Show("Password is Wrong! Pls input again", "Error");
                result = false;
            }
            return result;
        }

        //Open file ảnh tránh (xung đột)//
        public static Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }


        public static void CheckVersions(string version)
        {
            Task.Run(new Action(() =>
            {
                using (var ctx = new DBContext())
                {
                    var vers = ctx.Tbl_Version.ToList();
                    VersionInfo = vers.LastOrDefault();
                    PathAppRun = string.Format(VersionInfo.Path, VersionInfo.Version);
                    //MessageBox.Show("Check Version Info", "Thông Báo");
                    if (VersionInfo == null) return;
                    if (VersionInfo.Version != version)
                    {
                        string msg = string.Format("Đã lên version {0}. Hãy vào đường dẫn  {1}", VersionInfo.Version, PathAppRun);
                        MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();
                        return;
                    }
                }
            }));
        }

        public static string GetContentFromDataGrid(DataGridView dgr)
        {
            //Table start.
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 11pt'>";

            //Adding HeaderRow.
            html += "<tr>";
            foreach (DataGridViewColumn column in dgr.Columns)
            {
                var colName = column.HeaderText;
                if (colName == "Model")
                    html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc;font-size: 12pt' width = '40%'><b>" + colName + "</b></th>";
                else
                    html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc;font-size: 12pt'><b>" + colName + "</b></th>";
            }
            html += "</tr>";

            //Adding DataRow.
            foreach (DataGridViewRow row in dgr.Rows)
            {
                if (!row.Visible)
                    continue;
                html += "<tr>";
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    var cell = row.Cells[i];
                    if(i == 0)
                    {
                        html += "<td style='width:120px;border: 1px solid #ccc;text-align: left'>" + cell.Value + "</td>";
                    }
                    else
                    {
                        html += "<td style='width:360px;border: 1px solid #ccc;text-align: left'>" + cell.Value + "</td>";
                    }
                    
                }
                html += "</tr>";
            }

            //Table end.
            html += "</table>";
            return html;
        }
    }


    public class TimeInOut
    {
        public DateTime Date { get;  set;}
        public string Code { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public double OTDayShift { get; set; }
        public double AdjustOTDayShift { get; set; }
        public double OTNightShift { get; set; }
        public double AdjustOTNightShift { get; set; }
        public double TimeFinger { get; set; }
        public double OTPreShift { get; set; }
        public double TotalOT { get; set; }
        public string ShiftCode { get; set; }//CaLV
    }
    public class Product
    {
        public int ProductID;
        public string ProductName;
        public int CategoryID;

        public Product(int id, string name, int categoryId)
        {
            this.ProductID = id;
            this.ProductName = name;
            this.CategoryID = categoryId;
        }
    }
    public class Category
    {
        public int CategoryID;
        public string CategoryName;

        public Category(int id, string name)
        {
            this.CategoryID = id;
            this.CategoryName = name;
        }
    }

    public class Infomation
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        //public Infomation(int id, string name, int categoryId, string categoryName)
        //{
        //    this.ProductID = id;
        //    this.ProductName = name;
        //    this.CategoryID = categoryId;
        //    this.CategoryName = categoryName;
        //}
    }

    public class NameButton
    {
        public string Tag { get; set; }
        public string Text { get; set; }
    }
    public class AdjustOverTime
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Dept { get; set; }
        public string Position { get; set; }
        public string Direct { get; set; }
        public string Customer { get; set; }
        public string Line { get; set; }
        public string Shift { get; set; }
        public string Process { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public double TimeOTPreShift { get; set; }
        public double TimeFinger { get; set; }
        public double TotalOT { get; set; }
        public double RegisOT { get; set; }
        public double TimeDept { get; set; }
        public double Balance { get; set; }
        public string Comment { get; set; }
        public double Accumulated { get; set; }
    }
}
