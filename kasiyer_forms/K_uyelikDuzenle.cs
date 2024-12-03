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
    public partial class K_uyelikDuzenle : Form
    {
        public K_uyelikDuzenle()
        {
            InitializeComponent();
        }

        private void K_uyelikDuzenle_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik();
            this.Close();
            uyelik.Show();
        }
    }
}
