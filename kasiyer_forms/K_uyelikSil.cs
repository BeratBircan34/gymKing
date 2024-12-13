using gymKing.controls;
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

namespace gymKing.kasiyer_forms
{
    public partial class K_uyelikSil : Form
    {
        public K_uyelikSil(string id_)
        {
            InitializeComponent();
            this.id_ = id_;
        }
        public string id_ = "";

        private void K_uyelikSil_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select m_ad from tbl_musteriler", baglanti);
            SqlDataReader dr = ad.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAd.Items.Add(dr["m_ad"].ToString());

            }
            dr.Close();

            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {
                label11.Text = adgetir["kullaniciAdi"].ToString();
            }
            adgetir.Close();

            SqlCommand getir = new SqlCommand("select neden from tbl_silinme_nedeni",baglanti);
            SqlDataReader getir2 = getir.ExecuteReader();
            while (getir2.Read())
            {
                comboBoxNeden.Items.Add(getir2["neden"].ToString());
            }
            getir2.Close();

            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik(id_);
            this.Close();
            uyelik.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from tbl_musteriler", baglanti);
            SqlDataReader getir2 = getir.ExecuteReader();
            while (getir2.Read())
            {
                textBoxDogum.Text = getir2["m_DogumTarihi"].ToString();
                textBoxBaslangic.Text = getir2["m_uyelikBaslangic"].ToString();
                textBoxBitis.Text = getir2["m_uyelikBitis"].ToString();
                textBoxMail.Text = getir2["m_eMail"].ToString();
                textBoxAdres.Text = getir2["m_adres"].ToString();
                textBoxPt.Text = getir2["m_personalTrainer"].ToString();
                textBoxDiyetisyen.Text = getir2["m_diyetisyen"].ToString();
                textBoxTelefon.Text = getir2["m_telNo"].ToString();
            }
            getir2.Close();


            SqlCommand getir3 = new SqlCommand("select * from tbl_giris_Bilgileri", baglanti);
            SqlDataReader getir4 = getir3.ExecuteReader();
            while (getir4.Read())
            {
                textBoxID.Text = getir4["KullaniciID"].ToString();
                textBoxKullaniciAdi.Text = getir4["kullaniciAdi"].ToString();
                textBoxSifre.Text = getir4["sifre"].ToString();
            }
            getir4.Close();
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from tbl_musteriler where m_id = "+textBoxID.Text,baglanti);
            SqlCommand sil2 = new SqlCommand("delete from tbl_giris_Bilgileri where KullaniciID = " + textBoxID.Text, baglanti);

            SqlCommand raporla = new SqlCommand("insert into tbl_kasiyer_log(yapilan_islem,islemi_yapan,islem_tarihi,islem_yapilan_id)values(@islem,@yapan,@tarih,@id)", baglanti);
            raporla.Parameters.AddWithValue("@islem", ("Üyelik Silindi"+"/"+comboBoxNeden.Text));
            raporla.Parameters.AddWithValue("@yapan", label11.Text);
            raporla.Parameters.AddWithValue("@tarih", DateTime.Today);
            raporla.Parameters.AddWithValue("@id", textBoxID.Text);

            raporla.ExecuteNonQuery();


            sil.ExecuteNonQuery();
            sil2.ExecuteNonQuery();



            baglanti.Close() ;



            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void comboBoxSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            string sorgu = "SELECT m_soyad FROM tbl_musteriler WHERE m_ad = @mAd";
            SqlCommand soyad = new SqlCommand(sorgu, baglanti);
            soyad.Parameters.AddWithValue("@mAd", comboBoxAd.Text);
            SqlDataReader dr = soyad.ExecuteReader();
            comboBoxSoyad.Items.Clear();
            while (dr.Read())
            {
                comboBoxSoyad.Items.Add(dr["m_soyad"].ToString());
            }
            dr.Close();
            baglanti.Close();
        }
    }
}
