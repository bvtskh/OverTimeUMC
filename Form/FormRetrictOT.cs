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
    public partial class FormRetrictOT : Form
    {
        private List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstUser = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();
        private List<Tbl_RestrictOT> lstRetrictFromExcel = new List<Tbl_RestrictOT>();
        public FormRetrictOT()
        {
            InitializeComponent();
        }

        private void FormRetrictOT_Load(object sender, EventArgs e)
        {
            int Year = DateTime.Now.Year;
            int Month = DateTime.Now.Month;

            lstUser = PI_Lib.MankichiHelper.GetAllStaffWorking();
            
            LoadListRetrictOT();
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

        private void cboUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUser.Text = cboUser.Text;
                LoadDataToFormDesign();
            }
        }

        private void LoadDataToFormDesign()
        {
            string[] s = cboUser.Text.Split('_').ToArray();
            txtCode.Text = s[0];
            txtFullName.Text = s[1];
            txtDept.Text = s[2]; 
        }

        private void LoadListRetrictOT()
        {
            using (var db = new DBContext())
            {
                var lstRetrict = db.Tbl_RestrictOT.Where(w=>w.Code!=null).ToList();
                dgvRetrict.DataSource = null;
                dgvRetrict.DataSource = lstRetrict;
                lblRow.Text = lstRetrict.Count() + " rows";
                EditViewDgv();
                dgvRetrict.Refresh();
            }
        }

        private void EditViewDgv()
        {
            dgvRetrict.Columns["Id"].Visible = false;
            dgvRetrict.Columns["Code"].Width = 80;
            dgvRetrict.Columns["Name"].Width = 220;
            dgvRetrict.Columns["Dept"].Width = 100;
            dgvRetrict.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRetrict.Columns["DateLimit"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvRetrict.Columns["DateLimit"].Width = 100;
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbReason.Text.Contains("Hạn chế tăng ca đến ngày"))
            {
                label2.Visible = dateTimePicker1.Visible = true;
            }
            else
            {
                label2.Visible = dateTimePicker1.Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCode.Text))
            {
                using (var db = new DBContext())
                {
                    var findUser = db.Tbl_RestrictOT.FirstOrDefault(x => x.Code == txtCode.Text);
                    if(findUser!= null)
                    {
                        findUser.Reason = cbbReason.Text;
                        if(cbbReason.Text.Contains("Hạn chế tăng ca đến ngày"))
                        {
                            findUser.DateLimit = dateTimePicker1.Value.Date;
                        }
                        else
                        {
                            findUser.DateLimit = null;
                        }
                        db.Entry<Tbl_RestrictOT>(findUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Save Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(findUser == null)
                    {
                        Tbl_RestrictOT r = new Tbl_RestrictOT();
                        r.Code = txtCode.Text;
                        r.Name = txtFullName.Text;
                        r.Dept = txtDept.Text;
                        r.Reason = cbbReason.Text;
                        if (cbbReason.Text.Contains("Hạn chế tăng ca đến ngày"))
                        {
                            r.DateLimit = dateTimePicker1.Value.Date;
                        }
                        db.Tbl_RestrictOT.Add(r);
                        db.SaveChanges();
                        MessageBox.Show("Save Success!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadListRetrictOT();
            }
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtCode.Text = dgvRetrict.Rows[e.RowIndex].Cells["Code"].Value.ToString();
            txtFullName.Text = dgvRetrict.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtDept.Text = dgvRetrict.Rows[e.RowIndex].Cells["Dept"].Value.ToString();
            cbbReason.Text = dgvRetrict.Rows[e.RowIndex].Cells["Reason"].Value.ToString();
            if(dgvRetrict.Rows[e.RowIndex].Cells["DateLimit"].Value != null)
            {
                label2.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker1.Value = Convert.ToDateTime(dgvRetrict.Rows[e.RowIndex].Cells["DateLimit"].Value.ToString());
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                lstRetrictFromExcel = ExcelFileProcess.GetListRetrictOTFromExcel(FileDlg.FileName);
                dgvRetrict.DataSource = null;
                dgvRetrict.DataSource = lstRetrictFromExcel;
                EditViewDgv();
                dgvRetrict.Refresh();
                if (lstRetrictFromExcel.Count > 0)
                {
                    btnSaveTimeINOUT.Enabled = true;
                }
                else { btnSaveTimeINOUT.Enabled = false; }
            }
        }

        private void btnSaveTimeINOUT_Click(object sender, EventArgs e)
        {
            if(lstRetrictFromExcel.Count > 0)
            {
                using (var db = new DBContext())
                {
                    var lstDel = db.Tbl_RestrictOT.ToList();
                    db.Tbl_RestrictOT.RemoveRange(lstDel);
                    db.Tbl_RestrictOT.AddRange(lstRetrictFromExcel);
                    db.SaveChanges();
                    MessageBox.Show("Save Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void cboUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtUser.Text = cboUser.Text;
            LoadDataToFormDesign();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
