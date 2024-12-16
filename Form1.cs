using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using gymKing.controls;

using gymKing.kasiyer_forms;
using gymKing.yonetici_forms;
using gymKing.Üye_forms;

namespace gymKing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlOtoBaglanti.pcAdiAl();
        }
        public string id_ = "";
       

        private void girisKontrol(string kullaniciAdi,string sifre)
        {
            string rol = "Yok";
            string id = "";
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select  * from tbl_giris_bilgileri where kullaniciadi = @kAdi and sifre = @sifre", baglanti);
            kmt.Parameters.Add("@kAdi", kullaniciAdi);
            kmt.Parameters.Add("@sifre", sifre);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                rol = dr["rol"].ToString();
                id = dr["KullaniciID"].ToString();
                switch (rol)
                {
                    case "Temizlikçi":
                        Temizlik frm = new Temizlik();
                        frm.Show();
                        
                        break;
                    case "Pt":
                        frm_pt frmpt = new frm_pt();
                        bilgiAl per = new perBilgiAl(id);
                        per.bilgi(id);
                        frmpt.oturmSahibi = per.Ad + " " + per.Soyad;
                        frmpt.Show();
                        this.Hide();
                        MessageBox.Show(id);
                        MessageBox.Show("Hoşgeldiniz! " + per.Ad + " " + per.Soyad);
                        break;
                    case "Kasiyer":
                        Kasiyer kasiyer = new Kasiyer(id);
                        bilgiAl bilgiAl = new perBilgiAl(id);
                        bilgiAl.bilgi(id);
                        kasiyer.id_ = id;
                        kasiyer.kasiyer_oturumSahibi = bilgiAl.Ad + " " + bilgiAl.Soyad;
                        kasiyer.Show();
                        this.Hide();
                        MessageBox.Show("Hoşgeldiniz! " + bilgiAl.Ad + " " + bilgiAl.Soyad);
                        break;
                    case "Yönetici":
                        yonetici yonetici = new yonetici(id);
                        bilgiAl perrbilgi = new perBilgiAl(id);
                        perrbilgi.bilgi(id);
                        yonetici.id_ = id;
                        yonetici.yonetici_oturumSahibi = perrbilgi.Ad + " " + perrbilgi.Soyad;
                        yonetici.Show();
                        this.Hide();
                        MessageBox.Show("Hoşgeldiniz! " + perrbilgi.Ad + " " + perrbilgi.Soyad);
                        break;
                    case "Üye":
                        üyePaneli üyelik = new üyePaneli(id);
                        bilgiAl uyebilgi = new uyeBilgiAl(id);
                        uyebilgi.bilgi(id);
                        üyelik.id_ = id;
                        üyelik.uyeOturumSahibi = uyebilgi.Ad + " " + uyebilgi.Soyad;
                        üyelik.Show();
                        this.Hide();
                        MessageBox.Show("Hoşgeldiniz! " + uyebilgi.Ad + " " + uyebilgi.Soyad);

                        break;

                    default:
                        MessageBox.Show("Rolünüzün giriş ekranı yapım aşamasında");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Giriş bilgilerini kontrol ediniz!");
            }
            dr.Close();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            girisKontrol(txtK_adi.Text, txt_Sifre.Text);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personelEkle prs = new personelEkle(id_);
            prs.Show();
        }
    }
}
