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
    public partial class personebilgigüncelle : Form
    {
        public static string gelenpbid;
        public static int GS;
        public static string gelenkid;
        public static string gelensbid;
        public static int guncelle;

        string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
        
        public void combo1ekle()
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
       public void kullanicilist()     //kullanıcı  tablosunu silteliyor  eğer personelin id sütunuda personelimizin id si yok ise
                                       // kullanıcı oluşturma paneli görünür oluyor var ise görünürlüğü gidiyor ve personelin kullanıcı adı
                                       // şifre bilgilerinin olduğu panel görünür oluyor bunların hepsini programa giriş yapan kişinin yetkisi
                                       // yönetici ise yapıyor yönetici değil iste yetkiniz yok yazıyor personel işlemi yaptırmıyor
        {
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand list = new SqlCommand("SELECT * FROM kullanici_bilgi where kullanici_personel_bilgi_id=@pp",baglan);
            list.Parameters.AddWithValue("@pp",gelenpbid);
            SqlDataReader dr1 = list.ExecuteReader();
            if(dr1.Read() )
            {
                    panel1.Visible = true;
                textBox5.Text = dr1[1].ToString();
                textBox6.Text = dr1[2].ToString();
                comboBox2.SelectedItem = dr1[3];
                button2.Visible = false;
                

              
            }
            else
            {
                panel1.Visible = false;
                button2.Visible = true;
            }
            baglan.Close();
        }
        public void pbcek()
        {
            int j=0;
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand cek = new SqlCommand("SELECT * FROM personel_bilgi where personel_bilgi_id=@p", baglan);
            cek.Parameters.AddWithValue("@p",gelenpbid);
    
            SqlDataReader dr = cek.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox7.Text = dr[8].ToString();
                maskedTextBox1.Text = dr[5].ToString();
                pictureBox1.ImageLocation = dr[7].ToString();
                foreach (var item in comboBox1.Items)
                {

                    DataRowView row1 = item as DataRowView;
                    string displayValue1 = row1["spor_brans_id"].ToString();
                    if (displayValue1 == dr[6].ToString())
                    {

                        comboBox1.SelectedIndex = j;
                    }
                    j = j + 1;
                }
            }
            baglan.Close();
        }
        public void kcek()
        {

            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand cek = new SqlCommand("SELECT * FROM personel_bilgi where personel_bilgi_id=@p", baglan);
        }
        public personebilgigüncelle()
        {
            InitializeComponent();
        }

        private void personebilgigüncelle_Load(object sender, EventArgs e)
        {
            if(GS==0)    // eğer ana sayfadan personel bilgilerini sil i seçersek güncellemme butonu kayboluyor
            {            // eğer ana sayfadan personel bilgi güncelle yi seçersek sil butonu kayboluyor
                bunifuFlatButton1.Visible = true;
                button5.Visible = false;           
            }
            else
            {
                bunifuFlatButton1.Visible = false;
                button5.Visible = true;
            }
            combo1ekle();
            pbcek();
            kullanicilist();
            if (PersonelEkle.yetki != "yönetici")
            {
                panel1.Visible = false;
            }



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (PersonelEkle.yetki == "yönetici")
            {
                try
                {



                    DataRowView sb = comboBox1.SelectedItem as DataRowView;
                    string sbi = sb.Row["spor_brans_id"].ToString();
                    SqlConnection baglan = new SqlConnection(link);
                    baglan.Open();
                    SqlCommand pbgünc = new SqlCommand("UPDATE personel_bilgi SET personel_ad=@pa1,personel_soyad=@ps1,personel_tc=@ptc1,personel_adres=@padrs1,personel_ceptelefon=@pct1,personel_fotograf=@pff ,personel_eposta=@ee , personel_bilgi_spor_brans_id=@psbi1 WHERE personel_bilgi_id=@pp2 ", baglan);
                    pbgünc.Parameters.AddWithValue("@pa1", textBox1.Text);
                    pbgünc.Parameters.AddWithValue("@ps1", textBox2.Text);
                    pbgünc.Parameters.AddWithValue("@ptc1", textBox3.Text);
                    pbgünc.Parameters.AddWithValue("@padrs1", textBox4.Text);
                    pbgünc.Parameters.AddWithValue("@ee", textBox7.Text);
                    pbgünc.Parameters.AddWithValue("@pp2", gelenpbid);
                    pbgünc.Parameters.AddWithValue("@pct1", maskedTextBox1.Text);
                    pbgünc.Parameters.AddWithValue("@pff", pictureBox1.ImageLocation);
                    pbgünc.Parameters.AddWithValue("@psbi1", sbi);
                    pbgünc.ExecuteNonQuery();
                    baglan.Close();



                    baglan.Open();

                    SqlCommand kgunc = new SqlCommand("UPDATE kullanici_bilgi SET kullanici_kullanici_ad=@ka1,kullanici_kullanici_sifre=@ks1,kullanici_kullanici_yetki=@ky1 where kullanici_personel_bilgi_id=@kpb1i ", baglan);
                    kgunc.Parameters.AddWithValue("@ka1", textBox5.Text);
                    kgunc.Parameters.AddWithValue("@ks1", textBox6.Text);
                    kgunc.Parameters.AddWithValue("@ky1", comboBox2.SelectedItem);
                    kgunc.Parameters.AddWithValue("@kpb1i", gelenpbid);
                    kgunc.ExecuteNonQuery();

                    baglan.Close();
                    MessageBox.Show("Personel bilgileri başarıyla güncellendi!");
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("yetkiniz yok! "+"  " + PersonelEkle.kim);
            }
                    
      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = xtraOpenFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(PersonelEkle.yetki=="yönetici")
           {
             
                panel2.Visible = true;
                button2.Visible = false;
                button4.Visible = true;
            }
           else
            {
                label14.Text = "yetkiniz yok";
            }
           
           
            }

        private void button4_Click(object sender, EventArgs e)
        {


            
                panel2.Visible = false;
                button4.Visible = false;
                button2.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglan = new SqlConnection(link);
                baglan.Open();
                SqlCommand kekle = new SqlCommand("INSERT INTO kullanici_bilgi(kullanici_kullanici_ad,kullanici_kullanici_sifre,kullanici_kullanici_yetki,kullanici_personel_bilgi_id) VALUES(@aa,@ss,@ky,@kpi)", baglan);
                kekle.Parameters.AddWithValue("@aa", textBox8.Text);
                kekle.Parameters.AddWithValue("@ss", textBox9.Text);
                kekle.Parameters.AddWithValue("@ky", comboBox3.SelectedItem);
                kekle.Parameters.AddWithValue("@kpi", gelenpbid);
                kekle.ExecuteNonQuery();
                baglan.Close();
                button3.Visible = false;
            }
            catch
            {
                label15.Text = "alanlar boş bırakılamaz";
              
            }
         }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand pbsil = new SqlCommand("UPDATE personel_bilgi SET aktiflik=@a where personel_bilgi_id=@kpb1i ", baglan);
            pbsil.Parameters.AddWithValue("@a", false);
            pbsil.Parameters.AddWithValue("@kpb1i", gelenpbid);
            pbsil.ExecuteNonQuery();
            baglan.Close();
        }
    }

  
    }  
    
 

