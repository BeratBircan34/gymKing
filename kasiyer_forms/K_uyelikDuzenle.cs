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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikDuzenle : Form
    {
        public K_uyelikDuzenle()
        {
            InitializeComponent();
        }

        private void K_uyelikDuzenle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select m_ad from tbl_musteriler", baglanti);
            SqlDataReader dr = ad.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAd.Items.Add(dr["m_ad"].ToString());

            }
            dr.Close();
            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik();
            this.Close();
            uyelik.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            string sorgu = "SELECT m_soyad FROM tbl_musteriler WHERE m_ad = @mAd";
            SqlCommand soyad = new SqlCommand(sorgu, baglanti);
            soyad.Parameters.AddWithValue("@mAd", comboBoxAd.Text);
            SqlDataReader dr = soyad.ExecuteReader();
            comboBoxSoyad.Items.Clear();
            while (dr.Read())
            {
                comboBoxSoyad.Items.Add(dr["m_soyad"].ToString());
            }
            dr.Close();
            baglanti.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from tbl_musteriler", baglanti);
            SqlDataReader getir2 = getir.ExecuteReader();
            while (getir2.Read())
            {
                dateTimePickerDogum.Text = getir2["m_DogumTarihi"].ToString();
                dateTimePickerBaslangic.Text = getir2["m_uyelikBaslangic"].ToString();
                dateTimePickerBitis.Text = getir2["m_uyelikBitis"].ToString();
                textBoxMail.Text = getir2["m_eMail"].ToString();
                textBoxAdres.Text = getir2["m_adres"].ToString();
                comboBoxPt.Text = getir2["m_personalTrainer"].ToString();
                comboBoxDiyetisyen.Text = getir2["m_diyetisyen"].ToString();
                textBoxTelefon.Text = getir2["m_telNo"].ToString();
            }
            getir2.Close();


            SqlCommand getir3 = new SqlCommand("select * from tbl_giris_Bilgileri", baglanti);
            SqlDataReader getir4 = getir3.ExecuteReader();
            while (getir4.Read())
            {
                textBoxID.Text = getir4["KullaniciID"].ToString();
                textBoxKullaniciAdi.Text = getir4["kullaniciAdi"].ToString();
                textBoxSifre.Text = getir4["sifre"].ToString();
            }
            getir4.Close();
            baglanti.Close();



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            string güncelle = @"
             UPDATE tbl_musteriler 
             SET     
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

            MessageBox.Show("Düzenleme İşlemi Tamamlandı");
        }
    }
}
