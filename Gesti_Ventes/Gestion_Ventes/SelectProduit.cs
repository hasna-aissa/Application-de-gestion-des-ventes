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
    public partial class SelectProduit : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public SelectProduit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (button1.Text != "")
            {
                button1.Text = "";
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=30", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button1.Text += dt.Rows[0][0].ToString();
        }

        private void SelectProduit_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data source =Adminpc\\SQLEXPRESS;initial Catalog =Gestion_ventes;Integrated security = True");
            cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "select designation,prix from article";
            dr = cmd.ExecuteReader();
            con.Close();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=31", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button2.Text += dt.Rows[0][0].ToString();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.Text != "")
            {
                button2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.Text != "")
            {
                button3.Text = "";
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=32", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button3.Text += dt.Rows[0][0].ToString();

        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=33", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button6.Text += dt.Rows[0][0].ToString();
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=34", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button5.Text += dt.Rows[0][0].ToString();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=35", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button4.Text += dt.Rows[0][0].ToString();
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=36", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button9.Text += dt.Rows[0][0].ToString();
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=37", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button8.Text += dt.Rows[0][0].ToString();
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select designation,prix from article where numArticle=38", con);
            DataTable dt = new System.Data.DataTable();
            sd.Fill(dt);
            button7.Text += dt.Rows[0][0].ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            contacternous cn = new contacternous();
            cn.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            firstone ft = new firstone();
            this.Hide();
            ft.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            if (button6.Text != "")
            {
                button6.Text = "";
            }
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            if (button5.Text != "")
            {
                button5.Text = "";
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (button4.Text != "")
            {
                button4.Text = "";
            }
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            if (button9.Text != "")
            {
                button9.Text = "";
            }
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            if (button8.Text != "")
            {
                button8.Text = "";
            }
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            if (button7.Text != "")
            {
                button7.Text = "";
            }
        }
    }
}
