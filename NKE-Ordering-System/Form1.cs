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
                        DashboardForm dashboardForm = new DashboardForm();
                        dashboardForm.user_id = loginUser._Id;
                        dashboardForm.Show();
                        this.Hide();
                    }
                    else if (loginUser.isAdmin == true)
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Hide();
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
