using gymKing.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;
using gymKing.oto_Baglanti;
using System.Collections;

namespace gymKing.pt_forms
{
    public partial class frm_analizKayit : Form
    {
        public string bmh { get; set; }
        public string gki { get; set; }
        public string vki { get; set; }
        public string vyo { get; set; }
        public string vym { get; set; }
        public string bko { get; set; }
        public string bbo { get; set; }
        public string msr { get; set; }



        public frm_analizKayit()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public string islemTuru = "";


        private void verileriYerlestir()
        {
            deneme dnm = new deneme();
            txt_yasS.Text = dnm.yas;
            txt_kiloS.Text = dnm.kilo;
            txt_kalcaS.Text = dnm.kalca;
            txt_boyunS.Text = dnm.boyun;
            txt_boyS.Text = dnm.boy;
            txt_belS.Text = dnm.bel;
            lbl_bmhS.Text = dnm.bazalMetabolizmaHizi;
            lbl_gkiS.Text = dnm.gunlukKaloriIhtiyacı;
            lbl_vkiS.Text = dnm.vucutKitleEndeksi;
            lbl_vyoS.Text = dnm.vucutYagOrani;
            lbl_vymS.Text = dnm.vucutYagMiktari;
            lbl_bboS.Text = dnm.belBoyOrani_;
            lbl_bkoS.Text = dnm.belKalcaOrani;
            lbl_msr.Text = dnm.metabolikSendromRiski;
            lbl_boyun.Text = dnm.boyun;
            lbl_si.Text = dnm.suIhtiyacı;
            lbl_ki.Text = dnm.karbIhtiyacı;
            lbl_pi.Text = dnm.proteinIhtıyacı;
            lbl_yi.Text = dnm.yagIhtıyacı;
            lbl_ik.Text = dnm.idealKilo;
            lbl_cinsiyet.Text = dnm.cinsiyet;

        }
        public string egitmen = "";
        private void frm_analizKayit_Load(object sender, EventArgs e)
        {
            lbl_egitmen.Text = egitmen;
            verileriYerlestir();
            if (lbl_cinsiyet.Text == "Kadin")
                lbl_cinsiyet.ForeColor = Color.IndianRed;
            else
                lbl_cinsiyet.ForeColor= Color.CadetBlue;
        
            cmbbx_settings(3);
            /*void setLabelText(string yas, string boy, string kilo, string bel, string kalca, string boyun, string gki, string bmh, string msr, string si, string pi, string ki, string yi,
            string vyo, string bko, string bbo, string belBoyun, string vki, string vkm, string vym, string ik)
            {
                //Kişisel Bilgiler
                txt_kiloS.Text = kilo;
                txt_yasS.Text = yas;
                txt_kalcaS.Text = kalca;
                txt_belS.Text = bel;
                txt_boyS.Text = boy;
                txt_boyunS.Text = boyun;
                //Beslenme Bilgileri
                lbl_gkiS.Text = gki;
                lbl_bmhS.Text = bmh;
                lbl_msr.Text = msr;
                //Makro



            }*/

            //TODO RADİOBUTTONDAN SEÇİM YAPILACAK VE ONA GÖRE İŞLEMLER YAPILACAK
            //TODO ÖZELLİKLER BİTTİKTEN SONRA TASARIMA GEÇİLECEK

        }


        private void cmbbx_settings(int tf)
        {
            switch (tf)
            {
                case 1:
                    islemTuru = "Yeni Kayit";
                    cmbbx_isim.Enabled = true;
                    cmbbx_soyisim.Enabled = true;
                    break;
                case 2:
                    islemTuru = "Kayitli Güncelleme";
                    cmbbx_isim.Enabled = true;
                    cmbbx_soyisim.Enabled = true;
                    break;
                case 3:
                    cmbbx_isim.Enabled = false;
                    cmbbx_soyisim.Enabled = false;
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rd_kayitliGuncelle_CheckedChanged(object sender, EventArgs e)
        {
            cmbbx_isim.Items.Clear();
            cmbbx_soyisim.Items.Clear();
            cmbbx_settings(2);
            kayitliKisiCek();
        }

        private void rd_yeniKayit_CheckedChanged(object sender, EventArgs e)
        {
            cmbbx_isim.Items.Clear();
            cmbbx_soyisim.Items.Clear();
            cmbbx_settings(1);
            yeniKisiCek();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verileriCevirVeYolla();
        }
        private void sql_komut(string komut,SqlConnection bglnti)
        {
            SqlCommand cmd = new SqlCommand(komut, bglnti);
            parametrelereDegerVer(cmd);
            cmd.ExecuteNonQuery();

        }
        private void sql_komut_gecmis(string komut, SqlConnection bglnti)
        {
            SqlCommand cmd = new SqlCommand(komut, bglnti);
            parametrelereDegerVer(cmd,"gecmis");
            cmd.ExecuteNonQuery();
        }
        private void parametrelereDegerVer(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ad", cmbbx_isim.Text);
            cmd.Parameters.AddWithValue("@soyad", cmbbx_soyisim.Text);
            cmd.Parameters.AddWithValue("@bazalMetabolizma", decimal.Parse(lbl_bmhS.Text));
            cmd.Parameters.AddWithValue("@gunlukKalori", decimal.Parse(lbl_gkiS.Text));
            cmd.Parameters.AddWithValue("@metabolikSRisk", lbl_msr.Text.ToString());
            cmd.Parameters.AddWithValue("@vki", decimal.Parse(lbl_vkiS.Text));
            cmd.Parameters.AddWithValue("@vyo", decimal.Parse(lbl_vyoS.Text));
            cmd.Parameters.AddWithValue("@vym", decimal.Parse(lbl_vymS.Text));
            cmd.Parameters.AddWithValue("@ik", decimal.Parse(lbl_ik.Text));
            cmd.Parameters.AddWithValue("@bko", decimal.Parse(lbl_bkoS.Text));
            cmd.Parameters.AddWithValue("@bboy", decimal.Parse(lbl_bboS.Text));
            cmd.Parameters.AddWithValue("@bboyun", decimal.Parse(lbl_boyun.Text));
            cmd.Parameters.AddWithValue("@si", decimal.Parse(lbl_si.Text));
            cmd.Parameters.AddWithValue("@pi", decimal.Parse(lbl_pi.Text));
            cmd.Parameters.AddWithValue("@ki", decimal.Parse(lbl_ki.Text));
            cmd.Parameters.AddWithValue("@yi", decimal.Parse((lbl_ki.Text)));
            cmd.Parameters.AddWithValue("@kilo", int.Parse(txt_kiloS.Text));
            cmd.Parameters.AddWithValue("@bel", int.Parse(txt_belS.Text));
            cmd.Parameters.AddWithValue("@boyun", int.Parse(txt_boyunS.Text));
            cmd.Parameters.AddWithValue("@kalca", int.Parse(txt_kalcaS.Text));
            cmd.Parameters.AddWithValue("@boy", int.Parse(txt_boyS.Text));
            cmd.Parameters.AddWithValue("@yas", int.Parse(txt_yasS.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@egitmen", lbl_egitmen.Text);
            cmd.Parameters.AddWithValue("@cinsiyet",lbl_cinsiyet.Text);
            
        }
        private void parametrelereDegerVer(SqlCommand cmd,string islemTuru)
        {
            cmd.Parameters.AddWithValue("@ad", cmbbx_isim.Text);
            cmd.Parameters.AddWithValue("@soyad", cmbbx_soyisim.Text);
            cmd.Parameters.AddWithValue("@islemTarihi",DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@islemGunu", DateTime.Now.ToString("dddd"));
            cmd.Parameters.AddWithValue("@islemSaati", DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString("00"));
            cmd.Parameters.AddWithValue("@bazalMetabolizma", (lbl_bmhS.Text));
            cmd.Parameters.AddWithValue("@gunlukKalori", (lbl_gkiS.Text));
            cmd.Parameters.AddWithValue("@metabolikSRisk", lbl_msr.Text.ToString());
            cmd.Parameters.AddWithValue("@vki", (lbl_vkiS.Text));
            cmd.Parameters.AddWithValue("@vyo", (lbl_vyoS.Text));
            cmd.Parameters.AddWithValue("@vym", (lbl_vymS.Text));
            cmd.Parameters.AddWithValue("@ik", (lbl_ik.Text));
            cmd.Parameters.AddWithValue("@bko", (lbl_bkoS.Text));
            cmd.Parameters.AddWithValue("@bboy", (lbl_bboS.Text));
            cmd.Parameters.AddWithValue("@bboyun", (lbl_boyun.Text));
            cmd.Parameters.AddWithValue("@si", (lbl_si.Text));
            cmd.Parameters.AddWithValue("@pi", (lbl_pi.Text));
            cmd.Parameters.AddWithValue("@ki", (lbl_ki.Text));
            cmd.Parameters.AddWithValue("@yi", ((lbl_ki.Text)));
            cmd.Parameters.AddWithValue("@kilo", (txt_kiloS.Text));
            cmd.Parameters.AddWithValue("@bel", (txt_belS.Text));
            cmd.Parameters.AddWithValue("@boyun", (txt_boyunS.Text));
            cmd.Parameters.AddWithValue("@kalca", (txt_kalcaS.Text));
            cmd.Parameters.AddWithValue("@boy", (txt_boyS.Text));
            cmd.Parameters.AddWithValue("@yas", (txt_yasS.Text));
            cmd.Parameters.AddWithValue("@tarih", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@egitmen", lbl_egitmen.Text);

        }
        private void gecmiseYolla()
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            string araKomut = "";
            if (rd_yeniKayit.Checked)
                araKomut = "Yeni kisi kayit";
            if (rd_kayitliGuncelle.Checked)
                araKomut = "Kayitli Guncelleme";
            string komut_yeniKisi = ($"insert into tbl_gecmis_islemler (ad, soyad, islem_tarihi,islem_gunu,islem_saati,islem_turu,bmh, gki, msr, vki, vyo, vym, ik, bko, bbo, bboyun, si, pi, ki, yi, kilo, bel, boyun, kalca, boy, yas,egitmen)" +
                ($"values (@ad, @soyad, @islemTarihi,@islemGunu,@islemSaati,'{araKomut}',@bazalMetabolizma, @gunlukKalori, @metabolikSRisk, @vki, @vyo, @vym, @ik, @bko, @bboy, @bboyun, @si, @pi, @ki, @yi, @kilo, @bel, @boyun, @kalca, @boy, @yas ,@egitmen)"));
            baglanti.Open();
            sql_komut_gecmis(komut_yeniKisi, baglanti);
            baglanti.Close();


        }

        private void verileriCevirVeYolla()
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            string komut_yeniKisi = ("insert into tbl_guncelkayitlar (ad, soyad, bazalMetabolizma, gunlukKalori, metabolikSRisk, vki, vyo, vym, ik, bko, bboy, bboyun, si, pi, ki, yi, kilo, bel, boyun, kalca, boy, yas,egitmen,tarih,cinsiyet)" +
                "values (@ad, @soyad, @bazalMetabolizma, @gunlukKalori, @metabolikSRisk, @vki, @vyo, @vym, @ik, @bko, @bboy, @bboyun, @si, @pi, @ki, @yi, @kilo, @bel, @boyun, @kalca, @boy, @yas ,@egitmen,@tarih,@cinsiyet)");
            string komut_Kayitlikisi =  "UPDATE tbl_guncelkayitlar SET ad = @ad, soyad = @soyad, bazalMetabolizma = @bazalMetabolizma, gunlukKalori = @gunlukKalori, metabolikSRisk = @metabolikSRisk, vki = @vki, vyo = @vyo, vym = @vym, ik = @ik, bko = @bko, bboy = @bboy, bboyun = @bboyun, si = @si, pi = @pi, ki = @ki, yi = @yi, kilo = @kilo, bel = @bel, boyun = @boyun, kalca = @kalca, boy = @boy, yas = @yas , egitmen = @egitmen, tarih = @tarih";
            baglanti.Open();
            if (rd_yeniKayit.Checked)
            {
                sql_komut(komut_yeniKisi, baglanti);
                gecmiseYolla();
            }
            else if (rd_kayitliGuncelle.Checked)
            {
                sql_komut(komut_Kayitlikisi, baglanti);
                gecmiseYolla();
            }
            MessageBox.Show("Veriler başarıyla işlendi");
            baglanti.Close();

        }

        

        private void kayitliKisiCek()
        {
            
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select distinct ad from tbl_guncelKayitlar where cinsiyet = @p1", baglanti);
            kmt.Parameters.AddWithValue("@p1", lbl_cinsiyet.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                cmbbx_isim.Items.Add(dr["ad"].ToString());
                
            }
            dr.Close();
            baglanti.Close();
        }
        private void yeniKisiCek()
        {
            
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select distinct m_ad from tbl_musteriler where cinsiyet = @p1", baglanti);
            kmt.Parameters.AddWithValue("@p1", lbl_cinsiyet.Text);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                cmbbx_isim.Items.Add(dr["m_Ad"].ToString());
                
            }
        }

        private void soyadCek(string islemTuru_)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            switch (islemTuru)
            {

                case "Yeni Kayit":
                    
                    SqlCommand kmt = new SqlCommand("select distinct m_soyad from tbl_musteriler where m_ad = @p1 ", baglanti);
                    kmt.Parameters.AddWithValue("@p1", cmbbx_isim.Text);
                    SqlDataReader dr = kmt.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbbx_soyisim.Items.Add(dr["m_soyad"].ToString());
                        
                    }
                    break;
                case "Kayitli Güncelleme":
                    
                    SqlCommand kmt2 = new SqlCommand("select distinct soyad from tbl_guncelKayitlar where ad = @p1", baglanti);
                    kmt2.Parameters.AddWithValue("@p1", cmbbx_isim.Text);
                    SqlDataReader dr2 = kmt2.ExecuteReader();
                    while (dr2.Read())
                    {
                        cmbbx_soyisim.Items.Add(dr2["soyad"].ToString());
                       
                    }
                    break;

            }


        }
        public class deneme : pt_gecici_Bellek
        {
            public deneme()
            {

            }
        }

        private void cmbbx_isim_SelectedIndexChanged(object sender, EventArgs e)
        {
            soyadCek(islemTuru);
        }

        private void cmbbx_soyisim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}




