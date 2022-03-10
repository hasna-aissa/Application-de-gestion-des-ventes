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
    public partial class firstone : Form
    {
        public firstone()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connexion cn = new connexion();
            
            cn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectProduit cn = new SelectProduit();
            
            cn.Show();
        }
    }
}
