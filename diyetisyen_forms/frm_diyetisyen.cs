using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.diyetisyen_forms
{
    public partial class frm_diyetisyen : Form
    {
        public frm_diyetisyen()
        {
            InitializeComponent();
        }
        public string diyetisyen_oturumSahibi = "";
        private void frm_diyetisyen_Load(object sender, EventArgs e)
        {
            label1.Text = diyetisyen_oturumSahibi;
            SetMdiContainerBackColor(Color.Gainsboro);
        }
        private void itemGizle()
        {
            foreach (Control control in this.Controls)
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

        private void button1_Click(object sender, EventArgs e)
        {
            deneme dnm = new deneme();
            formAc(dnm);

        }
    }
}
