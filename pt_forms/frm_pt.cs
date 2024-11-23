using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing
{
    public partial class frm_pt : Form
    {
        public frm_pt()
        {
            InitializeComponent();
        }

        private void frm_pt_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString();
        }
    }
}
