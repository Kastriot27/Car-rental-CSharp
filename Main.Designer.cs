namespace Urhazo_Car_Rental_System
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnCarReg = new System.Windows.Forms.Button();
            this.btnRental = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCarReg
            // 
            this.btnCarReg.Location = new System.Drawing.Point(122, 69);
            this.btnCarReg.Name = "btnCarReg";
            this.btnCarReg.Size = new System.Drawing.Size(189, 55);
            this.btnCarReg.TabIndex = 0;
            this.btnCarReg.Text = "Car Registration";
            this.btnCarReg.UseVisualStyleBackColor = true;
            this.btnCarReg.Click += new System.EventHandler(this.btnCarReg_Click);
            // 
            // btnRental
            // 
            this.btnRental.Location = new System.Drawing.Point(122, 231);
            this.btnRental.Name = "btnRental";
            this.btnRental.Size = new System.Drawing.Size(189, 55);
            this.btnRental.TabIndex = 0;
            this.btnRental.Text = "Rental";
            this.btnRental.UseVisualStyleBackColor = true;
            this.btnRental.Click += new System.EventHandler(this.btnRental_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(122, 312);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(189, 55);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(122, 393);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(189, 55);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(122, 154);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(189, 55);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 507);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRental);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnCarReg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCarReg;
        private System.Windows.Forms.Button btnRental;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCustomer;
    }
}