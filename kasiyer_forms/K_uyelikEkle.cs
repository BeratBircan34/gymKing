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
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ekle = new SqlCommand("insert into tbl_musteriler(m_ad,m_soyad,m_DogumTarihi,m_telNo,m_eMail,m_adres,m_uyelikBaslangic,m_uyelikBitis,m_personalTrainer,m_diyetisyen)" +
                "values(@m_ad,@m_soyad,@m_DogumTarihi,@m_telNo,@m_eMail,@m_adres,@m_uyelikBaslangic,@m_uyelikBitis,@m_personalTrainer,@m_diyetisyen)", baglanti);
            ekle.Parameters.AddWithValue("@m_ad", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@m_soyad", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@m_DogumTarihi", dateTimePickerDogum.Value);
            ekle.Parameters.AddWithValue("@m_telNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@m_eMail", textBoxMail.Text);
            ekle.Parameters.AddWithValue("@m_adres", textBoxAdres.Text);
            ekle.Parameters.AddWithValue("@m_uyelikBaslangic", dateTimePickerBaslangic.Value);
            ekle.Parameters.AddWithValue("@m_uyelikBitis", dateTimePickerBitis.Value);
            ekle.Parameters.AddWithValue("@m_personalTrainer", comboBoxPt.Text);
            ekle.Parameters.AddWithValue("@m_diyetisyen", comboBoxDiyetisyen.Text);
            ekle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Tamamlandı");
            textBoxAd.Clear();
            textBoxSoyad.Clear();
            textBoxTelefon.Clear();
            textBoxMail.Clear();
            textBoxAdres.Clear();
            comboBoxPt.SelectedIndex = 0;
            comboBoxDiyetisyen.SelectedIndex = 0;
        }
    }
}
