using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.Üye_forms
{
    public partial class üyePaneli : Form
    {
        public üyePaneli()
        {
            InitializeComponent();
        }

        public string uyeOturumSahibi = "";

        private void üyePaneli_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_oturumSahibi.Text = uyeOturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");





        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uyeHesapAyarlari ayarlar = new uyeHesapAyarlari();
            this.Close();
            ayarlar.Show();
        }
    }
}
