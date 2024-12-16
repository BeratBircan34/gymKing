using gymKing.oto_Baglanti;
using iText.Kernel.Crypto.Securityhandler;
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
    public partial class personelSil : Form
    {
        public personelSil(string id)
        {
            InitializeComponent();
            this.id_=id;

            //// DataGridView SelectionChanged olayına abone ol
            //dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }
        public string id_ = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            persIslemleri pers_islem = new persIslemleri(id_);
            this.Close();
            pers_islem.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            persIslemleri pers_islem = new persIslemleri(id_);
            this.Close();
            pers_islem.Show();
        }

        private void personelSil_Load(object sender, EventArgs e)
        {
            // VeriYonetimi sınıfından bir örnek oluştur
            perBilgiCek cek = new perBilgiCek();

            // GetVeri metodunu çağırarak verileri al
            DataTable veri = cek.VeriCek();

            // Alınan verileri DataGridView'e yükle
            dataGridView1.DataSource = veri;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen satırdaki hücrelere erişim
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];

                // TextBox'lara verileri aktar
                txtad.Text = secilenSatir.Cells["ad"].Value.ToString();
                txtsoyad.Text = secilenSatir.Cells["soyad"].Value.ToString();
                txttc.Text = secilenSatir.Cells["tcno"].Value.ToString();
                txtdogum.Text = secilenSatir.Cells["dogumTarihi"].Value.ToString();
                txttel.Text = secilenSatir.Cells["telNo"].Value.ToString();
                txtmail.Text = secilenSatir.Cells["email"].Value.ToString();
                txtrol.Text = secilenSatir.Cells["rol"].Value.ToString();
                txtadres.Text = secilenSatir.Cells["adres"].Value.ToString();

            }
        }

        private void personelSil_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // TextBox'lardaki değerleri almak
            string ad = txtad.Text;
            string soyad = txtsoyad.Text;
            string tc = txttc.Text;
            string dogum = txtdogum.Text;
            string telefon = txttel.Text;
            string email = txtmail.Text;
            string rol = txtrol.Text;
            string adres = txtadres.Text;

            // Veritabanı bağlantısını açma
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());

            try
            {
                baglanti.Open();

                // Tarih formatını kontrol et ve uygun şekilde dönüşüm yap
                DateTime dogumTarihi;
                if (!DateTime.TryParse(dogum, out dogumTarihi))
                {
                    MessageBox.Show("Geçersiz tarih formatı.");
                    return;
                }

                // SQL sorgusunu oluşturma (sadece WHERE şartında kullanılacak)
                string silme = @"
            DELETE FROM tbl_per_bilgiler
            WHERE 
                ad = @ad AND
                soyad = @soyad AND
                TCNO = @TCNO AND
                dogumTarihi = @dogumTarihi AND
                rol = @rol AND
                adres = @adres AND
                telNo = @telefon AND
                email = @email";

                SqlCommand sil = new SqlCommand(silme, baglanti);

                // Parametreleri ekleme
                sil.Parameters.AddWithValue("@ad", ad);
                sil.Parameters.AddWithValue("@soyad", soyad);
                sil.Parameters.AddWithValue("@TCNO", tc);
                sil.Parameters.AddWithValue("@dogumTarihi", dogumTarihi.ToString("yyyy-MM-dd"));  // Tarihi ISO formatına zorla
                sil.Parameters.AddWithValue("@rol", rol);
                sil.Parameters.AddWithValue("@adres", adres);
                sil.Parameters.AddWithValue("@telefon", telefon);
                sil.Parameters.AddWithValue("@email", email);

                // Silme işlemi
                int sonuc = sil.ExecuteNonQuery(); // SQL komutunu çalıştırma

                // Sonuç kontrolü
                if (sonuc > 0)
                {
                    MessageBox.Show("Kayıt başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı veya silinemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close(); // Bağlantıyı kapatma
            }
        }
    }
}