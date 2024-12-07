using gymKing.controls;
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

namespace gymKing.Üye_forms
{
    public partial class uyeHesapAyarlari : Form
    {
        public uyeHesapAyarlari()
        {
            InitializeComponent();
        }

        

        private void uyeHesapAyarlari_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            üyePaneli üye = new üyePaneli();
            this.Close();
            üye.Show();
        }
    }
}
