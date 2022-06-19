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
    public partial class AdminForm : Form
    {
        TableController table = new TableController();
        ItemController item = new ItemController();
        public AdminForm()
        {
            InitializeComponent();
            this.Icon = NKE_Ordering_System.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Administrator;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                initialTableData();
                // table.showTable();
                item.getItemType();

                // comboBoxTable.DataSource = table.allTable;
                // comboBoxAMenuCategory.DataSource = item.allItemType;
                comboBoxSMenuCategory.DataSource = item.allItemType;
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Application.Exit();
        }

        

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();*/
            this.Close();
        }

        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.O)
            {
                logoutToolStripMenuItem_Click(sender, e);
            }
        }

        public void initialTableData()
        {
            try
            {
                comboBoxTable.Items.Clear();

                table.showAllTable();

                foreach (var t in table.allTable)
                    comboBoxTable.Items.Add(t);

                table.allTable.Clear();

                comboBoxTable.ResetText();
                comboBoxTable.SelectedIndex = -1;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                table.Name = comboBoxTable.SelectedItem.ToString();
                table.getTableID();

                textBoxNewTable.Text = table.Name;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void comboBoxSMenuCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // string menuName = "";

                // menuName = comboBoxSMenuCategory.SelectedItem.ToString();
                comboBoxUDMenuItem.Items.Clear();
                comboBoxUDMenuItem.DataSource = null;

                item.Item_Type = comboBoxSMenuCategory.SelectedItem.ToString();

                item.showItem();
                foreach (var i in item.allItem)
                    comboBoxUDMenuItem.Items.Add(i);
                // comboBoxUDMenuItem.DataSource = item.allItem;
                

                item.allItem.Clear();

                comboBoxUDMenuItem.ResetText();
                comboBoxUDMenuItem.SelectedIndex = -1;
                textBoxUDPrice.Text = string.Empty;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void comboBoxUDMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // MessageBox.Show(comboBoxUDMenuItem.SelectedItem.ToString());
                item.Item_Name = comboBoxUDMenuItem.SelectedItem.ToString();

                item.getItemData();

                textBoxNewItem.Text = item.Item_Name;
                textBoxUDPrice.Text = item.Item_Price.ToString();

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public bool validateAddItem()
        {
            if(comboBoxAMenuCategory.SelectedItem == null || textBoxMenuItem.Text == string.Empty || textBoxPrice.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateCrudItem()
        {
            if(comboBoxSMenuCategory.SelectedItem == null || comboBoxUDMenuItem.SelectedItem == null ||
                textBoxNewItem.Text == string.Empty || textBoxUDPrice.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validateAddTable()
        {
            if (textBoxTable.Text == string.Empty)
                return false;
            else
                return true;
        }

        public bool validateCrudTable()
        {
            if (comboBoxTable.SelectedItem == null || textBoxNewTable.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(validateAddItem())
                {
                    item.Item_ID = item.generateID();
                    item.Item_Name = textBoxMenuItem.Text;
                    item.Item_Price = decimal.Parse(textBoxPrice.Text);
                    item.Item_Type = comboBoxAMenuCategory.SelectedItem.ToString();

                    item.Store();
                    
                    if(item.exist == true)
                    {
                        MessageBox.Show("Item already exist.");
                    }
                    else
                    {
                        comboBoxSMenuCategory_SelectedIndexChanged(sender, e);

                        textBoxMenuItem.Text = string.Empty;
                        textBoxPrice.Text = string.Empty;

                        MessageBox.Show("Item Successfully added.");
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

        private void buttonUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateCrudItem())
                {
                    item.Item_Name = comboBoxUDMenuItem.SelectedItem.ToString();
                    item.getItemID();
                    item.Item_ID = item.Item_ID;
                    item.Item_Name = textBoxNewItem.Text;
                    item.Item_Type = comboBoxSMenuCategory.SelectedItem.ToString();
                    item.Item_Price = decimal.Parse(textBoxUDPrice.Text);

                    item.Update();

                    textBoxNewItem.Text = string.Empty;

                    comboBoxSMenuCategory_SelectedIndexChanged(sender, e);
                    // comboBoxUDMenuItem_SelectedIndexChanged(sender, e);

                    MessageBox.Show("Item Successfully Updated.");
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateCrudItem())
                {
                    string message = "Do you confirm to delete this data?";
                    string title = "Delete Item";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);

                    if(result == DialogResult.Yes)
                    {
                        item.Item_Name = comboBoxUDMenuItem.SelectedItem.ToString();

                        item.Delete();

                        textBoxNewItem.Text = string.Empty;

                        comboBoxSMenuCategory_SelectedIndexChanged(sender, e);

                        MessageBox.Show("Item Successfully Deleted.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonAddTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateAddTable())
                {
                    table.Id = table.generateID();
                    table.Name = textBoxTable.Text;
                    table.Status = 0;

                    table.Store();

                    // comboBoxTable.Items.Clear();
                    initialTableData();

                    if (table.exists == true)
                    {
                        MessageBox.Show("Table already exist.");
                    }
                    else
                    {
                        textBoxTable.Text = string.Empty;

                        MessageBox.Show("Table Successfully added.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonUpdateTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateCrudTable())
                {
                    table.Name = comboBoxTable.SelectedItem.ToString();
                    table.getTableID();
                    table.Id = table.Id;
                    table.Name = textBoxNewTable.Text;

                    table.Update();

                    initialTableData();

                    textBoxNewTable.Text = string.Empty;

                    MessageBox.Show("Table Successfully Updated.");
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxTable.SelectedItem != null)
                {
                    string message = "Do you confirm to delete this data?";
                    string title = "Delete Table";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);

                    if (result == DialogResult.Yes)
                    {
                        table.Name = comboBoxTable.SelectedItem.ToString();

                        table.Delete();

                        initialTableData();

                        textBoxNewTable.Text = string.Empty;

                        MessageBox.Show("Table Successfully Deleted.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all form.");
                }
            }
            catch (Exception error)
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

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
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
                if (textBoxPrice.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (textBoxPrice.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.'
                if (alreadyExist(textBoxPrice.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' is in middle of a number and after it is not a number greater than 99
                if (textBoxPrice.SelectionStart != textBoxPrice.Text.Length && e.Handled == false)
                {
                    // '.' is in the middle
                    string AfterDotString = textBoxPrice.Text.Substring(textBoxPrice.SelectionStart);

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
                if (alreadyExist(textBoxPrice.Text, ref sepratorChar))
                {
                    int sepratorPosition = textBoxPrice.Text.IndexOf(sepratorChar);
                    string afterSepratorString = textBoxPrice.Text.Substring(sepratorPosition + 1);
                    if (textBoxPrice.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBoxUDPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
