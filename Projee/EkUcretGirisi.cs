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
    public partial class EkUcretGirisi : Form
    {
        public EkUcretGirisi()
        {
            InitializeComponent();
        }
        private void listelebasket()
        {
   
            SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand basklist = new SqlCommand("SELECT sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_bilgi_id, spor_brans.spor_brans_ad FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id WHERE  (spor_brans.spor_brans_id = 2) AND (sporcu_ekle.aktiflik = 1)", baglan);
            SqlDataReader dr = basklist.ExecuteReader();
            if(dr.Read())
            {
                gridControl1.DataSource = dr;
            }
            baglan.Close();
        }
        private void listelejimn()
        {

            SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand basklist = new SqlCommand("SELECT sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_bilgi_id, spor_brans.spor_brans_ad FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id WHERE  (spor_brans.spor_brans_id =5 ) AND (sporcu_ekle.aktiflik = 1)", baglan);
            SqlDataReader dr = basklist.ExecuteReader();
            if (dr.Read())
            {
                gridControl2.DataSource = dr;
            }
            baglan.Close();
        }
        private void listelevoleyb()
        {

            SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand basklist = new SqlCommand("SELECT sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_bilgi_id, spor_brans.spor_brans_ad FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id WHERE  (spor_brans.spor_brans_id =3 ) AND (sporcu_ekle.aktiflik = 1)", baglan);
            SqlDataReader dr = basklist.ExecuteReader();
            if (dr.Read())
            {
                gridControl5.DataSource = dr;
            }
            baglan.Close();
        }
        private void listelefutbo()
        {

            SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand basklist = new SqlCommand("SELECT sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_bilgi_id, spor_brans.spor_brans_ad FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id WHERE  (spor_brans.spor_brans_id =1 ) AND (sporcu_ekle.aktiflik = 1)", baglan);
            SqlDataReader dr = basklist.ExecuteReader();
            if (dr.Read())
            {
                gridControl3.DataSource = dr;
            }
            baglan.Close();
        }
        private void listeletekwa()
        {

            SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
            baglan.Open();
            SqlCommand basklist = new SqlCommand("SELECT sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_bilgi_id, spor_brans.spor_brans_ad FROM     sporcu_bilgi INNER JOIN sporcu_ekle ON sporcu_bilgi.sporcu_bilgi_id = sporcu_ekle.sporcu_ekle_sporcu_bilgi_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id WHERE  (spor_brans.spor_brans_id =4 ) AND (sporcu_ekle.aktiflik = 1)", baglan);
            SqlDataReader dr = basklist.ExecuteReader();
            if (dr.Read())
            {
                gridControl4.DataSource = dr;
            }
            baglan.Close();
        }
        public int id;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                EKUCRETLERRTableAdapters.EkUcretEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.EkUcretEkleTableAdapter();
                ekle.InsertEkucret(textBox1.Text, dateTimePicker1.Text, richTextBox1.Text);
                MessageBox.Show("Ek ücret başarıyla kaydedilmiştir!");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata:\n" + hata);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {


                EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();
                ekle.Insert1(textBox2.Text, dateTimePicker2.Text, richTextBox2.Text, id);

                MessageBox.Show("Ek ücret ekleme işlemi başarıyla gerçekleşti!");
                //listele();

            }


            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata kodu:\n" + hata);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {


               EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();
                ekle.Insert1(textBox3.Text, dateTimePicker3.Text, richTextBox3.Text, id);
                MessageBox.Show("Ek ücret ekleme işlemi başarıyla gerçekleşti!");
                //listele();

            }


            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata kodu:\n" + hata);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {


                EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();
                ekle.Insert1(textBox4.Text, dateTimePicker4.Text, richTextBox4.Text, id);
                MessageBox.Show("Ek ücret ekleme işlemi başarıyla gerçekleşti!");
                //listele();

            }


            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata kodu:\n" + hata);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {


                EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();
                ekle.Insert1(textBox5.Text, dateTimePicker5.Text, richTextBox5.Text, id);
                MessageBox.Show("Ek ücret ekleme işlemi başarıyla gerçekleşti!");
                //listele();

            }


            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata kodu:\n" + hata);
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {


                EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter ekle = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();
                ekle.Insert1(textBox6.Text, dateTimePicker6.Text, richTextBox6.Text, id);
                MessageBox.Show("Ek ücret ekleme işlemi başarıyla gerçekleşti!");
                //listele();

            }


            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata kodu:\n" + hata);
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void EkUcretGirisi_Load(object sender, EventArgs e)
        {
            listelebasket();
            listelefutbo();
            listelejimn();
            listeletekwa();
            listelevoleyb();
            //   listele();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("sporcu_bilgi_id"));
                label8.Text = id.ToString();


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi. Hata kodu:\n" + hata);
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView2.GetFocusedRowCellValue("sporcu_bilgi_id"));
                label9.Text = id.ToString();


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi. Hata kodu:\n" + hata);
            }
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView3.GetFocusedRowCellValue("sporcu_bilgi_id"));
                label14.Text = id.ToString();


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi. Hata kodu:\n" + hata);
            }
        }

        private void gridView4_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView4.GetFocusedRowCellValue("sporcu_bilgi_id"));
                label19.Text = id.ToString();


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi. Hata kodu:\n" + hata);
            }
        }

        private void gridView5_Click(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(gridView5.GetFocusedRowCellValue("sporcu_bilgi_id"));
                label24.Text = id.ToString();


            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata meydana geldi. Hata kodu:\n" + hata);
            }
        }

        private void tabNavigationPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
