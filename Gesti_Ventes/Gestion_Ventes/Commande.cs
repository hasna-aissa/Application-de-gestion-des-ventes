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
    public partial class Commande : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public Commande()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            comboBox1.Visible = false;
            //con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                if (button1.Text == "Ajouter")
                {
                    cmd = new SqlCommand("AjouterCommande", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Ajouter");
                    cmd.Parameters.AddWithValue("@numClient ", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@numArticle ", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateCommande", textBox5.Text.Trim());
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Commande bien enregistré ", "Ajout du client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message erreur");
            }
            finally
            {
                con.Close();
            }

        }
        void FillDataGridView()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataAdapter sqldat = new SqlDataAdapter("chercherCommande", con);
                sqldat.SelectCommand.CommandType = CommandType.StoredProcedure;
     
                sqldat.SelectCommand.Parameters.AddWithValue("@numClient", textBox1.Text.Trim());
                DataTable dtable = new DataTable();
                sqldat.Fill(dtable);
                dataGridView1.DataSource = dtable;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }

        private void Commande_Load(object sender, EventArgs e)
        {

            con = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
            cmd = new SqlCommand("", con);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd = new SqlCommand("AjouterCommande", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "Modifier");
                cmd.Parameters.AddWithValue("@numClient ", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@numArticle ", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dateCommande", textBox5.Text.Trim());
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Commande bien modifié ", "modification du client ", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message erreur");
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand("SupprimerCommande", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumArticle ", textBox3.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Commande bien supprimer ", "suppression du ccommande ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message erreur");
            }
            finally
            {
                con.Close();
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message erreur");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
