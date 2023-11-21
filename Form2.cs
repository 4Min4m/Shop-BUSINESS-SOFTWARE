using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 y = new Form3();
            y.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form3 x = new Form3();
            x.Show();
            this.Close();
        }
    }
}
