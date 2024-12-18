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
        public personelBilgiEkle(string id)
        {
            InitializeComponent();
            this.id_=id;
        }
        public string id_ = "";
        public personelBilgiEkle(string gelenVeri, string gelenVeri2, string gelenVeri3)
        {
            InitializeComponent();

            // önceki formdaki verileri TextBox'a gelen veriyi aktarıyoruz
            textBoxAd.Text = gelenVeri;  // textBoxAd, personelBilgiEkle formundaki TextBox'ın adı
            textBoxSoyad.Text = gelenVeri2;
            comboBoxRol.Text = gelenVeri3;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            personelEkle perEkle = new personelEkle(id_);
            this.Close();

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

            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            // SQL sorgusu (parametreli.)
            string güncelle = @"
                 UPDATE tbl_per_bilgiler
                 SET
             ad = @pad, 
             soyad = @psoyad, 
             isegiris = @pisegiris,
             TCNO = @ptcno,
             dogumTarihi = @pDogumTarihi,
             telNo = @pTelNo, 
             email = @pEmail,
             adres = @pAdres, 
             rol = @pRol
                 WHERE perId = @perId;";  // perId için geçerli bir değer ekleyin

            SqlCommand komut = new SqlCommand(güncelle, baglanti);

            komut.Parameters.AddWithValue("@pad", textBoxAd.Text);
            komut.Parameters.AddWithValue("@psoyad", textBoxSoyad.Text);
            komut.Parameters.AddWithValue("@ptcno", textBoxTC.Text);
            komut.Parameters.AddWithValue("@pDogumTarihi", dateTimePickerDogum.Value);
            komut.Parameters.AddWithValue("@pTelNo", textBoxTelefon.Text);
            komut.Parameters.AddWithValue("@pEmail", textBoxMail.Text);
            komut.Parameters.AddWithValue("@pRol", comboBoxRol.Text);
            komut.Parameters.AddWithValue("@pAdres", textBoxAdres.Text);
            komut.Parameters.AddWithValue("@pisegiris", dateTimePickerİseGiris.Value);
            komut.Parameters.AddWithValue("@perId", textBoxID.Text); // perId için geçerli bir değer ekleyin

            // Execute the update command
            int etkilenenSatir = komut.ExecuteNonQuery();

            if (etkilenenSatir > 0)
            {
                MessageBox.Show("Personel Bilgileri Başarıyla Güncellendi!");
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu. Hiçbir satır güncellenmedi.");
            }

            baglanti.Close();
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
            this.WindowState = FormWindowState.Minimized; // Formu küçült
        }
    }
}
