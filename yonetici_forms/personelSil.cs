using gymKing.controls;
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
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personelSil_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand ad = new SqlCommand("select ad from tbl_per_bilgiler", baglanti);
            SqlDataReader dr = ad.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAd.Items.Add(dr["ad"].ToString());

            }
            dr.Close();

            //SqlCommand kullaniciAdi = new SqlCommand("select kullaniciAdi from tbl_giris_Bilgileri where kullaniciID = " + id_, baglanti);
            //SqlDataReader adgetir = kullaniciAdi.ExecuteReader();
            //while (adgetir.Read())
            //{
            //    label11.Text = adgetir["kullaniciAdi"].ToString();
            //}
            //adgetir.Close();


            //baglanti.Close();




            //// VeriYonetimi sınıfından bir örnek oluştur
            //perBilgiCek cek = new perBilgiCek();

            //// GetVeri metodunu çağırarak verileri al
            //DataTable veri = cek.VeriCek();

            //// Alınan verileri DataGridView'e yükle
            //dataGridView1.DataSource = veri;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Seçilen satırdaki hücrelere erişim
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow secilenSatir = dataGridView1.SelectedRows[0];

            //    // TextBox'lara verileri aktar
            //    txtad.Text = secilenSatir.Cells["ad"].Value.ToString();
            //    txtsoyad.Text = secilenSatir.Cells["soyad"].Value.ToString();
            //    txttc.Text = secilenSatir.Cells["tcno"].Value.ToString();
            //    txtdogum.Text = secilenSatir.Cells["dogumTarihi"].Value.ToString();
            //    txttel.Text = secilenSatir.Cells["telNo"].Value.ToString();
            //    txtmail.Text = secilenSatir.Cells["email"].Value.ToString();
            //    txtrol.Text = secilenSatir.Cells["rol"].Value.ToString();
            //    txtadres.Text = secilenSatir.Cells["adres"].Value.ToString();

            }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand getir = new SqlCommand("select * from tbl_per_bilgiler where perId = " + textBoxID.Text, baglanti);
            SqlDataReader getir2 = getir.ExecuteReader();
            while (getir2.Read())
            {
                textBoxDogum.Text = getir2["dogumTarihi"].ToString();
                textBoxisegiris.Text = getir2["isegiris"].ToString();
                textBoxMail.Text = getir2["email"].ToString();
                textBoxAdres.Text = getir2["adres"].ToString();
                textBoxTelefon.Text = getir2["telNo"].ToString();
               comboBoxRol.Text = getir2["rol"].ToString();
            }
            getir2.Close();


            SqlCommand getir3 = new SqlCommand("select * from tbl_giris_Bilgileri where KullaniciID = " + textBoxID.Text, baglanti);
            SqlDataReader getir4 = getir3.ExecuteReader();
            while (getir4.Read())
            {
                textBoxKullaniciAdi.Text = getir4["kullaniciAdi"].ToString();
                textBoxSifre.Text = getir4["sifre"].ToString();
            }
            getir4.Close();
            baglanti.Close();
        }

        private void comboBoxSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand id = new SqlCommand("select perId from tbl_per_bilgiler where ad ='" + comboBoxAd.Text + "' and soyad = '" + comboBoxSoyad.Text + "'", baglanti);
            SqlDataReader reader = id.ExecuteReader();
            while (reader.Read())
            {
                textBoxID.Text = reader["perId"].ToString();
            }
        }

        private void comboBoxAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            string sorgu = "SELECT soyad FROM tbl_per_bilgiler WHERE ad = @pAd";
            SqlCommand soyad = new SqlCommand(sorgu, baglanti);
            soyad.Parameters.AddWithValue("@pAd", comboBoxAd.Text);
            SqlDataReader dr = soyad.ExecuteReader();
            comboBoxSoyad.Items.Clear();
            while (dr.Read())
            {
                comboBoxSoyad.Items.Add(dr["soyad"].ToString());
            }
            dr.Close();
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from tbl_per_bilgiler where perId = " + textBoxID.Text, baglanti);
            SqlCommand sil2 = new SqlCommand("delete from tbl_giris_Bilgileri where KullaniciID = " + textBoxID.Text, baglanti);

            sil.ExecuteNonQuery();
            sil2.ExecuteNonQuery();



            baglanti.Close();



            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
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
    }

       
}
   
