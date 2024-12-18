using gymKing.kasiyer_forms;
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
                textBoxAd.Text = row.Cells["Ad"].Value.ToString();
                textBoxSoyad.Text = row.Cells["Soyad"].Value.ToString();
                textBoxTelefon.Text = row.Cells["Telefon"].Value.ToString();
                textBoxPozisyon.Text = row.Cells["Pozisyon"].Value.ToString();
                textBoxAdres.Text = row.Cells["Adres"].Value.ToString();
           
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            

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
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            yonetici yoneticipanel = new yonetici(id_);
            //yoneticipanel.Show();
            this.Close();
        }

        private void pictureBoxolus_Click(object sender, EventArgs e)
        {        

        }

        private void pictureBoxo_Click(object sender, EventArgs e)
        {           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string sifre = sifreUretme.GenerateRandomPassword();

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand uyelikEkle = new SqlCommand("insert into tbl_giris_Bilgileri(rol,kullaniciAdi,sifre) values (@rol,@kullaniciAdi,@sifre)", baglanti);
            uyelikEkle.Parameters.AddWithValue("@rol", textBoxPozisyon.Text);
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
        }

        private void label8_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            string güncelle = @"
            UPDATE tbl_per_bilgiler
            SET 
                ad = @Ad, 
                soyad = @Soyad, 
                telNo = @TelNo,                                 
                adres = @Adres,
                rol = @Rol
            WHERE perId = @id";

            SqlCommand ekle = new SqlCommand(güncelle, baglanti);

            ekle.Parameters.AddWithValue("@Ad", textBoxAd.Text);
            ekle.Parameters.AddWithValue("@Soyad", textBoxSoyad.Text);
            ekle.Parameters.AddWithValue("@TelNo", textBoxTelefon.Text);
            ekle.Parameters.AddWithValue("@Adres", textBoxAdres.Text);
            ekle.Parameters.AddWithValue("@Rol", textBoxPozisyon.Text);
            ekle.Parameters.AddWithValue("@id", textBoxID.Text);

            ekle.ExecuteNonQuery();
            MessageBox.Show("Aktif Personellere Kayıt Eklendi!");
            baglanti.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            VerileriGetir(); // DataGridView'i yenile
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form a = this.MdiParent;
            a.WindowState = FormWindowState.Minimized;
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
         
            
         
        
    

    

