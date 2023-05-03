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

namespace Projee
{
    
    public partial class Form1 : Form
    {
        string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand giris = new SqlCommand("SELECT personel_bilgi.personel_bilgi_id, personel_bilgi.personel_ad, personel_bilgi.personel_soyad, personel_bilgi.personel_tc, personel_bilgi.personel_adres, personel_bilgi.personel_ceptelefon, personel_bilgi.personel_bilgi_spor_brans_id, personel_bilgi.personel_fotograf, personel_bilgi.personel_eposta, kullanici_bilgi.kullanici_bilgi_id, kullanici_bilgi.kullanici_kullanici_ad, kullanici_bilgi.kullanici_kullanici_sifre, kullanici_bilgi.kullanici_kullanici_yetki, kullanici_bilgi.kullanici_personel_bilgi_id FROM     personel_bilgi INNER JOIN kullanici_bilgi ON personel_bilgi.personel_bilgi_id = kullanici_bilgi.kullanici_personel_bilgi_id where kullanici_bilgi.kullanici_kullanici_ad=@ka and kullanici_bilgi.kullanici_kullanici_sifre=@ks", baglan);
            giris.Parameters.AddWithValue("@ka",bunifuMetroTextbox1.Text);
            giris.Parameters.AddWithValue("@ks", bunifuMetroTextbox2.Text);
            SqlDataReader dr = giris.ExecuteReader();
            if(dr.Read())
            {
                AnaSayfa.ka = bunifuMetroTextbox1.Text;
                AnaSayfa.sf = bunifuMetroTextbox2.Text;
                AnaSayfa.eposta = dr[8].ToString();
                AnaSayfa.id = dr[0].ToString();
                PersonelEkle.yetki = dr[12].ToString();
                PersonelEkle.kim = dr[1].ToString();
                AnaSayfa git = new AnaSayfa();
                this.Hide();
                git.Show();
           
            }
            else
            {
                MessageBox.Show("HATA!!!!!!");
            }
            baglan.Close();
            

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }

        private void bunifuMetroTextbox2_Click(object sender, EventArgs e)
        {
            bunifuMetroTextbox2.Text = "";
        }

        private void bunifuMetroTextbox2_MouseClick(object sender, MouseEventArgs e)
        {
            bunifuMetroTextbox2.Text = "";
        }

        private void bunifuMetroTextbox1_MouseClick(object sender, MouseEventArgs e)
        {
            bunifuMetroTextbox1.Text = "";
        }
    }
}
