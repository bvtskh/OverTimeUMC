namespace OverTime
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.btnShowPassword = new Sunny.UI.UISymbolButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbChangePassword = new Sunny.UI.UISymbolLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLoginReadOnly = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSaveAccount = new Sunny.UI.UICheckBox();
            this.uiSymbolButton6 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton7 = new Sunny.UI.UISymbolButton();
            this.btnLogin = new Sunny.UI.UISymbolButton();
            this.txtUser = new Sunny.UI.UITextBox();
            this.txtPassword = new Sunny.UI.UITextBox();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.btnMinized = new Sunny.UI.UISymbolButton();
            this.panelFormChangePassword = new System.Windows.Forms.Panel();
            this.btnConfirmChangePws = new Sunny.UI.UIButton();
            this.txtNewChangePws = new Sunny.UI.UITextBox();
            this.txtOldChangePws = new Sunny.UI.UITextBox();
            this.txtAccontChangePws = new Sunny.UI.UITextBox();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFormChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiPanel1, "uiPanel1");
            this.uiPanel1.Controls.Add(this.btnShowPassword);
            this.uiPanel1.Controls.Add(this.pictureBox1);
            this.uiPanel1.Controls.Add(this.label3);
            this.uiPanel1.Controls.Add(this.lbChangePassword);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.lbLoginReadOnly);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Controls.Add(this.cbSaveAccount);
            this.uiPanel1.Controls.Add(this.uiSymbolButton6);
            this.uiPanel1.Controls.Add(this.uiSymbolButton7);
            this.uiPanel1.Controls.Add(this.btnLogin);
            this.uiPanel1.Controls.Add(this.txtUser);
            this.uiPanel1.Controls.Add(this.txtPassword);
            this.uiPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.uiPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.uiPanel1.FillDisableColor = System.Drawing.Color.Transparent;
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 25;
            this.uiPanel1.RectColor = System.Drawing.Color.DarkGray;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassword.FillColor = System.Drawing.Color.White;
            this.btnShowPassword.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnShowPassword, "btnShowPassword");
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Radius = 15;
            this.btnShowPassword.RectColor = System.Drawing.Color.Transparent;
            this.btnShowPassword.Symbol = 558391;
            this.btnShowPassword.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowPassword.SymbolHoverColor = System.Drawing.Color.Silver;
            this.btnShowPassword.TabStop = false;
            this.btnShowPassword.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            this.btnShowPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterLogin);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Name = "label3";
            // 
            // lbChangePassword
            // 
            this.lbChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lbChangePassword, "lbChangePassword");
            this.lbChangePassword.Name = "lbChangePassword";
            this.lbChangePassword.Symbol = 362193;
            this.lbChangePassword.SymbolColor = System.Drawing.Color.Black;
            this.lbChangePassword.SymbolSize = 20;
            this.lbChangePassword.TabStop = false;
            this.lbChangePassword.Click += new System.EventHandler(this.lbChangePassword_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbLoginReadOnly
            // 
            resources.ApplyResources(this.lbLoginReadOnly, "lbLoginReadOnly");
            this.lbLoginReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.lbLoginReadOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLoginReadOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbLoginReadOnly.Name = "lbLoginReadOnly";
            this.lbLoginReadOnly.Click += new System.EventHandler(this.lbLoginReadOnly_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbSaveAccount
            // 
            this.cbSaveAccount.CheckBoxColor = System.Drawing.Color.Black;
            this.cbSaveAccount.Checked = true;
            this.cbSaveAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.cbSaveAccount, "cbSaveAccount");
            this.cbSaveAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cbSaveAccount.Name = "cbSaveAccount";
            this.cbSaveAccount.TabStop = false;
            this.cbSaveAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterLogin);
            // 
            // uiSymbolButton6
            // 
            this.uiSymbolButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton6.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiSymbolButton6, "uiSymbolButton6");
            this.uiSymbolButton6.Name = "uiSymbolButton6";
            this.uiSymbolButton6.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton6.Symbol = 61849;
            this.uiSymbolButton6.SymbolColor = System.Drawing.SystemColors.Highlight;
            this.uiSymbolButton6.SymbolSize = 28;
            this.uiSymbolButton6.TabStop = false;
            this.uiSymbolButton6.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton7
            // 
            this.uiSymbolButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton7.FillColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiSymbolButton7, "uiSymbolButton7");
            this.uiSymbolButton7.Name = "uiSymbolButton7";
            this.uiSymbolButton7.RectColor = System.Drawing.Color.Transparent;
            this.uiSymbolButton7.Symbol = 61592;
            this.uiSymbolButton7.SymbolColor = System.Drawing.SystemColors.Highlight;
            this.uiSymbolButton7.SymbolSize = 28;
            this.uiSymbolButton7.TabStop = false;
            this.uiSymbolButton7.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FillColor = System.Drawing.SystemColors.WindowText;
            this.btnLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLogin.FillHoverColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 15;
            this.btnLogin.RectColor = System.Drawing.Color.Transparent;
            this.btnLogin.Symbol = 0;
            this.btnLogin.TabStop = false;
            this.btnLogin.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.Name = "txtUser";
            this.txtUser.Radius = 15;
            this.txtUser.RectColor = System.Drawing.Color.Transparent;
            this.txtUser.ShowText = false;
            this.txtUser.Symbol = 62142;
            this.txtUser.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUser.Watermark = "Tài khoản";
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterLogin);
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Radius = 15;
            this.txtPassword.RadiusSides = ((Sunny.UI.UICornerRadiusSides)((Sunny.UI.UICornerRadiusSides.LeftTop | Sunny.UI.UICornerRadiusSides.LeftBottom)));
            this.txtPassword.RectColor = System.Drawing.Color.Transparent;
            this.txtPassword.ShowText = false;
            this.txtPassword.Symbol = 61475;
            this.txtPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPassword.Watermark = "Mật khẩu";
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterLogin);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.FillColor2 = System.Drawing.Color.Transparent;
            this.btnClose.Name = "btnClose";
            this.btnClose.RectColor = System.Drawing.Color.Transparent;
            this.btnClose.Symbol = 61453;
            this.btnClose.SymbolColor = System.Drawing.Color.Red;
            this.btnClose.SymbolSize = 32;
            this.btnClose.TabStop = false;
            this.btnClose.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinized
            // 
            resources.ApplyResources(this.btnMinized, "btnMinized");
            this.btnMinized.BackColor = System.Drawing.Color.Transparent;
            this.btnMinized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinized.FillColor = System.Drawing.Color.Transparent;
            this.btnMinized.FillColor2 = System.Drawing.Color.Transparent;
            this.btnMinized.Name = "btnMinized";
            this.btnMinized.RectColor = System.Drawing.Color.Transparent;
            this.btnMinized.Symbol = 61544;
            this.btnMinized.SymbolSize = 32;
            this.btnMinized.TabStop = false;
            this.btnMinized.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnMinized.Click += new System.EventHandler(this.btnMinized_Click);
            // 
            // panelFormChangePassword
            // 
            this.panelFormChangePassword.BackColor = System.Drawing.Color.Transparent;
            this.panelFormChangePassword.Controls.Add(this.btnConfirmChangePws);
            this.panelFormChangePassword.Controls.Add(this.txtNewChangePws);
            this.panelFormChangePassword.Controls.Add(this.txtOldChangePws);
            this.panelFormChangePassword.Controls.Add(this.txtAccontChangePws);
            resources.ApplyResources(this.panelFormChangePassword, "panelFormChangePassword");
            this.panelFormChangePassword.Name = "panelFormChangePassword";
            // 
            // btnConfirmChangePws
            // 
            this.btnConfirmChangePws.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmChangePws.FillColor = System.Drawing.Color.Brown;
            resources.ApplyResources(this.btnConfirmChangePws, "btnConfirmChangePws");
            this.btnConfirmChangePws.Name = "btnConfirmChangePws";
            this.btnConfirmChangePws.Radius = 15;
            this.btnConfirmChangePws.RectColor = System.Drawing.Color.Transparent;
            this.btnConfirmChangePws.TabStop = false;
            this.btnConfirmChangePws.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnConfirmChangePws.Click += new System.EventHandler(this.btnConfirmChangePws_Click);
            // 
            // txtNewChangePws
            // 
            this.txtNewChangePws.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtNewChangePws, "txtNewChangePws");
            this.txtNewChangePws.Name = "txtNewChangePws";
            this.txtNewChangePws.Radius = 15;
            this.txtNewChangePws.RectColor = System.Drawing.Color.Transparent;
            this.txtNewChangePws.ShowText = false;
            this.txtNewChangePws.Symbol = 61528;
            this.txtNewChangePws.TabStop = false;
            this.txtNewChangePws.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewChangePws.Watermark = "Mật khẩu mới";
            // 
            // txtOldChangePws
            // 
            this.txtOldChangePws.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtOldChangePws, "txtOldChangePws");
            this.txtOldChangePws.Name = "txtOldChangePws";
            this.txtOldChangePws.Radius = 15;
            this.txtOldChangePws.RectColor = System.Drawing.Color.Transparent;
            this.txtOldChangePws.ShowText = false;
            this.txtOldChangePws.Symbol = 61475;
            this.txtOldChangePws.TabStop = false;
            this.txtOldChangePws.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOldChangePws.Watermark = "Mật khẩu cũ";
            // 
            // txtAccontChangePws
            // 
            this.txtAccontChangePws.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txtAccontChangePws, "txtAccontChangePws");
            this.txtAccontChangePws.Name = "txtAccontChangePws";
            this.txtAccontChangePws.Radius = 15;
            this.txtAccontChangePws.RectColor = System.Drawing.Color.Transparent;
            this.txtAccontChangePws.ShowText = false;
            this.txtAccontChangePws.Symbol = 62142;
            this.txtAccontChangePws.TabStop = false;
            this.txtAccontChangePws.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAccontChangePws.Watermark = "Tài khoản";
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelFormChangePassword);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.btnMinized);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFormChangePassword.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox txtUser;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UISymbolButton btnLogin;
        private Sunny.UI.UICheckBox cbSaveAccount;
        private Sunny.UI.UISymbolButton uiSymbolButton6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISymbolButton uiSymbolButton7;
        private Sunny.UI.UISymbolLabel lbChangePassword;
        private Sunny.UI.UISymbolButton btnShowPassword;
        private System.Windows.Forms.Label lbLoginReadOnly;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UISymbolButton btnClose;
        private Sunny.UI.UISymbolButton btnMinized;
        private System.Windows.Forms.Panel panelFormChangePassword;
        private Sunny.UI.UIButton btnConfirmChangePws;
        private Sunny.UI.UITextBox txtNewChangePws;
        private Sunny.UI.UITextBox txtOldChangePws;
        private Sunny.UI.UITextBox txtAccontChangePws;
    }
}