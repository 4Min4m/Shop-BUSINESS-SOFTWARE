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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        SqlConnection objconn = new SqlConnection("Data Source=.;Initial Catalog=123;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand stcomm = new SqlCommand();
            SqlDataReader stdata;
            stcomm.Connection = objconn;
            stcomm.CommandText = "select password from Users where id=@a and alien=@b";
            stcomm.Parameters.AddWithValue("@a", textBox1.Text);
            stcomm.Parameters.AddWithValue("@b", textBox2.Text);
            objconn.Open();
            stdata = stcomm.ExecuteReader();
            stdata.Read();
            if (stdata.HasRows)
                textBox3.Text = stdata.GetString(0);
            else
                MessageBox.Show("You are not a member", "OoPs!");
            objconn.Close();
        }
    }
}
