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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 a = new Form7();
            a.Show();
            this.Visible = false;
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 q = new Form9();
            q.Show();
            this.Visible = false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select isnull(max(I_id)+1,1)from Item";
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
            if (textBox2.Text != "")
            {
                SqlCommand jcommand = new SqlCommand();
                SqlDataReader stdata;
                jcommand.Connection = objconnection;
                jcommand.CommandText = "select I_id from Item where I_id=@a";
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
                    textBox6.Text = "insert into Item(I_id,I_name,I_price,I_Total,I_left) values(@I_id,@I_name,@I_price,@I_Total,@I_left)";
                    SqlCommand stcommand = new SqlCommand();
                    stcommand.Connection = objconnection;
                    stcommand.CommandText = textBox6.Text;
                    stcommand.Parameters.AddWithValue("@I_id", textBox1.Text);
                    stcommand.Parameters.AddWithValue("@I_name", textBox2.Text);
                    stcommand.Parameters.AddWithValue("@I_price", textBox3.Text);
                    stcommand.Parameters.AddWithValue("@I_Total", textBox4.Text);
                    stcommand.Parameters.AddWithValue("@I_left", textBox5.Text);

                    objconnection.Open();
                    stcommand.ExecuteNonQuery();
                    objconnection.Close();
                }
                for (int i = 1; i <= 100; i++)
                {
                    progressBar1.Value = i;
                    for (int j = 0; j <= 1000000; j++) ;
                }
                MessageBox.Show("Complete!");
            }
            else
                MessageBox.Show("Please Insert Name");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "update Item set I_name=@b,I_price=@c,I_Total=@d,I_left=@e where I_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            stcommand.Parameters.AddWithValue("@b", textBox2.Text);
            stcommand.Parameters.AddWithValue("@c", textBox3.Text);
            stcommand.Parameters.AddWithValue("@d", textBox4.Text);
            stcommand.Parameters.AddWithValue("@e", textBox5.Text);

            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "delete from Item where I_id=@a";
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
            objdataadaptor.SelectCommand.CommandText = "select * from Item order by I_id";
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

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form16 f = new Form16();
            f.Show();
            this.Visible = false;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            usersToolStripMenuItem.Enabled = access.field1;
        }

       
    }
}
