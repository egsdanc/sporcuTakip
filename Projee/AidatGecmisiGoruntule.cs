using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projee
{
    public partial class AidatGecmisiGoruntule : Form
    {
        public AidatGecmisiGoruntule()
        {
            InitializeComponent();
        }
        public static int aid;
        private void button2_Click(object sender, EventArgs e)
        {
            Duzenle gec = new Duzenle();
            gec.Show();
        }

        private void AidatGecmisiGoruntule_Load(object sender, EventArgs e)
        {
            try
            {
                AidatIslemleriTableAdapters.GecmisListeleTableAdapter goster = new AidatIslemleriTableAdapters.GecmisListeleTableAdapter();
                gridControl6.DataSource = goster.basketial();
                gridControl2.DataSource = goster.cimnastikial();
                gridControl3.DataSource = goster.fitbolal();
                gridControl4.DataSource = goster.tekvandoal();
                gridControl5.DataSource = goster.voleybolal();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Bir hata oluştu. Hata:\n" + hata);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AidatIslemleriTableAdapters.GecmisListeleTableAdapter goster = new AidatIslemleriTableAdapters.GecmisListeleTableAdapter();
                gridControl6.DataSource = goster.basketial();
                gridControl2.DataSource = goster.cimnastikial();
                gridControl3.DataSource = goster.fitbolal();
                gridControl4.DataSource = goster.tekvandoal();
                gridControl5.DataSource = goster.voleybolal();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Bir hata oluştu. Hata:\n" + hata);
            }
        }

        private void gridView6_Click(object sender, EventArgs e)
        {
            aid = Convert.ToInt32(gridView6.GetFocusedRowCellValue("aidat_bilgi_id"));
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            aid = Convert.ToInt32(gridView2.GetFocusedRowCellValue("aidat_bilgi_id"));
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            aid = Convert.ToInt32(gridView3.GetFocusedRowCellValue("aidat_bilgi_id"));
        }

        private void gridView4_Click(object sender, EventArgs e)
        {
            aid = Convert.ToInt32(gridView4.GetFocusedRowCellValue("aidat_bilgi_id"));
        }

        private void gridView5_Click(object sender, EventArgs e)
        {
            aid = Convert.ToInt32(gridView5.GetFocusedRowCellValue("aidat_bilgi_id"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
