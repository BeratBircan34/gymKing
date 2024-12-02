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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace gymKing
{
    public partial class frm_pt : Form
    {
        public frm_pt()
        {
            InitializeComponent();
        }
        public string oturmSahibi = "";

        private void frm_pt_Load(object sender, EventArgs e)
        {

            timer1.Start();
            SetMdiContainerBackColor(Color.Gainsboro);
            lbl_oturumSahibi.Text = oturmSahibi;
            lbl_tarih.Text = DateTime.Now.ToString("dd.MM.yyyy");
            lbl_gun.Text = DateTime.Now.ToString("dddd");
            
        }
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_saat.Text = DateTime.Now.Hour.ToString()+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString("00");
        }

        private void itemGizle()
        {
            foreach(Control control in this.Controls)
            {
                if (!(control is MdiClient)) // MDI alanını koru
                {
                    control.Visible = false;
                }
            }
        }
        private void ShowParentControls()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control is MdiClient)) // MDI alanını gösterme
                {
                    control.Visible = true; // Kontrolleri tekrar görünür yap
                }
            }
        }
        private void SetMdiContainerBackColor(Color color)
        {
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.Gainsboro;
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = color; // Arka plan rengini ayarla
                }
            }
        }
        private void formAc(Form childform)
        {
            itemGizle();
            if (this.IsMdiContainer)
            {
                childform.MdiParent = this;
                childform.FormBorderStyle = FormBorderStyle.None;
                childform.WindowState = FormWindowState.Maximized;
                childform.Dock = DockStyle.Fill;
                childform.Show();
                childform.BringToFront();
                childform.FormClosed += (s, args) => ShowParentControls();
            }

        }

        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.DarkSalmon;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.Transparent;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            
            
            frm_vucutAnaliz frmanaliz = new frm_vucutAnaliz();
            formAc(frmanaliz);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
