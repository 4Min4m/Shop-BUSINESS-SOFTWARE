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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select * from users where Username=@a and Password=@b";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            stcommand.Parameters.AddWithValue("@b", textBox2.Text);
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            if (stdata.HasRows)
            {
                if (textBox1.Text == "amin")
                   access.field1 = true;
                else
                    access.field1 = false;
                SqlCommand stcommand2 = new SqlCommand();
                SqlDataReader stdata2;
                stcommand2.Connection = objconnection;
                stcommand2.CommandText = "select SystemInformation,DailyActivities,Reports from users where username=@a";
                stcommand2.Parameters.AddWithValue("@a", textBox1.Text);
                stdata.Close();
                stdata2 = stcommand2.ExecuteReader();
                stdata2.Read();
                if (stdata2.HasRows)
                {
                    access.field2 = stdata2.GetBoolean(0);
                    access.field3 = stdata2.GetBoolean(1);
                    access.field4 = stdata2.GetBoolean(2);
                }

                stdata2.Close();
                Form2 x = new Form2();
                x.Show();
                this.Visible = false;
                
            }
            else
                MessageBox.Show("Please Insert Correct Username Or Password","Error");
            
            stdata.Close();
            objconnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form15 x = new Form15();
            x.Show();
        }

 
    }
}
