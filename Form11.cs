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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection objconnection = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 x = new Form3();
            x.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "" & textBox6.Text != "")
            {
                SqlCommand jcommand = new SqlCommand();
                SqlDataReader stdata;
                jcommand.Connection = objconnection;
                jcommand.CommandText = "select f_sh from kharid where f_sh=@a";
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
                    SqlCommand st1command = new SqlCommand();
                    SqlCommand st2command = new SqlCommand();
                    stcommand.Connection = objconnection;
                    st1command.Connection = objconnection;
                    st2command.Connection = objconnection;
                    stcommand.CommandText = "insert into kharid(f_sh,f_date,I_id,c_id,tedad,mablagh) values(@a,@b,@c,@d,@f,@g)";
                    st1command.CommandText = "update Item set I_total=I_total + @f where I_id=@c";
                    st2command.CommandText = "update Company set Co_bedehi=Co_bedehi + @g where Co_id = @d";
                    stcommand.Parameters.AddWithValue("@a", textBox1.Text);
                    stcommand.Parameters.AddWithValue("@b", textBox2.Text);
                    stcommand.Parameters.AddWithValue("@c", textBox3.Text);
                    stcommand.Parameters.AddWithValue("@d", textBox4.Text);
                    stcommand.Parameters.AddWithValue("@f", textBox5.Text);
                    stcommand.Parameters.AddWithValue("@g", textBox6.Text);
                    st1command.Parameters.AddWithValue("@f", textBox5.Text);
                    st1command.Parameters.AddWithValue("@c", textBox3.Text);
                    st2command.Parameters.AddWithValue("@g", textBox6.Text);
                    st2command.Parameters.AddWithValue("@d", textBox4.Text);
                    objconnection.Open();
                    stcommand.ExecuteNonQuery();
                    st1command.ExecuteNonQuery();
                    st2command.ExecuteNonQuery();
                    objconnection.Close();
            
                }
            }
            else
                MessageBox.Show("Please Fill All Fields", "Error");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable objdatatable = new DataTable();
            SqlDataAdapter objdataadaptor = new SqlDataAdapter();
            objdataadaptor.SelectCommand = new SqlCommand();
            objdataadaptor.SelectCommand.Connection = objconnection;
            objdataadaptor.SelectCommand.CommandText = "select * from kharid order by f_sh";
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select I_name from Item where I_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox3.Text);
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                label7.Text = Convert.ToString(stdata.GetString(0));
            else
                label7.Text = "There's No Item";

            stdata.Close();
            objconnection.Close();
        }


        private void textBox4_Leave(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select Co_name from Company where Co_id=@a";
            stcommand.Parameters.AddWithValue("@a", textBox4.Text);
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                label8.Text = Convert.ToString(stdata.GetString(0));
            else
                label8.Text = "There's No Company";

            stdata.Close();
            objconnection.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            SqlCommand stcommand = new SqlCommand();
            SqlDataReader stdata;
            stcommand.Connection = objconnection;
            stcommand.CommandText = "select isnull(max(f_sh)+1,1)from kharid";
            objconnection.Open();
            stdata = stcommand.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                textBox1.Text = Convert.ToString(stdata.GetInt32(0));
            stdata.Close();
            objconnection.Close();
        }



        




    }
}
