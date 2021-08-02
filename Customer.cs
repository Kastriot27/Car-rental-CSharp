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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            AutoNo();
            customerload();
        }

        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-JGQCCD4U; Initial Catalog = Car-Rental; Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataReader dr;

        string proId;
        string sql;
        bool Mode = true;
        string id;


        public void AutoNo()
        {
            sql = "select custid from Customer order by custid desc";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proId = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proId = ("00001");
            }
            else
            {
                proId = ("00001");

            }


            txtCustId.Text = proId.ToString();
            connection.Close();


        }

        public void customerload()
        {
            sql = "select * from Customer";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

            }
            connection.Close();

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string custid = txtCustId.Text;
            string custname = txtCustName.Text;
            string address = txtAddress.Text;
            string mobile = txtMobile.Text;

           // id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "insert into Customer(custid,custname,address,mobile)values(@custid,@custname,@address,@mobile)";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@custid", custid);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added!!!!");

                
                txtCustName.Clear();
                txtAddress.Clear();
                txtMobile.Clear();
                txtCustName.Focus();


            }
            else
            {
                sql = "update Customer set custname= @custname,address=@address,mobile=@mobile where custid = @custid";
                connection.Open();
                cmd = new SqlCommand(sql, connection);

               // cmd.Parameters.AddWithValue("@custname", custname);
               // cmd.Parameters.AddWithValue("@address", address);
               // cmd.Parameters.AddWithValue("@mobile", mobile);
               // cmd.Parameters.AddWithValue("@custid", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated!!!!");
               // txtCustId.Enabled = true;
               // Mode = true;

               // txtCustName.Clear();
               // txtAddress.Clear();
               // txtMobile.Clear();
                //txtCustName.Focus();


            }
            connection.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            customerload();
            AutoNo();
            txtCustName.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
            txtCustName.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}
