using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing
{
    public partial class Temizlik : Form
    {

        public static List<string> GorevListesi = new List<string>();

        public Temizlik(string id)
        {
            InitializeComponent();
            GorevleriListele(); // Form açıldığında görevleri göster
            this.id_ = id;
        }
        public string temizlikoturumsahibi = "";
        public string id_ = "";
        public void GorevleriListele()
        {
            listBoxGorevler.Items.Clear(); // Mevcut görevleri temizle
            foreach (var gorev in GorevListesi)
            {
                listBoxGorevler.Items.Add(gorev); // Görevleri ekle
            }
        }


        private void Temizlik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            while (adgetir.Read())
            {                                                         
                label2.Text = adgetir["kullaniciAdi"].ToString();
            }
            adgetir.Close();
            baglanti.Close();
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand kayit = new SqlCommand(
                "insert into tbl_temizlik(Genel_Alan_Temizligi, Ekipman_Alet_Temizligi, Soyunma_Odaları_Temizligi, Zeminlerin_Temzligi, Cop_Atik_Temizligi, Hijyen_Malzemelerinin_Stoklanmasi, Havalandirma_Koku_Kontrolu, Ek_Gorevler, Notlar, Tarih, Personel) " +
                "values(@genel, @ekipman, @soyunma, @zemin, @cop, @stok, @havalandırma, @gorev, @not, @tarih, @personel)", baglanti);

            kayit.Parameters.AddWithValue("@genel", chkbx_GenelAlanlarinTemizligi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@ekipman", chkbx__EkipmanAletlerinTemizligi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@soyunma", chkbx_SoyunmaOdalariDuslarinTemizligi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@zemin", chkbx_ZeminleriTemizligi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@cop", chkbx_CopAtikYonetimi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@stok", chkbx_HijyenMalzemelerininStoklanmasi.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@havalandırma", chkbx_HavalandirmaKokuKontrolu.Checked ? "Temizlendi" : "Temizlenmedi");
            kayit.Parameters.AddWithValue("@gorev", chkbx_EkGorevler.Checked ? "Yapıldı" : "Yapılmadı");
            kayit.Parameters.AddWithValue("@tarih", DateTime.Now);
            kayit.Parameters.AddWithValue("@personel", label2.Text);
            kayit.Parameters.AddWithValue("@not", txtbx_Notlar.Text);

            kayit.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rapor Gönderildi");
        } 
       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // ListBox'tan seçilen öğeyi kontrol etme //ListBox.SelectedIndex özelliği, listBoxta seçilen öğenin indeksini (sırasını) döner.
            // Eğer hiçbir öğe seçilmediyse SelectedIndex değeri -1 oluyor. 

            if (listBoxGorevler.SelectedIndex != -1)
            {
                // Seçilen görevi alma
                string secilenGorev = listBoxGorevler.SelectedItem.ToString();

                // Görev listesinden çıkarma
                GorevListesi.Remove(secilenGorev);

                // Güncel listeyi gösterme
                GorevleriListele();

                MessageBox.Show("Görev başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir görev seçin.");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
    }
}
