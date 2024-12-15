

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
        public K_uyelikDuzenle(string id_)
        {
            InitializeComponent();
            this.id_ = id_;
        }
        public string id_ = "";
        private void K_uyelikDuzenle_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand getir = new SqlCommand("select cinsiyet from tbl_cinsiyet",baglanti);
            SqlDataReader cinsiyet = getir.ExecuteReader();
            while (cinsiyet.Read())
            {
                comboBox1.Items.Add(cinsiyet["cinsiyet"].ToString());
            }
            cinsiyet.Close();

            SqlCommand ad = new SqlCommand("select m_ad from tbl_musteriler", baglanti);
            SqlDataReader dr = ad.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAd.Items.Add(dr["m_ad"].ToString());

            }
            dr.Close();

            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {
                label15.Text = adgetir["kullaniciAdi"].ToString();
            }
            adgetir.Close();


            SqlCommand getir2 = new SqlCommand("select ad,soyad from tbl_per_bilgiler where rol = 'Pt'", baglanti);
            SqlDataReader dr2 = getir2.ExecuteReader();
            comboBoxPt.Items.Clear();
            while (dr2.Read())
            {
                comboBoxPt.Items.Add(dr2["ad"].ToString());
            }
            dr2.Close();


            SqlCommand getir3 = new SqlCommand("select ad,soyad from tbl_per_bilgiler where rol = 'Diyetisyen'", baglanti);
            SqlDataReader dr3 = getir3.ExecuteReader();
            comboBoxDiyetisyen.Items.Clear();
            while (dr3.Read())
            {
                comboBoxDiyetisyen.Items.Add(dr3["ad"].ToString());
            }
            dr3.Close();
            baglanti.Close();


            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            SqlCommand getir = new SqlCommand("select * from tbl_musteriler where m_id ="+textBoxID.Text, baglanti);
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
                comboBox1.Text = getir2["m_cinsiyet"].ToString() ;
            }
            getir2.Close();


            SqlCommand getir3 = new SqlCommand("select * from tbl_giris_Bilgileri where KullaniciID ="+textBoxID.Text, baglanti);
            SqlDataReader getir4 = getir3.ExecuteReader();
            while (getir4.Read())
            { 
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
                 m_diyetisyen = @mDiyetisyen,
                 m_cinsiyet = @mcinsiyet
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
            ekle.Parameters.AddWithValue("@mcinsiyet", comboBox1.Text);
            ekle.Parameters.AddWithValue("@id", textBoxID.Text);

            ekle.ExecuteNonQuery();

            SqlCommand raporla = new SqlCommand("insert into tbl_kasiyer_log(yapilan_islem,islemi_yapan,islem_tarihi,islem_yapilan_id)values(@islem,@yapan,@tarih,@id)", baglanti);
            raporla.Parameters.AddWithValue("@islem", "Üyelik Bilgileri Düzenlendi");
            raporla.Parameters.AddWithValue("@yapan", label15.Text);
            raporla.Parameters.AddWithValue("@tarih", DateTime.Today);
            raporla.Parameters.AddWithValue("@id", textBoxID.Text);

            raporla.ExecuteNonQuery();



            baglanti.Close();

            MessageBox.Show("Düzenleme İşlemi Tamamlandı");
        }

        private void comboBoxPt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand id = new SqlCommand("select m_id from tbl_musteriler where m_ad ='"+comboBoxAd.Text+"' and m_soyad = '"+comboBoxSoyad.Text+"'",baglanti);
            SqlDataReader reader = id.ExecuteReader();
            while (reader.Read())
            {
                textBoxID.Text = reader["m_id"].ToString();
            }
        }
    }
}
