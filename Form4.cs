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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int s = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
                textBox1.Text += "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            s = 0;
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "+";
            textBox2.Text = textBox1.Text;
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "-";
            textBox2.Text = textBox1.Text;
            textBox1.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = "*";
            textBox2.Text = textBox1.Text;
            textBox1.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox3.Text = "/";
            textBox2.Text = textBox1.Text;
            textBox1.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int x, y;
            x = System.Convert.ToInt32(textBox2.Text);
            y = System.Convert.ToInt32(textBox1.Text);
            if (textBox3.Text == "+")

                textBox1.Text = System.Convert.ToString(x + y);


            else if (textBox3.Text == "-")

                textBox1.Text = System.Convert.ToString(x - y);
            else if (textBox3.Text == "*")
                textBox1.Text = System.Convert.ToString(x * y);
            else if (textBox3.Text == "/")
                textBox1.Text = System.Convert.ToString((float)x / y);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            s += System.Convert.ToInt32(textBox1.Text);
            textBox4.Text = System.Convert.ToString(s);
            textBox1.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            s -= System.Convert.ToInt32(textBox1.Text);
            textBox4.Text = System.Convert.ToString(s);
            textBox1.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = System.Convert.ToString(textBox4.Text);
            textBox4.Clear();
        }

        private void phonebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 a = new Form5();
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
            Form3 d = new Form3();
            d.Show();
            this.Visible = false;
        }

       
    }
}
