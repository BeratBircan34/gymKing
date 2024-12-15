using gymKing.controls;
using gymKing.kasiyer_forms;
using gymKing.pt_forms;
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
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);

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

            persIslemleri personelislem = new persIslemleri();
            otoform_ayarla personel_islem = new otoform_ayarla(personelislem);
            personel_islem.formAc(personelislem, this);

            //persIslemleri persislem = new persIslemleri();
            //persislem.Show(); 
            //this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frm_pt formpt = new frm_pt();
            formpt.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            personelilan persilan = new personelilan();
            otoform_ayarla persilann = new otoform_ayarla(persilan);
            persilann.formAc(persilan, this);

            //İstatistikler istatistik = new İstatistikler();
            //otoform_ayarla istatistikk = new otoform_ayarla(istatistik);
            //istatistikk.formAc(istatistik, this);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Kasiyer kasiyerr = new Kasiyer();
            //otoform_ayarla kasiyerrr = new otoform_ayarla(kasiyerr);
            //kasiyerrr.formAc(kasiyerr, this);

            //Kasiyer kasiyerr = new Kasiyer();
            //kasiyerr.Show();
            //this.Close();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Temizlik temizlikk = new Temizlik();
            otoform_ayarla temizlikkk = new otoform_ayarla(temizlikk);
            temizlikkk.formAc(temizlikk, this);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            gelirGider gelir_gider = new gelirGider();
            otoform_ayarla gelir__gider = new otoform_ayarla(gelir_gider);
            gelir__gider.formAc(gelir_gider, this);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }
    }
}
