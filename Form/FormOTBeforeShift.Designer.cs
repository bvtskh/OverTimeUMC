namespace OverTime
{
    partial class FormOTBeforeShift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOTBeforeShift));
            this.btnLoad = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvOTPreShift = new System.Windows.Forms.DataGridView();
            this.dtTimeOTBeforeShift = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditOTPreShift = new System.Windows.Forms.Button();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSaveTimeINOUT = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTPreShift)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(151)))), ((int)(((byte)(134)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Image = global::OverTime.Properties.Resources.search1;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(242, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(116, 30);
            this.btnLoad.TabIndex = 246;
            this.btnLoad.Text = "Tìm kiếm";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 242;
            this.label12.Text = "Thời gian";
            // 
            // dgvOTPreShift
            // 
            this.dgvOTPreShift.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOTPreShift.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOTPreShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOTPreShift.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOTPreShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOTPreShift.EnableHeadersVisualStyles = false;
            this.dgvOTPreShift.Location = new System.Drawing.Point(0, 97);
            this.dgvOTPreShift.Name = "dgvOTPreShift";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOTPreShift.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOTPreShift.RowHeadersVisible = false;
            this.dgvOTPreShift.Size = new System.Drawing.Size(1118, 416);
            this.dgvOTPreShift.TabIndex = 241;
            // 
            // dtTimeOTBeforeShift
            // 
            this.dtTimeOTBeforeShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTimeOTBeforeShift.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTimeOTBeforeShift.Location = new System.Drawing.Point(98, 9);
            this.dtTimeOTBeforeShift.Name = "dtTimeOTBeforeShift";
            this.dtTimeOTBeforeShift.Size = new System.Drawing.Size(138, 29);
            this.dtTimeOTBeforeShift.TabIndex = 240;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnEditOTPreShift);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnImportFile);
            this.panel1.Controls.Add(this.dtTimeOTBeforeShift);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 46);
            this.panel1.TabIndex = 249;
            // 
            // btnEditOTPreShift
            // 
            this.btnEditOTPreShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOTPreShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(32)))), ((int)(((byte)(67)))));
            this.btnEditOTPreShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOTPreShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOTPreShift.ForeColor = System.Drawing.Color.White;
            this.btnEditOTPreShift.Image = ((System.Drawing.Image)(resources.GetObject("btnEditOTPreShift.Image")));
            this.btnEditOTPreShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditOTPreShift.Location = new System.Drawing.Point(995, 5);
            this.btnEditOTPreShift.Name = "btnEditOTPreShift";
            this.btnEditOTPreShift.Size = new System.Drawing.Size(116, 36);
            this.btnEditOTPreShift.TabIndex = 248;
            this.btnEditOTPreShift.Tag = "3";
            this.btnEditOTPreShift.Text = "Add/Edit";
            this.btnEditOTPreShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditOTPreShift.UseVisualStyleBackColor = false;
            this.btnEditOTPreShift.Click += new System.EventHandler(this.btnEditOTPreShift_Click);
            // 
            // btnImportFile
            // 
            this.btnImportFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(86)))));
            this.btnImportFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportFile.ForeColor = System.Drawing.Color.White;
            this.btnImportFile.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFile.Image")));
            this.btnImportFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportFile.Location = new System.Drawing.Point(847, 5);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(145, 36);
            this.btnImportFile.TabIndex = 243;
            this.btnImportFile.Text = "Nhập file Excel";
            this.btnImportFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportFile.UseVisualStyleBackColor = false;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnSaveTimeINOUT);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1118, 48);
            this.panel2.TabIndex = 250;
            // 
            // btnSaveTimeINOUT
            // 
            this.btnSaveTimeINOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTimeINOUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(116)))), ((int)(((byte)(66)))));
            this.btnSaveTimeINOUT.FlatAppearance.BorderSize = 0;
            this.btnSaveTimeINOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTimeINOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTimeINOUT.ForeColor = System.Drawing.Color.Black;
            this.btnSaveTimeINOUT.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTimeINOUT.Image")));
            this.btnSaveTimeINOUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveTimeINOUT.Location = new System.Drawing.Point(1019, 7);
            this.btnSaveTimeINOUT.Name = "btnSaveTimeINOUT";
            this.btnSaveTimeINOUT.Size = new System.Drawing.Size(92, 38);
            this.btnSaveTimeINOUT.TabIndex = 245;
            this.btnSaveTimeINOUT.Text = "Lưu";
            this.btnSaveTimeINOUT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveTimeINOUT.UseVisualStyleBackColor = false;
            this.btnSaveTimeINOUT.Click += new System.EventHandler(this.btnSaveTimeINOUT_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Controls.Add(this.uiSmoothLabel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1118, 51);
            this.panel5.TabIndex = 254;
            // 
            // uiSmoothLabel1
            // 
            this.uiSmoothLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.uiSmoothLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiSmoothLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSmoothLabel1.Location = new System.Drawing.Point(0, 0);
            this.uiSmoothLabel1.Name = "uiSmoothLabel1";
            this.uiSmoothLabel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(110)))), ((int)(((byte)(222)))));
            this.uiSmoothLabel1.Size = new System.Drawing.Size(554, 51);
            this.uiSmoothLabel1.TabIndex = 0;
            this.uiSmoothLabel1.Text = "NHẬP DỮ LIỆU ĐĂNG KÝ TĂNG CA TRƯỚC GIỜ";
            this.uiSmoothLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormOTBeforeShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 561);
            this.Controls.Add(this.dgvOTPreShift);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOTBeforeShift";
            this.Text = "FormOTBeforeShift";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOTPreShift)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSaveTimeINOUT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvOTPreShift;
        private System.Windows.Forms.DateTimePicker dtTimeOTBeforeShift;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Button btnEditOTPreShift;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
    }
}