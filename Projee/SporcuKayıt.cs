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
    public partial class SporcuKayıt : Form
    {
       bool aktif = true;
        public void veliek()
        {
            DataSet1TableAdapters.veli_bilgiTableAdapter veliekle = new DataSet1TableAdapters.veli_bilgiTableAdapter();
            veliekle.velibilgi(textBox10.Text,textBox12.Text,maskedTextBox3.Text,textBox9.Text,textBox11.Text,maskedTextBox2.Text);
        }
        SqlConnection baglan = new SqlConnection("Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True");
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

        
        public SporcuKayıt()
        {
            InitializeComponent();
        }
        int sporcu_bilgi_id;
        int veli_bilgi_id;

        public void sprcid()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select sporcu_bilgi_id From sporcu_bilgi where sporcu_tc=@p1",baglan);
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                sporcu_bilgi_id = Convert.ToInt32(dr[0]);
            }
            baglan.Close();
        }
       
        public void veliid()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select veli_bilgi_id From veli_bilgi where veli_baba_ceptelefon=@c1", baglan);
            komut.Parameters.AddWithValue("@c1", maskedTextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                veli_bilgi_id = Convert.ToInt32(dr[0]);
            }
            baglan.Close();
        }
        DataSet1TableAdapters.sporcu_bilgiTableAdapter sporcbilgiekle = new DataSet1TableAdapters.sporcu_bilgiTableAdapter();
        DataSet1TableAdapters.sporcu_ekleTableAdapter sprcekle = new DataSet1TableAdapters.sporcu_ekleTableAdapter();
        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView sb = comboBox2.SelectedItem as DataRowView;
            string sbi = sb.Row["spor_brans_id"].ToString();
            DataRowView sb22 = comboBox1.SelectedItem as DataRowView;
            string sbi22 = sb22.Row["yas_grubu_id"].ToString();

            
            veliek();
            veliid();
            baglan.Open();
            sporcbilgiekle.sporcu_bilgienttysorgu(textBox2.Text, textBox3.Text, textBox1.Text, textBox6.Text, textBox4.Text, textBox5.Text, dateEdit2.Text, maskedTextBox1.Text, textBox15.Text, veli_bilgi_id,pictureBox1.ImageLocation) ;
            baglan.Close();
            sprcid();
            baglan.Open();
            sprcekle.sprceklesorgu(sporcu_bilgi_id,Convert.ToInt32(sbi22),Convert.ToInt32(sbi),dateEdit3.Text,dateEdit1.Text,textBox8.Text, aktif);
            baglan.Close();
            MessageBox.Show("Kayıt işlemi başarılı!");
        }

        private void SporcuKayıt_Load(object sender, EventArgs e)
        {
            combo1ekle();
            combo2ekle();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.ShowDialog();
           pictureBox1.ImageLocation = xtraOpenFileDialog1.FileName;
            
        }
    }
}
