using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormInputShitfCa : Form
    {
        public FormInputShitfCa()
        {
            InitializeComponent();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                var destinationPath = $@"\\172.28.10.12\DX Center\ThanhDX\ShiftCa_{DateTime.Now.ToString("ddMMyyyy hhmmss")}.xlsx";
                ATCommon.ATCommon.CopyExcelFile(FileDlg.FileName, destinationPath);
                DataTable dataTable = ExcelFileProcess.GetShiftCaData(FileDlg.FileName);
                dgvShiftCa.DataSource = dataTable;
            }
        }

        private void dgvShiftCa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if it's the first column and row index is 7 or 8
            if (e.ColumnIndex == 0 && (e.RowIndex == 7 || e.RowIndex == 8))
            {
                // Paint the cell's background without the grid lines
                e.PaintBackground(e.ClipBounds, true);
                // Mark the event as handled
                e.Handled = true;
            }
        }
    }
}
