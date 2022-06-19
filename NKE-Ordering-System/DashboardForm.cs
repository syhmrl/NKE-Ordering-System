using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKE_Ordering_System
{
    public partial class DashboardForm : Form, InitialInterface
    {
        
        // FormController form = new FormController();

        NKEOrderDataContext db = new NKEOrderDataContext();

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
                OrderController orders = new OrderController();
                TableController table = new TableController();
                ItemController item = new ItemController();

                initialState();
                
                item.getItemType();
                
                comboBoxMenu.DataSource = item.allItemType;

                initialTableData();
                initialTakeAwayData();

                //int result = item.debug();
                //MessageBox.Show(result.ToString());
                /*dataGridViewOrderList.ColumnCount = 5;
                dataGridViewOrderList.Columns[0].Name = "No.";
                dataGridViewOrderList.Columns[1].Name = "Name";
                dataGridViewOrderList.Columns[2].Name = "Type";
                dataGridViewOrderList.Columns[3].Name = "Price";
                dataGridViewOrderList.Columns[4].Name = "Quantity";*/
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void initialTableData()
        {
            TableController table = new TableController();

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

        public void initialTakeAwayData()
        {
            OrderController order = new OrderController();

            comboBoxTakeAway.Items.Clear();

            order.showTakeAwayID();

            foreach (var t in order.takeAwayTable)
                comboBoxTakeAway.Items.Add(t);

            order.takeAwayTable.Clear();

            comboBoxTakeAway.ResetText();

            comboBoxTakeAway.SelectedIndex = -1;
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form1 loginForm = new Form1();
            loginForm.Show();*/
            // Application.Exit();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*PaymentForm paymentForm = new PaymentForm();
            paymentForm.StartPosition = FormStartPosition.CenterScreen;
            paymentForm.Show();*/
            this.Hide();
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.StartPosition = FormStartPosition.CenterScreen;
            paymentForm.ShowDialog();
            paymentForm = null;
            this.Show();
            OrderController order = new OrderController();
            TableController table = new TableController();
            ItemController item = new ItemController();
            this.initialTableData();
            this.initialState();
            this.initialTakeAwayData();
            dataGridViewOrderList.DataSource = null;
            // this.loadOrderTable(order.OrderID);

            /*if(paymentForm.isClosed == true)
            {
                this.Refresh();
                initialTableData();
                loadOrderTable();
            }*/
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            buttoUpdateOrder.Enabled = false;
            buttonDeleteAll.Enabled = false;
            dataGridViewOrderList.Enabled = false;
            labelPrice.Text = "0.00";
            labelTotalPrice.Text = "0.00";
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
                buttonDeleteAll.Enabled = false;
                buttoUpdateOrder.Enabled = false;
                dataGridViewOrderList.Enabled = false;
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
                    buttonDeleteAll.Enabled = false;
                    buttonRefresh.Enabled = false;
                    dataGridViewOrderList.Enabled = false;
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
                    buttonDeleteAll.Enabled = false;
                    buttonRefresh.Enabled = true;
                    dataGridViewOrderList.Enabled = true;
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
                    buttonDeleteAll.Enabled = false;
                    buttonRefresh.Enabled = false;
                    dataGridViewOrderList.Enabled = false;
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
                    buttonDeleteAll.Enabled = false;
                    buttonRefresh.Enabled = true;
                    dataGridViewOrderList.Enabled = true;
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

        private void comboBoxActiveTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxActiveTable.SelectedIndex != -1)
                buttonDeleteAll.Enabled = true;

            OrderController order = new OrderController();
            TableController table = new TableController();
            ItemController item = new ItemController();

            table.Name = comboBoxActiveTable.SelectedItem.ToString();
            table.getOrderID();
            // table.getTableID();
            // order.TableID = table.Id;
            // order.getOrderID();
            // int count = table.debug();
            // order.OrderID = order.OrderID;
            order.OrderID = table.Order_ID;
            item.Order_ID = order.OrderID;
            // MessageBox.Show(order.OrderID.ToString());
            order.getTotalPrice();

            labelTotalPrice.Text = order.Total_Price.ToString();

            // item.Show();

            // var first = item.allOrder[0].;

            loadOrderTable(order.OrderID);

            // MessageBox.Show(item.allOrder.ToString());

            // dataGridViewOrderList.Rows.Add(1, item.Item_Name, item.Item_Type, item.Item_Price, item.Quantity);


        }
        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemController item = new ItemController();
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
            TableController table = new TableController();
            ItemController item = new ItemController();

            item.Item_Name = comboBoxItem.SelectedItem.ToString();

            item.getItemData();
            

            if(comboBoxStatus.SelectedIndex == 1 && comboBoxActiveTable.SelectedIndex != -1)
            {
                // Get Order ID
                table.Name = comboBoxActiveTable.SelectedItem.ToString();
                table.getOrderID();

                item.Order_ID = table.Order_ID;

                item.getItemID();
                item.getQuantity();

                if(item.exist == true)
                    numericUpDownQuantity.Value = item.Quantity;
                else
                    numericUpDownQuantity.Value = 1;
            }

            labelPrice.Text = item.Item_Price.ToString();
        }

        private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            ItemController item = new ItemController();

            decimal totalPrice = 0;

            item.Item_Name = comboBoxItem.SelectedItem.ToString();

            item.getItemData();

            labelPrice.Text = item.Item_Price.ToString();

            totalPrice = decimal.Parse(labelPrice.Text) * numericUpDownQuantity.Value;

            labelPrice.Text = totalPrice.ToString();

            totalPrice = 0;
        }

        public void loadOrderTable(int id)
        {
            // item = new ItemController();

            var queryItem =
                (from i in db.Items
                 join o_item in db.Order_Items on i.ItemID equals o_item.ItemID
                 where o_item.OrderID == id
                 select new
                 {
                     Id = o_item.OrderItemID,
                     Name = i.ItemName,
                     Type = i.ItemType,
                     Price = i.ItemPrice,
                     Quantity = o_item.Quantity
                 }).ToList();

            dataGridViewOrderList.DataSource = queryItem;
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
                        OrderController order = new OrderController();
                        TableController table = new TableController();
                        ItemController item = new ItemController();
                        // Store Order Table
                        order.OrderID = order.generateID();
                        order.Order_Time = DateTime.Now;
                        order.Order_Status = 1;
                        order.Order_Type = 1;
                        order.Total_Price = decimal.Parse(labelPrice.Text);
                        order.UserID = user_id;

                        // Get Table ID
                        table.Name = comboBoxTable.SelectedItem.ToString();
                        table.getTableID(); // Get Table Id by Name

                        // Store Order_Table's Table
                        order.Order_Table_ID = order.generateOrderTableID();
                        order.TableID = table.Id;

                        // Set Table Status
                        table.Status = 1;

                        order.Store(); // Store Order

                        // Item ID
                        item.Item_Name = comboBoxItem.SelectedItem.ToString();

                        item.getItemID(); // Get Item Id by Name

                        // Store Order_Item Table
                        item.Order_Item_ID = item.generateOrderItemId();
                        item.Order_ID = order.OrderID;
                        item.Quantity = int.Parse(numericUpDownQuantity.Text);

                        
                        table.UpdateTableStatus(); // Update Table Status
                        item.StoreOrderItem(); // Store Order_Item

                        initialTableData(); // Reset Form

                        // display(order.OrderID.ToString());

                        display("New dine-in order successfully added.");
                    }
                    else // take away
                    {
                        OrderController order = new OrderController();
                        ItemController item = new ItemController();
                        // Store Order Table
                        order.OrderID = order.generateID();
                        order.Order_Time = DateTime.Now;
                        order.Order_Status = 1;
                        order.Order_Type = 2;
                        order.Total_Price = decimal.Parse(labelPrice.Text);
                        order.UserID = user_id;

                        order.storeTA(); // Store Order

                        // Item ID
                        item.Item_Name = comboBoxItem.SelectedItem.ToString();

                        item.getItemID(); // Get Item Id by Name

                        // Store Order_Item Table
                        item.Order_Item_ID = item.generateOrderItemId();
                        item.Order_ID = order.OrderID;
                        item.Quantity = int.Parse(numericUpDownQuantity.Text);

                        item.StoreOrderItem(); // Store Order_Item

                        initialTakeAwayData(); // Reset Form

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
                        OrderController order = new OrderController();
                        TableController table = new TableController();
                        ItemController item = new ItemController();
                        // Get Order ID
                        table.Name = comboBoxActiveTable.SelectedItem.ToString();
                        table.getOrderID(); // Get Order Id by Name

                        // Item ID
                        item.Item_Name = comboBoxItem.SelectedItem.ToString();

                        item.getItemID(); // Get Item Id by Name

                        // Update Order_Item
                        item.Order_ID = table.Order_ID;
                        item.Order_Item_ID = item.generateOrderItemId();
                        item.Quantity = int.Parse(numericUpDownQuantity.Text);

                        item.UpdateOrderItem();

                        if (item.exist == false)
                            item.StoreOrderItem();

                        order.OrderID = table.Order_ID;
                        order.Total_Price = order.calculateTotalPrice();
                        //int count = order.debug();
                        order.UpdateTotalPrice();
                        loadOrderTable(order.OrderID);
                        // display(order.Total_Price.ToString());
                        labelTotalPrice.Text = order.Total_Price.ToString();

                        display("Order dine-in updated");
                    }
                    else // Take Away
                    {
                        OrderController order = new OrderController();
                        ItemController item = new ItemController();

                        order.getOrderIDByType();

                        foreach (var t in order.takeAwayTable)
                            comboBoxTakeAway.Items.Add(t);

                        // Get Order ID
                        // staff._Name = comboBoxTakeAway.SelectedItem.ToString();
                        order.getOrderIDByType(); // Get Order Id by Name

                        // Item ID
                        item.Item_Name = comboBoxItem.SelectedItem.ToString();

                        item.getItemID(); // Get Item Id by Name

                        // Update Order_Item
                        item.Order_ID = order.OrderID;
                        item.Order_Item_ID = item.generateOrderItemId();
                        item.Quantity = int.Parse(numericUpDownQuantity.Text);

                        item.UpdateOrderItem();

                        if (item.exist == false)
                            item.StoreOrderItem();

                        order.OrderID = item.Order_ID;
                        order.Total_Price = order.calculateTotalPrice();
                        //int count = order.debug();
                        order.UpdateTotalPrice();
                        loadOrderTable(order.OrderID);
                        // display(order.Total_Price.ToString());
                        labelTotalPrice.Text = order.Total_Price.ToString();
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

        private void dataGridViewOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ValidateMessage display = errorMessage;

            try
            {
                if(comboBoxOrderType.SelectedIndex == 0)
                { 
                OrderController order = new OrderController();
                TableController table = new TableController();
                ItemController item = new ItemController();
                string message = "Do you confirm to delete this item?";
                string title = "Delete Item";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        // Get Order ID
                        table.Name = comboBoxActiveTable.SelectedItem.ToString();
                        table.getOrderID();
                        /*table.getTableID();
                        order.TableID = table.Id;
                        order.getOrderID();*/

                        // Get Order Item ID
                        item.Order_Item_ID = Convert.ToInt32(dataGridViewOrderList.Rows[e.RowIndex].Cells[0].FormattedValue);

                        // Delete Data
                        item.DeleteOrder();

                        // Update Total Price
                        order.OrderID = table.Order_ID;
                        order.Total_Price = order.calculateTotalPrice();
                        order.UpdateTotalPrice();
                        labelTotalPrice.Text = order.Total_Price.ToString();

                        item.Order_ID = table.Order_ID;
                        // Reset Table
                        loadOrderTable(order.OrderID);

                        item.checkStatus(); // Check if any item exist after delete

                        if (item.exist == false)
                        {
                            table.Status = 0; // Set Table Status
                            table.getTableID(); // Get Table ID based on Table Name
                            table.UpdateTableStatus(); // Update Table Status based on Table Id
                            order.Delete(); // Delete Order and Order Table based Order Id
                            initialTableData(); // Reset Form
                            initialTakeAwayData();
                        }

                        display("Item Succesfully Deleted");
                    }
                }
                else
                {
                    OrderController order = new OrderController();
                    ItemController item = new ItemController();
                    string message = "Do you confirm to delete this item?";
                    string title = "Delete Item";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);

                    if (result == DialogResult.Yes)
                    {
                        // Get Order ID
                        order.getOrderIDByType();
                        /*table.Name = comboBoxActiveTable.SelectedItem.ToString();
                        table.getOrderID();*/
                        /*table.getTableID();
                        order.TableID = table.Id;
                        order.getOrderID();*/

                        // Get Order Item ID
                        item.Order_Item_ID = Convert.ToInt32(dataGridViewOrderList.Rows[e.RowIndex].Cells[0].FormattedValue);

                        // Delete Data
                        item.DeleteOrder();

                        // Update Total Price
                        //order.OrderID = item.Order_ID;
                        order.Total_Price = order.calculateTotalPrice();
                        order.UpdateTotalPrice();
                        labelTotalPrice.Text = order.Total_Price.ToString();

                        //item.Order_ID = table.Order_ID;
                        // Reset Table
                        loadOrderTable(order.OrderID);

                        item.checkStatus(); // Check if any item exist after delete

                        if (item.exist == false)
                        {
                            order.Delete(); // Delete Order and Order Table based Order Id
                            initialTableData(); // Reset Form
                            initialTakeAwayData();
                        }

                        display("Item Succesfully Deleted");
                    }
                }
            }
            catch(Exception error)
            {
                display(error.Message);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ValidateMessage display = errorMessage;

            try
            {
                // Reset
                initialTableData();
                initialTakeAwayData();
                // loadOrderTable();

                display("Table Refreshed");
            }
            catch(Exception error)
            {
                display(error.Message);
            }
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            ValidateMessage display = errorMessage;

            try
            {
                OrderController order = new OrderController();
                TableController table = new TableController();
                ItemController item = new ItemController();

                string message = "Do you confirm to canceled this order?";
                string title = "Delete Order";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    table.Name = comboBoxActiveTable.SelectedItem.ToString();
                    table.getOrderID();

                    item.Order_ID = table.Order_ID;
                    order.OrderID = table.Order_ID;
                    table.Status = 0;

                    table.getTableID(); // Get Table ID based on Table Name
                    table.UpdateTableStatus(); // Update Table Status based on Table Id
                    order.getOrderIDByType();
                    item.DeleteAllOrder(); // Delete all item
                    order.Delete(); // Delete Order and Order Table based Order Id

                    // Reset
                    initialTableData();
                    initialTakeAwayData();
                    loadOrderTable(order.OrderID);

                    MessageBox.Show("Order Canceled Successfully", title);
                }
            }
            catch(Exception error)
            {
                display(error.Message);
            }
        }

        private void numericUpDownQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void comboBoxTakeAway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTakeAway.SelectedItem != null)
            {
                if (comboBoxActiveTable.SelectedIndex != -1)
                    buttonDeleteAll.Enabled = true;

                OrderController order = new OrderController();
                ItemController item = new ItemController();

                //order.OrderID = (int) comboBoxActiveTable.SelectedItem;
                order.getOrderIDByType();
                // table.getTableID();
                // order.TableID = table.Id;
                // order.getOrderID();
                // int count = table.debug();
                // order.OrderID = order.OrderID;
                //order.OrderID = table.Order_ID;
                item.Order_ID = order.OrderID;
                // MessageBox.Show(order.OrderID.ToString());
                order.getTotalPrice();

                labelTotalPrice.Text = order.Total_Price.ToString();

                // item.Show();

                // var first = item.allOrder[0].;

                loadOrderTable(order.OrderID);

                // MessageBox.Show(item.allOrder.ToString());

                // dataGridViewOrderList.Rows.Add(1, item.Item_Name, item.Item_Type, item.Item_Price, item.Quantity);

            }
            else
            {
                MessageBox.Show("error");
            }


        }
    }
}