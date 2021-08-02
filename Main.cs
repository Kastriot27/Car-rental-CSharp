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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Show();
            this.Hide();

        }

        private void btnCarReg_Click(object sender, EventArgs e)
        {
            Car_Registration cr = new Car_Registration();
            cr.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            returncar re = new returncar();
            re.Show();
            this.Hide();
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            rental r = new rental();
            r.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
