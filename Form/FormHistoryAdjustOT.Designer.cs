namespace OverTime
{
    partial class FormHistoryAdjustOT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistoryAdjustOT));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdjust = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbReqNo = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbCode = new Sunny.UI.UIComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateAdjustPicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.txtTimeAdjust = new System.Windows.Forms.TextBox();
            this.txtTimeIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeRegisted = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabApprove = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbReqWaitAppr = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbDeptAppr = new System.Windows.Forms.ComboBox();
            this.cbbReqNo = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnRejectOne = new System.Windows.Forms.Button();
            this.btnApproveAll = new System.Windows.Forms.Button();
            this.lbDept = new System.Windows.Forms.Label();
            this.btnApproveOne = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvApprove = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbstt = new Sunny.UI.UISmoothLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAdjust.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabApprove.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprove)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistory
            // 
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(3, 200);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.Size = new System.Drawing.Size(1167, 396);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistory_CellFormatting);
            this.dgvHistory.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHistory_CellMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdjust);
            this.tabControl1.Controls.Add(this.tabApprove);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 630);
            this.tabControl1.TabIndex = 244;
            // 
            // tabAdjust
            // 
            this.tabAdjust.BackColor = System.Drawing.Color.White;
            this.tabAdjust.Controls.Add(this.dgvHistory);
            this.tabAdjust.Controls.Add(this.panel2);
            this.tabAdjust.Controls.Add(this.groupBox1);
            this.tabAdjust.Location = new System.Drawing.Point(4, 27);
            this.tabAdjust.Name = "tabAdjust";
            this.tabAdjust.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdjust.Size = new System.Drawing.Size(1173, 599);
            this.tabAdjust.TabIndex = 0;
            this.tabAdjust.Text = "Điều chỉnh Đặc biệt";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.labelID);
            this.panel2.Controls.Add(this.btnSendEmail);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbReqNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 42);
            this.panel2.TabIndex = 263;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(89)))), ((int)(((byte)(153)))));
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.White;
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendEmail.Location = new System.Drawing.Point(956, 5);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(201, 32);
            this.btnSendEmail.TabIndex = 245;
            this.btnSendEmail.Text = "Gửi mail xin phê duyệt";
            this.btnSendEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::OverTime.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(846, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 32);
            this.btnSearch.TabIndex = 44;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(22, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 45;
            this.label5.Text = "Request No: ";
            // 
            // lbReqNo
            // 
            this.lbReqNo.AutoSize = true;
            this.lbReqNo.BackColor = System.Drawing.Color.Transparent;
            this.lbReqNo.Location = new System.Drawing.Point(125, 11);
            this.lbReqNo.Name = "lbReqNo";
            this.lbReqNo.Size = new System.Drawing.Size(0, 18);
            this.lbReqNo.TabIndex = 45;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(380, 11);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(23, 18);
            this.labelID.TabIndex = 261;
            this.labelID.Text = "---";
            this.labelID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.cbbCode);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateAdjustPicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTimeOut);
            this.groupBox1.Controls.Add(this.txtTimeAdjust);
            this.groupBox1.Controls.Add(this.txtTimeIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTimeRegisted);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.cbbDept);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1167, 155);
            this.groupBox1.TabIndex = 242;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều chỉnh tăng ca";
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
            this.cbbCode.Location = new System.Drawing.Point(146, 107);
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
            this.cbbCode.Size = new System.Drawing.Size(248, 29);
            this.cbbCode.Style = Sunny.UI.UIStyle.Custom;
            this.cbbCode.TabIndex = 251;
            this.cbbCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbbCode.Watermark = "";
            this.cbbCode.SelectedValueChanged += new System.EventHandler(this.cbbCode_SelectedValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(1060, 70);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 66);
            this.btnSave.TabIndex = 241;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "Chọn Bộ Phận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Mã NV / Tên";
            // 
            // dateAdjustPicker
            // 
            this.dateAdjustPicker.CustomFormat = "dd/MMM/yyyy";
            this.dateAdjustPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateAdjustPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateAdjustPicker.Location = new System.Drawing.Point(146, 71);
            this.dateAdjustPicker.Name = "dateAdjustPicker";
            this.dateAdjustPicker.Size = new System.Drawing.Size(248, 26);
            this.dateAdjustPicker.TabIndex = 240;
            this.dateAdjustPicker.ValueChanged += new System.EventHandler(this.dateAdjustPicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Ngày điều chỉnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(411, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Mã Nhân viên";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeOut.Location = new System.Drawing.Point(672, 110);
            this.txtTimeOut.MaxLength = 3;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.ReadOnly = true;
            this.txtTimeOut.Size = new System.Drawing.Size(82, 26);
            this.txtTimeOut.TabIndex = 41;
            this.txtTimeOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeAdjust_KeyPress);
            // 
            // txtTimeAdjust
            // 
            this.txtTimeAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeAdjust.Location = new System.Drawing.Point(1060, 31);
            this.txtTimeAdjust.MaxLength = 4;
            this.txtTimeAdjust.Name = "txtTimeAdjust";
            this.txtTimeAdjust.Size = new System.Drawing.Size(97, 26);
            this.txtTimeAdjust.TabIndex = 41;
            this.txtTimeAdjust.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeAdjust_KeyPress);
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeIn.Location = new System.Drawing.Point(522, 110);
            this.txtTimeIn.MaxLength = 3;
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.ReadOnly = true;
            this.txtTimeIn.Size = new System.Drawing.Size(82, 26);
            this.txtTimeIn.TabIndex = 41;
            this.txtTimeIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeRegisted_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(411, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Họ và Tên";
            // 
            // txtTimeRegisted
            // 
            this.txtTimeRegisted.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeRegisted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeRegisted.Location = new System.Drawing.Point(859, 31);
            this.txtTimeRegisted.MaxLength = 3;
            this.txtTimeRegisted.Name = "txtTimeRegisted";
            this.txtTimeRegisted.ReadOnly = true;
            this.txtTimeRegisted.Size = new System.Drawing.Size(96, 26);
            this.txtTimeRegisted.TabIndex = 41;
            this.txtTimeRegisted.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeRegisted_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(411, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "Giờ Vào";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(859, 70);
            this.txtReason.MaxLength = 200;
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(195, 66);
            this.txtReason.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(760, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "Giờ đăng ký";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(796, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "Lý do";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(522, 70);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(232, 26);
            this.txtName.TabIndex = 41;
            // 
            // cbbDept
            // 
            this.cbbDept.BackColor = System.Drawing.SystemColors.Window;
            this.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(146, 29);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(248, 28);
            this.cbbDept.TabIndex = 42;
            this.cbbDept.SelectionChangeCommitted += new System.EventHandler(this.cbbHuman_SelectionChangeCommitted);
            this.cbbDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbHuman_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(610, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "Giờ Ra";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(522, 31);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(232, 26);
            this.txtCode.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(970, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Giờ báo lại";
            // 
            // tabApprove
            // 
            this.tabApprove.Controls.Add(this.groupBox4);
            this.tabApprove.Controls.Add(this.groupBox3);
            this.tabApprove.Location = new System.Drawing.Point(4, 27);
            this.tabApprove.Name = "tabApprove";
            this.tabApprove.Padding = new System.Windows.Forms.Padding(3);
            this.tabApprove.Size = new System.Drawing.Size(1173, 599);
            this.tabApprove.TabIndex = 1;
            this.tabApprove.Text = "Phê duyệt ";
            this.tabApprove.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox4.BackgroundImage")));
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.lbReqWaitAppr);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(3, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1164, 71);
            this.groupBox4.TabIndex = 245;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Request Chờ phê duyệt";
            // 
            // lbReqWaitAppr
            // 
            this.lbReqWaitAppr.AutoSize = true;
            this.lbReqWaitAppr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReqWaitAppr.Location = new System.Drawing.Point(247, 30);
            this.lbReqWaitAppr.Name = "lbReqWaitAppr";
            this.lbReqWaitAppr.Size = new System.Drawing.Size(17, 18);
            this.lbReqWaitAppr.TabIndex = 0;
            this.lbReqWaitAppr.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Các số yêu cầu chờ phê duyệt:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox3.Controls.Add(this.cbbDeptAppr);
            this.groupBox3.Controls.Add(this.cbbReqNo);
            this.groupBox3.Controls.Add(this.lbStatus);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnRejectOne);
            this.groupBox3.Controls.Add(this.btnApproveAll);
            this.groupBox3.Controls.Add(this.lbDept);
            this.groupBox3.Controls.Add(this.btnApproveOne);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.dgvApprove);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1164, 510);
            this.groupBox3.TabIndex = 244;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách điều chỉnh";
            // 
            // cbbDeptAppr
            // 
            this.cbbDeptAppr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDeptAppr.FormattingEnabled = true;
            this.cbbDeptAppr.Location = new System.Drawing.Point(66, 25);
            this.cbbDeptAppr.Name = "cbbDeptAppr";
            this.cbbDeptAppr.Size = new System.Drawing.Size(107, 24);
            this.cbbDeptAppr.TabIndex = 261;
            this.cbbDeptAppr.SelectedIndexChanged += new System.EventHandler(this.cbbDeptAppr_SelectedIndexChanged);
            // 
            // cbbReqNo
            // 
            this.cbbReqNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReqNo.FormattingEnabled = true;
            this.cbbReqNo.Location = new System.Drawing.Point(276, 25);
            this.cbbReqNo.Name = "cbbReqNo";
            this.cbbReqNo.Size = new System.Drawing.Size(95, 24);
            this.cbbReqNo.TabIndex = 261;
            this.cbbReqNo.SelectedIndexChanged += new System.EventHandler(this.cbbReqNo_SelectedIndexChanged);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(1009, 26);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(26, 18);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "---";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(921, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "Trạng thái:";
            // 
            // btnRejectOne
            // 
            this.btnRejectOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRejectOne.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnRejectOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejectOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejectOne.Image = ((System.Drawing.Image)(resources.GetObject("btnRejectOne.Image")));
            this.btnRejectOne.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRejectOne.Location = new System.Drawing.Point(8, 471);
            this.btnRejectOne.Name = "btnRejectOne";
            this.btnRejectOne.Size = new System.Drawing.Size(143, 33);
            this.btnRejectOne.TabIndex = 260;
            this.btnRejectOne.Text = "REJECT";
            this.btnRejectOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRejectOne.UseVisualStyleBackColor = false;
            this.btnRejectOne.Click += new System.EventHandler(this.btnRejectOne_Click);
            // 
            // btnApproveAll
            // 
            this.btnApproveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproveAll.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnApproveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnApproveAll.Image")));
            this.btnApproveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproveAll.Location = new System.Drawing.Point(157, 471);
            this.btnApproveAll.Name = "btnApproveAll";
            this.btnApproveAll.Size = new System.Drawing.Size(143, 33);
            this.btnApproveAll.TabIndex = 260;
            this.btnApproveAll.Text = "APPROVE ALL";
            this.btnApproveAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproveAll.UseVisualStyleBackColor = false;
            this.btnApproveAll.Click += new System.EventHandler(this.btnApproveAll_Click);
            // 
            // lbDept
            // 
            this.lbDept.AutoSize = true;
            this.lbDept.Location = new System.Drawing.Point(4, 28);
            this.lbDept.Name = "lbDept";
            this.lbDept.Size = new System.Drawing.Size(57, 16);
            this.lbDept.TabIndex = 45;
            this.lbDept.Text = "Bộ phận";
            // 
            // btnApproveOne
            // 
            this.btnApproveOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproveOne.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnApproveOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproveOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveOne.Image = ((System.Drawing.Image)(resources.GetObject("btnApproveOne.Image")));
            this.btnApproveOne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApproveOne.Location = new System.Drawing.Point(1025, 472);
            this.btnApproveOne.Name = "btnApproveOne";
            this.btnApproveOne.Size = new System.Drawing.Size(136, 33);
            this.btnApproveOne.TabIndex = 260;
            this.btnApproveOne.Text = "APPROVE";
            this.btnApproveOne.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApproveOne.UseVisualStyleBackColor = false;
            this.btnApproveOne.Click += new System.EventHandler(this.btnApproveOne_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 16);
            this.label15.TabIndex = 45;
            this.label15.Text = "Request No.";
            // 
            // dgvApprove
            // 
            this.dgvApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApprove.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApprove.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApprove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApprove.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApprove.EnableHeadersVisualStyles = false;
            this.dgvApprove.Location = new System.Drawing.Point(6, 55);
            this.dgvApprove.Name = "dgvApprove";
            this.dgvApprove.ReadOnly = true;
            this.dgvApprove.RowHeadersVisible = false;
            this.dgvApprove.Size = new System.Drawing.Size(1155, 409);
            this.dgvApprove.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.lbstt);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1181, 51);
            this.panel3.TabIndex = 252;
            // 
            // lbstt
            // 
            this.lbstt.BackColor = System.Drawing.Color.Transparent;
            this.lbstt.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbstt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbstt.Location = new System.Drawing.Point(0, 0);
            this.lbstt.Name = "lbstt";
            this.lbstt.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(222)))));
            this.lbstt.Size = new System.Drawing.Size(523, 51);
            this.lbstt.TabIndex = 0;
            this.lbstt.Text = "ĐIỀU CHỈNH TĂNG CA ĐẶC BIỆT - TẠO MỚI";
            this.lbstt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormHistoryAdjustOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHistoryAdjustOT";
            this.Text = "Điều chỉnh tăng ca đặc biệt";
            this.Load += new System.EventHandler(this.FormHistoryAdjustOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAdjust.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabApprove.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApprove)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.TextBox txtTimeRegisted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeAdjust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateAdjustPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdjust;
        private System.Windows.Forms.TabPage tabApprove;
        private System.Windows.Forms.Label lbReqNo;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.TextBox txtTimeIn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbbReqNo;
        private System.Windows.Forms.Button btnRejectOne;
        private System.Windows.Forms.Button btnApproveAll;
        private System.Windows.Forms.Button btnApproveOne;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvApprove;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbReqWaitAppr;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbbDeptAppr;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbDept;
        private Sunny.UI.UIComboBox cbbCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UISmoothLabel lbstt;
        private System.Windows.Forms.Label label5;
    }
}