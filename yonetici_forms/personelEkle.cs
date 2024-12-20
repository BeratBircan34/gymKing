using gymKing.controls;
using gymKing.kasiyer_forms;
using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.yonetici_forms
{
    public partial class personelEkle : Form
    {
        public personelEkle(string id)
        {
            InitializeComponent();
            this.id_=id;
        }
        public string id_ = "";
        public int kontrol;

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            try
            {
                string sifre = sifreUret.GenerateRndPassword();

            using (SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
             baglanti.Open();

             // Kullanıcı Ekleme Sorgusu
            using (SqlCommand Ekle = new SqlCommand("insert into tbl_giris_Bilgileri(rol, kullaniciAdi, sifre) values (@rol, @kullaniciAdi, @sifre)", baglanti))
            {
            if (string.IsNullOrWhiteSpace(textBoxAd.Text) || string.IsNullOrWhiteSpace(textBoxSoyad.Text))
              {
                MessageBox.Show("Ad ve Soyad boş olamaz.");
              }

             string kullaniciAdi = textBoxAd.Text + "." + textBoxSoyad.Text;

             Ekle.Parameters.AddWithValue("@rol", comboBoxRol.Text);
             Ekle.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
             Ekle.Parameters.AddWithValue("@sifre", sifre);

             Ekle.ExecuteNonQuery();
             }

             // Son Eklenen Kullanıcıyı Getirme Sorgusu
             using (SqlCommand getir = new SqlCommand("SELECT TOP 1 KullaniciID, kullaniciAdi, sifre FROM tbl_giris_Bilgileri ORDER BY KullaniciID DESC", baglanti))
             {
             using (SqlDataReader dr = getir.ExecuteReader())
             {
             if (dr.Read())
              {
              textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
              textBoxSifre.Text = dr["sifre"].ToString();
             textBoxID.Text = dr["KullaniciID"].ToString();
                 }
                }
               }
              }

                MessageBox.Show("Kullanıcı bilgileri başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            string gelenVeri = textBoxAd.Text;
            string gelenVeri2 = textBoxSoyad.Text;
            string gelenVeri3 = comboBoxRol.Text;
            personelBilgiEkle perBilgiEkle = new personelBilgiEkle(gelenVeri, gelenVeri2, gelenVeri3);
            perBilgiEkle.BringToFront();
            perBilgiEkle.Show();
            //otoform_ayarla perbilgiekle_C = new otoform_ayarla(perBilgiEkle);
           // perbilgiekle_C.formAc(perBilgiEkle, this);


        }

        private void personelEkle_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
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
