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
    public partial class Duzenle : Form
    {
        public Duzenle()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            AidatIslemleriTableAdapters.aidat_bilgi2TableAdapter guncelle = new AidatIslemleriTableAdapters.aidat_bilgi2TableAdapter();
            guncelle.AidatUpdateQuery(textBox1.Text, dateTimePicker1.Text, AidatGecmisiGoruntule.aid, AidatGecmisiGoruntule.aid);
            MessageBox.Show("Başarıyla Güncellendi!");
        }

        private void Duzenle_Load(object sender, EventArgs e)
        {
            
            string ad = "";
            string soyad = "";
            string tc = "";
            string ucret = "";
            string tarih = "";
            string brans = "";
            string resim = "";

            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-9C856BD;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT sporcu_bilgi.sporcu_fotograf,sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, spor_brans.spor_brans_ad, aidat_bilgi.aidat_bilgi_id, aidat_bilgi.aidat_bilgi_alinan_ucret, aidat_bilgi.aidat_bilgi_aidat_tarihi FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id INNER JOIN aidat_bilgi ON sporcu_ekle.sporcu_ekle_id = aidat_bilgi.aidat_bilgi_sporcu_ekle_id WHERE aidat_bilgi.aidat_bilgi_id=@id", baglan);
            komut.Parameters.AddWithValue("@id", AidatGecmisiGoruntule.aid);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                ad = dr["sporcu_ad"].ToString();
                soyad = dr["sporcu_soyad"].ToString();
                tc = dr["sporcu_tc"].ToString();
                ucret = dr["aidat_bilgi_alinan_ucret"].ToString();
                tarih = dr["aidat_bilgi_aidat_tarihi"].ToString();
                brans = dr["spor_brans_ad"].ToString();
                resim = dr[0].ToString();
            }

            
            label7.Text = ad;
            label8.Text = soyad;
            label9.Text = tc;
            label10.Text = brans;
            label12.Text = tarih;
            textBox1.Text = ucret;
            pictureBox1.ImageLocation = resim;
            baglan.Close();
        }
    }
}
