namespace OverTime
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.BudgetOT = new System.Windows.Forms.RibbonOrbMenuItem();
            this.User = new System.Windows.Forms.RibbonOrbMenuItem();
            this.RegisterOTPreShift = new System.Windows.Forms.RibbonOrbMenuItem();
            this.btnRetrictOT = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribBtnUpdateLineProcess = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribPannelSummary = new System.Windows.Forms.RibbonPanel();
            this.ribbtnSummary = new System.Windows.Forms.RibbonButton();
            this.ribPanelInput = new System.Windows.Forms.RibbonPanel();
            this.ribbtnInput = new System.Windows.Forms.RibbonButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.tabMain = new JacksiroKe.MdiTabCtrl.TabControl();
            this.lbUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.BackColor = System.Drawing.Color.White;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.ForeColor = System.Drawing.Color.Red;
            this.ribbon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.BudgetOT);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.User);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.RegisterOTPreShift);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.btnRetrictOT);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribBtnUpdateLineProcess);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 292);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "Menu";
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.DropDownButtonVisible = false;
            this.ribbon1.QuickAccessToolbar.Enabled = false;
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(1264, 79);
            this.ribbon1.TabIndex = 232;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.UseAlwaysStandardTheme = true;
            // 
            // BudgetOT
            // 
            this.BudgetOT.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.BudgetOT.Image = ((System.Drawing.Image)(resources.GetObject("BudgetOT.Image")));
            this.BudgetOT.LargeImage = ((System.Drawing.Image)(resources.GetObject("BudgetOT.LargeImage")));
            this.BudgetOT.Name = "BudgetOT";
            this.BudgetOT.SmallImage = ((System.Drawing.Image)(resources.GetObject("BudgetOT.SmallImage")));
            this.BudgetOT.Text = "Dự toán tăng ca";
            this.BudgetOT.Click += new System.EventHandler(this.BudgetOT_Click);
            // 
            // User
            // 
            this.User.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.User.Image = ((System.Drawing.Image)(resources.GetObject("User.Image")));
            this.User.LargeImage = ((System.Drawing.Image)(resources.GetObject("User.LargeImage")));
            this.User.Name = "User";
            this.User.SmallImage = ((System.Drawing.Image)(resources.GetObject("User.SmallImage")));
            this.User.Text = "Add User";
            this.User.Click += new System.EventHandler(this.User_Click);
            // 
            // RegisterOTPreShift
            // 
            this.RegisterOTPreShift.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.RegisterOTPreShift.Image = ((System.Drawing.Image)(resources.GetObject("RegisterOTPreShift.Image")));
            this.RegisterOTPreShift.LargeImage = ((System.Drawing.Image)(resources.GetObject("RegisterOTPreShift.LargeImage")));
            this.RegisterOTPreShift.Name = "RegisterOTPreShift";
            this.RegisterOTPreShift.SmallImage = ((System.Drawing.Image)(resources.GetObject("RegisterOTPreShift.SmallImage")));
            this.RegisterOTPreShift.Text = "Đăng ký tăng ca trước giờ";
            this.RegisterOTPreShift.Click += new System.EventHandler(this.RegisterOTPreShift_Click);
            // 
            // btnRetrictOT
            // 
            this.btnRetrictOT.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btnRetrictOT.Image = ((System.Drawing.Image)(resources.GetObject("btnRetrictOT.Image")));
            this.btnRetrictOT.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRetrictOT.LargeImage")));
            this.btnRetrictOT.Name = "btnRetrictOT";
            this.btnRetrictOT.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnRetrictOT.SmallImage")));
            this.btnRetrictOT.Text = "Hạn chế tăng ca";
            this.btnRetrictOT.Click += new System.EventHandler(this.btnRetrictOT_Click);
            // 
            // ribBtnUpdateLineProcess
            // 
            this.ribBtnUpdateLineProcess.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribBtnUpdateLineProcess.Image = ((System.Drawing.Image)(resources.GetObject("ribBtnUpdateLineProcess.Image")));
            this.ribBtnUpdateLineProcess.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribBtnUpdateLineProcess.LargeImage")));
            this.ribBtnUpdateLineProcess.Name = "ribBtnUpdateLineProcess";
            this.ribBtnUpdateLineProcess.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribBtnUpdateLineProcess.SmallImage")));
            this.ribBtnUpdateLineProcess.Text = "Update Line Công đoạn";
            this.ribBtnUpdateLineProcess.Click += new System.EventHandler(this.ribBtnUpdateLineProcess_Click);
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribPannelSummary);
            this.ribbonTab1.Panels.Add(this.ribPanelInput);
            this.ribbonTab1.Text = "";
            // 
            // ribPannelSummary
            // 
            this.ribPannelSummary.ButtonMoreVisible = false;
            this.ribPannelSummary.Items.Add(this.ribbtnSummary);
            this.ribPannelSummary.Name = "ribPannelSummary";
            this.ribPannelSummary.Text = "";
            // 
            // ribbtnSummary
            // 
            this.ribbtnSummary.Image = ((System.Drawing.Image)(resources.GetObject("ribbtnSummary.Image")));
            this.ribbtnSummary.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbtnSummary.LargeImage")));
            this.ribbtnSummary.Name = "ribbtnSummary";
            this.ribbtnSummary.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnSummary.SmallImage")));
            this.ribbtnSummary.Text = "ribbonButton1";
            // 
            // ribPanelInput
            // 
            this.ribPanelInput.ButtonMoreVisible = false;
            this.ribPanelInput.Items.Add(this.ribbtnInput);
            this.ribPanelInput.Name = "ribPanelInput";
            this.ribPanelInput.Text = "";
            this.ribPanelInput.Click += new System.EventHandler(this.ribPanelInput_Click);
            // 
            // ribbtnInput
            // 
            this.ribbtnInput.Image = ((System.Drawing.Image)(resources.GetObject("ribbtnInput.Image")));
            this.ribbtnInput.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbtnInput.LargeImage")));
            this.ribbtnInput.Name = "ribbtnInput";
            this.ribbtnInput.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbtnInput.SmallImage")));
            this.ribbtnInput.Text = "ribbonButton2";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(-2, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1268, 28);
            this.label6.TabIndex = 233;
            this.label6.Text = "SOLDER PASTE MANAGEMENT SOFWARE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1268, 28);
            this.label1.TabIndex = 236;
            this.label1.Text = "OVER TIME MANAGEMENT SYSTEM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Panels.Add(this.ribbonPanel3);
            this.ribbonTab2.Panels.Add(this.ribbonPanel4);
            this.ribbonTab2.Text = "";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.ribbonButton2);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.ribbonButton3);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "ribbonButton1";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.ribbonButton4);
            this.ribbonPanel4.Name = "ribbonPanel4";
            this.ribbonPanel4.Text = "";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "ribbonButton2";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "ribbonTab3";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Panels.Add(this.ribbonPanel5);
            this.ribbonTab4.Panels.Add(this.ribbonPanel6);
            this.ribbonTab4.Panels.Add(this.ribbonPanel7);
            this.ribbonTab4.Text = "";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.ribbonButton5);
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton2";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbonButton6);
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.LargeImage")));
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "ribbonButton1";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.ribbonButton7);
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Text = "";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.LargeImage")));
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "ribbonButton2";
            // 
            // tabMain
            // 
            this.tabMain.Alignment = JacksiroKe.MdiTabCtrl.TabControl.TabAlignment.Bottom;
            this.tabMain.AllowDrop = true;
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.DropButtonVisible = false;
            this.tabMain.Location = new System.Drawing.Point(0, 78);
            this.tabMain.MenuRenderer = null;
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1264, 605);
            this.tabMain.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.tabMain.TabBackHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tabMain.TabBackLowColorDisabled = System.Drawing.Color.DarkGray;
            this.tabMain.TabCloseButtonImage = null;
            this.tabMain.TabCloseButtonImageDisabled = null;
            this.tabMain.TabCloseButtonImageHot = null;
            this.tabMain.TabCloseButtonVisible = false;
            this.tabMain.TabHeight = 25;
            this.tabMain.TabIndex = 237;
            // 
            // lbUser
            // 
            this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.Color.White;
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbUser.Location = new System.Drawing.Point(984, 55);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(37, 16);
            this.lbUser.TabIndex = 238;
            this.lbUser.Text = "User";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribPannelSummary;
        private System.Windows.Forms.RibbonButton ribbtnSummary;
        private System.Windows.Forms.RibbonPanel ribPanelInput;
        private System.Windows.Forms.RibbonButton ribbtnInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private JacksiroKe.MdiTabCtrl.TabControl tabMain;
        private System.Windows.Forms.RibbonOrbMenuItem BudgetOT;
        private System.Windows.Forms.RibbonOrbMenuItem User;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.RibbonOrbMenuItem RegisterOTPreShift;
        private System.Windows.Forms.RibbonOrbMenuItem btnRetrictOT;
        private System.Windows.Forms.RibbonOrbMenuItem ribBtnUpdateLineProcess;
    }
}

