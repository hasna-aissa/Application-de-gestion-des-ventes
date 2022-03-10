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
    public partial class contacternous : Form
    {
        public contacternous()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SelectProduit sp = new SelectProduit();
            this.Hide();
            sp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void contacternous_Load(object sender, EventArgs e)
        {

        }
    }
}
