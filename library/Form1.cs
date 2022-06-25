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
    public partial class Form1 : Form       
    {
        string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //создание запроса и передача данных сначала в таблицу, затем в datagridview
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select vidacha_literaturi.id_vidacha_literaturi, " +
                "chitateli.familia, literatura.nazvanie, data_vidachi, data_sdachi from [dbo].[vidacha_literaturi] inner join [dbo].[literatura]";
            sqlquery += "on literatura.id_literatura = vidacha_literaturi.literatura inner join [dbo].[chitateli]" +
                " on chitateli.id_chitatel = vidacha_literaturi.chitatel"; 
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;

            //запрет на выделение в datagridview
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;

            //автозаполнение в textbox

            Autocomp(sqlconn, "SELECT familia FROM chitateli", textBox1);
            Autocomp(sqlconn, "SELECT imia FROM chitateli", textBox2);
            Autocomp(sqlconn, "SELECT otchestvo FROM chitateli", textBox3);
            Autocomp(sqlconn, "SELECT nazvanie FROM literatura", textBox4);
            Autocomp(sqlconn, "SELECT kategoria FROM literatura", textBox5);
            Autocomp(sqlconn, "SELECT avtor FROM literatura", textBox6);
            Autocomp(sqlconn, "SELECT izdatelstvo FROM literatura", textBox7);
            Autocomp(sqlconn, "SELECT data_vidachi FROM vidacha_literaturi", textBox8);
            Autocomp(sqlconn, "SELECT data_sdachi FROM vidacha_literaturi", textBox9);
            Autocomp(sqlconn, "SELECT familia FROM chitateli", textBox11);
            Autocomp(sqlconn, "SELECT nomer_telefona FROM chitateli", textBox12);

            sqlconn.Close();
                       
        }

        private void Autocomp(SqlConnection sqlconn, string command, TextBox box)
        {
            //автозаполнение в textbox
            SqlCommand sqlcommm = new SqlCommand(command, sqlconn);
            sqlconn.Open();
            SqlDataReader dr = sqlcommm.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            box.AutoCompleteCustomSource = mycollection;
            sqlconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();

            //добавление читателей
            string query = "INSERT INTO chitateli (familia,imia,otchestvo,nomer_telefona) VALUES (@familia,@imia,@otchestvo,@nomer_telefona); "
                + "SELECT CAST(scope_identity() AS int)";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@familia", textBox1.Text);
            sqlcomm.Parameters.AddWithValue("@imia", textBox2.Text);
            sqlcomm.Parameters.AddWithValue("@otchestvo", textBox3.Text);
            sqlcomm.Parameters.AddWithValue("@nomer_telefona", textBox12.Text);
            int chitatel = (int)sqlcomm.ExecuteScalar();

            //добавление литературы
            query = "INSERT INTO literatura (nazvanie,kategoria,avtor,izdatelstvo) VALUES (@nazvanie,@kategoria,@avtor,@izdatelstvo); " 
                + "SELECT CAST(scope_identity() AS int)";
            sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@nazvanie", textBox4.Text);
            sqlcomm.Parameters.AddWithValue("@kategoria", textBox5.Text);
            sqlcomm.Parameters.AddWithValue("@avtor", textBox6.Text);
            sqlcomm.Parameters.AddWithValue("@izdatelstvo", textBox7.Text);
            int literatura = (int)sqlcomm.ExecuteScalar();

            //добавление выдачи
            query = "INSERT INTO vidacha_literaturi (chitatel,literatura,data_vidachi,data_sdachi) VALUES (@chitatel,@literatura,@data_vidachi,@data_sdachi);";
            sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@chitatel", chitatel);
            sqlcomm.Parameters.AddWithValue("@literatura", literatura);
            sqlcomm.Parameters.AddWithValue("@data_vidachi", textBox8.Text);
            sqlcomm.Parameters.AddWithValue("@data_sdachi", textBox9.Text);
            sqlcomm.ExecuteNonQuery();

            sqlconn.Close();

            Form1_Load(sender, e);

            //очищение textbox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox12.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            //сообщение на неверно введеное число
            if (!int.TryParse(textBox10.Text, out int id))
            {
                MessageBox.Show("Введите число (ID)", "Ошибка данных");
                return;
            }
            //удаление по id
            string query = "DELETE FROM vidacha_literaturi WHERE @id = vidacha_literaturi.id_vidacha_literaturi;";
            SqlCommand sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.AddWithValue("@id", id);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            textBox10.Text = "";

            Form1_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //нахождение нужной записи
            dataGridView1.ClearSelection();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                var value = dataGridView1[1, i].Value.ToString().ToLower();

                if (value.Contains(textBox11.Text.ToLower()))
                {
                    dataGridView1.Rows[i].Selected = true;
                    textBox11.Text = "";
                    return;
                }
            }

            MessageBox.Show("Запись не найдена", "Предупреждение");
        }

        private void openliteratura(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
        }

        private void ЧитателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }

        private void заказатьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form4();
            form.Show();
        }

        private void поискПоДолжникамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form5();
            form.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void друшиеБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
