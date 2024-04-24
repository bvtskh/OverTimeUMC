namespace OverTime
{
    partial class FormBudgetOT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveBudget = new FontAwesome.Sharp.IconButton();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalOT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAddBudget = new System.Windows.Forms.DataGridView();
            this.Col_Dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NumHuman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_BudgetOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Trungbinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cboMonth);
            this.panel2.Controls.Add(this.cboYear);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSaveBudget);
            this.panel2.Controls.Add(this.cboDept);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbTotalOT);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgvAddBudget);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 681);
            this.panel2.TabIndex = 254;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(235, 45);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(105, 28);
            this.cboMonth.TabIndex = 260;
            this.cboMonth.SelectionChangeCommitted += new System.EventHandler(this.cboMonth_SelectionChangeCommitted);
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(63, 45);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(83, 28);
            this.cboYear.TabIndex = 261;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 258;
            this.label2.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 259;
            this.label4.Text = "Năm";
            // 
            // btnSaveBudget
            // 
            this.btnSaveBudget.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSaveBudget.FlatAppearance.BorderSize = 0;
            this.btnSaveBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBudget.ForeColor = System.Drawing.Color.Black;
            this.btnSaveBudget.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnSaveBudget.IconColor = System.Drawing.Color.Green;
            this.btnSaveBudget.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnSaveBudget.IconSize = 30;
            this.btnSaveBudget.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSaveBudget.Location = new System.Drawing.Point(434, 616);
            this.btnSaveBudget.Name = "btnSaveBudget";
            this.btnSaveBudget.Size = new System.Drawing.Size(156, 31);
            this.btnSaveBudget.TabIndex = 257;
            this.btnSaveBudget.Text = "Lưu Dự Toán";
            this.btnSaveBudget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveBudget.UseVisualStyleBackColor = true;
            this.btnSaveBudget.Click += new System.EventHandler(this.btnSaveBudget_Click);
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(454, 45);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(136, 28);
            this.cboDept.TabIndex = 256;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(613, 35);
            this.label3.TabIndex = 252;
            this.label3.Text = "Thiết Lập Dự Toán Tăng Ca";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTotalOT
            // 
            this.lbTotalOT.AutoSize = true;
            this.lbTotalOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalOT.ForeColor = System.Drawing.Color.Red;
            this.lbTotalOT.Location = new System.Drawing.Point(506, 89);
            this.lbTotalOT.Name = "lbTotalOT";
            this.lbTotalOT.Size = new System.Drawing.Size(29, 20);
            this.lbTotalOT.TabIndex = 253;
            this.lbTotalOT.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(329, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 20);
            this.label6.TabIndex = 253;
            this.label6.Text = "Tổng số giờ Dự toán:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(329, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 20);
            this.label5.TabIndex = 253;
            this.label5.Text = "Tổng số giờ Dự toán";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 253;
            this.label1.Text = "Bộ Phận";
            // 
            // dgvAddBudget
            // 
            this.dgvAddBudget.AllowUserToAddRows = false;
            this.dgvAddBudget.AllowUserToDeleteRows = false;
            this.dgvAddBudget.AllowUserToResizeColumns = false;
            this.dgvAddBudget.AllowUserToResizeRows = false;
            this.dgvAddBudget.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddBudget.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddBudget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_Dept,
            this.Col_Customer,
            this.col_NumHuman,
            this.Col_BudgetOT,
            this.col_Trungbinh});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddBudget.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAddBudget.EnableHeadersVisualStyles = false;
            this.dgvAddBudget.Location = new System.Drawing.Point(13, 117);
            this.dgvAddBudget.Name = "dgvAddBudget";
            this.dgvAddBudget.RowHeadersVisible = false;
            this.dgvAddBudget.RowTemplate.Height = 30;
            this.dgvAddBudget.Size = new System.Drawing.Size(577, 488);
            this.dgvAddBudget.TabIndex = 253;
            this.dgvAddBudget.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddBudget_CellEndEdit);
            // 
            // Col_Dept
            // 
            this.Col_Dept.HeaderText = "Bộ phận";
            this.Col_Dept.Name = "Col_Dept";
            this.Col_Dept.ReadOnly = true;
            this.Col_Dept.Width = 90;
            // 
            // Col_Customer
            // 
            this.Col_Customer.DataPropertyName = "Line";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Col_Customer.DefaultCellStyle = dataGridViewCellStyle2;
            this.Col_Customer.HeaderText = "Khách hàng";
            this.Col_Customer.Name = "Col_Customer";
            this.Col_Customer.ReadOnly = true;
            this.Col_Customer.Width = 120;
            // 
            // col_NumHuman
            // 
            this.col_NumHuman.HeaderText = "Số Người";
            this.col_NumHuman.Name = "col_NumHuman";
            // 
            // Col_BudgetOT
            // 
            this.Col_BudgetOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Col_BudgetOT.DataPropertyName = "Value";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            this.Col_BudgetOT.DefaultCellStyle = dataGridViewCellStyle3;
            this.Col_BudgetOT.HeaderText = "Số Giờ OT";
            this.Col_BudgetOT.Name = "Col_BudgetOT";
            this.Col_BudgetOT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // col_Trungbinh
            // 
            this.col_Trungbinh.HeaderText = "Trung bình (H/Người/Tháng)";
            this.col_Trungbinh.Name = "col_Trungbinh";
            this.col_Trungbinh.Width = 130;
            // 
            // FormBudgetOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Name = "FormBudgetOT";
            this.Text = "FormBudgetOT";
            this.Load += new System.EventHandler(this.FormBudgetOT_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddBudget)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnSaveBudget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAddBudget;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalOT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Dept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NumHuman;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_BudgetOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Trungbinh;
    }
}