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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Visible = false;
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 b = new Form6();
            b.Show();
            this.Visible = false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 c = new Form3();
            c.Show();
            this.Visible = false;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
           

        }
    }
}
