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
    public partial class returncar : Form
    {
        public returncar()
        {
            InitializeComponent();
            rentalload();
        }

        SqlConnection connection = new SqlConnection("Data Source = LAPTOP-JGQCCD4U; Initial Catalog = Car-Rental; Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlCommand cmd1;
        SqlDataReader dr;

        string proId;
        string sql;
        string sql1;
        string id;
        bool Mode = true;


        public void rentalload()
        {
            sql = "select * from returncar";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);

            }
            connection.Close();

        }


        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmd = new SqlCommand("select car_id, cust_id, date, due, DATEDIFF(dd,due,GETDATE()) as elap from Rental where car_id = '" + txtcarid.Text + "'", connection);
                connection.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtcustid.Text = dr["cust_id"].ToString();
                    txtdate.Text = dr["due"].ToString();

                    string elap = dr["elap"].ToString();

                    int elapped = int.Parse(elap);

                    txtdayselapsed.Text = (elap);


                    if (elapped > 0)
                    {
                        int fine = elapped * 100;
                        txtfine.Text = fine.ToString();
                    }
                    else
                    {
                        txtfine.Text = "0";
                        txtfine.Text = "0";
                    }

                    connection.Close();

                }


            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string carid = txtcarid.Text;
            string custid = txtcustid.Text;
            string date = txtdate.Text;
            string elp = txtdayselapsed.Text;
            string fine = txtfine.Text;

           // id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {

                sql = "insert into returncar(car_id, cust_id, date, elp, fine)values(@car_id,@cust_id,@date,@elp, @fine)";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@car_id", carid);
                cmd.Parameters.AddWithValue("@cust_id", custid);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@elp", elp);
                cmd.Parameters.AddWithValue("@fine", fine);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added!!!!");

                txtcarid.Clear();
                txtcustid.Clear();
                txtdate.Clear();
                txtdayselapsed.Clear();
                txtfine.Clear();

            }
            connection.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }
    }
}
