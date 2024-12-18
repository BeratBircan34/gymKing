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
using System.Windows.Forms.DataVisualization.Charting;

namespace gymKing.yonetici_forms
{
    public partial class gelirGider : Form
    {
        public gelirGider(string id)
        {
            InitializeComponent();
            this.id_=id;
        }
        public string id_ = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // SQL Bağlantısı
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            // SQL sorgusu (parametreli)
            string query = @"
    INSERT INTO tbl_GelirGider (IslemTuru, Aciklama, Tutar, Tarih) 
    VALUES (@IslemTuru, @Aciklama, @Tutar, @Tarih)";

            SqlCommand ekle = new SqlCommand(query, baglanti);

            // Parametrelerin eklenmesi
            ekle.Parameters.AddWithValue("@IslemTuru", comboBoxIslemTuru.SelectedItem.ToString());
            ekle.Parameters.AddWithValue("@Aciklama", textAciklama.Text);
            ekle.Parameters.AddWithValue("@Tutar", numTutar.Value);
            ekle.Parameters.AddWithValue("@Tarih", dtpTarih.Value);

            // Sorgunun çalıştırılması
            ekle.ExecuteNonQuery();

            MessageBox.Show("Gelir/Gider kaydı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // SQL sorgusu
            string query = "SELECT * FROM tbl_GelirGider WHERE Tarih BETWEEN @Baslangic AND @Bitis";

            // Bağlantı açma
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            SqlCommand cek = new SqlCommand(query, baglanti);

            // Parametrelerin eklenmesi
            cek.Parameters.AddWithValue("@Baslangic", dtpBaslangic.Value.Date);
            cek.Parameters.AddWithValue("@Bitis", dtpBitis.Value.Date);

            // DataTable ve DataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter(cek);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // DataGridView'e bağlama
            dataGridViewRapor.DataSource = dt;

            // Toplam Gelir, Gider ve Kar Hesaplama
            decimal toplamGelir = 0;
            decimal toplamGider = 0;


            foreach (DataRow row in dt.Rows)
            {
                decimal tutar = Convert.ToDecimal(row["Tutar"]);
                if (row["IslemTuru"].ToString() == "Gelir")
                    toplamGelir += tutar;
                else if (row["IslemTuru"].ToString() == "Gider")
                    toplamGider += tutar;
            }

            // Label'lara değer atama // ToString("C") komutu sayıyı para birimi formatına döndürür.
            lblToplamGelir.Text = "Toplam Gelir: " + toplamGelir.ToString("C");
            lblToplamGider.Text = "Toplam Gider: " + toplamGider.ToString("C");
            lblKarZarar.Text = "Kar/Zarar: " + (toplamGelir - toplamGider).ToString("C");



            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            // GrafikCizici sınıfını çağırma
            GrafikCizici grafikCizici = new GrafikCizici();

            // Grafik çizme işlemi
            grafikCizici.GrafikCiz(chartGelirGider); // chartGelirGider, formunuzdaki Chart nesnesidir

        }

        private void gelirGider_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        
    

