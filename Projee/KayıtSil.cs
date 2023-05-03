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
    public partial class KayıtSil : Form
    {
        DataSet1TableAdapters.sporcu_ekle2TableAdapter sprc = new DataSet1TableAdapters.sporcu_ekle2TableAdapter();
        public static string ks;
        public static int ksint;

        public KayıtSil()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            string sc = gridView1.GetFocusedRowCellValue("sporcu_ekle_id").ToString();
            sporcubilgigüncelle.id = sc;
            
            sporcubilgigüncelle git = new sporcubilgigüncelle();
            sporcubilgigüncelle.deger = 0;
            git.Show();
        }

        private void KayıtSil_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = sprc.aaa();
        }
    }
}
