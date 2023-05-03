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
    public partial class SporcuGuncelle : Form
    {
       
        DataSet1TableAdapters.sporcu_ekle3TableAdapter tb3 = new DataSet1TableAdapters.sporcu_ekle3TableAdapter();

        public static string sg;
        public static int sgint;
        public SporcuGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void SporcuGuncelle_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = tb3.spgünc1();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           string sei = gridView1.GetFocusedRowCellValue("sporcu_ekle_id").ToString();
           sporcubilgigüncelle.id = sei;
            

            sporcubilgigüncelle git = new sporcubilgigüncelle();
            sporcubilgigüncelle.deger = 1;
            git.Show();
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

        }
    }
}
