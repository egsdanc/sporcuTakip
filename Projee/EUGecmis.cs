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
    public partial class EUGecmis : DevExpress.XtraEditors.XtraForm
    {
        public EUGecmis()
        {
            InitializeComponent();
        }
        bool a = true;
        EkUcretGirisi gs = new EkUcretGirisi();
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            gs.BringToFront();
            if (a == true)
            {

                gs.Show();
                a = false;

            }
        }

        private void EUGecmis_Load(object sender, EventArgs e)
        {
            EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter listele = new EKUCRETLERRTableAdapters.SporcuEUEkleTableAdapter();

            gridControl1.DataSource= listele.sporcueual();
        }
    }
}
