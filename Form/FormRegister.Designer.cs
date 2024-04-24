using System.Windows.Forms;

namespace OverTime
{
    partial class FormRegister
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbCode = new Sunny.UI.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotalHours = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtDateOverTime = new System.Windows.Forms.DateTimePicker();
            this.cbbShift = new System.Windows.Forms.ComboBox();
            this.lbTotalHuman = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeSetOT = new System.Windows.Forms.TextBox();
            this.cbbCustomer = new System.Windows.Forms.ComboBox();
            this.btnSetTimeOT = new System.Windows.Forms.Button();
            this.cbbLine = new PresentationControls.CheckBoxComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new OverTime.Button_AQ.AQButton();
            this.Col_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Direct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Luyke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_RegisOverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Reason = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeight = 40;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Code,
            this.Col_Name,
            this.Col_Direct,
            this.Col_Dept,
            this.Col_Customer,
            this.Col_Line,
            this.Col_Shift,
            this.Col_Luyke,
            this.Col_RegisOverTime,
            this.Col_Reason,
            this.Col_Status,
            this.Col_Remove});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.Location = new System.Drawing.Point(0, 199);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.RowTemplate.Height = 30;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMain.Size = new System.Drawing.Size(1264, 431);
            this.dgvMain.TabIndex = 16;
            this.dgvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellEndEdit);
            this.dgvMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.cbbCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbTotalHours);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtDateOverTime);
            this.groupBox1.Controls.Add(this.cbbShift);
            this.groupBox1.Controls.Add(this.lbTotalHuman);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbbDept);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTimeSetOT);
            this.groupBox1.Controls.Add(this.cbbCustomer);
            this.groupBox1.Controls.Add(this.btnSetTimeOT);
            this.groupBox1.Controls.Add(this.cbbLine);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1264, 148);
            this.groupBox1.TabIndex = 246;
            this.groupBox1.TabStop = false;
            // 
            // cbbCode
            // 
            this.cbbCode.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cbbCode.DataSource = null;
            this.cbbCode.DropDownWidth = 300;
            this.cbbCode.FillColor = System.Drawing.Color.White;
            this.cbbCode.FilterMaxCount = 50;
            this.cbbCode.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCode.ItemHoverColor = System.Drawing.SystemColors.Control;
            this.cbbCode.ItemRectColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbbCode.ItemSelectBackColor = System.Drawing.SystemColors.Control;
            this.cbbCode.ItemSelectForeColor = System.Drawing.SystemColors.GrayText;
            this.cbbCode.Location = new System.Drawing.Point(9, 109);
            this.cbbCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbCode.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbbCode.Name = "cbbCode";
            this.cbbCode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbbCode.Radius = 2;
            this.cbbCode.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbbCode.RectDisableColor = System.Drawing.SystemColors.Control;
            this.cbbCode.ScrollBarBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbbCode.ScrollBarColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbbCode.ScrollBarStyleInherited = false;
            this.cbbCode.ShowFilter = true;
            this.cbbCode.Size = new System.Drawing.Size(150, 29);
            this.cbbCode.Style = Sunny.UI.UIStyle.Custom;
            this.cbbCode.TabIndex = 250;
            this.cbbCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbCode.Watermark = "";
            this.cbbCode.SelectedValueChanged += new System.EventHandler(this.cbbCode_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 40;
            this.label5.Text = "Ngày ĐK";
            // 
            // lbTotalHours
            // 
            this.lbTotalHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalHours.AutoSize = true;
            this.lbTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalHours.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTotalHours.Location = new System.Drawing.Point(1207, 120);
            this.lbTotalHours.Name = "lbTotalHours";
            this.lbTotalHours.Size = new System.Drawing.Size(15, 16);
            this.lbTotalHours.TabIndex = 241;
            this.lbTotalHours.Text = "0";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(45)))), ((int)(((byte)(77)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::OverTime.Properties.Resources.icons8_search_book_20;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(689, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 29);
            this.btnSearch.TabIndex = 245;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 248;
            this.label4.Text = "Mã Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Khách hàng";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(1113, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 16);
            this.label9.TabIndex = 241;
            this.label9.Text = "Tổng số giờ:";
            // 
            // dtDateOverTime
            // 
            this.dtDateOverTime.CustomFormat = "dd/MM/yyyy";
            this.dtDateOverTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOverTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOverTime.Location = new System.Drawing.Point(6, 38);
            this.dtDateOverTime.Name = "dtDateOverTime";
            this.dtDateOverTime.Size = new System.Drawing.Size(117, 27);
            this.dtDateOverTime.TabIndex = 240;
            this.dtDateOverTime.ValueChanged += new System.EventHandler(this.dtDateOverTime_ValueChanged);
            // 
            // cbbShift
            // 
            this.cbbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbShift.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbShift.FormattingEnabled = true;
            this.cbbShift.Items.AddRange(new object[] {
            "DAY",
            "NIGHT",
            "ALL"});
            this.cbbShift.Location = new System.Drawing.Point(429, 38);
            this.cbbShift.Name = "cbbShift";
            this.cbbShift.Size = new System.Drawing.Size(87, 27);
            this.cbbShift.TabIndex = 38;
            // 
            // lbTotalHuman
            // 
            this.lbTotalHuman.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalHuman.AutoSize = true;
            this.lbTotalHuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalHuman.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTotalHuman.Location = new System.Drawing.Point(1046, 119);
            this.lbTotalHuman.Name = "lbTotalHuman";
            this.lbTotalHuman.Size = new System.Drawing.Size(15, 16);
            this.lbTotalHuman.TabIndex = 241;
            this.lbTotalHuman.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(125, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 19);
            this.label22.TabIndex = 40;
            this.label22.Text = "Bộ phận";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(971, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 241;
            this.label8.Text = "Số Người:";
            // 
            // cbbDept
            // 
            this.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDept.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(129, 38);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(128, 27);
            this.cbbDept.TabIndex = 39;
            this.cbbDept.SelectedIndexChanged += new System.EventHandler(this.cbbDept_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(518, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Group";
            // 
            // txtTimeSetOT
            // 
            this.txtTimeSetOT.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeSetOT.Location = new System.Drawing.Point(164, 110);
            this.txtTimeSetOT.Name = "txtTimeSetOT";
            this.txtTimeSetOT.Size = new System.Drawing.Size(82, 28);
            this.txtTimeSetOT.TabIndex = 36;
            // 
            // cbbCustomer
            // 
            this.cbbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCustomer.FormattingEnabled = true;
            this.cbbCustomer.Location = new System.Drawing.Point(263, 38);
            this.cbbCustomer.Name = "cbbCustomer";
            this.cbbCustomer.Size = new System.Drawing.Size(160, 27);
            this.cbbCustomer.TabIndex = 38;
            this.cbbCustomer.SelectedIndexChanged += new System.EventHandler(this.cbbCustomer_SelectedIndexChanged);
            // 
            // btnSetTimeOT
            // 
            this.btnSetTimeOT.BackColor = System.Drawing.Color.Chocolate;
            this.btnSetTimeOT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSetTimeOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetTimeOT.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetTimeOT.ForeColor = System.Drawing.Color.White;
            this.btnSetTimeOT.Image = global::OverTime.Properties.Resources.icons8_generate_income_30;
            this.btnSetTimeOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetTimeOT.Location = new System.Drawing.Point(250, 109);
            this.btnSetTimeOT.Name = "btnSetTimeOT";
            this.btnSetTimeOT.Size = new System.Drawing.Size(171, 29);
            this.btnSetTimeOT.TabIndex = 37;
            this.btnSetTimeOT.Text = "Đặt số Giờ Tăng Ca";
            this.btnSetTimeOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetTimeOT.UseVisualStyleBackColor = false;
            this.btnSetTimeOT.Click += new System.EventHandler(this.btnSetTimeOT_Click);
            // 
            // cbbLine
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbbLine.CheckBoxProperties = checkBoxProperties1;
            this.cbbLine.DisplayMemberSingleItem = "";
            this.cbbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLine.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLine.FormattingEnabled = true;
            this.cbbLine.Location = new System.Drawing.Point(522, 38);
            this.cbbLine.Name = "cbbLine";
            this.cbbLine.Size = new System.Drawing.Size(161, 27);
            this.cbbLine.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(166, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 40;
            this.label7.Text = "Số Giờ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(425, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Ca LV";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.uiSmoothLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 51);
            this.panel2.TabIndex = 252;
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.uiSmoothLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiSmoothLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(222)))));
            this.uiSmoothLabel1.Size = new System.Drawing.Size(302, 51);
            this.uiSmoothLabel1.TabIndex = 0;
            this.uiSmoothLabel1.Text = "ĐĂNG KÝ TĂNG CA";
            this.uiSmoothLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 51);
            this.panel1.TabIndex = 247;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(115)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(24)))), ((int)(((byte)(115)))));
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 2;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1171, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 38);
            this.btnSave.TabIndex = 242;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Col_Code
            // 
            this.Col_Code.DataPropertyName = "Col_Code";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col_Code.DefaultCellStyle = dataGridViewCellStyle3;
            this.Col_Code.Frozen = true;
            this.Col_Code.HeaderText = "Mã NV";
            this.Col_Code.MinimumWidth = 22;
            this.Col_Code.Name = "Col_Code";
            this.Col_Code.ReadOnly = true;
            this.Col_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Code.Width = 90;
            // 
            // Col_Name
            // 
            this.Col_Name.DataPropertyName = "Col_Name";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col_Name.DefaultCellStyle = dataGridViewCellStyle4;
            this.Col_Name.Frozen = true;
            this.Col_Name.HeaderText = "Họ tên";
            this.Col_Name.MinimumWidth = 22;
            this.Col_Name.Name = "Col_Name";
            this.Col_Name.ReadOnly = true;
            this.Col_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Name.Width = 250;
            // 
            // Col_Direct
            // 
            this.Col_Direct.DataPropertyName = "Col_Direct";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Direct.DefaultCellStyle = dataGridViewCellStyle5;
            this.Col_Direct.Frozen = true;
            this.Col_Direct.HeaderText = "Công việc";
            this.Col_Direct.MinimumWidth = 22;
            this.Col_Direct.Name = "Col_Direct";
            this.Col_Direct.ReadOnly = true;
            this.Col_Direct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Direct.Width = 140;
            // 
            // Col_Dept
            // 
            this.Col_Dept.DataPropertyName = "Col_Dept";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Dept.DefaultCellStyle = dataGridViewCellStyle6;
            this.Col_Dept.Frozen = true;
            this.Col_Dept.HeaderText = "Bộ phận";
            this.Col_Dept.MinimumWidth = 22;
            this.Col_Dept.Name = "Col_Dept";
            this.Col_Dept.ReadOnly = true;
            this.Col_Dept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Dept.Width = 90;
            // 
            // Col_Customer
            // 
            this.Col_Customer.DataPropertyName = "Col_Customer";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Customer.DefaultCellStyle = dataGridViewCellStyle7;
            this.Col_Customer.HeaderText = "Khách hàng";
            this.Col_Customer.MinimumWidth = 22;
            this.Col_Customer.Name = "Col_Customer";
            this.Col_Customer.ReadOnly = true;
            this.Col_Customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Customer.Width = 120;
            // 
            // Col_Line
            // 
            this.Col_Line.DataPropertyName = "Col_Line";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Line.DefaultCellStyle = dataGridViewCellStyle8;
            this.Col_Line.HeaderText = "Line";
            this.Col_Line.MinimumWidth = 22;
            this.Col_Line.Name = "Col_Line";
            this.Col_Line.ReadOnly = true;
            this.Col_Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Line.Visible = false;
            this.Col_Line.Width = 70;
            // 
            // Col_Shift
            // 
            this.Col_Shift.DataPropertyName = "Col_Shift";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Shift.DefaultCellStyle = dataGridViewCellStyle9;
            this.Col_Shift.HeaderText = "Ca LV";
            this.Col_Shift.MinimumWidth = 22;
            this.Col_Shift.Name = "Col_Shift";
            this.Col_Shift.ReadOnly = true;
            this.Col_Shift.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Shift.Visible = false;
            this.Col_Shift.Width = 80;
            // 
            // Col_Luyke
            // 
            this.Col_Luyke.DataPropertyName = "Col_Luyke";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Luyke.DefaultCellStyle = dataGridViewCellStyle10;
            this.Col_Luyke.HeaderText = "Lũy kế";
            this.Col_Luyke.MinimumWidth = 22;
            this.Col_Luyke.Name = "Col_Luyke";
            this.Col_Luyke.ReadOnly = true;
            this.Col_Luyke.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Luyke.Width = 80;
            // 
            // Col_RegisOverTime
            // 
            this.Col_RegisOverTime.DataPropertyName = "Col_RegisOverTime";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Col_RegisOverTime.DefaultCellStyle = dataGridViewCellStyle11;
            this.Col_RegisOverTime.HeaderText = "ĐK TăngCa";
            this.Col_RegisOverTime.MinimumWidth = 22;
            this.Col_RegisOverTime.Name = "Col_RegisOverTime";
            this.Col_RegisOverTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Col_Reason
            // 
            this.Col_Reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Col_Reason.DataPropertyName = "Col_Reason";
            this.Col_Reason.HeaderText = "Lý do";
            this.Col_Reason.MinimumWidth = 22;
            this.Col_Reason.Name = "Col_Reason";
            this.Col_Reason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Col_Status
            // 
            this.Col_Status.DataPropertyName = "Col_Status";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Col_Status.DefaultCellStyle = dataGridViewCellStyle12;
            this.Col_Status.HeaderText = "Status";
            this.Col_Status.MinimumWidth = 22;
            this.Col_Status.Name = "Col_Status";
            this.Col_Status.ReadOnly = true;
            this.Col_Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Status.Width = 70;
            // 
            // Col_Remove
            // 
            this.Col_Remove.DataPropertyName = "Col_Remove";
            this.Col_Remove.HeaderText = "Xóa";
            this.Col_Remove.MinimumWidth = 22;
            this.Col_Remove.Name = "Col_Remove";
            this.Col_Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Col_Remove.Width = 60;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegister";
            this.Text = "Đăng ký tăng ca";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnSetTime_FormClosing);
            this.Load += new System.EventHandler(this.FormInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dgvMain;
        private System.Windows.Forms.ComboBox cbbCustomer;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private PresentationControls.CheckBoxComboBox cbbLine;
        private System.Windows.Forms.TextBox txtTimeSetOT;
        private System.Windows.Forms.Button btnSetTimeOT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtDateOverTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTotalHuman;
        private System.Windows.Forms.Label lbTotalHours;
        private Button_AQ.AQButton btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UIComboBox cbbCode;
        private Panel panel1;
        private Panel panel2;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private DataGridViewTextBoxColumn Col_Code;
        private DataGridViewTextBoxColumn Col_Name;
        private DataGridViewTextBoxColumn Col_Direct;
        private DataGridViewTextBoxColumn Col_Dept;
        private DataGridViewTextBoxColumn Col_Customer;
        private DataGridViewTextBoxColumn Col_Line;
        private DataGridViewTextBoxColumn Col_Shift;
        private DataGridViewTextBoxColumn Col_Luyke;
        private DataGridViewTextBoxColumn Col_RegisOverTime;
        private DataGridViewComboBoxColumn Col_Reason;
        private DataGridViewTextBoxColumn Col_Status;
        private DataGridViewButtonColumn Col_Remove;
    }
}