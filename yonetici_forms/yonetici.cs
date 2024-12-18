using gymKing.controls;
using gymKing.kasiyer_forms;
using gymKing.oto_Baglanti;
using gymKing.pt_forms;
using gymKing.Üye_forms;
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
    public partial class yonetici : Form
    {
        public yonetici(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }
        public string yonetici_oturumSahibi = "";
        public string id_ = "";
        private void yonetici_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbl_oturumSahibi.Text = yonetici_oturumSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            otoform_ayarla.renkAyarla(this, Color.WhiteSmoke);

            // ComboBox'ları temizliyoruz
            comboBoxPT.Items.Clear();
            comboBoxKasiyer.Items.Clear();

            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            // "Pt" rolündeki kullanıcıları getiren SQL sorgusu
            SqlCommand kmt = new SqlCommand("SELECT KullaniciID, kullaniciAdi FROM tbl_giris_bilgileri WHERE rol = 'Pt'", baglanti);
            SqlDataReader dr = kmt.ExecuteReader();

            if (dr.Read())
            {
                string kullaniciAdi = dr["kullaniciAdi"].ToString();
                string kullaniciID = dr["KullaniciID"].ToString();

                // UserItem nesnesi oluşturup ComboBox'a ekliyoruz
                //comboBoxPT.Items.Add(new UserItem { Ad = kullaniciAdi, ID = kullaniciID });
                comboBoxPT.Items.Add(new UserItem { Ad = getUserName(kullaniciID), ID = kullaniciID });
            }

            dr.Close();

            // "Kasiyer" rolündeki kullanıcıları getiren SQL sorgusu
            SqlCommand kmt2 = new SqlCommand("SELECT KullaniciID, kullaniciAdi FROM tbl_giris_bilgileri WHERE rol = 'Kasiyer'", baglanti);
            SqlDataReader dr2 = kmt2.ExecuteReader();

            while (dr2.Read())
            {
                string kullaniciAdi = dr2["kullaniciAdi"].ToString();
                string kullaniciID = dr2["KullaniciID"].ToString();

                // UserItem nesnesi oluşturup ComboBox2'ye ekliyoruz
                comboBoxKasiyer.Items.Add(new UserItem { Ad = getUserName(kullaniciID), ID = kullaniciID });
            }

            dr2.Close();

            //// "Temizlikçi" rolündeki kullanıcıları getiren SQL sorgusu
            //SqlCommand kmt3 = new SqlCommand("SELECT KullaniciID, kullaniciAdi FROM tbl_giris_bilgileri WHERE rol = 'Temizlikçi'", baglanti);
            //SqlDataReader dr3 = kmt3.ExecuteReader();

            //while (dr3.Read())
            //{
            //    string kullaniciAdi = dr3["kullaniciAdi"].ToString();
            //    string kullaniciID = dr3["KullaniciID"].ToString();

            //    // UserItem nesnesi oluşturup ComboBoxTemizlik'e ekliyoruz
            //    comboBoxTemizlik.Items.Add(new UserItem { Ad = kullaniciAdi, ID = kullaniciID });
            //}

            //dr3.Close();
            baglanti.Close();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frm_pt formpt = new frm_pt();
            formpt.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            personelilan persilan = new personelilan(id_);
            otoform_ayarla persilann = new otoform_ayarla(persilan);
            persilann.formAc(persilan, this);

            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Kasiyer kasiyerr = new Kasiyer();
            //otoform_ayarla kasiyerrr = new otoform_ayarla(kasiyerr);
            //kasiyerrr.formAc(kasiyerr, this);

            Kasiyer kasiyerr = new Kasiyer(id_);
            kasiyerr.Show();
            this.Close();

        }


        private void pictureBox12_Click(object sender, EventArgs e)
        {
            gelirGider gelir_gider = new gelirGider(id_);
            otoform_ayarla gelir__gider = new otoform_ayarla(gelir_gider);
            gelir__gider.formAc(gelir_gider, this);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient mdiClient)
                {
                    // mdiClient.BackColor = Color.White; // Arka planı beyaza ayarla veya istediğiniz bir renge
                }
                else
                {
                    control.Visible = false; // Diğer kontrolleri gizle
                }
            }
            gorevVer gorev = new gorevVer(id_)
            {
                MdiParent = this, // Parent formu belirt
                Text = "Child Form",             
                StartPosition = FormStartPosition.CenterScreen // Ortada açılması için
            };
            gorev.Show();
            gorev.BringToFront();

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            personelEkle pers_ekle = new personelEkle(id_);
            otoform_ayarla pers_ekle2 = new otoform_ayarla(pers_ekle);
            pers_ekle2.formAc(pers_ekle, this);
            
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            personelSil pers_sil = new personelSil(id_);
            otoform_ayarla pers_sil2 = new otoform_ayarla(pers_sil);
            pers_sil2.formAc(pers_sil, this);

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            personelGüncelle pers_güncelle = new personelGüncelle(id_);
            otoform_ayarla pers_güncelle2 = new otoform_ayarla(pers_güncelle);
            pers_güncelle2.formAc(pers_güncelle, this);

        }

        private string getUserRole(string kullaniciID)
        {
            string rol = "";
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT rol FROM tbl_giris_bilgileri WHERE KullaniciID = @KullaniciID", baglanti);
            kmt.Parameters.AddWithValue("@KullaniciID", kullaniciID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                rol = dr["rol"].ToString();
            }
            dr.Close();
            baglanti.Close();
            return rol;
        }

        private string getUserName(string kullaniciID)
        {
            string adSoyad = "";
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("SELECT ad,soyad FROM tbl_per_bilgiler WHERE perId = @KullaniciID", baglanti);
            kmt.Parameters.AddWithValue("@KullaniciID", kullaniciID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                adSoyad = dr[0].ToString()+" "+ dr[1].ToString(); // Kullanıcı adı burada alınabilir
            }
            dr.Close();
            baglanti.Close();
            return adSoyad;
        }      

        public class UserItem
        {
            public string Ad { get; set; }
            public string ID { get; set; }

            // ComboBox'ta sadece kullanıcı adını gösterebilmek için ToString() metodunu override ediyoruz
            public override string ToString()
            {
                return Ad;  // ComboBox'ta sadece kullanıcı adını gösterecek
            }
        }


        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            if (comboBoxPT.SelectedItem != null)
            {
                // Seçilen öğeyi UserItem türünde alıyoruz
                UserItem selectedItem = comboBoxPT.SelectedItem as UserItem;
                string kullaniciAdi = selectedItem.Ad;
                string kullaniciID = selectedItem.ID;

                // Kullanıcı ID'sine göre rolü ve diğer bilgileri almak için
                string rol = getUserRole(kullaniciID);

                switch (rol)
                {
                    case "Pt":
                        frm_pt frmpt = new frm_pt();
                        frmpt.oturmSahibi = getUserName(kullaniciID)+"_Admin";
                        frmpt.Show();
                        break;
                    case "Kasiyer":
                        Kasiyer kasiyer = new Kasiyer(kullaniciID);
                        kasiyer.kasiyer_oturumSahibi = getUserName(kullaniciID)+"_Admin";
                        string deneme = getUserName(kullaniciID) ;
                        kasiyer.Show();
                        break;
                    default:
                        MessageBox.Show("Seçilen kullanıcının rolü geçerli değil.");
                        break;
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBoxKasiyer.SelectedItem != null)
            {
                // Seçilen öğeyi UserItem türünde alıyoruz
                UserItem selectedKasiyerItem = comboBoxKasiyer.SelectedItem as UserItem;
                string kullaniciAdiKasiyer = selectedKasiyerItem.Ad;
                string kullaniciIDKasiyer = selectedKasiyerItem.ID;

                // Kullanıcı ID'sine göre rolü ve diğer bilgileri almak için
                string rolKasiyer = getUserRole(kullaniciIDKasiyer);

                switch (rolKasiyer)
                {
                    case "Pt":
                        frm_pt frmptKasiyer = new frm_pt();
                        frmptKasiyer.oturmSahibi = getUserName(kullaniciIDKasiyer);
                        frmptKasiyer.Show();
                        break;
                    case "Kasiyer":
                        Kasiyer kasiyer = new Kasiyer(kullaniciIDKasiyer);
                        kasiyer.kasiyer_oturumSahibi = getUserName(kullaniciIDKasiyer) +"_Admin";
                        kasiyer.Show();
                        break;
                    default:
                        MessageBox.Show("Seçilen kullanıcının rolü geçerli değil.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu küçült
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
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
