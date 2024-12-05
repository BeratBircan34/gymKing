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

            // SQL sorgusu (parametreli)
            string güncelle = @"
             UPDATE tbl_musteriler 
             SET 
                m_ad = @mAd, 
                m_soyad = @mSoyad, 
                m_DogumTarihi = @mDogumTarihi, 
                m_telNo = @mTelNo, 
                 m_eMail = @mEmail, 
                 m_adres = @mAdres, 
                 m_uyelikBaslangic = @mUyelikBaslangic, 
                 m_uyelikBitis = @mUyelikBitis, 
                 m_personalTrainer = @mPersonalTrainer, 
                 m_diyetisyen = @mDiyetisyen
             WHERE m_id = @id"; 

            SqlCommand ekle = new SqlCommand(güncelle, baglanti);

            ekle.Parameters.AddWithValue("@mAd", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@mSoyad", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@mDogumTarihi", dateTimePickerDogum.Value);
            ekle.Parameters.AddWithValue("@mTelNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@mEmail", textBoxMail.Text);
            ekle.Parameters.AddWithValue("@mAdres", textBoxAdres.Text);
            ekle.Parameters.AddWithValue("@mUyelikBaslangic", dateTimePickerBaslangic.Value);
            ekle.Parameters.AddWithValue("@mUyelikBitis", dateTimePickerBitis.Value);
            ekle.Parameters.AddWithValue("@mPersonalTrainer", comboBoxPt.Text);
            ekle.Parameters.AddWithValue("@mDiyetisyen", comboBoxDiyetisyen.Text);
            ekle.Parameters.AddWithValue("@id", textBoxID.Text);

            ekle.ExecuteNonQuery();
            baglanti.Close();



        }

        private void gymKingdbDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
