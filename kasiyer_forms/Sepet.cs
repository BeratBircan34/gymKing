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
    public partial class Sepet : Form
    {
        public Sepet()
        {
            InitializeComponent();
            
        }
        Urunler urun = new Urunler();
        private void Sepet_Load(object sender, EventArgs e)
        {
            if(urun.urun1 >= 1)
            {
                listBox1.Items.Add(urun.urun1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            urunSatis satis = new urunSatis();
            this.Close();
            satis.Show();
        }
    }
}
