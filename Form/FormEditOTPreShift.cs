using OverTime.Business;
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
    public partial class FormEditOTPreShift : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstUser = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        public FormEditOTPreShift()
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
            int MonthPresent = DateTime.Now.Month;
            for (int i = MonthPresent; i <= 12; i++)
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
            else { cboMonth.SelectedValue = (curMont).ToString(); }

        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lstSearch = lstUser.Where(x => x.AltCode.Contains(txtUser.Text) || x.Name.ToUpper().Contains(txtUser.Text.ToUpper())).ToList();
                List<string> lstInfo = new List<string>();
                foreach (var item in lstSearch)
                {
                    string s = string.Format("{0}_{1}_{2}", item.AltCode, item.Name, item.Dept);
                    lstInfo.Add(s);
                }
                cboUser.DroppedDown = false;
                cboUser.Items.Clear();
                cboUser.Items.AddRange(lstInfo.ToArray());
                cboUser.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else if (e.KeyCode == Keys.Down)
            {
                cboUser.Focus();
                cboUser.SelectedIndex = 0;
            }
        }

        private void FormEditOTPreShift_Load(object sender, EventArgs e)
        {
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;
            lstUser = GAMankuchiAll.Instance()._listAllStaff;
        }

        private void CheckAndLoadDataToDgv()
        {
            string[] s = cboUser.Text.Split('_').ToArray();
            int Month = Convert.ToInt16(cboMonth.Text);
            int Year = Convert.ToInt16(cboYear.Text);
            string Code = s[0];
            string FullName = s[1];
            dgvOTPreShift.Rows.Clear();
            using (var db = new DBContext())
            {
                var findUserOTPreShift = db.Tbl_OTBeforeShift.FirstOrDefault(x => x.Code == Code && x.MonthOfYear.Value.Month == Month && x.MonthOfYear.Value.Year == Year);
                if(findUserOTPreShift != null)
                {
                    for(int i = 0; i< DateTime.DaysInMonth(Year,Month); i++)
                    {
                        dgvOTPreShift.Rows.Add(findUserOTPreShift.Code, findUserOTPreShift.Name, i + 1, "0");
                    }
                    var value = findUserOTPreShift.RegisOverTime.Split('|');
                    for(int j = 0; j < value.Length; j++ )
                    {
                        var val = "O";
                        if (value[j] == "O")
                            val = "O";
                        else if (value[j] == "")
                            val = "X";
                        dgvOTPreShift.Rows[j].Cells["Regis"].Value = val;
                    }
                }
                if(findUserOTPreShift ==  null)
                {
                    string mes = string.Format("Nhân viên có mã Code:{0}\nTên:{1}\nChưa đăng ký tăng ca trước giờ\nBấm Yes để đăng ký mới\nBấm No đển hủy bỏ",Code, FullName);
                    DialogResult dlr = MessageBox.Show(mes, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    dgvOTPreShift.Rows.Clear();
                    if(dlr == DialogResult.Yes)
                    {
                        for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
                        {
                            dgvOTPreShift.Rows.Add(Code, FullName, i + 1, "O");
                        }
                        for (int j = 0; j < DateTime.DaysInMonth(Year, Month); j++)
                        {
                            dgvOTPreShift.Rows[j].Cells["Regis"].Value = "X";
                        }
                    }

                }
            }
        }

        private void cboUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtUser.Text = cboUser.Text;
                CheckAndLoadDataToDgv();
            }
            
        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUser.Text = cboUser.Text;
            //CheckAndLoadDataToDgv();
        }

        private void cboUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CheckAndLoadDataToDgv();
        }

        private void btnSaveTimeINOUT_Click(object sender, EventArgs e)
        {
            var value = string.Empty;
            var detailOper = string.Empty;
            string Code;
            Code = dgvOTPreShift.Rows[0].Cells["Code"].Value.ToString();
            var FullName = dgvOTPreShift.Rows[0].Cells["FullName"].Value.ToString();
            foreach (DataGridViewRow r in dgvOTPreShift.Rows)
            {
                
                var luachon = r.Cells["Regis"].Value.ToString();
                if (luachon == "X")
                { luachon = ""; }
                luachon += "|";
                value = string.Format("{0}{1}", value, luachon);
            }
            if (value.EndsWith("|"))
            { value = value.Remove(value.Length - 1, 1).Trim(); }
            int Month = Convert.ToInt16(cboMonth.Text);
            int Year = Convert.ToInt16(cboYear.Text);
            using (var db = new DBContext())
            {
                var findUserOTPreShift = db.Tbl_OTBeforeShift.FirstOrDefault(x => x.Code == Code && x.MonthOfYear.Value.Month == Month && x.MonthOfYear.Value.Year == Year);
                if(findUserOTPreShift != null)
                {
                    findUserOTPreShift.RegisOverTime = value;
                    db.Entry<Tbl_OTBeforeShift>(findUserOTPreShift).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Save Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(findUserOTPreShift == null)
                {
                    Tbl_OTBeforeShift otpre = new Tbl_OTBeforeShift();
                    otpre.MonthOfYear = new DateTime(Year, Month, 1, 0, 0, 0);
                    otpre.Code = Code;
                    otpre.Name = FullName;
                    otpre.RegisOverTime = value;
                    db.Tbl_OTBeforeShift.Add(otpre);
                    db.SaveChanges();
                    MessageBox.Show("Save Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void dgvOTPreShift_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == 3)
            {
                var cell = dgvOTPreShift.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewComboBoxCell)
                {
                    DataGridViewComboBoxCell cbx = cell as DataGridViewComboBoxCell;
                    if (cbx.Value.ToString() == "O")
                        cbx.Style.BackColor = Color.Lime;
                    else if (cbx.Value.ToString() == "X")
                        cbx.Style.BackColor = Color.Red;
                }
            }
        }


    }
}
