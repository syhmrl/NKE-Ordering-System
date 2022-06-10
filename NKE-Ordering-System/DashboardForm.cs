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
    public partial class DashboardForm : Form, InitialInterface
    {
        TableController table = new TableController();
        ItemController item = new ItemController();
        OrderController order = new OrderController();

        public delegate void ValidateMessage(string str);

        public int user_id { get; set; }
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                initialState();
                
                item.getItemType();
                
                comboBoxMenu.DataSource = item.allItemType;

                initialTableData();

                dataGridViewOrderList.ColumnCount = 4;
                dataGridViewOrderList.Columns[0].Name = "No.";
                dataGridViewOrderList.Columns[1].Name = "Name";
                dataGridViewOrderList.Columns[2].Name = "Type";
                dataGridViewOrderList.Columns[3].Name = "Price";
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void initialTableData()
        {
            comboBoxTable.Items.Clear();
            comboBoxActiveTable.Items.Clear();

            table.showAvailableTable();
            table.showActiveTable();

            foreach (var t in table.allAvailableTable)
                comboBoxTable.Items.Add(t);

            foreach (var at in table.allActiveTable)
                comboBoxActiveTable.Items.Add(at);

            /*comboBoxTable.DataSource = table.allAvailableTable;
            comboBoxActiveTable.DataSource = table.allActiveTable;*/

            table.allAvailableTable.Clear();
            table.allActiveTable.Clear();

            comboBoxTable.ResetText();
            comboBoxActiveTable.ResetText();

            comboBoxTable.SelectedIndex = -1;
            comboBoxActiveTable.SelectedIndex = -1;
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form1 loginForm = new Form1();
            loginForm.Show();*/
            Application.Exit();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.StartPosition = FormStartPosition.CenterScreen;
            paymentForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        public void initialState()
        {
            comboBoxStatus.Enabled = true;
            comboBoxOrderType.Enabled = false;
            comboBoxTable.Enabled = false;
            comboBoxMenu.Enabled = false;
            comboBoxItem.Enabled = false;
            comboBoxActiveTable.Enabled = false;
            comboBoxTakeAway.Enabled = false;
            numericUpDownQuantity.Enabled = false;
            buttonAddOrder.Enabled = false;
            buttonClear.Enabled = false;
            buttonRemove.Enabled = false;
            buttoUpdateOrder.Enabled = false;
        }
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxOrderType.ResetText();
            comboBoxOrderType.SelectedIndex = -1;

            if (comboBoxStatus.SelectedText != null)
            {
                comboBoxOrderType.Enabled = true;
                comboBoxTable.Enabled = false;
                comboBoxMenu.Enabled = false;
                comboBoxItem.Enabled = false;
                comboBoxActiveTable.Enabled = false;
                comboBoxTakeAway.Enabled = false;
                numericUpDownQuantity.Enabled = false;
                buttonAddOrder.Enabled = false;
                buttonClear.Enabled = false;
                buttonRemove.Enabled = false;
                buttoUpdateOrder.Enabled = false;
            }
            
        }

        private void comboBoxOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxOrderType.SelectedIndex == 0) // Dine-In
            {
                if(comboBoxStatus.SelectedIndex == 0) // New Order
                {
                    comboBoxTable.Enabled = true;
                    comboBoxActiveTable.Enabled = false;
                    comboBoxTakeAway.Enabled = false;
                    comboBoxMenu.Enabled = true;
                    comboBoxItem.Enabled = true;
                    numericUpDownQuantity.Enabled = true;
                    buttonAddOrder.Enabled = true;
                    buttoUpdateOrder.Enabled = false;
                }
                else if(comboBoxStatus.SelectedIndex == 1) // Active Order
                {
                    comboBoxTable.Enabled = false;
                    comboBoxActiveTable.Enabled = true;
                    comboBoxTakeAway.Enabled = false;
                    comboBoxMenu.Enabled = true;
                    comboBoxItem.Enabled = true;
                    numericUpDownQuantity.Enabled = true;
                    buttonAddOrder.Enabled = false;
                    buttoUpdateOrder.Enabled = true;
                }
            }
            else if(comboBoxOrderType.SelectedIndex == 1) // TA
            {
                if(comboBoxStatus.SelectedIndex == 0) // New Order
                {
                    comboBoxMenu.Enabled = true;
                    comboBoxTakeAway.Enabled = false;
                    comboBoxTable.Enabled = false;
                    comboBoxActiveTable.Enabled = false;
                    comboBoxItem.Enabled = true;
                    numericUpDownQuantity.Enabled = true;
                    buttonAddOrder.Enabled = true;
                    buttoUpdateOrder.Enabled = false;
                }
                else if(comboBoxStatus.SelectedIndex == 1) // Active Order
                {
                    comboBoxMenu.Enabled = true;
                    comboBoxTakeAway.Enabled = true;
                    comboBoxTable.Enabled = false;
                    comboBoxActiveTable.Enabled = false;
                    comboBoxItem.Enabled = true;
                    numericUpDownQuantity.Enabled = true;
                    buttonAddOrder.Enabled = false;
                    buttoUpdateOrder.Enabled = true;
                }
            }
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (comboBoxTable.SelectedIndex != -1) // if table exists
            {
                comboBoxMenu.Enabled = true;
            }*/
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(comboBoxMenu.SelectedIndex != -1)
            {*/
             // comboBoxItem.Enabled = true;
            string menuName = comboBoxMenu.SelectedItem.ToString();

            comboBoxItem.Items.Clear();
            comboBoxItem.DataSource = null;

            item.Item_Type = menuName;

            item.showItem();

            foreach (var i in item.allItem)
                comboBoxItem.Items.Add(i);
            // comboBoxItem.DataSource = item.allItem;

            item.allItem.Clear();
            // }
        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.Item_Name = comboBoxItem.SelectedItem.ToString();

            item.getItemData();

            labelPrice.Text = item.Item_Price.ToString();
        }

        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            decimal totalPrice = 0;

            item.Item_Name = comboBoxItem.SelectedItem.ToString();

            item.getItemData();

            labelPrice.Text = item.Item_Price.ToString();

            totalPrice = decimal.Parse(labelPrice.Text) * numericUpDownQuantity.Value;

            labelPrice.Text = totalPrice.ToString();

            totalPrice = 0;
        }

        public bool validationForm()
        {
            if (comboBoxOrderType.SelectedIndex == 0) // Dine-In
            {
                if (comboBoxStatus.SelectedIndex == 0) // New Order
                {
                    if (comboBoxStatus.SelectedItem == null || comboBoxOrderType.SelectedItem == null ||
                        comboBoxTable.SelectedItem == null || comboBoxItem.SelectedItem == null ||
                        comboBoxMenu.SelectedItem == null || numericUpDownQuantity.Text == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else // Active Order
                {
                    if (comboBoxStatus.SelectedItem == null || comboBoxOrderType.SelectedItem == null ||
                        comboBoxItem.SelectedItem == null || comboBoxMenu.SelectedItem == null ||
                        comboBoxActiveTable.SelectedItem == null || numericUpDownQuantity.Text == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else// TA
            {
                if (comboBoxStatus.SelectedIndex == 0) // New Order
                {
                    if (comboBoxStatus.SelectedItem == null || comboBoxOrderType.SelectedItem == null ||
                        comboBoxItem.SelectedItem == null || comboBoxMenu.SelectedItem == null ||
                        numericUpDownQuantity.Text == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else// Active Order
                {
                    if (comboBoxStatus.SelectedItem == null || comboBoxOrderType.SelectedItem == null ||
                        comboBoxTakeAway.SelectedItem == null || comboBoxItem.SelectedItem == null ||
                        comboBoxMenu.SelectedItem == null || numericUpDownQuantity.Text == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        private void errorMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        // New Order
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            ValidateMessage display = errorMessage;

            try
            {
                if(validationForm())
                {
                    if(comboBoxOrderType.SelectedIndex == 0) // Dine In
                    {
                        order.OrderID = order.generateID();
                        order.Order_Time = DateTime.Now;
                        order.Order_Status = 1;
                        order.Order_Type = 1;
                        order.Total_Price = decimal.Parse(labelPrice.Text);
                        order.UserID = user_id;

                        item.Item_Name = comboBoxItem.SelectedItem.ToString();

                        item.getItemID();

                        item.Order_Item_ID = item.generateID();
                        item.Order_ID = order.OrderID;
                        item.Quantity = int.Parse(numericUpDownQuantity.Text);

                        table.Name = comboBoxTable.SelectedItem.ToString();

                        table.getTableID();

                        order.Order_Table_ID = order.generateID();
                        order.TableID = table.Id;

                        table.Status = 1;

                        order.Store();
                        table.UpdateTableStatus();
                        item.StoreOrderItem();

                        initialTableData();

                        display("New dine-in order successfully added.");
                    }
                    else // take away
                    {
                        display("New take away order successfully added.");
                    }
                }
                else
                {
                    display("Please fill all the form.");
                }
            }
            catch(Exception error)
            {
                display(error.Message);
            }
        }

        // Active Order
        private void buttoUpdateOrder_Click(object sender, EventArgs e)
        {
            ValidateMessage display = errorMessage;

            try
            {
                if(validationForm())
                {
                    if(comboBoxOrderType.SelectedIndex == 0) // Dine In
                    {

                        display("Order dine-in updated");
                    }
                    else // Take Away
                    {
                        display("Order take away updated");
                    }
                }
                else
                {
                    display("Please fill all form");
                }
            }
            catch(Exception ex)
            {
                display(ex.Message);
            }
        }

        private void numericUpDownQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        
    }
}