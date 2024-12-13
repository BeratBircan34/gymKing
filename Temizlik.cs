using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing
{
    public partial class Temizlik : Form
    {


        public Temizlik()
        {
            InitializeComponent();
        }

        private void Temizlik_Load(object sender, EventArgs e)
        {

        }

        public void test()
        {
            if (chkbx_GenelAlanlarinTemizligi.Checked)
            {
                
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
