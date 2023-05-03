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
    public partial class PersonelListesi : Form
    {
        string link = "Data Source=desktop-9c856bd;Initial Catalog=proje3;Integrated Security=True";
        public void personellist()
        {
            SqlConnection baglan = new SqlConnection(link);
            baglan.Open();
            SqlCommand list = new SqlCommand("SELECT personel_bilgi.*, spor_brans.* FROM     personel_bilgi INNER JOIN spor_brans ON personel_bilgi.personel_bilgi_spor_brans_id = spor_brans.spor_brans_id where aktiflik=@a", baglan);
            list.Parameters.AddWithValue("@a", true);
            SqlDataAdapter da = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            baglan.Close();
        }
            
        public PersonelListesi()
        {
            InitializeComponent();
        }

        private void PersonelListesi_Load(object sender, EventArgs e)
        {
            personellist();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           personebilgigüncelle.gelenpbid = gridView1.GetFocusedRowCellValue("personel_bilgi_id").ToString();
            personebilgigüncelle.gelensbid = gridView1.GetFocusedRowCellValue("spor_brans_id").ToString();
            personebilgigüncelle pbg = new personebilgigüncelle();
            pbg.Show();
            this.Hide();
        }
    }
}
