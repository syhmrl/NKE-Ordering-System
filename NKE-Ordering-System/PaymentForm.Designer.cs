namespace NKE_Ordering_System
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTakeAway = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.textBoxAmountPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxTakeAway);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonPayment);
            this.groupBox1.Controls.Add(this.textBoxAmountPaid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxTable);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPaymentType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(306, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(524, 605);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Dine-In",
            "Take Away"});
            this.comboBoxType.Location = new System.Drawing.Point(244, 56);
            this.comboBoxType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(216, 33);
            this.comboBoxType.TabIndex = 12;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Order Type";
            // 
            // comboBoxTakeAway
            // 
            this.comboBoxTakeAway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTakeAway.FormattingEnabled = true;
            this.comboBoxTakeAway.Location = new System.Drawing.Point(244, 184);
            this.comboBoxTakeAway.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTakeAway.Name = "comboBoxTakeAway";
            this.comboBoxTakeAway.Size = new System.Drawing.Size(216, 33);
            this.comboBoxTakeAway.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Take Away ID";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(272, 388);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(24, 25);
            this.labelTotal.TabIndex = 8;
            this.labelTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 388);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total (RM) : ";
            // 
            // buttonPayment
            // 
            this.buttonPayment.Location = new System.Drawing.Point(276, 444);
            this.buttonPayment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(186, 52);
            this.buttonPayment.TabIndex = 6;
            this.buttonPayment.Text = "Proceed Payment";
            this.buttonPayment.UseVisualStyleBackColor = true;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // textBoxAmountPaid
            // 
            this.textBoxAmountPaid.Location = new System.Drawing.Point(244, 317);
            this.textBoxAmountPaid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxAmountPaid.Name = "textBoxAmountPaid";
            this.textBoxAmountPaid.Size = new System.Drawing.Size(216, 31);
            this.textBoxAmountPaid.TabIndex = 5;
            this.textBoxAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmountPaid_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 322);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Amount Paid (RM)";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(244, 122);
            this.comboBoxTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(216, 33);
            this.comboBoxTable.TabIndex = 3;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Table";
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaymentType.FormattingEnabled = true;
            this.comboBoxPaymentType.Items.AddRange(new object[] {
            "Bank",
            "Cash"});
            this.comboBoxPaymentType.Location = new System.Drawing.Point(244, 250);
            this.comboBoxPaymentType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(216, 33);
            this.comboBoxPaymentType.TabIndex = 1;
            this.comboBoxPaymentType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaymentType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Type";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PaymentForm";
            this.Text = "Payment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaymentForm_FormClosed);
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.TextBox textBoxAmountPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTakeAway;
        private System.Windows.Forms.Label label5;
    }
}