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
        
        // FormController form = new FormController();

        // public bool isClosed = false;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            OrderController order = new OrderController();
            TableController table = new TableController();
            ItemController item = new ItemController();

            initialState();
            initialTableData();
        }

        public void initialTableData()
        {
            TableController table = new TableController();

            comboBoxTable.Items.Clear();

            table.showActiveTable();

            foreach (var at in table.allActiveTable)
                comboBoxTable.Items.Add(at);

            table.allActiveTable.Clear();

            comboBoxTable.ResetText();
            comboBoxTable.SelectedIndex = -1;
        }

        public void initialState()
        {
            comboBoxType.Enabled = true;
            comboBoxTable.Enabled = false;
            comboBoxTakeAway.Enabled = false;
            comboBoxPaymentType.Enabled = false;
            textBoxAmountPaid.Enabled = false;
            buttonPayment.Enabled = false;
            labelTotal.Text = "0.00";
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

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderController order = new OrderController();
            TableController table = new TableController();

            table.Name = comboBoxTable.SelectedItem.ToString();
            table.getOrderID();

            order.OrderID = table.Order_ID;

            order.getTotalPrice();

            labelTotal.Text = order.Total_Price.ToString();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                OrderController order = new OrderController();
                TableController table = new TableController();
                ItemController item = new ItemController();
                PaymentController payment = new PaymentController();

                if (validationForm())
                {
                    if(comboBoxType.SelectedIndex == 0) // Dine-In
                    {
                        payment.Payment_ID = payment.generateID();
                        payment.Payment_Amount = decimal.Parse(labelTotal.Text);
                        payment.Payment_Type = comboBoxPaymentType.SelectedIndex;
                        payment.Payment_Status = 1;

                        table.Name = comboBoxTable.SelectedItem.ToString();
                        table.getOrderID();

                        order.OrderID = table.Order_ID;
                        payment.Order_ID = table.Order_ID;
                        item.Order_ID = table.Order_ID;

                        order.Order_Status = 2;
                        table.Status = 0;

                        if(comboBoxPaymentType.SelectedIndex == 0) // Bank
                        {
                            // MessageBox.Show(order.Order_Status.ToString());
                            order.UpdateStatus();
                            // order.Delete();
                            table.UpdateTableStatus();
                            payment.Store();
                            item.DeleteAllOrder();
                            // order.DeleteOrderTable();

                            initialTableData();
                            initialState();

                            MessageBox.Show("Dine-In | Bank | Payment Successfull");
                        }
                        else // Cash
                        {
                            decimal balance = decimal.Parse(textBoxAmountPaid.Text) - decimal.Parse(labelTotal.Text);
                            if (balance < 0)
                                MessageBox.Show("Your Balance is inefficient.");
                            else
                            {
                                order.UpdateStatus();
                                table.UpdateTableStatus();
                                payment.Store();
                                item.DeleteAllOrder();
                                // order.DeleteOrderTable();

                                initialTableData();
                                initialState();

                                MessageBox.Show($"Your Balance is RM{balance}\n" +
                                    $"Dine-In | Cash | Payment Successfull "); // Display Balance
                            }
                            
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

        private bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            return false;
        }

        private void textBoxAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //check if '.'
            char sepratorChar = 's';
            if (e.KeyChar == '.')
            {
                // check if it's in the beginning of text not accept
                if (textBoxAmountPaid.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (textBoxAmountPaid.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.'
                if (alreadyExist(textBoxAmountPaid.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' is in middle of a number and after it is not a number greater than 99
                if (textBoxAmountPaid.SelectionStart != textBoxAmountPaid.Text.Length && e.Handled == false)
                {
                    // '.' is in the middle
                    string AfterDotString = textBoxAmountPaid.Text.Substring(textBoxAmountPaid.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a dot exist
                if (alreadyExist(textBoxAmountPaid.Text, ref sepratorChar))
                {
                    int sepratorPosition = textBoxAmountPaid.Text.IndexOf(sepratorChar);
                    string afterSepratorString = textBoxAmountPaid.Text.Substring(sepratorPosition + 1);
                    if (textBoxAmountPaid.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();*/
        }
    }
}
