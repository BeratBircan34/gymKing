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
    public partial class K_uyelikSil : Form
    {
        public K_uyelikSil()
        {
            InitializeComponent();
        }

        private void K_uyelikSil_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            K_Uyelik uyelik = new K_Uyelik();
            this.Close();
            uyelik.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
