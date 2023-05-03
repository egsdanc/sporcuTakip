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
    public partial class AidatGuncelleme : Form
    {
        public AidatGuncelleme()
        {
            InitializeComponent();
        }

        public int id;
        private void listele()
        {
            AidatIslemleriTableAdapters.DataTable2TableAdapter listele = new AidatIslemleriTableAdapters.DataTable2TableAdapter();
            gridControl6.DataSource = listele.basketal();
            gridControl7.DataSource = listele.cimnastikal();
            gridControl3.DataSource = listele.futbolal();
            gridControl4.DataSource = listele.taekwondoal();
            gridControl5.DataSource = listele.voleybolal();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AidatIslemleriTableAdapters.aidat_bilgi1TableAdapter ekle = new AidatIslemleriTableAdapters.aidat_bilgi1TableAdapter();
            ekle.InsertAidat(id, textBox1.Text, dateTimePicker1.Text);
            MessageBox.Show("Aidat tarihi seçili sporcuya başarıyla eklendi");
            listele();
        }

        private void AidatGuncelleme_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView6_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gridView6.GetFocusedRowCellValue("sporcu_ekle_id"));
            label3.Text = id.ToString();
        }

        private void gridView7_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gridView7.GetFocusedRowCellValue("sporcu_ekle_id"));
            label3.Text = id.ToString();
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gridView3.GetFocusedRowCellValue("sporcu_ekle_id"));
            label3.Text = id.ToString();
        }

        private void gridView4_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gridView4.GetFocusedRowCellValue("sporcu_ekle_id"));
            label3.Text = id.ToString();
        }

        private void gridView5_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gridView5.GetFocusedRowCellValue("sporcu_ekle_id"));
            label3.Text = id.ToString();
        }

        private void gridControl5_Click(object sender, EventArgs e)
        {

        }
    }
}
