using gymKing.controls;
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
    public partial class urunSatis : Form
    {
        public urunSatis(string id)
        {
            InitializeComponent();
            this.id_ = id;
        }

        public string id_ = "";

        Urunler urun = new Urunler();
        

        private void urunSatis_Load(object sender, EventArgs e)
        {
            otoform_ayarla.renkAyarla(this, Color.Gainsboro);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Sepet sepet = new Sepet(id_);
            sepet.Show();
   
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            urun.urun1--;
            label2.Text=urun.urun1.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            urun.urun1++;
            label2.Text=urun.urun1.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            urun.urun2++;
            label5.Text=urun.urun2.ToString();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            urun.urun2--;
            label5.Text =urun.urun2.ToString();
        }
    }
}
