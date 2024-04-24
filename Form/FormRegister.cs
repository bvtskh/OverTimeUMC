using OverTime.Business;
using OverTime.Button_AQ;
using OverTime.Class;
using OverTime.DataBase;
using OverTime.MsgBox_AQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OverTime
{
    public partial class FormRegister : Form
    {
        public List<Tbl_Setting> lstSetting = new List<Tbl_Setting>();
        public DateTime OldTime;
        public List<TimeInOut> lstFingerPrint = new List<TimeInOut>();
        public List<Tbl_RestrictOT> lstRetrict = new List<Tbl_RestrictOT>();
        List<Tbl_DailyOverTime> lstChange = new List<Tbl_DailyOverTime>();
        List<PI_Lib.Entities.Tbl_Mankichi_Entity> lstHumanSearch = new List<PI_Lib.Entities.Tbl_Mankichi_Entity>();

        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            LoadInfoMasterData();
            LoadListUser();
            LoadSetting();
            CheckDateAndEnableSave(dtDateOverTime.Value.Date);
            CheckUserAndRule();
        }
        private void LoadListUser()
        {
            IList<Info> infoList = new List<Info>();
            foreach (var item in GAMankuchi.Instance()._listCurrentStaff)
            {
                infoList.Add(new Info() { Id = item.AltCode, Name = item.Name + "-" + item.AltCode });
            }

            cbbCode.ValueMember = "Id";
            cbbCode.DisplayMember = "Name";
            cbbCode.DataSource = infoList;

        }

        private void CheckUserAndRule()
        {
            if (Common.UserLogin.UserName == "View")
            {
                btnSave.Enabled = false;
            }
        }


        private void LoadInfoMasterData()
        {
            string[] ArrDept = Common.UserLogin.Dept.Split('|').ToArray();
            foreach (var item in ArrDept)
            {
                cbbDept.Items.Add(item);
            }
            if (ArrDept.Length == 1)
            {
                cbbDept.SelectedIndex = 0;
            }
        }


        private void LoadSetting()
        {
            using (var db = new DBContext())
            {
                lstSetting = db.Tbl_Setting.ToList();
            }
        }

        private void cbbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCustomer.Enabled = cbbLine.Enabled = true;
            var lstCustomerGroup = GAMankuchi.Instance()._listCurrentStaff
                .Where(x => x.Dept == cbbDept.Text)
                .GroupBy(x => new { x.Customer }).Select(x => new
                {
                    Customer = x.Key.Customer,
                }).ToList();
            cbbCustomer.Items.Clear();
            foreach (var item in lstCustomerGroup)
            {
                if (!string.IsNullOrEmpty(item.Customer))
                {
                    cbbCustomer.Items.Add(item.Customer);
                }
            }
            cbbLine.Items.Clear();
        }

        private void cbbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lstLine = GAMankuchi.Instance()._listCurrentStaff.Where(x => x.Dept == cbbDept.Text && x.Customer == cbbCustomer.Text).ToList();
            var lstLineGroup = lstLine.GroupBy(x => new { x.GroupProcess }).Select(x => new
            {
                Group = x.Key.GroupProcess,
            }).ToList();
            cbbLine.Items.Clear();
            foreach (var item in lstLineGroup)
            {
                if (!string.IsNullOrEmpty(item.Group))
                    cbbLine.Items.Add(item.Group);
            }
        }
        private void CheckUserSaveData()
        {
            if (lstChange.Count > 0 && btnSave.Enabled == true)
            {
                var result = RJMessageBox.Show("Bạn có muốn lưu lại dữ liệu trước khi thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    btnSave_Click(null, null);
                }
                else
                {
                    ClearRegistedTime();
                }
            }
        }

        private void cbbCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbCode.SelectedValue == null) return;
            cbbCode.HideDropDown();
            var lstHumanSearch = OverTimeHelper.GetListUserWillRegister("",
               "",
               "",
               dtDateOverTime.Value.Date,
               "",
               cbbCode.SelectedValue.ToString()
               );
            if (lstHumanSearch == null) return;
            List<DataGridViewRow> row =
            new List<DataGridViewRow>
            (from DataGridViewRow r in dgvMain.Rows
             where r.Cells["Col_Code"].Value.ToString().Equals(cbbCode.SelectedValue.ToString())
             select r);
            if (row.Count == 0)
            {
                AddRow(lstHumanSearch.FirstOrDefault());
                dgvMain.FirstDisplayedScrollingRowIndex = dgvMain.RowCount - 1;
                if (GroupSupportHelper.CheckExistGroup(cbbCode.SelectedValue.ToString(), cbbLine.Text.Trim()))
                {
                    var result = RJMessageBox.Show($"Bạn có muốn thêm {cbbCode.SelectedValue.ToString()} vào danh sách hỗ trợ của nhóm {cbbLine.Text} không?",
                       "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        var r = GroupSupportHelper.AddToGroup(cbbCode.SelectedValue.ToString(), cbbLine.Text.Trim(),cbbCustomer.Text);
                        if (string.IsNullOrEmpty(r)) RJMessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else RJMessageBox.Show(r, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RJMessageBox.Show($"{cbbCode.SelectedValue.ToString()} đã có trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvMain.FirstDisplayedScrollingRowIndex = row.FirstOrDefault().Index;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDept.Text))
            {
                var result = RJMessageBox.Show("Chưa chọn bộ phận đăng ký tăng ca.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CheckUserSaveData();
            DateTime DateSelect = dtDateOverTime.Value.Date;
            var lstHumanSearch = OverTimeHelper.GetListUserWillRegister(cbbCustomer.Text,
                cbbDept.Text,
                cbbLine.Text,
                DateSelect.Date,
                cbbShift.Text
                );
            dgvMain.Rows.Clear();

            foreach (var item in lstHumanSearch)
            {
                AddRow(item);
            }
            CalculationHumanAndTotalHoursOverTime();
            AlarmYellowRowLuyKe();
        }
        private void AddRow(HistoryDetailOverTime item)
        {
            int rowId = dgvMain.Rows.Add();
            DataGridViewRow row = dgvMain.Rows[rowId];
            row.Cells["Col_Code"].Value = item.Code;
            row.Cells["Col_Name"].Value = item.Name;
            row.Cells["Col_Direct"].Value = item.Direct.TrimStart();
            row.Cells["Col_Dept"].Value = item.Dept;
            row.Cells["Col_Customer"].Value = item.Customer;
            row.Cells["Col_Line"].Value = item.Line;
            row.Cells["Col_Remove"].Value = "Xóa";
            row.Cells["Col_Remove"].Style.ForeColor = Color.Red;
            if (row.Cells["Col_Reason"] is DataGridViewComboBoxCell)
            {
                if (lstSetting.Count > 0)
                {
                    foreach (var itemReason in lstSetting)
                    {
                        DataGridViewComboBoxCell comboBoxCell = (row.Cells["Col_Reason"] as DataGridViewComboBoxCell);
                        comboBoxCell.Items.Add(itemReason.ReasonOverTime);
                        comboBoxCell.Value = itemReason.ReasonOverTime;
                    }
                }
                if (!string.IsNullOrEmpty(item.Reason))
                {
                    row.Cells["Col_Reason"].Value = item.Reason;
                }
            }
            row.Cells["Col_Luyke"].Value = item.TotalOT;
            row.Cells["Col_RegisOverTime"].Style.BackColor = Color.Moccasin;
            row.Cells["Col_Status"].Value = item.Status;
            if (item.Block)
            {
                row.DefaultCellStyle.BackColor = Color.Gray;
                row.Cells["Col_RegisOverTime"].ReadOnly = true;
                row.Cells["Col_RegisOverTime"].Style.BackColor = Color.Gray;
            }
            if (item.Restrict)
            {
                row.DefaultCellStyle.BackColor = Color.IndianRed;
                row.Cells["Col_RegisOverTime"].ReadOnly = true;
                row.Cells["Col_RegisOverTime"].Style.BackColor = Color.IndianRed;
            }
            row.Cells["Col_Status"].Value = item.Block ? STATUS.BLOCK : row.Cells["Col_Status"].Value;
            row.Cells["Col_RegisOverTime"].Value = item.TimeRegisted;
            row.Cells["Col_Status"].Value = item.Restrict ? STATUS.RESTRICT : row.Cells["Col_Status"].Value;
        }
       
        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCell = dgvMain.CurrentCell;
            DataGridViewRow curRow = dgvMain.CurrentRow;
            if (curCell.ColumnIndex == 8)
            {
                if (curRow.Cells["Col_Status"].Value != null && curRow.Cells["Col_Status"].Value.ToString() == "RETRICT")
                {
                    RJMessageBox.Show("Người này trong danh sách hạn chế tăng ca", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvMain.CurrentCell.Value = 0;
                    return;
                }

                string mainStr = dgvMain.CurrentCell.Value != null ? dgvMain.CurrentCell.Value.ToString() : "";
                double NumberInput = 0;
                double.TryParse(mainStr, out NumberInput);
                if (NumberInput > Constants.MaxOverTimeInDay)
                {
                    RJMessageBox.Show($"Không được đăng ký tăng ca quá {Constants.MaxOverTimeInDay} tiếng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvMain.CurrentCell.Value = Constants.MaxOverTimeInDay;
                    return;
                }

                if (NumberInput > 0)
                {
                    double t = NumberInput / 0.5;
                    t = Math.Floor(t);
                    double t2 = t * 0.5;
                    if (t2 != NumberInput)
                    {
                        RJMessageBox.Show("Giờ đăng ký tăng ca phải làm tròn đến 0.5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvMain.CurrentCell.Value = 0;
                        return;
                    }

                }
                if (!IsDouble(mainStr))
                {
                    RJMessageBox.Show("Chỉ được nhập số, và phải >= 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvMain.CurrentCell.Value = 0;
                    dgvMain.ClearSelection();
                    dgvMain.CurrentCell = curCell;
                    dgvMain.CurrentCell.Selected = true;
                    return;
                }
                AddListChange(curRow);
                CalculationHumanAndTotalHoursOverTime();
            }
        }

        private bool IsDouble(string mainStr)
        {
            double result;
            int check;
            if (!string.IsNullOrEmpty(mainStr))
            {
                if (!int.TryParse(mainStr.Last().ToString(), out check)) return false;
                if (!int.TryParse(mainStr.First().ToString(), out check)) return false;
                foreach (var ch in mainStr)
                {
                    if (double.TryParse(ch.ToString(), out result))
                    {
                        if (double.TryParse(mainStr, out result)) return true;
                        return false;
                    }
                }
            }
            return false;
        }

        private void AddListChange(DataGridViewRow curRow)
        {
            double NumberInput = 0;
            if (curRow.Cells["Col_RegisOverTime"].Value == null)
            {
                NumberInput = 0;
            }
            else
            {
                var mainStr = curRow.Cells["Col_RegisOverTime"].Value.ToString();
                double.TryParse(mainStr, out NumberInput);
            }
            var isExist = lstChange.Where(m => m.Code == curRow.Cells["Col_Code"].Value.ToString()).FirstOrDefault();
            if (isExist == null)
            {
                lstChange.Add(new Tbl_DailyOverTime()
                {
                    Code = curRow.Cells["Col_Code"].Value.ToString(),
                    TimeRegisted = NumberInput,
                    DateOverTime = dtDateOverTime.Value.Date,
                    Reason = curRow.Cells["Col_Reason"].Value.ToString(),
                    FullName = curRow.Cells["Col_Name"].Value.ToString(),
                    UserRegister = Common.UserLogin.UserName
                });
            }
            else
            {
                isExist.TimeRegisted = NumberInput;
                isExist.Reason = curRow.Cells["Col_Reason"].Value.ToString();
            }
        }

        private void btnSetTimeOT_Click(object sender, EventArgs e)
        {
            if (MsgBox_AQ.RJMessageBox.Show("Chức năng thay đổi tất cả số giờ đăng ký tăng ca trong danh sách, chọn YES để tiếp tục! NO hủy bỏ", "Xác nhận giờ tăng ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            double TimeOT = 0;
            //if (!double.TryParse(txtTimeSetOT.Text, out TimeOT))
            //{
            //    //insert
            //}
            double.TryParse(txtTimeSetOT.Text, out TimeOT);
            if (TimeOT > 0 && TimeOT <= Constants.MaxOverTimeInDay)
            {
                double t = TimeOT / 0.5;
                t = Math.Floor(t);
                double t2 = t * 0.5;
                if (t2 == TimeOT)
                {
                    foreach (DataGridViewRow r in dgvMain.Rows)
                    {
                        string Status = r.Cells["Col_Status"].Value != null ? r.Cells["Col_Status"].Value.ToString() : "";
                        if (Status.Contains("BLOCK") || Status.Contains("RETRICT"))
                        {
                            r.Cells["Col_RegisOverTime"].Value = 0;
                        }
                        else
                        {
                            r.Cells["Col_RegisOverTime"].Value = TimeOT.ToString();
                            AddListChange(r);
                        }

                    }
                }
                else
                {
                    RJMessageBox.Show("Giờ Đăng ký Tăng ca phải làm tròn đến 0.5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                RJMessageBox.Show($"Số giờ nhập vào phải lớn hơn 0 và nhỏ hơn {Constants.MaxOverTimeInDay} giờ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CalculationHumanAndTotalHoursOverTime();
        }

        private void CheckDateAndEnableSave(DateTime dateSelect)
        {
            if (Common.UserLogin.UserName != "View")
            {
                DateTime DateNow = DateTime.Now.Date;
                int Time = DateTime.Now.Hour;
                if (DateNow != dateSelect)
                {
                    DateTime Yesterday = DateNow.AddDays(-1);
                    if (dateSelect == Yesterday)
                    {
                        if (Time >= Constants.TimeEnableModify) { btnSave.Enabled = false; }
                        else if (Time < Constants.TimeEnableModify) { btnSave.Enabled = true; }
                    }
                    else if (dateSelect > DateNow)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }

                }
                else if (DateNow == dateSelect)
                {
                    btnSave.Enabled = true;
                }
            }
        }
        private bool IsValidSaveDateTime()
        {
            if (Common.UserLogin.UserName != "View")
            {
                DateTime DateNow = DateTime.Now.Date;
                DateTime dateSelect = dtDateOverTime.Value.Date;
                int Time = DateTime.Now.Hour;
                if (DateNow != dateSelect)
                {
                    DateTime Yesterday = DateNow.AddDays(-1);
                    if (dateSelect == Yesterday)
                    {
                        if (Time >= Constants.TimeEnableModify) return false;
                        else if (Time < Constants.TimeEnableModify) return true;
                    }
                    else if (dateSelect > DateNow)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (DateNow == dateSelect)
                {
                    return true;
                }
            }
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                string Code = dgvMain.Rows[e.RowIndex].Cells[0].Value.ToString();
                string Status = dgvMain.Rows[e.RowIndex].Cells["Col_Status"].Value.ToString();
                if(Status == STATUS.SUPPORT)
                {
                    var result = RJMessageBox.Show($"Bạn có muốn xóa {Code} ra khỏi danh sách hỗ trợ của nhóm {cbbLine.Text} không?"
                        , "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        var message = GroupSupportHelper.DeleteFromGroup(Code);
                        if (string.IsNullOrEmpty(message)) RJMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else RJMessageBox.Show(message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dgvMain.Rows.RemoveAt(e.RowIndex);
                RemoveListChange(Code);
            }
        }
        private void RemoveListChange(string code)
        {
            var exist = lstChange.Where(m => m.Code == code).FirstOrDefault();
            if (exist != null)
            {
                lstChange.Remove(exist);
            }
        }
        private void btnSetTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckUserSaveData();
        }

        private void CalculationHumanAndTotalHoursOverTime()
        {
            double result;
            int Human = 0;
            double TotalHours = 0;
            foreach (DataGridViewRow r in dgvMain.Rows)
            {
                string value = r.Cells["Col_RegisOverTime"].Value != null ? r.Cells["Col_RegisOverTime"].Value.ToString() : "0";
                if(double.TryParse(value, out result))
                {
                    if (result != 0)
                    {
                        Human++;
                        TotalHours += result;
                    }
                } 
            }
            lbTotalHuman.Text = Human.ToString();
            lbTotalHours.Text = TotalHours.ToString();
        }

        private void dtDateOverTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectDate = dtDateOverTime.Value.Date;
            if (btnSave.Enabled == true)
            {
                CheckUserSaveData();
            }
            CheckDateAndEnableSave(selectDate);
            ClearRegistedTime();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidSaveDateTime())
            {
                RJMessageBox.Show("Đã quá giờ đăng ký tăng ca!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearRegistedTime();
                return;
            }
            if (lstChange.Count == 0)
            {
                RJMessageBox.Show("Bạn chưa có sửa đổi gì để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (OverTimeHelper.SaveRegister(lstChange))
            {
                RJMessageBox.Show($"Đăng ký thành công cho {lstChange.Count} users", "Thông Báo", MessageBoxButtons.OK);
                ClearRegistedTime();
            }
            else
            {
                RJMessageBox.Show("Đăng ký thất bại, vui lòng liên hệ bộ phận DX.", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                ClearRegistedTime();
            }
        }

        private void ClearRegistedTime()
        {
            dgvMain.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.Cells["Col_RegisOverTime"].Value = "");
            lstChange.Clear();
        }

        private void cbbCode_DoEnter(object sender, EventArgs e)
        {
            Console.Write("");
        }

        private void cbbCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlarmYellowRowLuyKe()
        {
            dgvMain.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Col_Direct"].Value.ToString().Contains("Gián") && ConvertDouble(w.Cells["Col_Luyke"].Value) >= (int)AlarmYellow.GianTiep).ToList().ForEach(f => f.Cells["Col_Luyke"].Style.BackColor = Color.Yellow);
            dgvMain.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Col_Direct"].Value.ToString().Contains("Trực") && ConvertDouble(w.Cells["Col_Luyke"].Value) >= (int)AlarmYellow.TrucTiep).ToList().ForEach(f => f.Cells["Col_Luyke"].Style.BackColor = Color.Yellow);
        }
        private double ConvertDouble(object value)
        {
            if(value != null)
            {
                return double.Parse(value.ToString());
            }
            return 0;
        }
    }
}
