using gymKing.kasiyer_forms;
using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.yonetici_forms
{
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            string sifre = sifreUret.GenerateRndPassword();

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand personelEkle = new SqlCommand("insert into tbl_giris_Bilgileri(rol,kullaniciAdi,sifre) values (@rol,@kullaniciAdi,@sifre)", baglanti);
            personelEkle.Parameters.AddWithValue("@rol", comboBoxRol.Text);
            personelEkle.Parameters.AddWithValue("@kullaniciAdi", textBoxAd.Text + "." + textBoxSoyad.Text);
            personelEkle.Parameters.AddWithValue("@sifre", sifre);
            personelEkle.ExecuteNonQuery();


            SqlCommand getir = new SqlCommand("select top 1 KullaniciID,kullaniciAdi,sifre from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            dr.Read();
            textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
            textBoxSifre.Text = dr["sifre"].ToString();
            textBoxID.Text = dr["KullaniciID"].ToString();


            baglanti.Close();

            MessageBox.Show("Personel Kullanıcı Adı ve Şifre Oluşturuldu !");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string gelenVeri = textBoxAd.Text;
            string gelenVeri2 = textBoxSoyad.Text;
            string gelenVeri3 = comboBoxRol.Text;
            personelBilgiEkle perBilgiEkle = new personelBilgiEkle(gelenVeri, gelenVeri2, gelenVeri3);
            this.Hide();
            perBilgiEkle.Show();

        }

        private void personelEkle_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void personelEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
