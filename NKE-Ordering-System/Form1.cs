using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKE_Ordering_System
{
    public partial class Form1 : Form
    {
        Staff loginUser = new Staff();
        public delegate void ValidateMessage(string str);
        public Form1()
        {
            InitializeComponent();
            this.Icon = NKE_Ordering_System.Properties.Resources.Papirus_Team_Papirus_Apps_Cs_login;
            this.BackgroundImage = NKE_Ordering_System.Properties.Resources.background_profile_2;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void buttonToRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regisForm = new RegisterForm();
            regisForm.Show();
        }

        private bool formValidation()
        {
            if(textBoxName.Text == string.Empty || textBoxPassword.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void errorMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateMessage display = errorMessage;

                if (formValidation())
                {
                    loginUser._Name = textBoxName.Text;
                    loginUser._Password = textBoxPassword.Text;
                    loginUser.loginUser();
                    
                    if (loginUser.isStaff == true)
                    {
                        this.Hide();
                        DashboardForm dashboardForm = new DashboardForm();
                        dashboardForm.user_id = loginUser._Id;
                        dashboardForm.ShowDialog();
                        dashboardForm = null;
                        this.Show();
                        textBoxName.Text = string.Empty;
                        textBoxPassword.Text = string.Empty;
                    }
                    else if (loginUser.isAdmin == true)
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                        adminForm = null;
                        this.Show();
                        textBoxName.Text = string.Empty;
                        textBoxPassword.Text = string.Empty;
                    }
                }
                else
                    display("Please fill all form.");
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                buttonLogin_Click(sender, e);

            if (e.Alt && e.Shift && e.KeyCode == Keys.R)
                buttonToRegister_Click(sender, e);
        }

        private void buttonLogin_MouseHover(object sender, EventArgs e)
        {
            toolTipButton.Show("Press Enter", buttonLogin);
        }

        private void buttonToRegister_MouseHover(object sender, EventArgs e)
        {
            toolTipButton.Show("Press Alt + Shift + R", buttonToRegister);
        }
    }
}
