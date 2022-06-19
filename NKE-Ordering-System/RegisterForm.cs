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
    public partial class RegisterForm : Form, InitialInterface
    {
        Staff registerUser = new Staff();
        public delegate void ValidateMessage(string str);
        public RegisterForm()
        {
            InitializeComponent();
            this.Icon = NKE_Ordering_System.Properties.Resources.Papirus_Team_Papirus_Apps_Cs_login;
        }

        private void errorMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        public void initialState()
        {
            textBoxAccessPassword.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            initialState();
        }

        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedIndex == 0)
            {
                initialState();
            }
            else if(comboBoxRole.SelectedIndex == 1)
            {
                textBoxAccessPassword.Enabled = true;
            }
        }

        public bool validationForm()
        {
            if(textBoxName.Text == string.Empty || textBoxPassword.Text == string.Empty || 
                comboBoxRole.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void resetState()
        {
            textBoxName.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            comboBoxRole.SelectedIndex = 0;
            textBoxAccessPassword.Text = string.Empty;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateMessage display = errorMessage;
                if (validationForm())
                {
                    registerUser._Id = registerUser.generateID();
                    registerUser._Name = textBoxName.Text;
                    registerUser._Password = textBoxPassword.Text;
                    registerUser._Role = comboBoxRole.SelectedItem.ToString();
                    if (comboBoxRole.SelectedIndex == 1)
                    {
                        registerUser.Access_Password = textBoxAccessPassword.Text;
                        registerUser.accessPasswordValidation();
                        if (registerUser.ValidateAdmin == true)
                        {
                            registerUser.SaveUser();
                            if(registerUser.exist == true)
                                display("User name already exists.");
                            else
                            {
                                resetState();
                                display("User registered.");
                            }
                        }
                        else
                            display("Invalid Access");
                    }
                    else if (comboBoxRole.SelectedIndex == 0)
                    {
                        registerUser.SaveUser();
                        if (registerUser.exist == true)
                            display("User name already exists.");
                        else
                        {
                            resetState();
                            display("User registered.");
                        }
                    }
                }
                else
                {
                    display("Please fill in all the empty fills");
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void RegisterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                buttonRegister_Click(sender, e);
        }

        private void buttonRegister_MouseHover(object sender, EventArgs e)
        {
            toolTipButton.Show("Press Enter", buttonRegister);
        }
    }
}
