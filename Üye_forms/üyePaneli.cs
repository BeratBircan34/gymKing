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
    public partial class üyePaneli : Form
    {
        public üyePaneli(string id)
        {
            InitializeComponent();
            this.id_=id;
        }

        public string uyeOturumSahibi = "";
        public string id_ = "";
        private void üyePaneli_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_id.Text = id_;
            lbl_oturumSahibi.Text = uyeOturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);



            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select m_uyelikBaslangic,m_uyelikBitis from tbl_musteriler where m_id ="+lbl_id.Text, baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                labelBaslangic.Text = dr["m_uyelikBaslangic"] != DBNull.Value ? Convert.ToDateTime(dr["m_uyelikBaslangic"]).ToString("dd.MM.yyyy") : "Tarih bilgisi yok";
                labelBitis.Text = dr["m_uyelikBitis"] != DBNull.Value ? Convert.ToDateTime(dr["m_uyelikBitis"]).ToString("dd.MM.yyyy") : "Tarih bilgisi yok";
            }
            dr.Close();
            baglanti.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uyeHesapAyarlari ayarlar = new uyeHesapAyarlari(lbl_id.Text);
            otoform_ayarla ayarlarr = new otoform_ayarla(ayarlar);
            ayarlarr.formAc(ayarlar,this);
        }

        private void lbl_id_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_tarih_Click(object sender, EventArgs e)
        {

        }

        private void labelBaslangic_Click(object sender, EventArgs e)
        {

        }
    }
}
