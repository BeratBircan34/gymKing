using gymKing.controls;
using gymKing.kasiyer_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.yonetici_forms
{
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }
        public string yonetici_oturumSahibi = "";
        private void yonetici_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_oturumSahibi.Text = yonetici_oturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            persIslemleri persislem = new persIslemleri();
            persislem.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            İstatistikler istatik = new İstatistikler();
            istatik.Show();
            this.Close();
        }
    }
}
