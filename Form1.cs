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

namespace VeriTtabaniGoruntuleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=GÖKHAN;Initial Catalog=Okul;Integrated Security=True");
        private void verigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Bilgiler",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adi"].ToString();
                ekle.SubItems.Add(oku["SoyAdi"].ToString());
                ekle.SubItems.Add(oku["Okul"].ToString());
                ekle.SubItems.Add(oku["Bolum"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close(); // bunu yazmazsak bağlantı açık olduğu için, butona bir daha tıkladığımızda hata verir.
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verigoster();
        }
    }
}
