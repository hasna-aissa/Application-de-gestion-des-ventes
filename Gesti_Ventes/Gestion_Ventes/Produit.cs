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
    public partial class Produit : Form
    {
        SqlCommand cmd;
        int numArticle = 0;
        SqlConnection con = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
        public Produit()
        {
            InitializeComponent();
        }
        void FillDataGridView()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataAdapter sqldat = new SqlDataAdapter("chercherProduit", con);
                sqldat.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqldat.SelectCommand.Parameters.AddWithValue("@designation", textBox1.Text.Trim());
                DataTable dtable = new DataTable();
                sqldat.Fill(dtable);
                dataGridView1.DataSource = dtable;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }
        private void Produit_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message erreur");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                if (button1.Text == "Ajouter")
                {
                    cmd = new SqlCommand("AjouterProduit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Ajouter");
                    cmd.Parameters.AddWithValue("@numArticle ", 0);
                    cmd.Parameters.AddWithValue("@designation ", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@prix", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@quantite", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@seuilminimum", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@seuilmaximum", textBox7.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produit bien enregistré ", "Ajout du produit ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message erreur");
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                if (button2.Text == "Modifier")
                {
                    cmd = new SqlCommand("AjouterProduit", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Modifier");
                    cmd.Parameters.AddWithValue("@numArticle ", numArticle);
                    cmd.Parameters.AddWithValue("@designation ", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@prix", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@quantite", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@seuilminimum", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@seuilmaximum", textBox7.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produit bien modifié ", "modification du produit ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "message erreur");
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                numArticle = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand("SupprimerProduit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numArticle ", numArticle);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produit bien supprimer ", "suppression du produit ", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
