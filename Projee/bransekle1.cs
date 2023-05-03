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
    public partial class bransekle1 : Form
    {
        public static bool aktif = true;
        SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
        public void combobrans()
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
        public void comboyas()
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
        
         string kt,at,au;

        public void spekle()
        {
            DataRowView sb = comboBox2.SelectedItem as DataRowView;
            string ygi = sb.Row["spor_brans_id"].ToString();
            DataRowView sb22 = comboBox1.SelectedItem as DataRowView;
            string bei = sb22.Row["yas_grubu_id"].ToString();
            kt = dateEdit1.Text;
            at = dateEdit2.Text;
            au = textBox1.Text;

            DataSet1TableAdapters.sporcu_ekle1TableAdapter sp = new DataSet1TableAdapters.sporcu_ekle1TableAdapter();
          sp.srpeklee1(Convert.ToInt32(BransEkle.a),Convert.ToInt32(bei),Convert.ToInt32(ygi),kt,at,au,aktif);
            
        }
        public void fotolistele()
        {
            baglan.Open();
            SqlCommand listele = new SqlCommand("SELECT sporcu_fotograf FROM sporcu_bilgi WHERE sporcu_bilgi_id=@a",baglan);
            listele.Parameters.AddWithValue("a",BransEkle.a);
            SqlDataReader dr = listele.ExecuteReader();
            while (dr.Read())
            {
                pictureBox1.ImageLocation = dr[0].ToString();
            }
            baglan.Close();

        }
        public bransekle1()
        {
            InitializeComponent();
        }

        private void bransekle1_Load(object sender, EventArgs e)
        {
            fotolistele();
            combobrans();
            comboyas();
            dateEdit1.Text = "Tarih seç";
        }

        private void dateEdit1_Click(object sender, EventArgs e)
        {
            dateEdit1.ForeColor = Color.Black;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            
            spekle();
            MessageBox.Show("Sporcuya branş başarıyla eklenmiştir!");
        }
    }
}
