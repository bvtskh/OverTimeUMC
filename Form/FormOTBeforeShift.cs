using OverTime.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormOTBeforeShift : Form
    {
        public List<OTBeforeShift> lstOTBeforeShift = new List<OTBeforeShift>();
        public FormOTBeforeShift()
        {
            InitializeComponent();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            lstOTBeforeShift.Clear();
            OpenFileDialog FileDlg = new OpenFileDialog();
            FileDlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            FileDlg.RestoreDirectory = true;
            if (FileDlg.ShowDialog() == DialogResult.OK)
            {
                Common.RunProcess("LoadTitle.exe");
                lstOTBeforeShift = OTBeforeShift.GetListOTBeforeShift(FileDlg.FileName);

                Common.KillProcess("LoadTitle");
                dgvOTPreShift.DataSource = null;
                dgvOTPreShift.DataSource = lstOTBeforeShift;
                EditViewdgvOTBeforeShift();
                dgvOTPreShift.Refresh();
            }
        }


        private void EditViewdgvOTBeforeShift()
        {
            foreach(DataGridViewColumn col in dgvOTPreShift.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                string[] s = col.Name.Split('_');
                if(s.Length > 1)
                {
                    col.HeaderText = s[1];
                }  
            }
            dgvOTPreShift.Columns["Code"].Width = 80;
            dgvOTPreShift.Columns["Name"].Width = 150;
            dgvOTPreShift.Columns["Today"].Visible = false;
        }


        private List<Tbl_OTBeforeShift> ConvertListExcelOTBeforeShiftToListDataBase(List<OTBeforeShift> lstItem)
        {
            List<Tbl_OTBeforeShift> lstResult = new List<Tbl_OTBeforeShift>();
            int Month = dtTimeOTBeforeShift.Value.Month;
            int Year = dtTimeOTBeforeShift.Value.Year;
            DateTime MonthOTPreShift = new DateTime(Year, Month, 1, 0, 0, 0);
            foreach (var item in lstItem)
            {
                Tbl_OTBeforeShift ot = new Tbl_OTBeforeShift();
                ot.MonthOfYear = MonthOTPreShift;
                ot.Code = item.Code;
                ot.Name = item.Name;
                ot.RegisOverTime = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}|{21}|{22}|{23}|{24}|{25}|{26}|{27}|{28}|{29}|{30}",
                    item.Day_1, item.Day_2, item.Day_3, item.Day_4, item.Day_5, item.Day_6, item.Day_7, item.Day_8, item.Day_9, item.Day_10,
                    item.Day_11, item.Day_12, item.Day_13, item.Day_14, item.Day_15, item.Day_16, item.Day_17, item.Day_18, item.Day_19, item.Day_20,
                    item.Day_21, item.Day_22, item.Day_23, item.Day_24, item.Day_25, item.Day_26, item.Day_27, item.Day_28, item.Day_29, item.Day_30,
                    item.Day_31);
                lstResult.Add(ot);
            }
            return lstResult;
        }

        private void btnSaveTimeINOUT_Click(object sender, EventArgs e)
        {
            int Month = dtTimeOTBeforeShift.Value.Month;
            int Year = dtTimeOTBeforeShift.Value.Year;
            DateTime MonthOTPreShift = new DateTime(Year, Month, 1, 0, 0, 0);
            List<Tbl_OTBeforeShift> lstOTpreShift = new List<Tbl_OTBeforeShift>();
            lstOTpreShift = ConvertListExcelOTBeforeShiftToListDataBase(lstOTBeforeShift);
            using (var db = new DBContext())
            {
                var lstFindExit = db.Tbl_OTBeforeShift.Where(x => x.MonthOfYear == MonthOTPreShift).ToList();
                if(lstFindExit.Count > 0)
                {
                    db.Tbl_OTBeforeShift.RemoveRange(lstFindExit);
                    db.SaveChanges();
                }
                db.Tbl_OTBeforeShift.AddRange(lstOTpreShift);
                db.SaveChanges();
                MessageBox.Show("SaveSuccess","Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dgvOTPreShift.DataSource = null;
                //dgvOTPreShift.DataSource = lstOTpreShift;
                //dgvOTPreShift.Refresh();
                //btnLoad_Click(null, null);
            }
        }



        public static List<OTBeforeShift> ShowRegisterOTPreShift(List<Tbl_OTBeforeShift> lstItem, int today)
        {
            //int Month = dtTimeOTBeforeShift.Value.Month;
            //int Year = dtTimeOTBeforeShift.Value.Year;
            //DateTime MonthOTPreShift = new DateTime(Year, Month, 1, 0, 0, 0);
            List<OTBeforeShift> lstResult = new List<OTBeforeShift>();
            //int today = DateTime.Now.Day;
            //var lstOTPre = db.Tbl_OTBeforeShift.Where(x => x.MonthOfYear == MonthOTPreShift).ToList();
            if (lstItem.Count > 0)
            {
                foreach (var item in lstItem)
                {
                    OTBeforeShift ot = new OTBeforeShift();
                    ot.Code = item.Code;
                    ot.Name = item.Name;
                    string[] s = item.RegisOverTime.Split('|').ToArray();
                    if (s.Length >= 30)
                    {
                        ot.Day_1 = s[0]; ot.Day_2 = s[1]; ot.Day_3 = s[2]; ot.Day_4 = s[3]; ot.Day_5 = s[4]; ot.Day_6 = s[5]; ot.Day_7 = s[6]; ot.Day_8 = s[7]; ot.Day_9 = s[8]; ot.Day_10 = s[9];

                        ot.Day_11 = s[10]; ot.Day_12 = s[11]; ot.Day_13 = s[12]; ot.Day_14 = s[13]; ot.Day_15 = s[14]; ot.Day_16 = s[15]; ot.Day_17 = s[16]; ot.Day_18 = s[17]; ot.Day_19 = s[18]; ot.Day_20 = s[19];

                        ot.Day_21 = s[20]; ot.Day_22 = s[21]; ot.Day_23 = s[22]; ot.Day_24 = s[23]; ot.Day_25 = s[24]; ot.Day_26 = s[25]; ot.Day_27 = s[26]; ot.Day_28 = s[27]; ot.Day_29 = s[28]; ot.Day_30 = s[29];

                        if(s.Length > 30)
                        {
                            ot.Day_31 = s[30];
                        }
                        

                        ot.Today = s[today - 1];


                    }
                    lstResult.Add(ot);
                }
            }

            return lstResult;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int Month = dtTimeOTBeforeShift.Value.Month;
            int Year = dtTimeOTBeforeShift.Value.Year;
            DateTime MonthOTPreShift = new DateTime(Year, Month, 1, 0, 0, 0);
            int today = DateTime.Now.Day;
            using (var db = new DBContext())
            {
                var lstResult = db.Tbl_OTBeforeShift.Where(x => x.MonthOfYear == MonthOTPreShift).ToList();
                var lstDetailOTPre = ShowRegisterOTPreShift(lstResult, today);
                dgvOTPreShift.DataSource = null;
                dgvOTPreShift.DataSource = lstDetailOTPre;
                EditViewdgvOTBeforeShift();
                dgvOTPreShift.Refresh();
            }
                
        }

        private void btnEditOTPreShift_Click(object sender, EventArgs e)
        {
            FormEditOTPreShift frmEdit = new FormEditOTPreShift();
            frmEdit.Show();
        }
    }
}
