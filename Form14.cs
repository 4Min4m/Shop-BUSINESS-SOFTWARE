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
    public partial class Form14 : Form
    {
        public Form14()
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
            objdataadaptor.SelectCommand.CommandText = "Select * from forosh where f_date = @a";
            objdataadaptor.SelectCommand.Parameters.AddWithValue("@a", textBox1.Text);
            objconnection.Open();
            objdataadaptor.Fill(objdatatable);
            objconnection.Close();
            dataGridView1.DataSource = objdatatable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Visible = false;
        }
    }
}
