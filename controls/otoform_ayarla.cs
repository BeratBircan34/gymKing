using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.controls
{
    public class otoform_ayarla
    {
        
        public otoform_ayarla(Form frm)
        {
             
        }
        public static void renkAyarla(Form frm, Color color)
        {
            foreach (Control control in frm.Controls)
            {
                control.BackColor = Color.WhiteSmoke;
                if (control is MdiClient mdiClient)
                {
                    mdiClient.BackColor = color; // Arka plan rengini ayarla
                }
            }
        }

        public Form formAc(Form childform, Form suanki_form)
        {
            Form suankiform = suanki_form;
            childform.FormBorderStyle = FormBorderStyle.None;
            
            
            //childform.Dock = DockStyle.Fill;
            void itemGizle()
            {
                foreach (Control control in suankiform.Controls)
                {
                    if (control is MdiClient mdiClient)
                    {
                       // mdiClient.BackColor = Color.White; // Arka planı beyaza ayarla veya istediğiniz bir renge
                    }
                    else
                    {
                        control.Visible = false; // Diğer kontrolleri gizle
                    }
                }

                if (suanki_form.IsMdiContainer)
                {
                    childform.MdiParent = suanki_form;
                    childform.Load += (s, e) =>
                    {
                        // Başlık çubuğunu ve kontrolleri kaldır
                        childform.ControlBox = false;
                        childform.MinimizeBox = false;
                        childform.MaximizeBox = false;
                        childform.WindowState = FormWindowState.Maximized;
                        childform.StartPosition = FormStartPosition.CenterScreen;
                        childform.Dock = DockStyle.Fill;
                    };
                    childform.Show();
                    childform.BringToFront();
                    childform.FormClosed += (s, args) => ShowParentControls();
                }
            }

            void ShowParentControls()
            {
                foreach (Control control in suanki_form.Controls)
                {
                    if (!(control is MdiClient)) // MDI alanını gösterme
                    {
                        control.Visible = true; // Kontrolleri tekrar görünür yap
                    }
                }
            }

            itemGizle();
            return childform;
        }

    }
}
