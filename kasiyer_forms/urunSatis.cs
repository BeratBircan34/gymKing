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
        public urunSatis()
        {
            InitializeComponent();
        }

        public string kasiyer_oturumSahibi = "";

        private void urunSatis_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Kasiyer kasiyer = new Kasiyer();
            this.Close();
            kasiyer.Show();
        }

       
    }
}
