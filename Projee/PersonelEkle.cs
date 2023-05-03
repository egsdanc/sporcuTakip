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
    
    public partial class PersonelEkle : Form
    {
        bool aktiflik = true;
        public static string yetki;
        public static string kim;
        string pbi;
        string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
        public void combobrans()
        {
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand sbl = new SqlCommand("SELECT spor_brans_id, spor_brans_ad FROM spor_brans", baglan);
            SqlDataAdapter ck = new SqlDataAdapter(sbl);
            DataTable gs = new DataTable();
            ck.Fill(gs);
            comboBox1.DisplayMember = "spor_brans_ad";
            comboBox1.ValueMember = "spor_brans_id";
            comboBox1.DataSource = gs;
            baglan.Close();

        }
       public void personelid()
        {
            SqlConnection baglan1 = new SqlConnection(link);
            baglan1.Open();
            SqlCommand pilist = new SqlCommand("SELECT personel_bilgi_id FROM personel_bilgi where personel_tc=@tc",baglan1);
            pilist.Parameters.AddWithValue("@tc",textBox3.Text);
            SqlDataReader dr = pilist.ExecuteReader();
            if(dr.Read())
            {
                pbi = dr[0].ToString();
            }
            baglan1.Close();
        }

       
        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (yetki == "yönetici")
            {
                try
                {       //ekle butonuna bastığımızda önce personel ekleniyor kullanıcı tablosuna personel id sini yüklüyor
                        // her personele kullanıcı eklemek doğru olmadığından try catch kullandım
                        // sadece personeli eklemek istediğim için  kullanıcı bilgilerini boş bırakıyorum 
                        // kullanıcı tablosu boş deger kabul etmediği için program ahata veriyor try catch ile hatayı görmüyorum
                        // program hatayı personeli ekledikten sonra verdiği için personeli ekliyor 
                        // kullanıcı eklerken hata veriyor kullanıcı tablosuna ekleme yapmıyor
                        // giriiş yapanın yetkisi yönetici ise yapıyor yönetici değil iste yetkiniz yok yazıyor personel ekleme işlemi yaptırmıyor

                    DataRowView sb = comboBox1.SelectedItem as DataRowView;
                    string sbi = sb.Row["spor_brans_id"].ToString();

                    SqlConnection baglan = new SqlConnection(link);
                    baglan.Open();
                    SqlCommand eklepersonel = new SqlCommand("INSERT INTO personel_bilgi(personel_ad,personel_soyad,personel_tc,personel_adres,personel_ceptelefon,personel_bilgi_spor_brans_id,personel_fotograf,personel_eposta,aktiflik) VALUES(@pa,@ps,@ptc,@padrs,@pcpt,@psbi,@f,@eposta,@aktiflik)", baglan);
                    eklepersonel.Parameters.AddWithValue("@pa", textBox1.Text);
                    eklepersonel.Parameters.AddWithValue("@ps", textBox2.Text);
                    eklepersonel.Parameters.AddWithValue("@ptc", textBox3.Text);
                    eklepersonel.Parameters.AddWithValue("@padrs", textBox4.Text);
                    eklepersonel.Parameters.AddWithValue("@pcpt", maskedTextBox1.Text);
                    eklepersonel.Parameters.AddWithValue("@psbi", sbi);
                    eklepersonel.Parameters.AddWithValue("@f", pictureBox1.ImageLocation);
                    eklepersonel.Parameters.AddWithValue("@eposta", textBox7.Text);
                    eklepersonel.Parameters.AddWithValue("@aktiflik", aktiflik);
                    eklepersonel.ExecuteNonQuery();
                    baglan.Close();
                    personelid();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Personel başarıyla eklendi!");
                    baglan.Open();
                    SqlCommand eklekullanici = new SqlCommand("INSERT INTO kullanici_bilgi(kullanici_kullanici_ad,kullanici_kullanici_sifre,kullanici_kullanici_yetki,kullanici_personel_bilgi_id) VALUES(@kad,@ksdr,@kyetki,@kpbid)", baglan);
                    eklekullanici.Parameters.AddWithValue("@kad", textBox5.Text);
                    eklekullanici.Parameters.AddWithValue("@ksdr", textBox6.Text);
                    eklekullanici.Parameters.AddWithValue("@kyetki", comboBox2.SelectedItem);
                    eklekullanici.Parameters.AddWithValue("@kpbid", pbi);
                    eklekullanici.ExecuteNonQuery();
                    baglan.Close();
             
                }
                catch
                {
                    
                }
            }
            else
            {
                MessageBox.Show("yetkiniz yok! "+"  " + kim);
            }
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            combobrans();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = xtraOpenFileDialog1.FileName;
        }
    }
}
