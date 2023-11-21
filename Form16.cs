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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 x = new Form7();
            x.Show();
            this.Visible = false;

        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form8 x = new Form8();
            x.Show();
            this.Visible = false;
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form9 x = new Form9();
            x.Show();
            this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable objdatatable = new DataTable();
            SqlDataAdapter objdataadaptor = new SqlDataAdapter();
            objdataadaptor.SelectCommand = new SqlCommand();
            objdataadaptor.SelectCommand.Connection = objconnection;
            objdataadaptor.SelectCommand.CommandText = "select * from Users order by id";
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select isnull(max(id)+1,1)from Users";
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                textBox1.Text = Convert.ToString(stdata.GetInt32(0));
            stdata.Close();
            objconnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "delete from Users where id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" & textBox2.Text !="" & textBox3.Text != "" & textBox4.Text !="")
                       {
                SqlCommand jcommand = new SqlCommand();
                SqlDataReader stdata;
                jcommand.Connection = objconnection;
                jcommand.CommandText = "select id from users where id=@a";
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
                    SqlCommand stcommand = new SqlCommand();
                    stcommand.Connection = objconnection;
                    stcommand.CommandText = "insert into Users(id,Username,password,alien,SystemInformation,DailyActivities,Reports) values(@id,@username,@password,@alien,@SystemInformation,@DailyActivities,@Reports)";
                    stcommand.Parameters.AddWithValue("@id", textBox1.Text);
                    stcommand.Parameters.AddWithValue("@username", textBox2.Text);
                    stcommand.Parameters.AddWithValue("@password", textBox3.Text);
                    stcommand.Parameters.AddWithValue("@alien", textBox4.Text);
                    stcommand.Parameters.AddWithValue("@SystemInformation", checkBox1.Checked);
                    stcommand.Parameters.AddWithValue("@DailyActivities", checkBox2.Checked);
                    stcommand.Parameters.AddWithValue("@Reports", checkBox3.Checked);
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
                MessageBox.Show("please insert name correctly", "Error");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            stcommand.Connection = objconnection;
            stcommand.CommandText = "update Users set username=@b,password=@c,alien=@d,SystemInformation=@e,DailyActivities=@f,Reports=@g where id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox1.Text);
            stcommand.Parameters.AddWithValue("@b", textBox2.Text);
            stcommand.Parameters.AddWithValue("@c", textBox3.Text);
            stcommand.Parameters.AddWithValue("@d", textBox4.Text);
            stcommand.Parameters.AddWithValue("@e", checkBox1.Checked);
            stcommand.Parameters.AddWithValue("@f", checkBox2.Checked);
            stcommand.Parameters.AddWithValue("@g", checkBox3.Checked);
            objconnection.Open();
            stcommand.ExecuteNonQuery();
            objconnection.Close();
        }


    }
}
