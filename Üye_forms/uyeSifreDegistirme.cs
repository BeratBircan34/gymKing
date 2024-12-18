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

namespace gymKing.Üye_forms
{
    public partial class uyeSifreDegistirme : Form
    {
        public uyeSifreDegistirme(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }

        public string id_ = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uyeSifreDegistirme_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand getir = new SqlCommand("SELECT sifre FROM tbl_giris_Bilgileri WHERE kullaniciID = @id", baglanti);
            getir.Parameters.AddWithValue("@id", id_);

            SqlDataReader dr = getir.ExecuteReader();

               dr.Read();
            
                string mevcutSifre = dr["sifre"].ToString();

                if (textBoxEski.Text == mevcutSifre)
                {
                    if (textBoxYeni.Text == textBoxTekrar.Text)
                    {
                        dr.Close();

                        SqlCommand degistir = new SqlCommand("UPDATE tbl_giris_Bilgileri SET sifre = @sifre WHERE kullaniciID = @id", baglanti);
                        degistir.Parameters.AddWithValue("@sifre", textBoxYeni.Text);
                        degistir.Parameters.AddWithValue("@id", id_);
                        degistir.ExecuteNonQuery();

                        MessageBox.Show("Şifre Başarıyla Değiştirildi");
                    }
                    else
                    {
                        MessageBox.Show("Yeni şifreler aynı değil!");
                    }
                }
                else
                {
                    MessageBox.Show("Girilen eski şifre yanlış!");
                }


            dr.Close();
            baglanti.Close();

            this.Close();
        }
    }
}
