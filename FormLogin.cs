using CommonProject.MsgBox_AQ;
using OverTime.Business;
using OverTime.DataBase;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Input;
using Microsoft.Win32;
using Sunny.UI.Win32;

namespace OverTime
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Common.CheckVersions();
            var account = LoginHelper.GetAccountSaved();
            txtUser.Text = account.Key;
            txtPassword.Text = account.Value;
            if (!LoginHelper.CheckVersionSuccess())
            {
                RJMessageBox.Show($"Đã cập nhật phiên bản: {LoginHelper.GetCurrentVersion().Version}\nVui lòng truy cập : {LoginHelper.GetCurrentVersion().Path} để sử dụng phiên bản mới nhất!", "Thông báo cập nhật phiên bản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(1);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string user = txtUser.Text;
            string password = txtPassword.Text;
            var account = LoginHelper.GetAccout(user, password);
            if(account != null)
            { 
                LoginHelper.SaveChangeAccount(account,cbSaveAccount.Checked);
                this.Hide();
                Login(account);
            }
            else
            {
                UIMessageTip.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!");
                return;
            }
        }

        private void Login(Tbl_User account)
        {
            string param = account.UserCode+"|"+account.Password;
            FormMain formMain = new FormMain(param);
            formMain.ShowDialog();
            this.Close();
        }
        private void Login(string account)
        {           
            FormMain formMain = new FormMain(account);
            formMain.ShowDialog();
            this.Close();
        }
        bool isShow =false;
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if(!isShow)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
            isShow =!isShow;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnMinized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lbChangePassword_Click(object sender, EventArgs e)
        {
            panelFormChangePassword.Visible = !panelFormChangePassword.Visible;
        }

        private void btnConfirmChangePws_Click(object sender, EventArgs e)
        {
            var account = LoginHelper.GetAccout(txtAccontChangePws.Text,txtOldChangePws.Text);
            if(account == null) 
            {
                UIMessageTip.Show("Thông tin tài khoản hoặc mật khẩu không chính xác",TipStyle.Orange,1500);
                return;
            }
            if (LoginHelper.CheckPasswordChange(txtNewChangePws.Text) != null)
            {
                UIMessageTip.Show(LoginHelper.CheckPasswordChange(txtNewChangePws.Text),TipStyle.Red,1500);
                return;
            }
            else
            {
                if(LoginHelper.ChangePassword(account, txtNewChangePws.Text))
                {
                    UIMessageTip.Show("Tài khoản đã được thay đổi mật khẩu!", TipStyle.Green, 1500);
                    panelFormChangePassword.Controls.OfType<UITextBox>().ForEach(t => t.Text = null);
                    panelFormChangePassword.Visible = false;
                }
                else
                {
                    UIMessageTip.Show("Có lỗi xảy ra!", TipStyle.Red, 1500);
                }
            }
        }

        private void lbLoginReadOnly_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login("ReadOnly|umcvn");
        }

        private void EnterLogin(object sender,System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
