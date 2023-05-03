using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.Threading;
using Projee.EKUCRETLERRTableAdapters;

namespace Projee
{
    public partial class MailGonder : Form
    {
        string sbi="1";
        string sbi22="1";
        DataRowView sb22;
        DataRowView sb;
        public MailGonder()
        {
            InitializeComponent();
        }
        public string dosya = "";
        public void personellist()
        {
            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
           SqlCommand list=new SqlCommand ("SELECT * from personel_bilgi where personel_bilgi_spor_brans_id=@s and aktiflik=@a", baglan);
            list.Parameters.AddWithValue("@s",sbi );
            list.Parameters.AddWithValue("@a", true);
            SqlDataAdapter da = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
        }
        public void combo2ekle()
        {

            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
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
        public void combo1ekle()
        {

            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
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



        void Listele()
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {





            try
            {
                string mail;
                string parola;
                mail = mailtbox.Text;
                parola = mparolatbox.Text;
                MailMessage mesaj = new MailMessage();
                SmtpClient istemci = new SmtpClient();

                mesaj.IsBodyHtml = true;
                istemci.Credentials = new System.Net.NetworkCredential(mail, parola);
                istemci.Port = 587;
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true;
                mesaj.Subject = konutbox.Text;
                mesaj.Body = icerikrtbox.Text;
                mesaj.From = new MailAddress(mail);
                if (checkBox1.Checked)
                {
                    Attachment atach = new Attachment(dosya);
                    mesaj.Attachments.Add(atach);
                }

                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    if (null != dataGridView1.Rows[i].Cells["Mail Adresi"].Value.ToString())
                    {
                        mesaj.To.Add(dataGridView1.Rows[i].Cells["Mail Adresi"].Value.ToString());

                        istemci.Send(mesaj);
                        MessageBox.Show("Mailiniz başarıyla gönderilmiştir!");
                    }
                   
                    
                    if( i % 90 == 0)
                    {
                        Thread.Sleep(10000);
                    }


                }
            }



            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu.Hata kodu:\n" + hata);
            }

}

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                dosya = file.FileName;
                simpleButton2.Text = dosya;
            }
            catch (Exception sorun)
            {
                MessageBox.Show("Bir sorun oluştu. Hata kodu:\n" + sorun);
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                dosya = file.FileName;
                simpleButton2.Text = dosya;
            }
            catch (Exception sorun)
            {
                MessageBox.Show("Bir sorun oluştu. Hata kodu:\n" + sorun);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
                    }

       
        private void MailGonder_Load(object sender, EventArgs e)
        {
           

             combo1ekle();
            combo2ekle();



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
               
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
              sb22 = comboBox1.SelectedItem as DataRowView;
            sbi22 = sb22.Row["yas_grubu_id"].ToString();
           
            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand list = new SqlCommand("SELECT sporcu_ekle.sporcu_ekle_id, sporcu_ekle.sporcu_ekle_sporcu_bilgi_id, sporcu_ekle.sporcu_ekle_yas_grubu_id, sporcu_ekle.sporcu_ekle_spor_brans_id, sporcu_ekle.sporcu_ekle_kayit_tarihi, sporcu_ekle.sporcu_ekle_anlasilan_tarih, sporcu_ekle.sporcu_ekle_anlasilan_ucret, sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_adres, sporcu_bilgi.sporcu_okul, sporcu_bilgi.sporcu_dogum_yer, sporcu_bilgi.sporcu_dogum_tarih, sporcu_bilgi.sporcu_ceptelefon, sporcu_bilgi.sporcu_email, sporcu_bilgi.sporcu_bilgi_veli_bilgi_id, sporcu_bilgi.sporcu_fotograf, yas_grubu.yas_grubu_ad, spor_brans.spor_brans_ad FROM     sporcu_ekle INNER JOIN sporcu_bilgi ON sporcu_ekle.sporcu_ekle_sporcu_bilgi_id = sporcu_bilgi.sporcu_bilgi_id INNER JOIN yas_grubu ON sporcu_ekle.sporcu_ekle_yas_grubu_id = yas_grubu.yas_grubu_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id where yas_grubu.yas_grubu_id=@yg AND spor_brans.spor_brans_id=@sb AND sporcu_ekle.aktiflik=@a", baglan);
            list.Parameters.AddWithValue("@a", true);
            list.Parameters.AddWithValue("@yg", sbi22);
            list.Parameters.AddWithValue("@sb", sbi);
            SqlDataAdapter da = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;


             
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            sb = comboBox2.SelectedItem as DataRowView;
            sbi = sb.Row["spor_brans_id"].ToString();
             
            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand list = new SqlCommand("SELECT sporcu_ekle.sporcu_ekle_id, sporcu_ekle.sporcu_ekle_sporcu_bilgi_id, sporcu_ekle.sporcu_ekle_yas_grubu_id, sporcu_ekle.sporcu_ekle_spor_brans_id, sporcu_ekle.sporcu_ekle_kayit_tarihi, sporcu_ekle.sporcu_ekle_anlasilan_tarih, sporcu_ekle.sporcu_ekle_anlasilan_ucret, sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_adres, sporcu_bilgi.sporcu_okul, sporcu_bilgi.sporcu_dogum_yer, sporcu_bilgi.sporcu_dogum_tarih, sporcu_bilgi.sporcu_ceptelefon, sporcu_bilgi.sporcu_email, sporcu_bilgi.sporcu_bilgi_veli_bilgi_id, sporcu_bilgi.sporcu_fotograf, yas_grubu.yas_grubu_ad, spor_brans.spor_brans_ad FROM     sporcu_ekle INNER JOIN sporcu_bilgi ON sporcu_ekle.sporcu_ekle_sporcu_bilgi_id = sporcu_bilgi.sporcu_bilgi_id INNER JOIN yas_grubu ON sporcu_ekle.sporcu_ekle_yas_grubu_id = yas_grubu.yas_grubu_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id where yas_grubu.yas_grubu_id=@yg AND spor_brans.spor_brans_id=@sb AND sporcu_ekle.aktiflik=@a", baglan);
            list.Parameters.AddWithValue("@a", true);
            list.Parameters.AddWithValue("@yg", sbi22);
            list.Parameters.AddWithValue("@sb", sbi);
            SqlDataAdapter da = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            personellist();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string mail;
                string parola;
                mail = mailtbox.Text;
                parola = mparolatbox.Text;
                MailMessage mesaj = new MailMessage();
                SmtpClient istemci = new SmtpClient();

                mesaj.IsBodyHtml = true;
                istemci.Credentials = new System.Net.NetworkCredential(mail, parola);
                istemci.Port = 587;
                istemci.Host = "smtp.gmail.com";
                istemci.EnableSsl = true;
                mesaj.Subject = konutbox.Text;
                mesaj.Body = icerikrtbox.Text;
                mesaj.From = new MailAddress(mail);
                if (checkBox1.Checked)
                {
                    Attachment atach = new Attachment(dosya);
                    mesaj.Attachments.Add(atach);
                }

                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {

                    if (null != dataGridView2.Rows[i].Cells["Mail Adresi"].Value.ToString())
                    {
                        mesaj.To.Add(dataGridView2.Rows[i].Cells["Mail Adresi"].Value.ToString());

                        istemci.Send(mesaj);
                    }
                    MessageBox.Show("Mailiniz başarıyla gönderilmiştir!");
                    kimetbox.Clear();
                    if (i % 90 == 0)
                    {
                        Thread.Sleep(10000);
                    }


                }
            }



            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu.Hata kodu:\n" + hata);
            }
        }
    }
}
