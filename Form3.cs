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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 x = new Form1();
            x.Show();
            this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Visible = false;
        }

        private void phonebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 b = new Form5();
            b.Show();
            this.Visible = false;
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 c = new Form6();
            c.Show();
            this.Visible = false;
        }

        private void customersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 d = new Form7();
            d.Show();
            this.Visible = false;
        }

        private void itemsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Visible = false;
        }

        private void companiesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 g = new Form9();
            g.Show();
            this.Visible = false;
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 n = new Form10();
            n.Show();
            this.Visible = false;
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 m = new Form11();
            m.Show();
            this.Visible = false;

        }

        private void customerPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 x1 = new Form12();
            x1.Show();
            this.Visible = false;
        }

        private void itemSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 x2 = new Form13();
            x2.Show();
            this.Visible = false;
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 y = new Form14();
            y.Show();
            this.Visible = false;
        }

        private void usersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 l = new Form16();
            l.Show();
            this.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            usersInfoToolStripMenuItem.Enabled = access.field1;
            systemInformationsToolStripMenuItem.Enabled = access.field2;
            dailyActivitiesToolStripMenuItem.Enabled = access.field3;
            reportsToolStripMenuItem.Enabled = access.field4;
        }
    }
}
