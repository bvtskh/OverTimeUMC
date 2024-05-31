namespace OverTime
{
    partial class FormBenefit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBenefit));
            this.dgvbenefit = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtYear = new Sunny.UI.UITextBox();
            this.txtMonth = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.cbDept = new Sunny.UI.UIComboBox();
            this.txtCode = new Sunny.UI.UITextBox();
            this.btnExport = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbenefit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvbenefit
            // 
            this.dgvbenefit.AllowUserToAddRows = false;
            this.dgvbenefit.BackgroundColor = System.Drawing.Color.White;
            this.dgvbenefit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbenefit.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbenefit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvbenefit.Location = new System.Drawing.Point(5, 102);
            this.dgvbenefit.Name = "dgvbenefit";
            this.dgvbenefit.Size = new System.Drawing.Size(1795, 684);
            this.dgvbenefit.TabIndex = 0;
            this.dgvbenefit.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvbenefit_CellPainting);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbDept);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel1.Size = new System.Drawing.Size(1795, 97);
            this.panel1.TabIndex = 1;
            // 
            // txtYear
            // 
            this.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtYear.Location = new System.Drawing.Point(55, 53);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYear.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYear.Name = "txtYear";
            this.txtYear.Padding = new System.Windows.Forms.Padding(5);
            this.txtYear.RectColor = System.Drawing.Color.Silver;
            this.txtYear.ShowText = false;
            this.txtYear.Size = new System.Drawing.Size(71, 25);
            this.txtYear.TabIndex = 7;
            this.txtYear.Text = "0";
            this.txtYear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtYear.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtYear.Watermark = "";
            // 
            // txtMonth
            // 
            this.txtMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMonth.Location = new System.Drawing.Point(191, 53);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonth.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Padding = new System.Windows.Forms.Padding(5);
            this.txtMonth.RectColor = System.Drawing.Color.Silver;
            this.txtMonth.ShowText = false;
            this.txtMonth.Size = new System.Drawing.Size(61, 25);
            this.txtMonth.TabIndex = 7;
            this.txtMonth.Text = "0";
            this.txtMonth.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMonth.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtMonth.Watermark = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(731, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "DANH SÁCH NHÂN VIÊN NHẬN GIỜ BỒI DƯỠNG NGÀY/ĐÊM";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FillColor = System.Drawing.Color.Firebrick;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.Location = new System.Drawing.Point(487, 52);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Radius = 26;
            this.btnSearch.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.Symbol = 61442;
            this.btnSearch.TabIndex = 2;
            this.btnSearch.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbDept
            // 
            this.cbDept.DataSource = null;
            this.cbDept.FillColor = System.Drawing.Color.White;
            this.cbDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDept.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbDept.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbDept.Location = new System.Drawing.Point(260, 53);
            this.cbDept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDept.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbDept.Name = "cbDept";
            this.cbDept.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbDept.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbDept.Size = new System.Drawing.Size(112, 25);
            this.cbDept.TabIndex = 1;
            this.cbDept.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbDept.Watermark = "";
            // 
            // txtCode
            // 
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCode.Location = new System.Drawing.Point(384, 53);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtCode.RectColor = System.Drawing.Color.Silver;
            this.txtCode.ShowText = false;
            this.txtCode.Size = new System.Drawing.Size(96, 25);
            this.txtCode.TabIndex = 7;
            this.txtCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCode.Watermark = "Mã NV";
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Location = new System.Drawing.Point(1678, 61);
            this.btnExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.RectColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExport.Size = new System.Drawing.Size(112, 29);
            this.btnExport.Symbol = 362829;
            this.btnExport.SymbolColor = System.Drawing.Color.BlanchedAlmond;
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormBenefit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1805, 791);
            this.Controls.Add(this.dgvbenefit);
            this.Controls.Add(this.panel1);
            this.Name = "FormBenefit";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "FormBenefit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBenefit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbenefit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvbenefit;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UIComboBox cbDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox txtMonth;
        private Sunny.UI.UITextBox txtYear;
        private Sunny.UI.UITextBox txtCode;
        private Sunny.UI.UISymbolButton btnExport;
    }
}