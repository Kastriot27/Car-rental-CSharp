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
    public partial class Car_Registration : Form
    {
        public Car_Registration()
        {
            InitializeComponent();
            AutoNo();
            load();
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
            sql = "select RegNo from CarReg order by RegNo desc";
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
                proId = ("00000");
            }
            else
            {
                proId = ("00000");

            }


            txtRegNo.Text = proId.ToString();
            connection.Close();


        }

        public void load()
        {
            sql = "select * from CarReg";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1],dr[2],dr[3]);

            }
            connection.Close();

        }

        public void getid(String id)
        {
            sql = "select * from CarReg where RegNo = '" + id + "' ";
            cmd = new SqlCommand(sql, connection);
            connection.Open();
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                txtRegNo.Text = dr[0].ToString();
                txtBrand.Text = dr[1].ToString();
                txtModel.Text = dr[2].ToString();
                cmbAvl.Text = dr[3].ToString();
            }
            connection.Close();
        }

        private void Car_Registration_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string regno = txtRegNo.Text;
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string aval = cmbAvl.SelectedItem.ToString();

            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "insert into CarReg(RegNo,Brand,Model,Available)values(@RegNo,@Brand,@Model,@Available)";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@RegNo", regno);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added!!!!");

                txtBrand.Clear();
                txtModel.Clear();
                cmbAvl.Items.Clear();
                txtBrand.Focus();

            }
            else
            {
                sql = "update CarReg set Brand= @Brand,Model=@Model,Available=@Available where RegNo = @RegNo";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Model", model);
                cmd.Parameters.AddWithValue("@Available", aval);
                cmd.Parameters.AddWithValue("@RegNo", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated!!!!");
                txtRegNo.Enabled = true;
                Mode = true;

                txtBrand.Clear();
                txtModel.Clear();
                cmbAvl.Items.Clear();
                txtBrand.Focus();
                

            }
            connection.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                txtRegNo.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid(id);
                
            }
            else if(e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from CarReg where RegNo = @id";
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted!");
                connection.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load();
            AutoNo();
            txtBrand.Clear();
            txtModel.Clear();
            cmbAvl.Items.Clear();
            txtBrand.Focus();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void cmbAvl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
