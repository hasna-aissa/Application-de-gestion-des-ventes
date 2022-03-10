using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Gestion_Ventes
{
    
    public partial class LigneCommande : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        public LigneCommande()
        {
            InitializeComponent();
        }
        private void LigneCommande_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
            cmd = new SqlCommand("", cn);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            string chaine = "select prix from article where designation='" + label4.Text + "'";
            cmd.CommandText = chaine;
            int prix = int.Parse(label5.Text);
            

            int qte = int.Parse(textBox3.Text);
            string total = (qte * prix).ToString();
            dataGridView1.Rows.Add(comboBox2.Text, prix.ToString(), qte.ToString(), total);
            double somme = 0;
            for(int i=0;i<dataGridView1.Rows.Count-1;i++)
            {
                somme = somme + double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            double tva = somme * 0.2;
            double ttc = tva + somme;
            lb_ht.Text = somme.ToString();
            lb_tva.Text = tva.ToString();
            lb_ttc.Text = ttc.ToString();
            cn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            string chaine = "select prix from article where designation='" + comboBox2.Text + "'";
            cn.Open();
            cmd.CommandText = chaine;
            int prix = int.Parse(cmd.ExecuteScalar().ToString());
            int qte = int.Parse(textBox3.Text);
             label6.Text = "total ligne= "+(qte * prix).ToString()+"DH";
            cn.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] vals = comboBox1.Text.Split('-');
            cn.Open();
            string chaine = "select solde from client where nom='" + vals[0] + "' and prenom'" + vals[1] + "'";
            cmd.CommandText = chaine;
            string solde = cmd.ExecuteScalar().ToString();
            label4.Text = "Solde : " + solde + "DH";
            cn.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            string chaine = "select prix from article where designation='" + comboBox2.Text + "'";

            cmd.CommandText = chaine;
            string prix = cmd.ExecuteScalar().ToString();
            label5.Text = "Prix : " + prix + "DH";
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] vals = comboBox1.Text.Split('-');
             cn.Open();
            string chaine="select numClient from client where nom='"+vals[0]+"'";
            cmd.CommandText = chaine;
            string numClient = comboBox1.ToString();

            chaine = "insert into commande values('" + numClient + "'," + DateTime.Today + ")";
            cmd.CommandText = chaine;
            cmd.ExecuteNonQuery();

            chaine = "select max(numCommande) from commande" ;
            cmd.CommandText = chaine;
            string numCommande = cmd.ExecuteScalar().ToString();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                chaine = "select numArticle from article where designation='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                cmd.CommandText = chaine;
                string numArticle = cmd.ExecuteScalar().ToString();
                chaine = "insert into LigneCommande values("+numCommande+","+numArticle+","+ dataGridView1.Rows[i].Cells[2].Value.ToString() + "'";
                cmd.CommandText = chaine;
                cmd.ExecuteNonQuery();
                
            }
            cn.Close();
        }
    }
}
