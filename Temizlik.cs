using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing
{
    public partial class Temizlik : Form
    {

        public static List<string> GorevListesi = new List<string>();

        public Temizlik()
        {
            InitializeComponent();
            GorevleriListele(); // Form açıldığında görevleri göster

        }

        public void GorevleriListele()
        {
            listBoxGorevler.Items.Clear(); // Mevcut görevleri temizle
            foreach (var gorev in GorevListesi)
            {
                listBoxGorevler.Items.Add(gorev); // Görevleri ekle
            }
        }

        public void GorevEkle(string gorev)
        {
            listBoxGorevler.Items.Add(gorev);
        }

        private void Temizlik_Load(object sender, EventArgs e)
        {

        }

        public void test()
        {
            if (chkbx_GenelAlanlarinTemizligi.Checked)
            {
                
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
        }

        public void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // ListBox'tan seçilen öğeyi kontrol etme //ListBox.SelectedIndex özelliği, listBoxta seçilen öğenin indeksini (sırasını) döner.
            // Eğer hiçbir öğe seçilmediyse SelectedIndex değeri -1 oluyor. 

            if (listBoxGorevler.SelectedIndex != -1)
            {
                // Seçilen görevi alma
                string secilenGorev = listBoxGorevler.SelectedItem.ToString();

                // Görev listesinden çıkarma
                GorevListesi.Remove(secilenGorev);

                // Güncel listeyi gösterme
                GorevleriListele();

                MessageBox.Show("Görev başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir görev seçin.");
            }
        }
    }
}
