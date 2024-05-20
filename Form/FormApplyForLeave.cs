using NPOI.SS.Formula.Functions;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormApplyForLeave : Form
    {
        List<OTINFO> GAINFO=  new List<OTINFO>();
        List<OTINFO> DXINFO = new List<OTINFO>();
        public FormApplyForLeave()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) // GA
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(ofd.FileName);
                Worksheet sheet = workbook.Worksheets[0];

                // Loop through cells to read data
                double temp;
                for (int row = 2; row <= sheet.LastRow; row++)
                {
                    GAINFO.Add(new OTINFO {
                        CODE = sheet[row, 1].DisplayedText,
                        NAME = sheet[row, 2].DisplayedText,
                        THANG1 = double.TryParse(sheet[row, 3].DisplayedText,out temp) ? temp : 0,
                        THANG2 = double.TryParse(sheet[row, 4].DisplayedText, out temp) ? temp : 0,
                        THANG3 = double.TryParse(sheet[row, 5].DisplayedText, out temp) ? temp : 0,
                    }); ;                  
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(ofd.FileName);
                Worksheet sheet = workbook.Worksheets[0];

                // Loop through cells to read data
                double temp;
                for (int row = 10; row <= sheet.LastRow; row++)
                {
                    DXINFO.Add(new OTINFO
                    {
                        CODE = sheet[row, 2].DisplayedText,
                        NAME = sheet[row, 3].DisplayedText,
                        THANG1 = double.TryParse(sheet[row, 8].DisplayedText, out temp) ? temp : 0,
                        THANG2 = double.TryParse(sheet[row, 9].DisplayedText, out temp) ? temp : 0,
                        THANG3 = double.TryParse(sheet[row, 10].DisplayedText, out temp) ? temp : 0,
                    }); ;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();           
            Worksheet sheet = workbook.Worksheets[0];
            int index = 1;
            foreach(var dx in DXINFO)
            {
                var code = dx.CODE;
                var item = GAINFO.Where(w=>w.CODE == code).FirstOrDefault();
                if(item != null)
                {
                    if(dx.THANG1 != item.THANG1 || dx.THANG2 != item.THANG2 || dx.THANG3 != item.THANG3)
                    {
                        if (dx.THANG1 != item.THANG1)
                        {
                            sheet.Range[index, 1].Value = code;
                            sheet.Range[index, 2].Value = dx.NAME;
                            sheet.Range[index, 3].Value = dx.THANG1.ToString() + " => " + item.THANG1.ToString();
                            sheet.Range[index, 4].Value = dx.THANG2.ToString();
                            sheet.Range[index, 5].Value = dx.THANG3.ToString();
                        }
                        if (dx.THANG2 != item.THANG2)
                        {
                            sheet.Range[index, 1].Value = code;
                            sheet.Range[index, 2].Value = dx.NAME;
                            sheet.Range[index, 3].Value = dx.THANG1.ToString();
                            sheet.Range[index, 4].Value = dx.THANG2.ToString() + " => " + item.THANG2.ToString();
                            sheet.Range[index, 5].Value = dx.THANG3.ToString();
                        }
                        if (dx.THANG3 != item.THANG3)
                        {
                            sheet.Range[index, 1].Value = code;
                            sheet.Range[index, 2].Value = dx.NAME;
                            sheet.Range[index, 3].Value = dx.THANG1.ToString();
                            sheet.Range[index, 4].Value = dx.THANG2.ToString();
                            sheet.Range[index, 5].Value = dx.THANG3.ToString() + " => " + item.THANG3.ToString();
                        }
                        index++;
                    }
                   
                }
            }
            // Save the workbook to the specified file path
            workbook.SaveToFile("C:\\Users\\u42107\\Desktop\\Test\\ABC.xlsx", ExcelVersion.Version2013);
        }
    }
    public class OTINFO
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
        public double THANG1 {  get; set; }
        public double THANG2 { get; set;}
        public double THANG3 { get; set;}
    }
}
