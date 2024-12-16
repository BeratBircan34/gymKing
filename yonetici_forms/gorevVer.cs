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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            yonetici yoneticipanel = new yonetici(id_);
            //yoneticipanel.Show();
            this.Close();
        }
    }
}
