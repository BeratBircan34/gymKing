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

        }

        private void K_Uyelik_Load(object sender, EventArgs e)
        {

        }
    }
}
