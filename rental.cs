using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urhazo_Car_Rental_System
{
    public partial class rental : Form
    {
        public rental()
        {
            InitializeComponent();
            carload();
            rentalload();
        }

        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-JGQCCD4U; Initial Catalog = Car-Rental; Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;

        string proId;
        string sql;
        bool Mode = true;
        string id;
        string sql1;



        public void rentalload()
        {
            sql = "select * from Rental";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);

            }
            connection.Close();

        }





        public void carload()
        {
            cmd = new SqlCommand("select * from CarReg", connection);
            connection.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmbCarId.Items.Add(dr["RegNo"].ToString());
            }

            connection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rental_Load(object sender, EventArgs e)
        {

        }

        private void cmbCarId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from CarReg where RegNo = '" + cmbCarId.Text + "' ", connection);
            connection.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string aval;

                aval = dr["Available"].ToString();

                label1.Text = aval;

                if (aval == "No")
                {
                    txtCustId.Enabled = false;
                    txtCustName.Enabled = false;

                    txtRentalFee.Enabled = false;
                    dtpDate.Enabled = false;
                    dtpDue.Enabled = false;
                }
                else
                {
                    txtCustId.Enabled = true;
                    txtCustName.Enabled = true;

                    txtRentalFee.Enabled = true;
                    dtpDate.Enabled = true;
                    dtpDue.Enabled = true;

                }
            }
            else
            {
                label1.Text = "Car not available!";
            }

            connection.Close();



        }

        private void txtCustId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                cmd = new SqlCommand("select * from Customer where custid = '" + txtCustId.Text + "' ", connection);
                connection.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtCustName.Text = dr["custname"].ToString();

                }
                else
                {
                    MessageBox.Show("Customer ID not found");
                }

                connection.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string carid = cmbCarId.SelectedItem.ToString();
            string custid = txtCustId.Text;
            string custname = txtCustName.Text;
            string fee = txtRentalFee.Text;
            string date = dtpDate.Value.Date.ToString("yyyy-MM-dd");
            string due = dtpDue.Value.Date.ToString("yyyy-MM-dd");



            sql = "insert into Rental(car_id, cust_id, custname, fee, date, due)values(@car_id, @cust_id, @custname, @fee, @date, @due)";
            connection.Open();
            cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@car_id", carid);
            cmd.Parameters.AddWithValue("@cust_id", custid);
            cmd.Parameters.AddWithValue("@custname", custname);
            cmd.Parameters.AddWithValue("@fee", fee);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@due", due);
            cmd.ExecuteNonQuery();

            sql1 = "update CarReg set Available = 'No' where RegNo = @RegNo ";


            cmd1 = new SqlCommand(sql1, connection);
            cmd1.Parameters.AddWithValue("@RegNo", carid);
            cmd1.ExecuteNonQuery();


            MessageBox.Show("Record Added!!!!");
            connection.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}
