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

namespace Support
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Support = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Support.ConnectionString = "initial catalog = Support ; data source = . ; integrated Security = True ;";
                cmd.Connection = Support;
                Support.Open();
                cmd.CommandText = "Insert into Support values(@a,@b,@c,@d,@e)";
                cmd.Parameters.AddWithValue("@a", textBox1.Text);
                cmd.Parameters.AddWithValue("@b", textBox2.Text);
                cmd.Parameters.AddWithValue("@c", textBox3.Text);
                cmd.Parameters.AddWithValue("@d", textBox4.Text);
                if (radioButton1.Checked)
                {
                    cmd.Parameters.AddWithValue("@e", "Women");
                }
                else if (radioButton2.Checked)
                {
                    cmd.Parameters.AddWithValue("@e", "Men");
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Member Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Support.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Support = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Support.ConnectionString = "initial catalog = Support ; data source = . ; integrated Security = True ;";
                cmd.Connection = Support;
                cmd.CommandText = "Update Support Set First Name='@b', Last Name='@c', Age=@d ,Sexe=@e where ID = '@a'";
                cmd.Parameters.AddWithValue("@a", textBox1.Text);
                cmd.Parameters.AddWithValue("@b", textBox2.Text);
                cmd.Parameters.AddWithValue("@c", textBox3.Text);
                cmd.Parameters.AddWithValue("@d", textBox4.Text);
                if (radioButton1.Checked)
                    cmd.Parameters.AddWithValue("@e", "Women");
                else cmd.Parameters.AddWithValue("@e", "Men");
                Support.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Working on update.....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Support.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection Support = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Support.ConnectionString = "initial catalog = Support ; data source = . ; integrated Security = True ;";
                cmd.Connection = Support;
                cmd.CommandText = "delete from Support where ID=@a";
                cmd.Parameters.AddWithValue("@a", textBox1.Text);
                Support.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete the Member....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Support.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection Support = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Support.ConnectionString = "initial catalog = Support ; data source = . ; integrated Security = True ;";
                cmd.Connection = Support;
                Support.Open();
                cmd.CommandText = "Select*from Support";
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Support.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Support = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                Support.ConnectionString = "initial catalog = Support ; data source = . ; integrated Security = True ;";
                cmd.Connection = Support;
                Support.Open();
                switch (comboBox1.SelectedIndex)
                {
                    case 0: cmd.CommandText = "Select count(*) from Support where age>20";break;
                    case 1: cmd.CommandText = "Select count(*) from Support where age<=20"; break;
                    case 2: cmd.CommandText = "Select count(*) from Support where sexe='Men'"; break;
                    case 3: cmd.CommandText = "Select count(*) from Support where sexe='Women'"; break;
                }
                label8.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Support.Close();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Men")
                radioButton1.Checked = true;
            else radioButton2.Checked = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
