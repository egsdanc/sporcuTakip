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
using System.Net.Mail;
using DevExpress.XtraEditors.Filtering.Templates;

namespace Projee
{
    public partial class HesapBilgileri : Form
    {
        public HesapBilgileri()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == bunifuMetroTextbox3.Text)
            {
                string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
                SqlConnection baglan = new SqlConnection(link);
                baglan.Open();

                SqlCommand kgunc = new SqlCommand("UPDATE kullanici_bilgi SET kullanici_kullanici_ad=@kkk,kullanici_kullanici_sifre=@sss where  kullanici_kullanici_ad=@ka1 and kullanici_kullanici_sifre=@ks1   ", baglan);
                kgunc.Parameters.AddWithValue("@ka1", AnaSayfa.ka);
                kgunc.Parameters.AddWithValue("@ks1", AnaSayfa.sf);
                kgunc.Parameters.AddWithValue("@kkk", bunifuMetroTextbox1.Text);
                kgunc.Parameters.AddWithValue("@sss", bunifuMetroTextbox2.Text);
                kgunc.ExecuteNonQuery();


               

                 


            }
    
            else
            {
                MessageBox.Show("bilgilerinizi kontrol edin");
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
            SqlConnection baglan = new SqlConnection(link);
            baglan.Close();
            baglan.Open();
            SqlCommand personelekle = new SqlCommand("UPDATE personel_bilgi SET personel_eposta=@ep where personel_bilgi_id=@id", baglan);
            personelekle.Parameters.AddWithValue("@ep", bunifuMetroTextbox4.Text);
            personelekle.Parameters.AddWithValue("@id", AnaSayfa.id);
            personelekle.ExecuteNonQuery();
            baglan.Close();
        }
    }
}