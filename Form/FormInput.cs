using CommonProject.Loading.LoadingClass;
using OverTime.Business;
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
    public partial class FormInput : Form
    {
        public List<NameButton> lstButton = new List<NameButton>();
        public FormInput()
        {
            InitializeComponent();
        }

        private void ThuNhoMenu()
        {
            if (panelFunction.Width > 100)
            {
                panelFunction.Width = 54;
                btnThuNho.Image = OverTime.Properties.Resources.Right;
                foreach (Button bt in panelFunction.Controls.OfType<Button>())
                {
                    if (bt.Tag.ToString() != "0")
                    {
                        bt.Text = "";
                        bt.Width = bt.Height;
                        bt.ImageAlign = ContentAlignment.MiddleLeft;
                    }

                }
            }
        }



        private void LoadFormControll(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            panelMain.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
            if(form.Text == "FormEditOverTime" || form.Text == "FormInputFingerPrint")
            {
                Common.flagWait = false;
            }
            else { Common.flagWait = true; }
            
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.NavajoWhite;
            btnInputTime.BackColor = Color.Gainsboro;
            btnEditOverTime.BackColor = Color.Gainsboro;
            btnSpecialAdjust.BackColor = Color.Gainsboro;
            btnCheck.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.Gainsboro;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormHistoryRegistration());
            this.Focus();
        }

        private void btnInputTime_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Gainsboro;
            btnInputTime.BackColor = Color.NavajoWhite;
            btnEditOverTime.BackColor = Color.Gainsboro;
            btnSpecialAdjust.BackColor = Color.Gainsboro;
            btnCheck.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.Gainsboro;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormInputFingerPrint());
            this.Focus();
        }

        private void btnEditOverTime_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Gainsboro;
            btnInputTime.BackColor = Color.Gainsboro;
            btnEditOverTime.BackColor = Color.NavajoWhite;
            btnSpecialAdjust.BackColor = Color.Gainsboro;
            btnCheck.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.Gainsboro;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormEditOverTime());
            this.Focus();
        }


        private void btnThuNho_Click(object sender, EventArgs e)
        {
            if (panelFunction.Width > 100)
            {
                panelFunction.Width = 54;
                btnThuNho.Image = OverTime.Properties.Resources.Right;
                foreach (Button bt in panelFunction.Controls.OfType<Button>())
                {
                    if (bt.Tag.ToString() != "0")
                    {
                        bt.Text = "";
                        bt.Width = bt.Height;
                        bt.ImageAlign = ContentAlignment.MiddleLeft;
                    }

                }
            }
            else
            {
                panelFunction.Width = 130;
                btnThuNho.Image = OverTime.Properties.Resources.Left;
                foreach (Button bt in panelFunction.Controls.OfType<Button>())
                {
                    var findtext = lstButton.FirstOrDefault(x => x.Tag == bt.Tag.ToString());
                    if (findtext != null && bt.Tag.ToString() != "0")
                    {
                        bt.Text = findtext.Text;
                        bt.Width = 116;
                        bt.ImageAlign = ContentAlignment.MiddleRight;
                    }

                }
            }
        }


        private void LoadListButton()
        {
            foreach (Button bt in panelFunction.Controls.OfType<Button>())
            {
                NameButton n = new NameButton();
                n.Tag = bt.Tag.ToString();
                n.Text = bt.Text.ToString();
                lstButton.Add(n);
            }
        }

        private void CheckAction()
        {
            if(!string.IsNullOrEmpty(Common.UserLogin.Action))
            {
                if(Common.UserLogin.Action.ToLower() == "approve")
                {
                    btnCheck_Click(null, null);
                }
            }
            else
            {
                btnRegister_Click(null, null);
            }
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            BackgroundLoading BL = new BackgroundLoading(GetData, RequestCompleted);
            BL.Start();
            LoadListButton();
            CheckAction();
            CheckUserAndDecentralization();  
        }

        private static DataTable GetData()
        {
            GAMankuchi gAMankuchi = GAMankuchi.Instance();
            return null;
        }

        private static void RequestCompleted(DataTable dt)
        {

        }

        private void CheckUserAndDecentralization()
        {
            if (Common.UserLogin.UserName == "View")
            {
                btnInputTime.Enabled = btnSpecialAdjust.Enabled = false;
                btnEditOverTime.Enabled = btnGAWorkSpace.Enabled = false;
            }
            if (Common.UserLogin.Role == "Limitted")
            {
                if(Common.UserLogin.TypeUser == "Group")
                {
                    btnInputTime.Enabled = btnEditOverTime.Enabled = btnCheck.Enabled = btnGAWorkSpace.Enabled = btnSpecialAdjust.Enabled = false;
                }
                else if(Common.UserLogin.TypeUser == "Salary" || Common.UserLogin.TypeUser == "Admin")
                {
                    btnInputTime.Enabled = btnEditOverTime.Enabled = btnCheck.Enabled = btnGAWorkSpace.Enabled = btnSpecialAdjust.Enabled = true;
                }
                else
                {
                    btnEditOverTime.Enabled = btnCheck.Enabled = btnGAWorkSpace.Enabled = btnSpecialAdjust.Enabled = true;
                    btnInputTime.Enabled = false;
                }
            }
            if(Common.UserLogin.Role == "Approve")
            {
                btnEditOverTime.Enabled = btnCheck.Enabled = btnGAWorkSpace.Enabled = btnSpecialAdjust.Enabled = true;
                btnInputTime.Enabled = false;
            }
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Gainsboro;
            btnInputTime.BackColor = Color.Gainsboro;
            btnEditOverTime.BackColor = Color.Gainsboro;
            btnSpecialAdjust.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.Gainsboro;
            btnCheck.BackColor = Color.NavajoWhite;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormCheckAndApprove());
            this.Focus();
        }

        private void btnGAWorkSpace_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Gainsboro;
            btnInputTime.BackColor = Color.Gainsboro;
            btnEditOverTime.BackColor = Color.Gainsboro;
            btnSpecialAdjust.BackColor = Color.Gainsboro;
            btnCheck.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.NavajoWhite;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormGAWorkSpace());
            this.Focus();
        }


        private void btnSpecialAdjust_Click(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.Gainsboro;
            btnInputTime.BackColor = Color.Gainsboro;
            btnEditOverTime.BackColor = Color.Gainsboro;
            btnSpecialAdjust.BackColor = Color.NavajoWhite;
            btnCheck.BackColor = Color.Gainsboro;
            btnGAWorkSpace.BackColor = Color.Gainsboro;
            ThuNhoMenu();
            foreach (Form form in panelMain.Controls.OfType<Form>())
            {
                form.Close();
            }
            LoadFormControll(new FormSepcialAdjustOT());
            this.Focus();
        }


    }
}
