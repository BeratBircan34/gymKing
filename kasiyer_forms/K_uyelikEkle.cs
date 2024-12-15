using gymKing.controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikEkle : Form
    {
        public K_uyelikEkle(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string id_ = "";
        public int kontrol = 0;
        private void K_uyelikEkle_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {
                label11.Text = adgetir["kullaniciAdi"].ToString();
            }
            adgetir.Close();
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


        private void pictureBox3_Click_1(object sender, EventArgs e)
        { 
            
            if(!string.IsNullOrEmpty(textBoxAd.Text) && !string.IsNullOrEmpty(textBoxSoyad.Text))
            {

                string sifre = sifreUretme.GenerateRandomPassword();

                SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
                baglanti.Open();
                SqlCommand uyelikEkle = new SqlCommand("insert into tbl_giris_Bilgileri(rol,kullaniciAdi,sifre) values (@rol,@kullaniciAdi,@sifre)", baglanti);
                uyelikEkle.Parameters.AddWithValue("@rol", "Üye");
                uyelikEkle.Parameters.AddWithValue("@kullaniciAdi", textBoxAd.Text + "." + textBoxSoyad.Text);
                uyelikEkle.Parameters.AddWithValue("@sifre", sifre);
                uyelikEkle.ExecuteNonQuery();


                SqlCommand getir = new SqlCommand("select top 1 KullaniciID,kullaniciAdi,sifre from tbl_giris_Bilgileri order by KullaniciID desc", baglanti);
                SqlDataReader dr = getir.ExecuteReader();
                while (dr.Read())
                {
                    textBoxKullaniciAdi.Text = dr["kullaniciAdi"].ToString();
                    textBoxSifre.Text = dr["sifre"].ToString();
                    textBoxID.Text = dr["KullaniciID"].ToString();
                }
                dr.Close();
                SqlCommand raporla = new SqlCommand("insert into tbl_kasiyer_log(yapilan_islem,islemi_yapan,islem_tarihi,islem_yapilan_id)values(@islem,@yapan,@tarih,@id)", baglanti);
                raporla.Parameters.AddWithValue("@islem", "Yeni Üyelik Eklendi");
                raporla.Parameters.AddWithValue("@yapan", label11.Text);
                raporla.Parameters.AddWithValue("@tarih", DateTime.Today);
                raporla.Parameters.AddWithValue("@id", textBoxID.Text);

                raporla.ExecuteNonQuery();


                baglanti.Close();

                MessageBox.Show("Kullanıcı Adı ve Şifre Oluşturuldu");

                if (textBoxID != null)
                {
                    kontrol = +1;
                }
            }

            else
            {
                MessageBox.Show("İsim Soyisim Girmelisiniz!");
            }
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {   if(kontrol == 1)
            {
                K_uyelikBilgiEkle uyelikBilgiEkle = new K_uyelikBilgiEkle(id_);
                uyelikBilgiEkle.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Önce Bir Kullanıcı Eklemelisiniz!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
