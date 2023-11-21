using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Project_Shop
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 q = new Form7();
            q.Show();
            this.Visible = false;
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            a.Show();
            this.Visible = false;

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 w = new Form3();
            w.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select isnull(max(Co_id)+1,1)from Company";
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                textBox1.Text = Convert.ToString(stdata.GetInt32(0));
            stdata.Close();
            objconnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & textBox7.Text != "")
            {
                SqlCommand jcommand = new SqlCommand();
                SqlDataReader stdata;
                jcommand.Connection = objconnection;
                jcommand.CommandText = "select co_id from Company where Co_id=@a";
                jcommand.Parameters.AddWithValue("@a", textBox1.Text);

                objconnection.Open();
                stdata = jcommand.ExecuteReader();
                stdata.Read();
                if (stdata.HasRows)
                {
                    MessageBox.Show("ERROR,this ID has Used before", "Becareful");
                    stdata.Close();
                }
                else
                {
                    objconnection.Close();
                    textBox8.Text = "insert into company values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + "," + textBox6.Text + "," + "'" + textBox7.Text + "')";

                    SqlCommand stcommand = new SqlCommand();
                    stcommand.Connection = objconnection;
                    stcommand.CommandText = textBox8.Text;
                    objconnection.Open();
                    stcommand.ExecuteNonQuery();
                    objconnection.Close();
                    for (int i = 1; i <= 100; i++)
                    {
                        progressBar1.Value = i;
                        for (int j = 0; j <= 1000000; j++) ;
                    }
                    MessageBox.Show("Complete!");
                }
            }
            else
                MessageBox.Show("Please Fill the Empty Fields","Error");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "update company set Co_name=@b,Co_tel=@c,Co_address=@d,Co_talab=@e,Co_bedehi=@f,Co_owner=@g where Co_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            stcommand.Parameters.AddWithValue("@b", textBox2.Text);
            stcommand.Parameters.AddWithValue("@c", textBox3.Text);
            stcommand.Parameters.AddWithValue("@d", textBox4.Text);
            stcommand.Parameters.AddWithValue("@e", textBox5.Text);
            stcommand.Parameters.AddWithValue("@f", textBox6.Text);
            stcommand.Parameters.AddWithValue("g", textBox7.Text);
            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();
    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "delete from company where Co_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable objdatatable = new DataTable();
            SqlDataAdapter objdataadaptor = new SqlDataAdapter();
            objdataadaptor.SelectCommand = new SqlCommand();
            objdataadaptor.SelectCommand.Connection = objconnection;
            objdataadaptor.SelectCommand.CommandText = "select * from Company order by Co_id";
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form16 f = new Form16();
            f.Show();
            this.Visible = false;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            usersToolStripMenuItem.Enabled= access.field1;
        }

    }
}
