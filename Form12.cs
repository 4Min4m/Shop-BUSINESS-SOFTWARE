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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable objdatatable = new DataTable();
            SqlDataAdapter objdataadaptor = new SqlDataAdapter();
            objdataadaptor.SelectCommand = new SqlCommand();
            objdataadaptor.SelectCommand.Connection = objconnection;
            objdataadaptor.SelectCommand.CommandText = "select * from customer a JOIN forosh b ON a.C_id = b.C_id where C_name=@x and (f_date >= @y and f_date <= @z)";
            objdataadaptor.SelectCommand.Parameters.AddWithValue("@x", textBox1.Text);
            objdataadaptor.SelectCommand.Parameters.AddWithValue("@y", textBox2.Text);
            objdataadaptor.SelectCommand.Parameters.AddWithValue("@z", textBox3.Text);
            
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                String str = textBox2.Text;
                int y = Convert.ToInt32(str.Substring(0, 4));
                int m = Convert.ToInt32(str.Substring(5, 2));
                int d = Convert.ToInt32(str.Substring(8, 2));
                if (y > 1390 || y <= 1380)
                    MessageBox.Show("The year is wrong", "Error");
                if (m > 12)
                    MessageBox.Show("The month is Wrong", "Error");
                if (m <= 6 & d > 30)
                    MessageBox.Show("The Day is Wrong", "Error");
                else if (m > 6 & d > 31)
                    MessageBox.Show("The Day is Wrong", "Error");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                String str = textBox3.Text;
                int y = Convert.ToInt32(str.Substring(0, 4));
                int m = Convert.ToInt32(str.Substring(5, 2));
                int d = Convert.ToInt32(str.Substring(8, 2));
                if (y > 1390 || y <= 1380)
                    MessageBox.Show("The year is wrong", "Error");
                if (m > 12)
                    MessageBox.Show("The month is Wrong", "Error");
                if (m <= 6 & d > 30)
                    MessageBox.Show("The Day is Wrong", "Error");
                else if (m > 6 & d > 31)
                    MessageBox.Show("The Day is Wrong", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable objdatatable = new DataTable();
            SqlDataAdapter objdataadaptor = new SqlDataAdapter();
            objdataadaptor.SelectCommand = new SqlCommand();
            objdataadaptor.SelectCommand.Connection = objconnection;
            objdataadaptor.SelectCommand.CommandText = "select count(*),C_id from forosh group by C_id";
            
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }
    }
}
