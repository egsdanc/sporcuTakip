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
    public partial class BransEkle : Form
    {
        DataSet1TableAdapters.sporcu_ekle2TableAdapter sprc = new DataSet1TableAdapters.sporcu_ekle2TableAdapter();     
        public static string a;
    
        public BransEkle()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BransEkle_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dataSet1.sporcu_ekle' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            gridControl1.DataSource = sprc.aaa();

         
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
           



            



      
            
            




        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {
            
             


        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            string sc = gridView1.GetFocusedRowCellValue("sporcu_bilgi_id").ToString();
            
            a = sc;
            bransekle1 git = new bransekle1();
            git.Show();
        }
    }
}
