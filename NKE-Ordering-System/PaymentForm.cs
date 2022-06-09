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
    public partial class PaymentForm : Form, InitialInterface
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            initialState();
        }

        public void initialState()
        {
            comboBoxType.Enabled = true;
            comboBoxTable.Enabled = false;
            comboBoxTakeAway.Enabled = false;
            comboBoxPaymentType.Enabled = false;
            textBoxAmountPaid.Enabled = false;
            buttonPayment.Enabled = false;
        }

        public bool validationForm()
        {
            if (comboBoxType.SelectedIndex == 0) // Dine-In
            {
                if(comboBoxPaymentType.SelectedIndex == 0) // Bank
                {
                    if (comboBoxType.SelectedItem == null || comboBoxTable.SelectedItem == null ||
                        comboBoxPaymentType.SelectedItem == null)
                        return false;
                    else
                    {
                        return true;
                    }
                }
                else // Cash
                {
                    if (comboBoxType.SelectedItem == null || comboBoxTable.SelectedItem == null ||
                        comboBoxPaymentType.SelectedItem == null || textBoxAmountPaid.Text == string.Empty)
                        return false;
                    else
                    {
                        return true;
                    }
                }
                
            }
            else // Take Away
            {
                if (comboBoxPaymentType.SelectedIndex == 0) // Bank
                {
                    if (comboBoxType.SelectedItem == null || comboBoxTakeAway.SelectedItem == null ||
                        comboBoxPaymentType.SelectedItem == null)
                        return false;
                    else
                    {
                        return true;
                    }
                }
                else // Cash
                {
                    if (comboBoxType.SelectedItem == null || comboBoxTakeAway.SelectedItem == null ||
                        comboBoxPaymentType.SelectedItem == null || textBoxAmountPaid.Text == string.Empty)
                        return false;
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxType.SelectedIndex == 0) // Dine-In
            {
                comboBoxTable.Enabled = true;
                comboBoxTakeAway.Enabled = false;
                comboBoxPaymentType.Enabled = true;
            }
            else // Take Away
            {
                comboBoxTable.Enabled = false;
                comboBoxTakeAway.Enabled = true;
                comboBoxPaymentType.Enabled = true;
            }
        }

        private void comboBoxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPaymentType.SelectedIndex == 0) // Bank
            {
                textBoxAmountPaid.Enabled = false;
                buttonPayment.Enabled = true;
            }
            else // Cash
            {
                textBoxAmountPaid.Enabled = true; 
                buttonPayment.Enabled = true;
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if(validationForm())
                {
                    if(comboBoxType.SelectedIndex == 0) // Dine-In
                    {
                        if(comboBoxPaymentType.SelectedIndex == 0) // Bank
                        {
                            MessageBox.Show("Dine-In | Bank | Payment Successfull");
                        }
                        else // Cash
                        {
                            MessageBox.Show("Dine-In | Cash | Payment Successfull"); // Display Balance
                        }
                    }
                    else // Take Away
                    {
                        if (comboBoxPaymentType.SelectedIndex == 0) // Bank
                        {
                            MessageBox.Show("Take Away | Bank | Payment Successfull");
                        }
                        else // Cash
                        {
                            MessageBox.Show("Take Away | Cash | Payment Successfull"); // Display Balance
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        
    }
}
