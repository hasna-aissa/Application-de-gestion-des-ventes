using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Ventes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.Size = new Size(248, 592);
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (panel1.Width == 248)
            {
                panel1.Size = new Size(58,592);

            }
            else
                panel1.Size = new Size(248, 592);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Form1 frm = new Form1();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();

            /*
            pnlButCl.Top = button8.Top;
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();*/

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Produit frm = new Produit();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            /*  pnlButCl.Top = button7.Top;
              Produit p = new Produit();
              this.Hide();
              p.Show();*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Commande frm = new Commande();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            /*pnlButCl.Top = button6.Top;
            Commande p = new Commande();
            this.Hide();
            p.Show();*/
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void panelparam_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelparam_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            firstone fr = new firstone();
            this.Hide();
            fr.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
