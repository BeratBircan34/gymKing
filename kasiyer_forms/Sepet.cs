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
        public Sepet(string id_)
        {
            InitializeComponent();
            this.id_ = id_;
        }
        Urunler urun = new Urunler();

        public string id_ = "";
        private void Sepet_Load(object sender, EventArgs e)
        {
            if(urun.urun1 >= 1)
            {
                listBox1.Items.Add(urun.urun1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            urunSatis satis = new urunSatis(id_);
            this.Close();
            satis.Show();
        }
    }
}
