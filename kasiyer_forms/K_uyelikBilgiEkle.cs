using gymKing.controls;
using gymKing.oto_Baglanti;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikBilgiEkle : Form
    {
        public K_uyelikBilgiEkle(string id)                 //Giriş Yapan Kişinin İD'sini Alır
        {
            InitializeComponent();
            this.id_ = id;
        }

        public string id_ = "";

        public int kontrol = 0;
        private void K_uyelikBilgiEkle_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());  //Sql bağlantısı Açma
            baglanti.Open();




            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {                                                           //tbl_giriş_bilgileri Tablosundan Giriş Yapan Kişinin Kullanıcı Adı Verisini Alır ve Görünmez Label'a Yazdırır
                label14.Text = adgetir["kullaniciAdi"].ToString();                          
            }
            adgetir.Close();


            SqlCommand getir = new SqlCommand("select top 1 * from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
                textBoxSifre.Text = dr["sifre"].ToString();                        //tbl_giriş_bilgileri Tablosundan Son Eklenen Veriyi Alıp
                textBoxID.Text = dr["KullaniciID"].ToString();                     // Kullanıcı Adı, Şifre ve Kullanıcı İD Verilerini textBoxlara Yazdırır
            }
            dr.Close();


            SqlCommand getir2 = new SqlCommand("select ad,soyad from tbl_per_bilgiler where rol = 'Pt'", baglanti);
            SqlDataReader dr2 = getir2.ExecuteReader();
            comboBoxPt.Items.Clear();
            while (dr2.Read())                                  // tbl_per_bilgiler Tablosundan Rolü 'PT' Olanları comboBox'a Ekler
            {
                comboBoxPt.Items.Add(dr2["ad"].ToString());
            }
            dr2.Close();


            SqlCommand getir3 = new SqlCommand("select ad,soyad from tbl_per_bilgiler where rol = 'Diyetisyen'", baglanti);
            SqlDataReader dr3 = getir3.ExecuteReader();
            comboBoxDiyetisyen.Items.Clear();
            while (dr3.Read())                                         // tbl_per_bilgiler Tablosundan Rolü 'Diyetisyen' Olanları comboBox'a Ekler
            {
                comboBoxDiyetisyen.Items.Add(dr3["ad"].ToString());
            }
            dr3.Close();
            baglanti.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (kontrol == 1)
            {
                this.Close();       
            }
                                    // Kontrol Değişkenine Atanan Değeri Kontrol Ederek Sayfadan Çıkış Yapılıp Yapılamayacağını Belirler
            else
            {
                MessageBox.Show("Ad Soyad Girmeden Çıkış Yapamazsınız");
            }


        }

 

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxAd.Text) && !string.IsNullOrEmpty(textBoxSoyad.Text))
            {                                                                                          // Ad Soyad textBoxlarının Boş Olmadığı durumda
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
                m_diyetisyen = @mDiyetisyen,
                m_cinsiyet = @mcinsiyet
            WHERE m_id = @id";

                SqlCommand ekle = new SqlCommand(güncelle, baglanti);
                                                                                        // TextBoxlarda Yazan Verileri tbl_musteriler Tablosuna Aktarır
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
                ekle.Parameters.AddWithValue("@mcinsiyet", comboBox1.Text);
                ekle.Parameters.AddWithValue("@id", textBoxID.Text);

                ekle.ExecuteNonQuery();


                SqlCommand raporla = new SqlCommand("insert into tbl_kasiyer_log(yapilan_islem,islemi_yapan,islem_tarihi,islem_yapilan_id)values(@islem,@yapan,@tarih,@id)", baglanti);
                raporla.Parameters.AddWithValue("@islem", "Yeni Üyenin Bilgileri Eklendi");
                raporla.Parameters.AddWithValue("@yapan", label14.Text);
                raporla.Parameters.AddWithValue("@tarih", DateTime.Today);      // tbl_kasiyer_log Tablosuna Yapılan İşlemi, İşlemi Yapan Kişinin Kullanıcı Adını
                raporla.Parameters.AddWithValue("@id", textBoxID.Text);         // ve İşlem Yapılan Kişinin İD'sini Kaydeder

                raporla.ExecuteNonQuery();


                baglanti.Close();

                MessageBox.Show("Bilgi Ekleme İşlemi Tamamlandı");

                kontrol = +1;
                this.Close();
            }

            else
            {
                MessageBox.Show("Ad Soyad Girmeden Kayıt Yapamazsınız!");      // Ad Soyad textBoxlarının Boş Olduğunu ve İşlem Yapılamayacağını Belirtir
            }
            

        }

        private void gymKingdbDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePickerDogum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerBaslangic_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerBitis_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDiyetisyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(kontrol == 1)
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
            else
            {

            }
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
