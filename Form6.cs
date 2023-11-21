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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false; button2.Left = 0;
            button3.Enabled = false; button3.Left = 0;
            button4.Enabled = false; button4.Left = 0;

            Random R = new Random();
            int x;
            x = R.Next(3);


            if (x == 1)
                button2.Enabled = true;
            if (x == 2)
                button3.Enabled = true;
            if (x == 3)
                button4.Enabled = true;
            this.Width = Convert.ToInt32(textBox2.Text) + button2.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random R = new Random();
            int x;
            x = R.Next(Convert.ToInt32(textBox1.Text));
            button2.Left += x;
            if (button2.Left >= Convert.ToInt32(textBox2.Text))
                MessageBox.Show("BMW wins","Finish");
            else
            {
                button3.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random R = new Random();
            int x;
            x = R.Next(Convert.ToInt32(textBox1.Text));
            button3.Left += x;
            if (button3.Left >= Convert.ToInt32(textBox2.Text))
                MessageBox.Show("FORD wins","Finish");
            else
            {
                button4.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random R = new Random();
            int x;
            x = R.Next(Convert.ToInt32(textBox1.Text));
            button4.Left += x;
            if (button4.Left >= Convert.ToInt32(textBox2.Text))
                MessageBox.Show("Lamborgini wins","Finish");
            else
            {
                button2.Enabled = true;
                button4.Enabled = false;
            }
        }

        private void phnebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Visible = false;
        }

        private void phonebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 s = new Form5();
            s.Show();
                this.Visible=false;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 q = new Form3();
            q.Show();
            this.Visible = false;
        }
    }
}
