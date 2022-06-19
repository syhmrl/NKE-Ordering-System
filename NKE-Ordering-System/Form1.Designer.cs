using System;

namespace NKE_Ordering_System
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public EventHandler Form1_Load { get; private set; }

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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonToRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(323, 152);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(153, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(323, 186);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(153, 22);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(353, 236);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(123, 38);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.MouseHover += new System.EventHandler(this.buttonLogin_MouseHover);
            // 
            // buttonToRegister
            // 
            this.buttonToRegister.Location = new System.Drawing.Point(353, 289);
            this.buttonToRegister.Name = "buttonToRegister";
            this.buttonToRegister.Size = new System.Drawing.Size(123, 38);
            this.buttonToRegister.TabIndex = 6;
            this.buttonToRegister.Text = "Go To Register";
            this.buttonToRegister.UseVisualStyleBackColor = true;
            this.buttonToRegister.Click += new System.EventHandler(this.buttonToRegister_Click);
            this.buttonToRegister.MouseHover += new System.EventHandler(this.buttonToRegister_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 51);
            this.label3.TabIndex = 7;
            this.label3.Text = "Login";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonToRegister);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "NKE Order System | Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonToRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTipButton;
    }
}

