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
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into tbl_per_bilgiler(ad,soyad,tcno,dogumTarihi,telNo,email,adres,rol)" +
                "values(@ad,@soyad,@tcno,@dogumTarihi,@telNo,@email,@adres,@rol)", baglanti);
            ekle.Parameters.AddWithValue("@ad", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@soyad", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@tcno", textBoxTC.Text);
            ekle.Parameters.AddWithValue("@dogumtarihi", dateTimePickerDogum.Value);
            ekle.Parameters.AddWithValue("@telNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@email", textBoxMail.Text);
            ekle.Parameters.AddWithValue("@adres", textBoxAdres.Text);
            ekle.Parameters.AddWithValue("@rol", textBoxRol.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Tamamlandı");
            textBoxAd.Clear();
            textBoxSoyad.Clear();
            textBoxTelefon.Clear();
            textBoxMail.Clear();
            textBoxAdres.Clear();
            textBoxRol.Clear();
            textBoxTC.Clear();
        }

        private void personelEkle_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            persIslemleri pers_islem = new persIslemleri();
            this.Close();
            pers_islem.Show();
        }
    }
}
