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
    public partial class AnaSayfa : Form
    {
        public static string ka;
        public static string sf;
        public static string eposta;
        public static string id;
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            KayıtSil f2 = new KayıtSil();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            AidatGecmisiGoruntule f2 = new AidatGecmisiGoruntule();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement12_Click(object sender, EventArgs e)
        {
            //AidatListele f2 = new AidatListele();
            //f2.Dock = DockStyle.Fill;
            //f2.TopLevel = false;
            //f2.FormBorderStyle = FormBorderStyle.None;
            //panel2.Controls.Add(f2);
            //f2.Show();
            //f2.BringToFront();
        }

        private void accordionControlElement14_Click(object sender, EventArgs e)
        {
            EUGecmis f2 = new EUGecmis();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement15_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement16_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement18_Click(object sender, EventArgs e)
        {

        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement16_Click_1(object sender, EventArgs e)
        {
           
            PersonelEkle f2 = new PersonelEkle();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement21_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            SporcuKayıt f2 = new SporcuKayıt();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {
            BransEkle f2 = new BransEkle();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {
            SporcuGuncelle f2 = new SporcuGuncelle();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
            
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand cek = new SqlCommand("SELECT personel_bilgi.personel_ad, personel_bilgi.personel_soyad, personel_bilgi.personel_fotograf, kullanici_bilgi.kullanici_kullanici_ad, kullanici_bilgi.kullanici_kullanici_sifre, spor_brans.spor_brans_ad, spor_brans.spor_brans_id FROM     personel_bilgi INNER JOIN kullanici_bilgi ON personel_bilgi.personel_bilgi_id = kullanici_bilgi.kullanici_personel_bilgi_id INNER JOIN spor_brans ON personel_bilgi.personel_bilgi_spor_brans_id = spor_brans.spor_brans_id where kullanici_bilgi.kullanici_kullanici_ad=@a and kullanici_bilgi.kullanici_kullanici_sifre=@s", baglan);
            cek.Parameters.AddWithValue("@a", ka);
            cek.Parameters.AddWithValue("@s", sf);

            SqlDataReader dr = cek.ExecuteReader();
            if (dr.Read())
            {
                label3.Text = dr[0].ToString()+" "+ dr[1].ToString();
                label2.Text = dr[5].ToString();
                pictureBox1.ImageLocation = dr[2].ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void accordionControlElement19_Click(object sender, EventArgs e)
        {
           
        }

        private void accordionControlElement6_Click_1(object sender, EventArgs e)
        {
            AidatGuncelleme f2 = new AidatGuncelleme();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement20_Click(object sender, EventArgs e)
        {
            MailGonder f2 = new MailGonder();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement13_Click(object sender, EventArgs e)
        {
            EkUcretGirisi f2 = new EkUcretGirisi();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement17_Click(object sender, EventArgs e)
        {
            PersonelEkle f2 = new PersonelEkle();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement18_Click_1(object sender, EventArgs e)
        {
            personebilgigüncelle.GS = 0;
            PersonelListesi f2 = new PersonelListesi();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement15_Click_1(object sender, EventArgs e)
        {
            SporcuListesi f2 = new SporcuListesi();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            SporcuListesi.gec = 2;
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement22_Click(object sender, EventArgs e)
        {
            SporcuListesi f2 = new SporcuListesi();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            SporcuListesi.gec = 1;
            f2.Show();
            f2.BringToFront();
        }

        private void accordionControlElement24_Click(object sender, EventArgs e)
        {

            HesapBilgileri hb = new HesapBilgileri();
            hb.Dock = DockStyle.Fill;
            hb.TopLevel = false;
            hb.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(hb);
            hb.Show();
            hb.BringToFront();
        }

        private void accordionControlElement17_Click_1(object sender, EventArgs e)
        {
            personebilgigüncelle.GS = 1;
            PersonelListesi f2 = new PersonelListesi();
            f2.Dock = DockStyle.Fill;
            f2.TopLevel = false;
            f2.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(f2);
            f2.Show();
            f2.BringToFront();
        }
    }
}
