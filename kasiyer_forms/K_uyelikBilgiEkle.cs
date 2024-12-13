using gymKing.oto_Baglanti;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikBilgiEkle : Form
    {
        public K_uyelikBilgiEkle(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }

        public string id_ = "";


        private void K_uyelikBilgiEkle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();


            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {
                label14.Text = adgetir["kullaniciAdi"].ToString();
            }
            adgetir.Close();


            SqlCommand getir = new SqlCommand("select top 1 * from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
                textBoxSifre.Text = dr["sifre"].ToString();
                textBoxID.Text = dr["KullaniciID"].ToString();
            }
            dr.Close();


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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_uyelikEkle uyelikEkle = new K_uyelikEkle(id_);
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


            SqlCommand raporla = new SqlCommand("insert into tbl_kasiyer_log(yapilan_islem,islemi_yapan,islem_tarihi,islem_yapilan_id)values(@islem,@yapan,@tarih,@id)", baglanti);
            raporla.Parameters.AddWithValue("@islem", "Yeni Üyenin Bilgileri Eklendi");
            raporla.Parameters.AddWithValue("@yapan",label14.Text);
            raporla.Parameters.AddWithValue("@tarih", DateTime.Today);
            raporla.Parameters.AddWithValue("@id",textBoxID.Text);

            raporla.ExecuteNonQuery();


            baglanti.Close();

            MessageBox.Show("Bilgi Ekleme İşlemi Tamamlandı");

        }

        private void gymKingdbDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
