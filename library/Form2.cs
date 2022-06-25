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
using System.Configuration;

namespace library
{
    public partial class Form2 : Form
    {
        string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from [dbo].[literatura]";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("Введите число (ID)", "Ошибка данных");
                return;
            }

            string query = "DELETE FROM vidacha_literaturi WHERE @id = vidacha_literaturi.literatura;" +
                "DELETE FROM literatura WHERE @id = literatura.id_literatura;";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@id", id);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            Form2_Load(sender, e);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
                        
            string query = "INSERT INTO literatura (nazvanie,kategoria,avtor,izdatelstvo) VALUES (@nazvanie,@kategoria,@avtor,@izdatelstvo); "
                + "SELECT CAST(scope_identity() AS int)";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@nazvanie", textBox10.Text);
            sqlcomm.Parameters.AddWithValue("@kategoria", textBox5.Text);
            sqlcomm.Parameters.AddWithValue("@avtor", textBox6.Text);
            sqlcomm.Parameters.AddWithValue("@izdatelstvo", textBox7.Text);
            int literatura = (int)sqlcomm.ExecuteScalar();

            sqlconn.Close();

            Form2_Load(sender, e);

            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
        }
    }
}
