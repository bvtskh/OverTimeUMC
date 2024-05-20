namespace OverTime
{
    partial class FormCheckAndApprove
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckAndApprove));
            this.dgvConfirmOT = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accumulated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeFinger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOTPreShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtDateOverTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.lbRate = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbWaitApprove = new System.Windows.Forms.Label();
            this.picApproved = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbListWait = new System.Windows.Forms.Label();
            this.lbConfirm = new System.Windows.Forms.Label();
            this.cbViewAll = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTotalHours = new System.Windows.Forms.Label();
            this.lbTotalHuman = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnApproveALL = new System.Windows.Forms.Button();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmOT)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picApproved)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConfirmOT
            // 
            this.dgvConfirmOT.AllowUserToAddRows = false;
            this.dgvConfirmOT.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvConfirmOT.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfirmOT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConfirmOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfirmOT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.FullName,
            this.Dept,
            this.Direct,
            this.Customer,
            this.TimeIn,
            this.TimeOut,
            this.RegisOT,
            this.TimeDept,
            this.Balance,
            this.Accumulated,
            this.Comment,
            this.TimeFinger,
            this.TotalOT,
            this.Line,
            this.Shift,
            this.Process,
            this.TimeOTPreShift,
            this.Position});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConfirmOT.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConfirmOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfirmOT.EnableHeadersVisualStyles = false;
            this.dgvConfirmOT.Location = new System.Drawing.Point(0, 208);
            this.dgvConfirmOT.Name = "dgvConfirmOT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfirmOT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConfirmOT.RowHeadersVisible = false;
            this.dgvConfirmOT.Size = new System.Drawing.Size(1524, 294);
            this.dgvConfirmOT.TabIndex = 278;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.Frozen = true;
            this.Code.HeaderText = "Mã NV";
            this.Code.Name = "Code";
            this.Code.Width = 90;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.Frozen = true;
            this.FullName.HeaderText = "Họ Tên";
            this.FullName.Name = "FullName";
            this.FullName.Width = 150;
            // 
            // Dept
            // 
            this.Dept.DataPropertyName = "Dept";
            this.Dept.Frozen = true;
            this.Dept.HeaderText = "Bộ phận";
            this.Dept.Name = "Dept";
            // 
            // Direct
            // 
            this.Direct.DataPropertyName = "Direct";
            this.Direct.HeaderText = "Công việc";
            this.Direct.Name = "Direct";
            this.Direct.Width = 125;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Khách hàng";
            this.Customer.Name = "Customer";
            this.Customer.Width = 125;
            // 
            // TimeIn
            // 
            this.TimeIn.DataPropertyName = "TimeIn";
            this.TimeIn.HeaderText = "In";
            this.TimeIn.Name = "TimeIn";
            this.TimeIn.Width = 70;
            // 
            // TimeOut
            // 
            this.TimeOut.DataPropertyName = "TimeOut";
            this.TimeOut.HeaderText = "Out";
            this.TimeOut.Name = "TimeOut";
            this.TimeOut.Width = 70;
            // 
            // RegisOT
            // 
            this.RegisOT.DataPropertyName = "RegisOT";
            this.RegisOT.HeaderText = "Đăng ký";
            this.RegisOT.Name = "RegisOT";
            this.RegisOT.Width = 90;
            // 
            // TimeDept
            // 
            this.TimeDept.DataPropertyName = "TimeDept";
            this.TimeDept.HeaderText = "Giờ BP";
            this.TimeDept.Name = "TimeDept";
            this.TimeDept.Width = 80;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "Balance";
            this.Balance.HeaderText = "Chênh lệch";
            this.Balance.Name = "Balance";
            this.Balance.Width = 110;
            // 
            // Accumulated
            // 
            this.Accumulated.DataPropertyName = "Accumulated";
            this.Accumulated.HeaderText = "Lũy kế";
            this.Accumulated.Name = "Accumulated";
            this.Accumulated.Width = 85;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // TimeFinger
            // 
            this.TimeFinger.DataPropertyName = "TimeFinger";
            this.TimeFinger.HeaderText = "TimeFinger";
            this.TimeFinger.Name = "TimeFinger";
            this.TimeFinger.Visible = false;
            // 
            // TotalOT
            // 
            this.TotalOT.DataPropertyName = "TotalOT";
            this.TotalOT.HeaderText = "TotalOT";
            this.TotalOT.Name = "TotalOT";
            this.TotalOT.Visible = false;
            // 
            // Line
            // 
            this.Line.DataPropertyName = "Line";
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.Visible = false;
            // 
            // Shift
            // 
            this.Shift.DataPropertyName = "Shift";
            this.Shift.HeaderText = "Shift";
            this.Shift.Name = "Shift";
            this.Shift.Visible = false;
            // 
            // Process
            // 
            this.Process.DataPropertyName = "Process";
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.Visible = false;
            // 
            // TimeOTPreShift
            // 
            this.TimeOTPreShift.DataPropertyName = "TimeOTPreShift";
            this.TimeOTPreShift.HeaderText = "TimeOTPreShift";
            this.TimeOTPreShift.Name = "TimeOTPreShift";
            this.TimeOTPreShift.Visible = false;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Position";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.dtDateOverTime);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbbDept);
            this.panel1.Controls.Add(this.lbRate);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lbConfirm);
            this.panel1.Controls.Add(this.cbViewAll);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbTotalHours);
            this.panel1.Controls.Add(this.lbTotalHuman);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1524, 157);
            this.panel1.TabIndex = 279;
            // 
            // dtDateOverTime
            // 
            this.dtDateOverTime.CustomFormat = "dd/MMM/yyyy";
            this.dtDateOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOverTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOverTime.Location = new System.Drawing.Point(83, 38);
            this.dtDateOverTime.Name = "dtDateOverTime";
            this.dtDateOverTime.Size = new System.Drawing.Size(146, 26);
            this.dtDateOverTime.TabIndex = 257;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(333, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 265;
            this.label10.Text = "Tỷ lệ: ";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(86)))), ((int)(((byte)(112)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(233, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 69);
            this.btnSearch.TabIndex = 244;
            this.btnSearch.Text = "Check";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(138)))), ((int)(((byte)(52)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(536, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 69);
            this.button3.TabIndex = 244;
            this.button3.Text = "Gửi Email \r\nxin phê duyệt";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 84);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 20);
            this.label22.TabIndex = 256;
            this.label22.Text = "Bộ phận";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(333, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 264;
            this.label8.Text = "Đã xác nhận: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 255;
            this.label5.Text = "Ngày";
            // 
            // cbbDept
            // 
            this.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(83, 78);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(146, 28);
            this.cbbDept.TabIndex = 247;
            this.cbbDept.SelectedIndexChanged += new System.EventHandler(this.cbbDept_SelectedIndexChanged);
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.BackColor = System.Drawing.Color.Transparent;
            this.lbRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRate.ForeColor = System.Drawing.Color.Coral;
            this.lbRate.Location = new System.Drawing.Point(390, 84);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(54, 20);
            this.lbRate.TabIndex = 267;
            this.lbRate.Text = "100%";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox5);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1196, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 157);
            this.panel4.TabIndex = 278;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.groupBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox5.BackgroundImage")));
            this.groupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox5.Controls.Add(this.lbWaitApprove);
            this.groupBox5.Controls.Add(this.picApproved);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(0, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 77);
            this.groupBox5.TabIndex = 270;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trạng thái";
            // 
            // lbWaitApprove
            // 
            this.lbWaitApprove.BackColor = System.Drawing.Color.White;
            this.lbWaitApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWaitApprove.Location = new System.Drawing.Point(4, 22);
            this.lbWaitApprove.Name = "lbWaitApprove";
            this.lbWaitApprove.Size = new System.Drawing.Size(320, 39);
            this.lbWaitApprove.TabIndex = 1;
            this.lbWaitApprove.Text = "CHỜ PHÊ DUYỆT TĂNG CA";
            this.lbWaitApprove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picApproved
            // 
            this.picApproved.BackColor = System.Drawing.Color.Transparent;
            this.picApproved.Image = ((System.Drawing.Image)(resources.GetObject("picApproved.Image")));
            this.picApproved.InitialImage = ((System.Drawing.Image)(resources.GetObject("picApproved.InitialImage")));
            this.picApproved.Location = new System.Drawing.Point(123, 23);
            this.picApproved.Name = "picApproved";
            this.picApproved.Size = new System.Drawing.Size(150, 39);
            this.picApproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picApproved.TabIndex = 0;
            this.picApproved.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.lbListWait);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(328, 80);
            this.groupBox4.TabIndex = 270;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ngày chờ phê duyệt";
            // 
            // lbListWait
            // 
            this.lbListWait.BackColor = System.Drawing.Color.White;
            this.lbListWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListWait.ForeColor = System.Drawing.Color.Black;
            this.lbListWait.Location = new System.Drawing.Point(16, 25);
            this.lbListWait.Name = "lbListWait";
            this.lbListWait.Size = new System.Drawing.Size(336, 52);
            this.lbListWait.TabIndex = 0;
            this.lbListWait.Text = "---";
            // 
            // lbConfirm
            // 
            this.lbConfirm.AutoSize = true;
            this.lbConfirm.BackColor = System.Drawing.Color.Transparent;
            this.lbConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirm.ForeColor = System.Drawing.Color.Coral;
            this.lbConfirm.Location = new System.Drawing.Point(467, 42);
            this.lbConfirm.Name = "lbConfirm";
            this.lbConfirm.Size = new System.Drawing.Size(34, 20);
            this.lbConfirm.TabIndex = 266;
            this.lbConfirm.Text = "0/0";
            // 
            // cbViewAll
            // 
            this.cbViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbViewAll.AutoSize = true;
            this.cbViewAll.Checked = true;
            this.cbViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViewAll.Location = new System.Drawing.Point(1439, 132);
            this.cbViewAll.Name = "cbViewAll";
            this.cbViewAll.Size = new System.Drawing.Size(73, 20);
            this.cbViewAll.TabIndex = 273;
            this.cbViewAll.Text = "View All";
            this.cbViewAll.UseVisualStyleBackColor = true;
            this.cbViewAll.CheckedChanged += new System.EventHandler(this.cbViewAll_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(186, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 18);
            this.label9.TabIndex = 274;
            this.label9.Text = "Tổng số giờ:";
            // 
            // lbTotalHours
            // 
            this.lbTotalHours.AutoSize = true;
            this.lbTotalHours.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalHours.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTotalHours.Location = new System.Drawing.Point(308, 124);
            this.lbTotalHours.Name = "lbTotalHours";
            this.lbTotalHours.Size = new System.Drawing.Size(17, 18);
            this.lbTotalHours.TabIndex = 275;
            this.lbTotalHours.Text = "0";
            // 
            // lbTotalHuman
            // 
            this.lbTotalHuman.AutoSize = true;
            this.lbTotalHuman.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalHuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalHuman.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTotalHuman.Location = new System.Drawing.Point(98, 124);
            this.lbTotalHuman.Name = "lbTotalHuman";
            this.lbTotalHuman.Size = new System.Drawing.Size(17, 18);
            this.lbTotalHuman.TabIndex = 276;
            this.lbTotalHuman.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(8, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 277;
            this.label1.Text = "Số Người:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.uiSmoothLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1524, 51);
            this.panel3.TabIndex = 281;
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.uiSmoothLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiSmoothLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(222)))));
            this.uiSmoothLabel1.Size = new System.Drawing.Size(359, 49);
            this.uiSmoothLabel1.TabIndex = 0;
            this.uiSmoothLabel1.Text = "XÁC NHẬN VÀ PHÊ DUYỆT";
            this.uiSmoothLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnApprove);
            this.panel2.Controls.Add(this.btnApproveALL);
            this.panel2.Controls.Add(this.txtFeedback);
            this.panel2.Controls.Add(this.btnFeedback);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1524, 59);
            this.panel2.TabIndex = 280;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(140)))), ((int)(((byte)(83)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApprove.Location = new System.Drawing.Point(1377, 5);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(143, 50);
            this.btnApprove.TabIndex = 259;
            this.btnApprove.Text = "APPROVE";
            this.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnApproveALL
            // 
            this.btnApproveALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproveALL.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnApproveALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveALL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveALL.Image = ((System.Drawing.Image)(resources.GetObject("btnApproveALL.Image")));
            this.btnApproveALL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproveALL.Location = new System.Drawing.Point(1216, 6);
            this.btnApproveALL.Name = "btnApproveALL";
            this.btnApproveALL.Size = new System.Drawing.Size(147, 50);
            this.btnApproveALL.TabIndex = 259;
            this.btnApproveALL.Text = "APPROVE ALL";
            this.btnApproveALL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproveALL.UseVisualStyleBackColor = false;
            this.btnApproveALL.Visible = false;
            this.btnApproveALL.Click += new System.EventHandler(this.btnApproveALL_Click);
            // 
            // txtFeedback
            // 
            this.txtFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeedback.Location = new System.Drawing.Point(90, 17);
            this.txtFeedback.Name = "txtFeedback";
            this.txtFeedback.Size = new System.Drawing.Size(460, 26);
            this.txtFeedback.TabIndex = 272;
            // 
            // btnFeedback
            // 
            this.btnFeedback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedback.ForeColor = System.Drawing.Color.White;
            this.btnFeedback.Image = ((System.Drawing.Image)(resources.GetObject("btnFeedback.Image")));
            this.btnFeedback.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFeedback.Location = new System.Drawing.Point(558, 14);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(159, 33);
            this.btnFeedback.TabIndex = 258;
            this.btnFeedback.Text = "Send Feedback";
            this.btnFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFeedback.UseVisualStyleBackColor = false;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 271;
            this.label7.Text = "Feedback";
            // 
            // FormCheckAndApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 561);
            this.Controls.Add(this.dgvConfirmOT);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCheckAndApprove";
            this.Text = "FormCheckAndApprove";
            this.Load += new System.EventHandler(this.FormCheckAndApprove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmOT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picApproved)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.Label lbConfirm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.CheckBox cbViewAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picApproved;
        private System.Windows.Forms.Label lbWaitApprove;
        private System.Windows.Forms.Label lbListWait;
        private System.Windows.Forms.DateTimePicker dtDateOverTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTotalHours;
        private System.Windows.Forms.Label lbTotalHuman;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApproveALL;
        private System.Windows.Forms.DataGridView dgvConfirmOT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accumulated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeFinger;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shift;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOTPreShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
    }
}