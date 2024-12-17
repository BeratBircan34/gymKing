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
    public partial class İstatistikler : Form
    {
        public İstatistikler(string id)
        {
            InitializeComponent();
            this.id_=id;
        }
        public string id_ = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            
        }

        private void İstatistikler_Load(object sender, EventArgs e)
        {

        }
    }
}
