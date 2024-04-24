using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormBudgetOT : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanInfo = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        public FormBudgetOT()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            int curYear = DateTime.Now.Year;
            int curMont = DateTime.Now.Month;
            var lstYear = new List<ComboboxInfo>();
            for (int i = curYear - 1; i < curYear + 2; i++)
            {
                lstYear.Add(new ComboboxInfo { Text = i.ToString(), Value = i.ToString() });
            }

            cboYear.DisplayMember = "Text";
            cboYear.ValueMember = "Value";
            cboYear.DataSource = lstYear;
            cboYear.SelectedValue = curYear.ToString();

            var lstMonth = new List<ComboboxInfo>();
            for (int i = 1; i <= 12; i++)
            {
                lstMonth.Add(new ComboboxInfo { Text = i.ToString(), Value = i.ToString() });
            }
            cboMonth.DisplayMember = "Text";
            cboMonth.ValueMember = "Value";
            cboMonth.DataSource = lstMonth;
            if (curMont == 12)
            {
                cboYear.SelectedValue = (curYear + 1).ToString();
                cboMonth.SelectedValue = "1";
            }
            else { cboMonth.SelectedValue = (curMont + 1).ToString(); }

        }


        private void LoadInfoMasterData()
        {
            using (DBContext db = new DBContext())
            {
                lstHumanInfo = PI_Lib.MankichiHelper.GetAllStaffWorking();
                //var lstMankichi = ct.Tbl_Mankichi.Where(x => x.CaLV != null).ToList();
                // Add Department
                var lstDept = lstHumanInfo.GroupBy(x => new { x.Dept }).Select(x => new
                {
                    Dept = x.Key.Dept,
                }).ToList();
                foreach (var item in lstDept)
                {
                    cboDept.Items.Add(item.Dept);
                    //if (item.Dept.Contains("PD"))
                    //{
                    //    cboDept.Items.Add(item.Dept);
                    //}  
                }
            }
        }

        private void FormBudgetOT_Load(object sender, EventArgs e)
        {
            LoadInfoMasterData();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            month = Convert.ToInt16(cboMonth.Text);
            year = Convert.ToInt16(cboYear.Text);
            double TotalOT = 0;
            DateTime dateBudget = new DateTime(year, month, 1, 0, 0, 0);
            var lstDept = lstHumanInfo.Where(x => x.Dept == cboDept.Text && !string.IsNullOrEmpty(x.Dept)).ToList();
            var lstCustomer = lstDept.GroupBy(x => new { x.Dept, x.Customer }).Select(x => new
            {
                Dept = x.Key.Dept,
                Customer = x.Key.Customer,
            }).ToList();
            dgvAddBudget.Rows.Clear();
            using (var db = new DBContext())
            {
                var lstBudget = db.Tbl_BudgetOT.Where(x => x.MonthBudget == dateBudget).ToList();
                foreach (var item in lstCustomer)
                {
                    if (!string.IsNullOrEmpty(item.Customer))
                    {
                        int rowID = dgvAddBudget.Rows.Add();
                        DataGridViewRow row = dgvAddBudget.Rows[rowID];
                        row.Cells["Col_Dept"].Value = item.Dept;
                        row.Cells["Col_Customer"].Value = item.Customer;
                        var NumHuman = lstDept.Where(x => x.Customer == item.Customer).ToList().Count;
                        row.Cells["col_NumHuman"].Value = NumHuman;
                        var findBudgetOT = lstBudget.FirstOrDefault(x => x.Dept == item.Dept && x.Customer == item.Customer);
                        if(findBudgetOT != null)
                        {
                            row.Cells["Col_BudgetOT"].Value = findBudgetOT.BudgetOT.ToString();
                            double TimePerHuman = (double)findBudgetOT.BudgetOT / NumHuman;
                            TimePerHuman = Math.Round(TimePerHuman, 2);
                            row.Cells["col_Trungbinh"].Value = TimePerHuman.ToString();
                            TotalOT += (double)findBudgetOT.BudgetOT;
                        }
                    }
                }
                lbTotalOT.Text = TotalOT.ToString();
            }
                
        }

        private void dgvAddBudget_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dgvAddBudget.CurrentCell;
            DataGridViewRow curRow = dgvAddBudget.CurrentRow;
            if (curCell.ColumnIndex == 3)
            {
                string mainStr = dgvAddBudget.CurrentCell.Value.ToString();
                for (int scan = 0; scan < mainStr.Length; scan++)
                {
                    if (Char.IsDigit(mainStr[scan]) || mainStr[scan] == '.')
                    {
                        CalculatorTotalTimeOTBudget();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ được nhập số, và phải >= 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvAddBudget.CurrentCell.Value = null;
                        dgvAddBudget.ClearSelection();
                        dgvAddBudget.CurrentCell = curCell;
                        dgvAddBudget.CurrentCell.Selected = true;
                        break;
                    }
                }
            }
        }


        private void CalculatorTotalTimeOTBudget()
        {
            double TotalAmount = 0;
            foreach (DataGridViewRow r in dgvAddBudget.Rows)
            {
                if (r.Cells["Col_BudgetOT"].Value != null && r.Cells["col_NumHuman"].Value.ToString()!= null)
                {
                    double TotalOT = Convert.ToDouble(r.Cells["Col_BudgetOT"].Value.ToString());
                    double NumberHuman = Convert.ToDouble(r.Cells["col_NumHuman"].Value.ToString());
                    double TimePerHuman = Math.Round(TotalOT / NumberHuman, 2);
                    TotalAmount += TotalOT;
                    r.Cells["col_Trungbinh"].Value = TimePerHuman;
                    lbTotalOT.Text = TotalAmount.ToString();
                }
            }
        }

        private void btnSaveBudget_Click(object sender, EventArgs e)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            DateTime dateBudget = new DateTime(year, month, 1, 0, 0, 0);
            using (var db = new DBContext())
            {
                var lstBudget = db.Tbl_BudgetOT.Where(x => x.MonthBudget == dateBudget).ToList();
                foreach(DataGridViewRow r in dgvAddBudget.Rows)
                {
                    Tbl_BudgetOT b = new Tbl_BudgetOT();
                    b.MonthBudget = dateBudget;
                    b.Dept = r.Cells["col_Dept"].Value.ToString();
                    b.Customer = r.Cells["Col_Customer"].Value.ToString();
                    if(r.Cells["Col_BudgetOT"].Value != null)
                    {
                        b.BudgetOT = Convert.ToDouble(r.Cells["Col_BudgetOT"].Value.ToString());
                    }
                    var findBudget = lstBudget.FirstOrDefault(x => x.Dept == b.Dept && x.Customer == b.Customer);
                    if(findBudget != null)
                    {
                        findBudget.BudgetOT = b.BudgetOT;
                        db.Entry<Tbl_BudgetOT>(findBudget).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Tbl_BudgetOT.Add(b);
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Save Success","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cboMonth.Text) && !string.IsNullOrEmpty(cboDept.Text))
            {
                cboDept_SelectedIndexChanged(null, null);
            }
        }
    }


    public class ComboboxInfo
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

}
