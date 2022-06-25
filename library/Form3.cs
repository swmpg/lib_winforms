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
    public partial class Form3 : Form
    {
        string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from [dbo].[chitateli]";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("Введите число (ID)", "Ошибка данных");
                return;
            }

            string query = "DELETE FROM vidacha_literaturi WHERE @id = vidacha_literaturi.chitatel;" +
                "DELETE FROM chitateli WHERE @id = chitateli.id_chitatel;";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@id", id);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();

            Form3_Load(sender, e);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();

            string query = "INSERT INTO chitateli (familia,imia,otchestvo,nomer_telefona) VALUES (@familia,@imia,@otchestvo,@nomer_telefona); "
                + "SELECT CAST(scope_identity() AS int)";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@familia", textBox10.Text);
            sqlcomm.Parameters.AddWithValue("@imia", textBox5.Text);
            sqlcomm.Parameters.AddWithValue("@otchestvo", textBox6.Text);
            sqlcomm.Parameters.AddWithValue("@nomer_telefona", textBox7.Text);
            int chitatel = (int)sqlcomm.ExecuteScalar();

            sqlconn.Close();

            Form3_Load(sender, e);

            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
        }
    }
}
