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
            


            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select m_uyelikBaslangic,m_uyelikBitis from tbl_musteriler where m_id ="+lbl_id.Text, baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                labelBaslangic.Text = dr["m_uyelikBaslangic"].ToString();
                labelBitis.Text = dr["m_uyelikBitis"].ToString();
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
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uyeHesapAyarlari ayarlar = new uyeHesapAyarlari(lbl_id.Text);
            this.Hide();
            ayarlar.Show();
        }

        private void lbl_id_Click(object sender, EventArgs e)
        {

        }
    }
}
