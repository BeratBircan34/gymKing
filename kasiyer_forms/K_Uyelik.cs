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
            this.Close();
            uyelikSil.Show();
        }

       

        private void K_Uyelik_Load_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            K_uyelikEkle uyelikEkle = new K_uyelikEkle();
            this.Close();
            uyelikEkle.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            K_uyelikDuzenle uyelikduzenle = new K_uyelikDuzenle();
            this.Close();
            uyelikduzenle.Show();
        }
    }
}
