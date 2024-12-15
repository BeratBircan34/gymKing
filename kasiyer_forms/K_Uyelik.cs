using gymKing.controls;
using gymKing.pt_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.kasiyer_forms
{
    public partial class K_Uyelik : Form
    {
        public K_Uyelik()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Kasiyer kasiyer = new Kasiyer();
            this.Close();
            kasiyer.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            K_uyelikSil uyelikSil = new K_uyelikSil();
            otoform_ayarla uyelikSil_c = new otoform_ayarla(uyelikSil);
            uyelikSil_c.formAc(uyelikSil, this);
        }

       

        private void K_Uyelik_Load_1(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            K_uyelikEkle uyelikEkle = new K_uyelikEkle();
            otoform_ayarla uyelikEkle_c = new otoform_ayarla(uyelikEkle);
            uyelikEkle_c.formAc(uyelikEkle, this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           K_uyelikDuzenle uyelikDuzenle_ = new K_uyelikDuzenle();
            otoform_ayarla uyelikDuzenle_c = new otoform_ayarla(uyelikDuzenle_); 
            uyelikDuzenle_c.formAc(uyelikDuzenle_, this);
        }
    }
}
