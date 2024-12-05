using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.pt_forms
{
    public partial class frm_analizKayit : Form
    {
        public frm_analizKayit()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public string islemTuru = "";
        private void frm_analizKayit_Load(object sender, EventArgs e)
        {
            cmbbx_settings(3);
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
    }
}
