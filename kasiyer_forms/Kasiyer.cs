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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace gymKing.kasiyer_forms
{
    public partial class Kasiyer : Form
    {

        public Kasiyer(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string kasiyer_oturumSahibi = "";
        public string id_ = "";


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

       

        private void KASİYER_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_oturumSahibi.Text = kasiyer_oturumSahibi;
            if (kasiyer_oturumSahibi.Contains("_Admin"))
            {
                pictureBox10.Visible = true;
            }
            else
            {
                pictureBox10.Visible = false;
            }
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);
        }

      

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Kasiyer uyelik = new Kasiyer(id_);
            otoform_ayarla uyelikk = new otoform_ayarla(uyelik);
            uyelikk.formAc(uyelik, this);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            urunSatis urun = new urunSatis(id_);
            otoform_ayarla urunn = new otoform_ayarla(urun);
            urunn.formAc(urun, this);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            K_uyelikEkle uyelikEkle = new K_uyelikEkle(id_);
            otoform_ayarla uyelikEklee = new otoform_ayarla(uyelikEkle);
            uyelikEklee.formAc(uyelikEkle, this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_uyelikSil uyelikSil = new K_uyelikSil(id_);
            otoform_ayarla uyelikSill = new otoform_ayarla(uyelikSil);
            uyelikSill.formAc(uyelikSil, this);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            K_uyelikDuzenle uyelikduzenle = new K_uyelikDuzenle(id_);
            otoform_ayarla uyelikduzenlee = new otoform_ayarla(uyelikduzenle);
            uyelikduzenlee.formAc(uyelikduzenle, this);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
