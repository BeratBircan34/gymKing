using gymKing.controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikEkle : Form
    {
        public K_uyelikEkle()
        {
            InitializeComponent();
        }

        private void K_uyelikEkle_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik();
            this.Close();
            uyelik.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            K_uyelikBilgiEkle bilgiEkle = new K_uyelikBilgiEkle();
            this.Hide();
            bilgiEkle.Show();
        }

     

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            string sifre = sifreUretme.GenerateRandomPassword();

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand uyelikEkle = new SqlCommand("insert into tbl_giris_Bilgileri(rol,kullaniciAdi,sifre) values (@rol,@kullaniciAdi,@sifre)", baglanti);
            uyelikEkle.Parameters.AddWithValue("@rol", "Üye");
            uyelikEkle.Parameters.AddWithValue("@kullaniciAdi",textBoxAd.Text+"."+textBoxSoyad.Text);
            uyelikEkle.Parameters.AddWithValue("@sifre",sifre);
            uyelikEkle.ExecuteNonQuery();


            SqlCommand getir = new SqlCommand("select top 1 KullaniciID,kullaniciAdi,sifre from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
            SqlDataReader dr = getir.ExecuteReader();
            dr.Read();
            textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
            textBoxSifre.Text = dr["sifre"].ToString();
            textBoxID.Text=dr["KullaniciID"].ToString();


            baglanti.Close();

            MessageBox.Show("Kullanıcı Adı ve Şifre Oluşturuldu");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            K_uyelikBilgiEkle uyelikBilgiEkle = new K_uyelikBilgiEkle();
            this.Hide();
            uyelikBilgiEkle.Show();
        }
    }
}
