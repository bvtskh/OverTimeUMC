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
    public partial class FormUser : Form
    {
        private List<User> lstUser = new List<User>();
        public FormUser()
        {
            InitializeComponent();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            LoadDepttoCombobox();
        }


        private void LoadDepttoCombobox()
        {
            using (var ct = new ContextUser())
            {
                lstUser = ct.Users.ToList();
                var lstDept = lstUser.GroupBy(x => new { x.Dept }).Select(x => new
                {
                    Dept = x.Key.Dept,
                }).ToList();
                cbbDept.Items.Clear();
                foreach (var item in lstDept)
                {
                    cbbDept.Items.Add(item.Dept);
                }
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lstSearch = lstUser.Where(x => x.Code.Contains(txtUser.Text) || x.FullName.ToUpper().Contains(txtUser.Text.ToUpper())).ToList();
                List<string> lstInfo = new List<string>();
                foreach (var item in lstSearch)
                {
                    string s = string.Format("{0}_{1}_{2}", item.Code, item.FullName,item.Dept);
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

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUser.Text = cboUser.Text;
            LoadInfoUserToFormDesign();
        }

        private void cboUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadInfoUserToFormDesign();
            }
        }


        private void LoadInfoUserToFormDesign()
        {
            string info = cboUser.SelectedItem.ToString();
            string[] s = info.Split('_').ToArray();
            string Code = s[0];
            var findItem = lstUser.FirstOrDefault(x => x.Code == Code);
            txtCode.Text = findItem.Code;
            txtFullName.Text = findItem.FullName;
            txtDept.Text = findItem.Dept;
            txtEmails.Text = findItem.Email;
            using (var db = new DBContext())
            {
                var findRole = db.Tbl_User.FirstOrDefault(x => x.UserCode == Code);
                if (findRole != null)
                {
                    cbbRole.Text = findRole.Role;
                }
                else
                {
                    cbbRole.SelectedIndex = 0;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                var findUser = db.Tbl_User.FirstOrDefault(x => x.UserCode == txtCode.Text);
                if(findUser != null)
                {
                    findUser.Dept = txtDept.Text;
                    findUser.Email = txtEmails.Text;
                    findUser.Role = cbbRole.Text;
                    db.Entry<Tbl_User>(findUser).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    Tbl_User u = new Tbl_User();
                    u.UserCode = txtCode.Text.TrimStart('0');
                    u.Password = "umcvn";
                    u.FullName = txtFullName.Text;
                    u.Dept = txtDept.Text;
                    u.Email = txtEmails.Text;
                    u.Role = cbbRole.Text;
                    db.Tbl_User.Add(u);
                }
                db.SaveChanges();
                MessageBox.Show("Update Success", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbDept_SelectedIndexChanged(null, null);
            }
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new DBContext())
            {
                var lstSearch = db.Tbl_User.Where(x => x.Dept == cbbDept.Text).ToList();
                dgvUser.DataSource = null;
                dgvUser.DataSource = lstSearch;
                EditViewDgvUser();
                dgvUser.Refresh();
            }
        }

        private void EditViewDgvUser()
        {
            dgvUser.Columns["Id"].Width = 40;
            dgvUser.Columns["UserCode"].Width = 70;
            dgvUser.Columns["Dept"].Width = 60;
            dgvUser.Columns["Role"].Width = 60;
            dgvUser.Columns["Email"].Width = 160;
            dgvUser.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            else
            {
                txtCode.Text = dgvUser.Rows[e.RowIndex].Cells["UserCode"].Value.ToString();
                txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtDept.Text = dgvUser.Rows[e.RowIndex].Cells["Dept"].Value.ToString();
                txtEmails.Text = dgvUser.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cbbRole.Text = dgvUser.Rows[e.RowIndex].Cells["Role"].Value.ToString();
            }
        }
    }
}
