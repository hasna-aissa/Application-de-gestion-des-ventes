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
    public partial class connexion : Form
    {
        SqlConnection con;
        public connexion()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
            string query="select nom from client where nom= '"+ textBox2.Text.Trim()+"'and password ='"+ textBox3.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count==1)
            {
                Form2 fr = new Form2();
                this.Hide();
                fr.Show();
            }
            else
            {
                Form3 frm = new Form3();
                this.Hide();
                frm.Show();
            }
            if (testObligatoire() == null )
            {
                MessageBox.Show("Valide");
            }
            else
                MessageBox.Show(testObligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void connexion_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        string testObligatoire()
        {
            if(textBox2.Text == "Nom" || textBox2.Text == "")
            {
                return "Entrez Votre Nom";
            }
            if (textBox3.Text == "Mot de passe" || textBox3.Text == "")
            {
                return "Entrez Votre Mot De Passe";
            }
            return null;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Nom")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.Text = "Nom";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Mot de passe";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Mot de passe")
            {
                textBox3.Text = "";
                textBox3.UseSystemPasswordChar = false;
                textBox3.PasswordChar = '*';
                textBox3.ForeColor = Color.Black;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
