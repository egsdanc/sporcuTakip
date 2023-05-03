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
   
    public partial class sporcubilgigüncelle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
        int i = 0;
        int j = 0;
        public static string id;
        public static int deger;

        
        public void combo1ekle()
        {
            baglan.Open();
            SqlCommand sb2 = new SqlCommand("SELECT yas_grubu_id, yas_grubu_ad FROM yas_grubu", baglan);
            SqlDataAdapter ck1 = new SqlDataAdapter(sb2);
            DataTable gs1 = new DataTable();
            ck1.Fill(gs1);
            comboBox1.DisplayMember = "yas_grubu_ad";
            comboBox1.ValueMember = "yas_grubu_id";
            comboBox1.DataSource = gs1;
            baglan.Close();
        }
        public void combo2ekle()
        {
            baglan.Open();
            SqlCommand sbl = new SqlCommand("SELECT spor_brans_id, spor_brans_ad FROM spor_brans", baglan);
            SqlDataAdapter ck = new SqlDataAdapter(sbl);
            DataTable gs = new DataTable();
            ck.Fill(gs);
            comboBox2.DisplayMember = "spor_brans_ad";
            comboBox2.ValueMember = "spor_brans_id";
            comboBox2.DataSource = gs;
            baglan.Close();

        }
            String a;
        int blg;
        public sporcubilgigüncelle()
        {
            InitializeComponent();
        }
   
        DataSet1TableAdapters.DataTable1TableAdapter gnctrkcll = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {

        }
       
        private void sporcubilgigüncelle_Load(object sender, EventArgs e)
        {
           if(deger==1)
            {
                button4.Visible = false;
                
            }
           else 
                {
                button4.Visible = true;
                button3.Visible = false;
                
                }
            combo1ekle();
            combo2ekle();
            DataRowView sb = comboBox2.SelectedItem as DataRowView;
            string sbi = sb.Row["spor_brans_id"].ToString();

            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT sporcu_ekle.sporcu_ekle_id, sporcu_ekle.sporcu_ekle_sporcu_bilgi_id, sporcu_ekle.sporcu_ekle_yas_grubu_id, sporcu_ekle.sporcu_ekle_spor_brans_id, sporcu_ekle.sporcu_ekle_kayit_tarihi, sporcu_ekle.sporcu_ekle_anlasilan_tarih, sporcu_ekle.sporcu_ekle_anlasilan_ucret, sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_adres, sporcu_bilgi.sporcu_okul, sporcu_bilgi.sporcu_dogum_yer, sporcu_bilgi.sporcu_dogum_tarih, sporcu_bilgi.sporcu_ceptelefon, sporcu_bilgi.sporcu_email, sporcu_bilgi.sporcu_bilgi_veli_bilgi_id, sporcu_bilgi.sporcu_fotograf, yas_grubu.yas_grubu_ad, spor_brans.spor_brans_ad FROM     sporcu_ekle INNER JOIN sporcu_bilgi ON sporcu_ekle.sporcu_ekle_sporcu_bilgi_id = sporcu_bilgi.sporcu_bilgi_id INNER JOIN yas_grubu ON sporcu_ekle.sporcu_ekle_yas_grubu_id = yas_grubu.yas_grubu_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id where sporcu_ekle.sporcu_ekle_id=@p1", baglan);
            
            
            komut.Parameters.AddWithValue("@p1",id) ;
            
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                blg = Convert.ToInt32(dr[1]) ;
                textBox1.Text = (dr[9].ToString());
                textBox8.Text = (dr[6].ToString());
                textBox2.Text = (dr[7].ToString());
                textBox3.Text = (dr[8].ToString());
                dateEdit1.Text = dr[13].ToString();
                textBox4.Text= dr[12].ToString();
                textBox5.Text = dr[10].ToString();
                textBox6.Text = dr[11].ToString();
                maskedTextBox1.Text = dr[14].ToString();
                dateEdit2.Text= dr[4].ToString();
               
                dateEdit3.Text = dr[5].ToString();
                textBox15.Text= (dr[15].ToString());
       
                pictureBox1.ImageLocation = dr[17].ToString();
                a = dr[16].ToString();
                foreach(var item in comboBox2.Items)
                {
                    
                    DataRowView row = item as DataRowView;
                    string displayValue = row["spor_brans_id"].ToString();
                    if(displayValue==dr[3].ToString())  
                    {
                        
                        comboBox2.SelectedIndex=i;
                    }
                    i = i + 1;
                }
                foreach (var item in comboBox1.Items)
                {

                    DataRowView row1 = item as DataRowView;
                    string displayValue1 = row1["yas_grubu_id"].ToString();
                    if (displayValue1 == dr[3].ToString())
                    {
                        
                        comboBox1.SelectedIndex = j;
                    }
                    j = j + 1;
                }

            }
            baglan.Close();
            baglan.Open();
            SqlCommand list = new SqlCommand("Select * from veli_bilgi where veli_bilgi_id=@i", baglan);
          
            list.Parameters.AddWithValue("@i",a);
           
            SqlDataReader d = list.ExecuteReader();
            while (d.Read())
            {
                textBox10.Text = d[1].ToString();
                textBox12.Text = d[2].ToString();
                maskedTextBox3.Text = d[3].ToString();
                textBox9.Text = d[4].ToString();
                textBox11.Text = d[5].ToString();
                maskedTextBox2.Text = d[6].ToString();
               

            }
            baglan.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand veliguncelle = new SqlCommand("UPDATE veli_bilgi SET veli_anne_ad=@aad,veli_anne_soyad=@asa,veli_anne_ceptelefon=@acp,veli_baba_ad=@bad,veli_baba_soyad=@bsa,veli_baba_ceptelefon=@bcp WHERE veli_bilgi_id=@vbid",baglan);
            veliguncelle.Parameters.AddWithValue("@vbid",a);
            veliguncelle.Parameters.AddWithValue("@aad",textBox10.Text);
            veliguncelle.Parameters.AddWithValue("@asa", textBox12.Text);
            veliguncelle.Parameters.AddWithValue("@acp", maskedTextBox3.Text);
            veliguncelle.Parameters.AddWithValue("@bad", textBox9.Text);
            veliguncelle.Parameters.AddWithValue("@bsa", textBox11.Text);
            veliguncelle.Parameters.AddWithValue("@bcp", maskedTextBox2.Text);
            veliguncelle.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Veli bilgileri başarıyla güncellenmiştir!");



        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { DialogResult s = new DialogResult();
            s = MessageBox.Show("Emin misiniz?","Onayla",MessageBoxButtons.YesNo);
            if (s==DialogResult.Yes)
            {
                DataRowView sb = comboBox2.SelectedItem as DataRowView;
            string sbi = sb.Row["spor_brans_id"].ToString();
            DataRowView sb22 = comboBox1.SelectedItem as DataRowView;
            string sbi22 = sb22.Row["yas_grubu_id"].ToString();
            baglan.Open();

            SqlCommand guncelle = new SqlCommand("UPDATE sporcu_bilgi SET sporcu_ad=@a,sporcu_soyad=@sa,sporcu_tc=@tc,sporcu_adres=@adr,sporcu_okul=@o,sporcu_dogum_yer=@dy,sporcu_dogum_tarih=@dt,sporcu_ceptelefon=@ct,sporcu_email=@e,sporcu_fotograf=@f WHERE sporcu_bilgi_id=@bilgi ", baglan);
            guncelle.Parameters.AddWithValue("@bilgi", blg);
            guncelle.Parameters.AddWithValue("@a", textBox2.Text);
            guncelle.Parameters.AddWithValue("@sa", textBox3.Text);
            guncelle.Parameters.AddWithValue("@tc", textBox1.Text);
            guncelle.Parameters.AddWithValue("@adr", textBox5.Text);
            guncelle.Parameters.AddWithValue("@o", textBox6.Text);
            guncelle.Parameters.AddWithValue("@dy", textBox4.Text);
            guncelle.Parameters.AddWithValue("@dt", dateEdit1.Text);
            guncelle.Parameters.AddWithValue("@ct", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@e", textBox15.Text);
            guncelle.Parameters.AddWithValue("@f", pictureBox1.ImageLocation);
            guncelle.ExecuteNonQuery();
            baglan.Close();
            baglan.Open();
            SqlCommand seguncelle = new SqlCommand("UPDATE sporcu_ekle SET sporcu_ekle_yas_grubu_id=@ygi,sporcu_ekle_spor_brans_id=@sbi,sporcu_ekle_kayit_tarihi=@kt,sporcu_ekle_anlasilan_tarih=@at,sporcu_ekle_anlasilan_ucret=@au WHERE sporcu_ekle_id=@sei1", baglan);

            seguncelle.Parameters.AddWithValue("@sei1", id);
            seguncelle.Parameters.AddWithValue("@ygi", sbi22);
            seguncelle.Parameters.AddWithValue("@sbi", sbi);
            seguncelle.Parameters.AddWithValue("@kt", dateEdit2.Text);
            seguncelle.Parameters.AddWithValue("@at", dateEdit3.Text);
            seguncelle.Parameters.AddWithValue("@au", textBox8.Text);
            seguncelle.ExecuteNonQuery();
            baglan.Close();
                MessageBox.Show("Kayıt başarıyla güncellenmiştir!");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = xtraOpenFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sil = new SqlCommand("update sporcu_ekle SET aktiflik=@a where sporcu_ekle_id=@sss ",baglan);
            sil.Parameters.AddWithValue("@a",false);
            sil.Parameters.AddWithValue("@sss", id);
            sil.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt başarıyla silinmiştir!");

        }
    }
}
