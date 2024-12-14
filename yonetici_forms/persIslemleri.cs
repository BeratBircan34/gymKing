using gymKing.controls;
using gymKing.kasiyer_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.yonetici_forms
{
    public partial class persIslemleri : Form
    {
        public persIslemleri()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            personelEkle personel_Ekle = new personelEkle();
            otoform_ayarla perrsonelEkle = new otoform_ayarla(personel_Ekle);
            perrsonelEkle.formAc(personel_Ekle, this);

            //personelEkle pers_ekle = new personelEkle();
            //pers_ekle.Show();
            //this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            personelSil pers_sil = new personelSil();
            pers_sil.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            personelGüncelle pers_güncelle = new personelGüncelle();
            pers_güncelle.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
    }
}
