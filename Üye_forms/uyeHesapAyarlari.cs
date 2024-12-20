﻿using gymKing.controls;
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

namespace gymKing.Üye_forms
{
    public partial class uyeHesapAyarlari : Form
    {
        public uyeHesapAyarlari(string id)
        {
            InitializeComponent();
            this.id_ = id;

        }
        public string id_ = "";


     




        private void uyeHesapAyarlari_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);

            textBoxId.Text = id_;
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from tbl_musteriler where m_id = "+textBoxId.Text, baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                textBoxTelefon.Text = dr["m_telNo"].ToString();
                textBoxMail.Text = dr["m_eMail"].ToString();
                textBoxAdres.Text = dr["m_adres"].ToString();
                dateTimePickerDogum.Text = dr["m_DogumTarihi"].ToString();   
            }
            dr.Close();

            SqlCommand getir2 = new SqlCommand("select * from tbl_giris_Bilgileri where kullaniciID = "+textBoxId.Text, baglanti); 
            SqlDataReader dr2 = getir2.ExecuteReader();
            while (dr2.Read())
            {
                textBoxKullaniciAdi.Text = dr2["kullaniciAdi"].ToString();
                textBoxSifre.Text = dr2["sifre"].ToString() ;  
            }
            dr2.Close();
            baglanti.Close();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                 m_adres = @mAdres 
             WHERE m_id = @id";

            SqlCommand ekle = new SqlCommand(güncelle, baglanti);


            ekle.Parameters.AddWithValue("@mDogumTarihi", dateTimePickerDogum.Value);
            ekle.Parameters.AddWithValue("@mTelNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@mEmail", textBoxMail.Text);
            ekle.Parameters.AddWithValue("@mAdres", textBoxAdres.Text);
            ekle.Parameters.AddWithValue("@id",textBoxId.Text);


            string güncelle2 = @"
            update tbl_giris_Bilgileri
            set 
                kullaniciAdi=@kullaniciAdi,
                sifre=@sifre
            where kullaniciID=@id2";

            SqlCommand ekle2 = new SqlCommand(güncelle2, baglanti);

            ekle2.Parameters.AddWithValue("kullaniciAdi",textBoxKullaniciAdi.Text);
            ekle2.Parameters.AddWithValue("sifre",textBoxSifre.Text);
            ekle2.Parameters.AddWithValue("@id2",textBoxId.Text);  

            ekle.ExecuteNonQuery();
            ekle2.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Düzenleme İşlemi Tamamlandı");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            uyeSifreDegistirme sifreDegistirme = new uyeSifreDegistirme(textBoxId.Text);
            sifreDegistirme.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form a = this.MdiParent;
            a.WindowState = FormWindowState.Minimized;
        }
    }
}
