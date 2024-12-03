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
using gymKing.diyetisyen_forms;
using gymKing.kasiyer_forms;
using gymKing.yonetici_forms;

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
                        perBilgiAl per = new perBilgiAl(id);
                        frmpt.oturmSahibi = per.ad +" "+ per.soyad;
                        frmpt.Show();
                        this.Hide();
                        MessageBox.Show(id);
                        MessageBox.Show("Hoşgeldiniz!"+per.ad+" "+per.soyad);
                        break;
                    case "Diyetisyen":
                        frm_diyetisyen frmdiyet = new frm_diyetisyen();
                        perBilgiAl perBilgi = new perBilgiAl(id);
                        frmdiyet.diyetisyen_oturumSahibi = perBilgi.ad+" "+ perBilgi.soyad;
                        frmdiyet.Show();
                        this.Hide();
                        break;
                    case "Kasiyer":
                        Kasiyer kasiyer = new Kasiyer();
                        perBilgiAl K_bilgi = new perBilgiAl(id);
                        kasiyer.kasiyer_oturumSahibi = K_bilgi.ad + " " + K_bilgi.soyad;
                        kasiyer.Show();
                        this.Hide();
                        MessageBox.Show("Hoşgeldiniz!" + K_bilgi.ad + " " +K_bilgi.soyad);
                        break;
                    case "Yönetici":
                        yonetici yonetici = new yonetici();
                        perBilgiAl perrbilgi = new perBilgiAl(id);
                        yonetici.yonetici_oturumSahibi = perrbilgi.ad + " " + perrbilgi.soyad;
                        yonetici.Show();
                        this.Hide();
                        MessageBox.Show("Hoşgeldiniz!" + perrbilgi.ad + " " + perrbilgi.soyad);
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
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            girisKontrol(txtK_adi.Text, txt_Sifre.Text);
            
        }
    }
}
