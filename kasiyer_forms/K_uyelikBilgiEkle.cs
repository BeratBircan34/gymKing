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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikBilgiEkle : Form
    {
        public K_uyelikBilgiEkle()
        {
            InitializeComponent();
        }

        private void K_uyelikBilgiEkle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand getir = new SqlCommand("select top 1 * from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            dr.Read();
            textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
            textBoxSifre.Text = dr["sifre"].ToString();
            textBoxID.Text = dr["KullaniciID"].ToString();
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_uyelikEkle uyelikEkle = new K_uyelikEkle();
            this.Hide();
            uyelikEkle.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            


            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("update tbl_musteriler set m_ad="+textBoxAd.Text+",m_soyad="+textBoxSoyad.Text+",m_DogumTarihi="+dateTimePickerDogum.Text+",m_telNo="+textBoxTelefon.Text+
                ",m_eMail="+textBoxMail.Text+",m_adres="+textBoxAdres.Text+",m_uyelikBaslangic="+dateTimePickerBaslangic.Text +",m_uyelikBitis="+dateTimePickerBitis.Text+
                ",m_personalTrainer="+comboBoxPt.Text+",m_diyetisyen="+comboBoxDiyetisyen.Text,baglanti);
            ekle.ExecuteNonQuery();
            baglanti.Close();
            


        }

        private void gymKingdbDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
