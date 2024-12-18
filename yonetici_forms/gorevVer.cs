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

            // SqlConnection nesnesini sqlOtoBaglanti.sqlBaglantiDize() ile oluşturun
            using (SqlConnection connection = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                // SQL sorgusu
                string query = "SELECT * FROM tbl_temizlik";

                // SqlDataAdapter nesnesi oluşturun
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // DataTable oluşturun
                DataTable dataTable = new DataTable();

                try
                {
                    // Veriyi DataTable'a doldurun
                    dataAdapter.Fill(dataTable);

                    // DataTable'ı DataGridView'e bağlayın
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
   

        private void txtGorev_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Uygulamadan çıkış yapmak istiyor musunuz?",
              "Çıkış Onayı",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            // Kullanıcı "Evet" derse uygulamayı kapat
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu küçült
        }
    }
}
