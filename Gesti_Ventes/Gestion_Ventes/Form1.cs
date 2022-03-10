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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string n, l;
        public Form1()
        {
            InitializeComponent();
        }
        public string conString = "";

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
                        cmd = new SqlCommand("AjouterClient", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mode", "Ajouter");
                        cmd.Parameters.AddWithValue("@nom ", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@prenom ", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@CIN", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@adresse", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@ville", domainUpDown1.Text.Trim());
                        cmd.Parameters.AddWithValue("@tele", textBox4.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Client bien enregistré ", "Ajout du client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message erreur");
            }
            finally
            {
                con.Close();
            }
      
            /*cmd.CommandText = ("insert into client values ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + domainUpDown1.Text + "','" + textBox4.Text +"')");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Commande bien enregistré ", "Ajout de la commande ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
         
            
        }
        void FillDataGridView()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlDataAdapter sqldat = new SqlDataAdapter("chercherClient", con);
                sqldat.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqldat.SelectCommand.Parameters.AddWithValue("@nom", textBox6.Text.Trim());
                DataTable dtable = new DataTable();
                sqldat.Fill(dtable);
                dataGridView1.DataSource = dtable;
                dataGridView1.Columns[0].Visible = false;
                con.Close();
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged_1(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
            cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "select nom,adresse from client";
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr[0] + "  " + dr[1]);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                
                    cmd = new SqlCommand("AjouterClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mode", "Modifier");
                    cmd.Parameters.AddWithValue("@nom ", textBox1.Text);
                    cmd.Parameters.AddWithValue("@prenom ", textBox3.Text);
                    cmd.Parameters.AddWithValue("@CIN", textBox5.Text);
                    cmd.Parameters.AddWithValue("@adresse", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ville", domainUpDown1.Text);
                    cmd.Parameters.AddWithValue("@tele", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client bien modifié ", "modification du client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
               


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

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                    cmd = new SqlCommand("SupprimerClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CIN ", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client bien supprimer ", "suppression du client ", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message, "Message erreur");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string r = comboBox1.SelectedItem.ToString();
            n = r.Substring(0, comboBox1.Text.IndexOf("  "));
            l = r.Substring(comboBox1.Text.IndexOf("  ") + 1);
            textBox1.Text = n;
            textBox1.Text = l;

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                domainUpDown1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
