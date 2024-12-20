using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gymKing.yonetici_forms
{
    public partial class personelGüncelle : Form
    {
        public personelGüncelle(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string id_ = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void personelGüncelle_Load(object sender, EventArgs e)
        {
            // SQL sorgusu
            string çek = "SELECT ad, soyad FROM tbl_per_bilgiler";
            

            // Bağlantıyı oluştur ve aç
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            // SQL komutu oluştur
            SqlCommand komut = new SqlCommand(çek, baglanti);      

            // Veritabanından veri oku
            SqlDataReader reader = komut.ExecuteReader();

            // ComboBox'ı temizle
            comboBoxAd.Items.Clear();

            
            while (reader.Read())
            {
                // "ad" sütununu comboBoxAd'a ekle
                string ad = reader["ad"].ToString();
                comboBoxAd.Items.Add(ad);

                // "soyad" sütununu comboBoxSoyad'a ekle
                string soyad = reader["soyad"].ToString();
                comboBoxSoyad.Items.Add(soyad);
            }

            // Okuma işlemi tamamlanınca kapat
            baglanti.Close();
        }

        private void comboBoxSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand id = new SqlCommand("select perId from tbl_per_bilgiler where ad ='" + comboBoxAd.Text + "' and soyad = '" + comboBoxSoyad.Text + "'", baglanti);
            SqlDataReader reader = id.ExecuteReader();
            while (reader.Read())
            {
                textBoxID.Text = reader["perId"].ToString();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
                baglanti.Open();
                SqlCommand getir = new SqlCommand("select * from tbl_per_bilgiler where perId =" + textBoxID.Text, baglanti);
                SqlDataReader getir2 = getir.ExecuteReader();
                while (getir2.Read())
                {
                    dateTimePickerDogum.Text = getir2["dogumTarihi"].ToString();
                    dateTimePickerIsegiris.Text = getir2["isegiris"].ToString();
                    textBoxMail.Text = getir2["email"].ToString();
                    textBoxAdres.Text = getir2["adres"].ToString();
                    textBoxTelefon.Text = getir2["telNo"].ToString();
                }
                getir2.Close();


                SqlCommand getir3 = new SqlCommand("select * from tbl_giris_Bilgileri where KullaniciID =" + textBoxID.Text, baglanti);
                SqlDataReader getir4 = getir3.ExecuteReader();
                while (getir4.Read())
                {
                    textBoxKullaniciAdi.Text = getir4["kullaniciAdi"].ToString();
                    textBoxSifre.Text = getir4["sifre"].ToString();
                    comboBoxRol.Text = getir4["rol"].ToString();
                }
                getir4.Close();
                baglanti.Close();
            }

            catch
            {
                MessageBox.Show("Lütfen Kullanıcı Seçiniz!");
            }
            
        }

        private void comboBoxAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            string sorgu = "SELECT soyad FROM tbl_per_bilgiler WHERE ad = @pAd";
            SqlCommand soyad = new SqlCommand(sorgu, baglanti);
            soyad.Parameters.AddWithValue("@pAd", comboBoxAd.Text);
            SqlDataReader dr = soyad.ExecuteReader();
            comboBoxSoyad.Items.Clear();
            while (dr.Read())
            {
                comboBoxSoyad.Items.Add(dr["soyad"].ToString());
            }
            dr.Close();
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
                baglanti.Open();
                string güncelle = @"
             UPDATE tbl_per_bilgiler
             SET     
                 DogumTarihi = @pDogumTarihi, 
                 telNo = @ptelNo, 
                 email = @pemail, 
                 adres = @padres, 
                 isegiris = @pisegiris,
                 rol = @prol         
             WHERE perId = @id";

                SqlCommand ekle = new SqlCommand(güncelle, baglanti);


                ekle.Parameters.AddWithValue("@pDogumTarihi", dateTimePickerDogum.Value);
                ekle.Parameters.AddWithValue("@ptelNo", textBoxTelefon.Text);
                ekle.Parameters.AddWithValue("@pemail", textBoxMail.Text);
                ekle.Parameters.AddWithValue("@padres", textBoxAdres.Text);
                ekle.Parameters.AddWithValue("@pisegiris", dateTimePickerIsegiris.Value);
                ekle.Parameters.AddWithValue("@id", textBoxID.Text);
                ekle.Parameters.AddWithValue("@prol", comboBoxRol.Text);

                ekle.ExecuteNonQuery();

                string güncelle2 = @"
             UPDATE tbl_giris_Bilgileri
             SET     
                 rol = @prol         
             WHERE KullaniciID = @id";
                SqlCommand ekle2 = new SqlCommand(güncelle2, baglanti);
                ekle2.Parameters.AddWithValue("@prol",comboBoxRol.Text);
                ekle2.Parameters.AddWithValue("@id",textBoxID.Text);

                ekle2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Düzenleme İşlemi Tamamlandı \nTüm Değişiklikler Uygulama Yeniden Başlatılınca Güncellenecektir");
            }

            catch
            {
                MessageBox.Show("Boşluk Bırakmayın!");
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form a = this.MdiParent;
            a.WindowState = FormWindowState.Minimized;
        }
    }
}
