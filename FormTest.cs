using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OverTime.DataBase;
using PI_Lib.Entities;

namespace OverTime
{
    public partial class FormTest : Form
    {
        public List<Tbl_DailyOverTime> lstReadData = new List<Tbl_DailyOverTime>();
        public List<Tbl_DailyOverTime> lstWriteData = new List<Tbl_DailyOverTime>();
        public FormTest()
        {
            InitializeComponent();
        }

        public FormTest(string mes) : this()
        {

            textBox2.Text = mes;
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            var products = new Product[]{
            new Product(1,"PowerPoint",100),
            new Product(2,"Excel",100),
            new Product(3,"Photoshop",101),
            new Product(4,"Gmail",103)
            };

            var categories = new Category[]{
            new Category(100,"Microsoft"),
            new Category(101,"Adobe"),
            new Category(102,"Sun")
            };
            List<Product> lstpro = new List<Product>();
            List<Infomation> lstInfo = new List<Infomation>();
             lstInfo = (from c in categories
                          join p in products on c.CategoryID equals p.CategoryID
                          //into A
                          //from a in A.DefaultIfEmpty()
                              //where a == null
                          select new Infomation
                          {
                              ProductID = p.ProductID,
                              ProductName = p.ProductName,
                              CategoryID = p.CategoryID,
                              CategoryName = c.CategoryName,
                              //ProductName = p.ProductName,
                              //CategoryName = c.CategoryName,
                              //ProductID = p.ProductID,
                              //Infomation = new Infomation(p.ProductID, p.ProductName, p.CategoryID, c.CategoryName),
                          }).ToList();

            //foreach (var item in result)
            //{
            //    lstInfo.Add(item.Infomation);
            //}


            //lstpro = (from p in products
            //              join c in categories on p.CategoryID equals c.CategoryID into A
            //              from a in A.DefaultIfEmpty()
            //              where a == null
            //              select p).ToList();

            txtUser.Text = Common.UserLogin.UserName;
            txtPass.Text = Common.UserLogin.PassWord;
            txtDept.Text = Common.UserLogin.Dept;
            txtAction.Text = Common.UserLogin.Action;
            txtDeptApprove.Text = Common.DeptApprove;


        }

        private string GetRandomHistoryOT()
        {
            string res = string.Empty;
            Random r = new Random();
            for (int i = 1; i<= 15; i++)
            {
               
                int ot = r.Next(0, 4);
                res += i.ToString() + ":" + ot.ToString() + "|";
            }
            if(res.EndsWith("|"))
            {
                res = res.Remove(res.Length - 1, 1).Trim();
            }
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new DBContext())
            {
                DateTime dateSelect = DateTime.Now.Date;
                var listdaily = db.Tbl_DailyOverTime.Where(x => x.DateOverTime == dateSelect).ToList();
                if(listdaily.Count > 0)
                {
                    foreach (var item in listdaily)
                    {
                        item.Approve = null;
                        db.Entry<Tbl_DailyOverTime>(item).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                    MessageBox.Show("Success", "Thông Báo");
                }
            }      
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Common.DeptApprove = txtDeptApprove.Text;
            using (var db = new DBContext())
            {
                
                var lstSerach = db.Tbl_DailyOverTime.Where(x => x.DateOverTime.Year == 2023 && x.DateOverTime.Month == 10 && x.DateOverTime.Day == 5).ToList();
                if(lstSerach.Count > 0)
                {
                    lstSerach.All(c => { c.DateOverTime = dateTimePicker1.Value.Date; return true; });
                    lstSerach.ForEach(p => db.Entry(p).State = System.Data.Entity.EntityState.Modified);
                    db.SaveChanges();
                    MessageBox.Show("Save Success");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                var lstRegisted = db.Tbl_DailyOverTime.Where(x => x.DateOverTime.Month == 10 && (x.DateOverTime.Day == 2|| x.DateOverTime.Day == 3)).ToList();
                Common.RunProcess("LoadTitle.exe");
                lstRegisted.All(c => { c.Reason = "Trường hợp khẩn"; return true; });
                //lstRegisted.ForEach(p => db.Entry(p).State = System.Data.Entity.EntityState.Modified);
                foreach (var item in lstRegisted)
                {
                    item.Reason = "Theo Kế hoạch PC";
                    //db.Entry<Tbl_DailyOverTime>(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                Common.KillProcess("LoadTitle");
                MessageBox.Show("Save Success");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                var findList = db.Tbl_RestrictOT.ToList();
                foreach (var item in findList)
                {
                    item.Code = item.Code.PadLeft(5, '0');
                    db.Entry<Tbl_RestrictOT>(item).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                MessageBox.Show("Save Success");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rowId = dataGridView2.Rows.Add();
            DataGridViewRow row = dataGridView2.Rows[rowId];
            row.Cells["Col_Code"].Value = "30713";
            row.Cells["Col_Name"].Value = "Nguyễn Thanh Hải";
            row.Cells["Col_Register"].Value = 0;
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 2)
                textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["Col_Register"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView2.Rows[0].Cells["Col_Register"].Value.ToString();
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            using (var db = new DBContext())
            {
                var lstSummary = db.Tbl_SummaryOverTime.ToList();
                var lstMankichi = PI_Lib.MankichiHelper.GetAllStaff();
                var lstDirectnull = lstSummary.Where(x => x.Direct_InDirect == null).ToList();
                foreach (var item in lstDirectnull)
                {
                    //if(item.Direct_InDirect.Contains("Trực tiếp"))
                    //{
                    //    item.MaxOverTime = 30;
                    //}
                    //else { item.MaxOverTime = 25; }
                    //db.Entry<Tbl_SummaryOverTime>(item).State = System.Data.Entity.EntityState.Modified;
                    //db.SaveChanges();
                    var findItem = lstMankichi.FirstOrDefault(x => x.AltCode == item.Code);
                    if(findItem != null)
                    {
                        item.Direct_InDirect = findItem.Direct_Indirect;
                        db.Entry<Tbl_SummaryOverTime>(item).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Update Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
