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
    public partial class personelilan : Form
    {
       
        private object ID;

        public personelilan(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string id_ = "";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewPersonelIlani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Satırda bir tıklama varsa
            {
                DataGridViewRow row = dataGridViewPersonelIlani.Rows[e.RowIndex];

                // Satırdaki verileri TextBox'lara yansıt
                textBoxID.Text = row.Cells["ID"].Value.ToString();
                textBoxAd.Text = row.Cells["Ad"].Value.ToString();
                textBoxSoyad.Text = row.Cells["Soyad"].Value.ToString();              
                textBoxTelefon.Text = row.Cells["Telefon"].Value.ToString();
                textBoxPozisyon.Text = row.Cells["Pozisyon"].Value.ToString();
                textBoxAdres.Text = row.Cells["Adres"].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            string ad = textBoxAd.Text;
            string soyad = textBoxSoyad.Text;
            string telNo = textBoxTelefon.Text;
            string pozisyon = textBoxPozisyon.Text;
            string adres = textBoxAdres.Text;

            // Seçilen satırdan ID'yi al
            string ID = dataGridViewPersonelIlani.SelectedRows[0].Cells["ID"].Value.ToString(); // 'ID' yerine uygun kolon adı kullanmalısınız

            // Veritabanına ekleme sorgusu
            string sorgu = @"
                INSERT INTO tbl_per_bilgiler (Ad, Soyad, telNo, rol, Adres)
                VALUES (@ad, @soyad, @telNo, @rol, @adres)";

            using (SqlConnection connection = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                SqlCommand ekle = new SqlCommand(sorgu, connection);
                ekle.Parameters.AddWithValue("@ad", ad);
                ekle.Parameters.AddWithValue("@soyad", soyad);
                ekle.Parameters.AddWithValue("@telNo", telNo);
                ekle.Parameters.AddWithValue("@rol", pozisyon);
                ekle.Parameters.AddWithValue("@adres", adres);

                try
                {
                    connection.Open();
                    ekle.ExecuteNonQuery(); // Personel bilgilerini tbl_per_bilgiler tablosuna ekle

                    // Personel ilanını tbl_per_ilan tablosundan silme
                    string sorguSil = "DELETE FROM tbl_personel_ilani WHERE ID = @ID";
                    SqlCommand silmekomutu = new SqlCommand(sorguSil, connection);
                    silmekomutu.Parameters.AddWithValue("@ID", ID);
                    silmekomutu.ExecuteNonQuery(); // İlanı veritabanından sil

                    // DataGridView'dan ilgili satırı kaldır
                    dataGridViewPersonelIlani.Rows.RemoveAt(dataGridViewPersonelIlani.SelectedRows[0].Index);

                    MessageBox.Show("Personel bilgileri başarıyla kaydedildi ve ilan silindi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void personelilan_Load(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM tbl_personel_ilani"; // İlanları veritabanından al         

            using (SqlConnection connection = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sorgu, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewPersonelIlani.DataSource = dataTable;
            }           
        }
        private void VerileriGetir()
        {
            string sorgu = "SELECT * FROM tbl_per_bilgiler"; 

            using (SqlConnection connection = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sorgu, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // DataGridView'i doldur
                    dataGridViewAktifPersoneller.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            VerileriGetir(); // DataGridView'i yenile
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            yonetici yoneticipanel = new yonetici(id_);
            //yoneticipanel.Show();
            this.Close();
        }
    }
}
