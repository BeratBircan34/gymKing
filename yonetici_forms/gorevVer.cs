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
    public partial class gorevVer : Form
    {
        public gorevVer(string id)
        {
            InitializeComponent();
            this.id_=id;
        }
        public string id_ = "";
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            string gorev = txtGorev.Text;

            if (!string.IsNullOrWhiteSpace(gorev))
            {
                // Görevi listeye ekle
                Temizlik.GorevListesi.Add(gorev);

                // Gönderim sonrası TextBox'ı temizle
                txtGorev.Text = string.Empty;

                MessageBox.Show("Görev başarıyla gönderildi!");
            }
            else
            {
                MessageBox.Show("Görev alanı boş olamaz!");
            }
        }
        void ShowParentControls()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control is MdiClient)) // MDI alanını gösterme
                {
                    control.Visible = true; // Kontrolleri tekrar görünür yap
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //yonetici yoneticipanel = new yonetici(id_);
            //yoneticipanel.Show();
            Form parentForm = this.MdiParent;
            if (parentForm != null)
            {
                // Parent formdaki kontrolleri görünür yap
                foreach (Control control in parentForm.Controls)
                {
                    control.Visible = true;
                }
            }
            this.Close();
            /*this.FormClosed += (s, args) => ShowParentControls();
            foreach (Control control in this.Controls)
            {
                if (!control.Visible) // Eğer kontrol gizli ise
                {
                    control.Visible = true; // Görünür yap
                    
                }
            }*/

        }

        private void gorevVer_Load(object sender, EventArgs e)
        {
            
            //this.Size = new System.Drawing.Size(800,800);
        }
    }
}
