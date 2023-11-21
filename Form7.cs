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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private int GetId()
        {
            int t=0;
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select isnull(max(C_id)+1,1)from Customer";
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                t=  stdata.GetInt32(0);
            stdata.Close();
            objconnection.Close();
            return t;
        }
        private void DeleteCustomer(string id)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "delete from customer where C_id=@a";
            stcommand.Parameters.AddWithValue("@a", id);
            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();

        
        }
        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 q = new Form8();
            q.Show();
            this.Visible = false;
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 w = new Form9();
            w.Show();
            this.Visible = false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & textBox3.Text != "")
            {
                SqlCommand jcommand = new SqlCommand();
                SqlDataReader stdata;
                jcommand.Connection = objconnection;
                jcommand.CommandText = "select c_id from Customer where C_id=@a";
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
                    textBox8.Text = "insert into Customer(C_id,C_name,C_family,c_tel,C_tedad,C_total,C_last) values(@C_id,@C_name,@C_family,@C_tel,@C_tedad,@C_total,@C_last)";
                    SqlCommand stcommand = new SqlCommand();
                    stcommand.Connection = objconnection;
                    stcommand.CommandText = textBox8.Text;
                    stcommand.Parameters.AddWithValue("@C_id", textBox1.Text);
                    stcommand.Parameters.AddWithValue("@C_name", textBox2.Text);
                    stcommand.Parameters.AddWithValue("@C_family", textBox3.Text);
                    stcommand.Parameters.AddWithValue("@C_tel", textBox4.Text);
                    stcommand.Parameters.AddWithValue("@C_tedad", textBox5.Text);
                    stcommand.Parameters.AddWithValue("@C_total", textBox6.Text);
                    stcommand.Parameters.AddWithValue("@C_last", textBox7.Text);
                    objconnection.Open();
                    stcommand.ExecuteNonQuery();
                    stdata.Close();
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
                MessageBox.Show("please insert name correctly","Error");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = Convert.ToString(GetId());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer(textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "update customer set C_name=@b,C_family=@c,C_tel=@d,C_tedad=@e,C_total=@f,C_last=@g where C_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            stcommand.Parameters.AddWithValue("@b", textBox2.Text);
            stcommand.Parameters.AddWithValue("@c", textBox3.Text);
            stcommand.Parameters.AddWithValue("@d", textBox4.Text);
            stcommand.Parameters.AddWithValue("@e", textBox5.Text);
            stcommand.Parameters.AddWithValue("@f", textBox6.Text);
            stcommand.Parameters.AddWithValue("@g", textBox7.Text);
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
            objdataadaptor.SelectCommand.CommandText = "select * from Customer order by C_id";
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

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                String str = textBox7.Text;
                int y = Convert.ToInt32(str.Substring(0, 4));
                int m = Convert.ToInt32(str.Substring(5, 2));
                int d = Convert.ToInt32(str.Substring(8, 2));
                if (y > 1390 || y <= 1380)
                    MessageBox.Show("The year is wrong", "Error");
                if (m > 12)
                    MessageBox.Show("The month is Wrong", "Error");
                if (m <= 6 & d > 31)
                    MessageBox.Show("The Day is Wrong", "Error");
                else if (m > 6 & d >= 31)
                    MessageBox.Show("The Day is Wrong", "Error");
            }

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f = new Form16();
            f.Show();
            this.Visible = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            usersToolStripMenuItem.Enabled = access.field1;
        }

       
    }
}
