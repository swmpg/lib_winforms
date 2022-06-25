using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class Form5 : Form
    {
        string mainconn = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select " +
                "chitateli.familia, literatura.nazvanie, data_vidachi, data_sdachi from [dbo].[vidacha_literaturi] inner join [dbo].[literatura]";
            sqlquery += "on literatura.id_literatura = vidacha_literaturi.literatura inner join [dbo].[chitateli]" +
                " on chitateli.id_chitatel = vidacha_literaturi.chitatel where GETDATE() > CONVERT(DATETIME, data_sdachi, 103)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
