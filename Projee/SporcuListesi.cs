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
    public partial class SporcuListesi : Form
    {
        public static int gec;
        SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
        public void silinenlist()
        {
            baglan.Open();
            SqlCommand list = new SqlCommand("SELECT sporcu_bilgi.sporcu_tc, sporcu_bilgi.sporcu_ad, sporcu_bilgi.sporcu_soyad, sporcu_bilgi.sporcu_okul, sporcu_bilgi.sporcu_ceptelefon, spor_brans.spor_brans_ad, yas_grubu.yas_grubu_ad, sporcu_bilgi.sporcu_bilgi_id, sporcu_ekle.sporcu_ekle_id FROM     sporcu_ekle INNER JOIN yas_grubu ON sporcu_ekle.sporcu_ekle_yas_grubu_id = yas_grubu.yas_grubu_id INNER JOIN spor_brans ON sporcu_ekle.sporcu_ekle_spor_brans_id = spor_brans.spor_brans_id INNER JOIN sporcu_bilgi ON sporcu_ekle.sporcu_ekle_sporcu_bilgi_id = sporcu_bilgi.sporcu_bilgi_id WHERE  (sporcu_ekle.aktiflik !=1)", baglan);
            SqlDataAdapter da = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl2.DataSource = dt;


            baglan.Close(); 
        }
        
        DataSet1TableAdapters.sporcu_ekle2TableAdapter sprc = new DataSet1TableAdapters.sporcu_ekle2TableAdapter();
        public SporcuListesi()
        {
            InitializeComponent();
        }

        private void SporcuListesi_Load(object sender, EventArgs e)
        {
         if(gec==1)
            {
                gridControl1.Visible = false;
            }
         else if(gec==2)
            {
                gridControl2.Visible = false;
            }
            gridControl1.DataSource = sprc.aaa();
            silinenlist();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
