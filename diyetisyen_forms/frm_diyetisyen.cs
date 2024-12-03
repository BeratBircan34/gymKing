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

namespace gymKing.diyetisyen_forms
{

  public partial class frm_diyetisyen : Form
    {
        public frm_diyetisyen()
        {
            InitializeComponent();
        }
        public string diyetisyen_oturumSahibi = "";
        private void frm_diyetisyen_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_oturumSahibi.Text = diyetisyen_oturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);
            //SetMdiContainerBackColor(Color.Gainsboro);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            diyetlist diyetliste = new diyetlist();
            otoform_ayarla dyetliste = new otoform_ayarla(diyetliste);
            dyetliste.formAc(diyetliste, this);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            vkianalizi vkianaliz = new vkianalizi();
            otoform_ayarla vkianliz = new otoform_ayarla(vkianaliz);
            vkianliz.formAc(vkianaliz, this);
        }
    }  
}
