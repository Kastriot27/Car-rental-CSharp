using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urhazo_Car_Rental_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username.Equals("Admin") && password.Equals("1234"))
            {
                Main Main = new Main();
                this.Hide();
                Main.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect!");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
                



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
