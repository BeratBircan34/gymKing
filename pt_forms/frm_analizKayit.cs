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

namespace gymKing.pt_forms
{
    public partial class frm_analizKayit : Form
    {
        public string bmh {  get; set; }
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

        }
        private void frm_analizKayit_Load(object sender, EventArgs e)
        {
            verileriYerlestir();
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
                    cmbbx_isim.Enabled= false   ;
                    cmbbx_soyisim.Enabled = false ;
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void rd_kayitliGuncelle_CheckedChanged(object sender, EventArgs e)
        {
            cmbbx_settings(2);
        }

        private void rd_yeniKayit_CheckedChanged(object sender, EventArgs e)
        {
            cmbbx_settings(1);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
    public class deneme : pt_gecici_Bellek
    {
        public deneme()
        {
            
        }
    }

    
        

    }




