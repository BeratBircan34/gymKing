using gymKing.controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace gymKing
{
    public partial class frm_pt : Form
    {
        public frm_pt()
        {
            InitializeComponent();
        }
        public string oturmSahibi = "";

        
        private void frm_pt_Load(object sender, EventArgs e)
        {
            if (oturmSahibi.Contains("_Admin"))
            {
                // PictureBox nesnesini görünür yap
                pctrbx_geri.Visible = true;
            }
            else
            {
                // Aksi halde görünürlüğünü kapat
                pctrbx_geri.Visible = false;
            }
            timer1.Start();
            lbl_oturumSahibi.Text = oturmSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);
        }
      

         void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString("00");
            if (oturmSahibi.Contains("_Admin") && this.Text == "frm_pt")
                pctrbx_geri.Visible = true;
            else
                pctrbx_geri.Visible = false;
        }

       

        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.DarkSalmon;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.Transparent;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frm_sonucYazdir fsy = new frm_sonucYazdir();
            otoform_ayarla fsy_ = new otoform_ayarla(fsy);
            fsy_.formAc(fsy, this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(pt_islemKontrol.islemYapildiMi == true)
            {
                frm_vucutAnaliz drm = new frm_vucutAnaliz();
                frm_analizKayit analiz_kayit = new frm_analizKayit();
                otoform_ayarla c_analiz_kayit = new otoform_ayarla(analiz_kayit);
                analiz_kayit.egitmen = lbl_oturumSahibi.Text;
                c_analiz_kayit.formAc(analiz_kayit, this);

            }
            else
            {
                MessageBox.Show("Önce İşlem Yapmalısınız!");
            }
            

            
            
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frm_vucutAnaliz frmanaliz = new frm_vucutAnaliz();
            otoform_ayarla frmanalz = new otoform_ayarla(frmanaliz);
            frmanalz.formAc(frmanaliz,this);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            frm_pt_guncelKayitlar frmptgk = new frm_pt_guncelKayitlar();
            otoform_ayarla frmptgk_c = new otoform_ayarla(frmptgk);
            frmptgk_c.formAc(frmptgk,this);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            /*frm_kisiselBilgiler frmkb = new frm_kisiselBilgiler();
            otoform_ayarla frmkb_c = new otoform_ayarla(frmkb);
            frmkb_c.formAc(frmkb,this);*/

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frm_pt_gecmisİslemler frmgi = new frm_pt_gecmisİslemler();
            otoform_ayarla frmgi_ = new otoform_ayarla(frmgi);
            frmgi_.formAc(frmgi,this);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Uygulamadan çıkış yapmak istiyor musunuz?",
               "Çıkış Onayı",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse uygulamayı kapat
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu küçült
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.IndianRed;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Gainsboro;
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.SkyBlue;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor= Color.Gainsboro;
        }

        private void pctrbx_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
