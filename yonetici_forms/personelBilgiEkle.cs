using gymKing.kasiyer_forms;
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

namespace gymKing.yonetici_forms
{
    public partial class personelBilgiEkle : Form
    {
        public personelBilgiEkle()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personelEkle perEkle = new personelEkle();
            this.Hide();
            perEkle.Show();
        }

        private void personelBilgiEkle_Load_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand getir = new SqlCommand("select top 1 * from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            dr.Read();
            textBoxPerKullaniciAd.Text = dr["kullaniciAdi"].ToString();
            textBoxSifre.Text = dr["sifre"].ToString();
            textBoxID.Text = dr["KullaniciID"].ToString();
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            // SQL sorgusu (parametreli.)
            string güncelle = @"
             UPDATE tbl_per_bilgiler
             SET 
                ad = @pAd, 
                soyad = @pSoyad,               
                tcNo = @pTCNo,
                DogumTarihi = @pDogumTarihi,
                telNo = @pTelNo, 
                email = @pEmail,
                adres = @pAdres, 
                rol = @pRol                         
             WHERE perId = @perId";

            SqlCommand ekle = new SqlCommand(güncelle, baglanti);

            ekle.Parameters.AddWithValue("@pAd", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@pSoyad", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@pTCNo", textBoxTC.Text);
            ekle.Parameters.AddWithValue("@pDogumTarihi", dateTimePickerDogum.Value);
            ekle.Parameters.AddWithValue("@pTelNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@pEmail", textBoxMail.Text);
            ekle.Parameters.AddWithValue("@pRol", textBoxRol.Text);
            ekle.Parameters.AddWithValue("@pAdres", textBoxAdres.Text);
            //ekle.Parameters.AddWithValue("@pisegiris", dateTimePickerİseGiris.Value);
            ekle.Parameters.AddWithValue("@perId", textBoxID.Text);

            SqlDataReader dr = ekle.ExecuteReader();
                   

            /*int etkilenenSatir = ekle.ExecuteNonQuery();
            if (etkilenenSatir > 0)
            {
                MessageBox.Show("Personel Bilgileri Başarıyla Güncellendi!");
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu. Hiçbir satır güncellenmedi.");
          
            }
            */
            baglanti.Close();

        }
    }
}
