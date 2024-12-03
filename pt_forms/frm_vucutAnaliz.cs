using gymKing.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymKing.pt_forms
{
    public partial class frm_vucutAnaliz : Form
    {
        public frm_vucutAnaliz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer tuşa basılan karakter rakam değilse, o zaman işlemi engelle
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // 8, geri silme (Backspace) tuşu
            {
                e.Handled = true; // Harf veya geçersiz karakter basıldığında işlemi durdur
            }
        }
        private void ApplyNumericValidationToTextBoxes()
        {
            // GroupBox içindeki tüm TextBox'ları kontrol et
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    // KeyPress olayına metodu bağla
                    ((TextBox)control).KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
                }
            }
        }

       
        private void frm_vucutAnaliz_Load(object sender, EventArgs e)
        {
            ApplyNumericValidationToTextBoxes();
        }
        
        private string cinsiyetAl()
        {
            string cinsiyet = "";
            if(rd_erkek.Checked)
                cinsiyet = rd_erkek.Text;
            if(rd_kadin.Checked)
                cinsiyet = rd_kadin.Text;
            return cinsiyet;
        }
        private void sonucYerlestir(float suİhtiyaci,float proteinİhtiyaci,float karbonhidratİhtiyaci, float yağİhtiyaci,
            float bazalMetabolizmaHizi, float gunlukKaloriİhtiyaci, float vucutKitleEndeksi, float idealKilo,
            float vucutYagMiktari, float vucutKasMiktari, string metabolikSendromRiski, float vucutYagOrani, float belKalcaOrani,
            float belBoyunOrani,float belBoyOrani)
        {
            lbl_si.Text = suİhtiyaci.ToString("00.00")+" Litre/Gün";
            lbl_pi.Text = proteinİhtiyaci.ToString("00.00")+" Gram/Gün";
            lbl_yi.Text = yağİhtiyaci.ToString("00.00")+" Gram/Gün";
            lbl_ki.Text = karbonhidratİhtiyaci.ToString("00.00")+" Gram/Gün";
            lbl_bmh.Text = bazalMetabolizmaHizi.ToString("00.00") + " Kalori";
            lbl_gki.Text = gunlukKaloriİhtiyaci.ToString("00.00") + " Kalori/Gün";
            lbl_vke.Text = vucutKitleEndeksi.ToString("00.00");
            lbl_ik.Text = idealKilo.ToString("00.00") + " KG";
            lbl_msr.Text = metabolikSendromRiski;
            if (chkbox_sadeceKalori.Checked == false)
            {
                lbl_vym.Text = vucutYagMiktari.ToString("00.00") + " KG";
                lbl_vkm.Text = vucutKasMiktari.ToString("00.00") + " KG";
                lbl_vyo.Text = "% " + vucutYagOrani.ToString("00.00");
                lbl_bko.Text = belKalcaOrani.ToString("00.00");
                lbl_belboyun.Text = belBoyunOrani.ToString("00.00");
                lbl_belboy.Text = belBoyOrani.ToString("00.00");
            }
            

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(hataKontrol() == true)
            {
                MessageBox.Show("Aktivite Seviyesi ve Cinsiyet Mutlaka Girilmelidir!!", "Eksik Veri Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try { 
                if (chkbox_sadeceKalori.Checked == false)
                {

                    Pt_analizHesaplama hesapla = new Pt_analizHesaplama(cmbbx_aktivite.SelectedIndex, cinsiyetAl(), int.Parse(txt_yas.Text), float.Parse(txt_kilo.Text), float.Parse(txt_boy.Text), float.Parse(txt_belcevre.Text), float.Parse(txt_boyun.Text), float.Parse(txt_kalcacevre.Text));
                    sonucYerlestir(hesapla.suIhtiyacı, hesapla.proteinIhtıyacı, hesapla.karbIhtiyacı, hesapla.yagIhtıyacı, hesapla.bazalMetabolizmaHizi,
                        hesapla.gunlukKaloriIhtiyacı, hesapla.vucutKitleEndeksi, hesapla.idealKilo, hesapla.vucutYagMiktari, hesapla.vucutKasMiktari, hesapla.metabolikSendromRiski,
                        hesapla.vucutYagOrani, hesapla.belKalcaOrani, hesapla.belBoyunOrani, hesapla.belBoyOrani_);

                }
                else
                {
                    Pt_analizHesaplama hesapla = new Pt_analizHesaplama(cmbbx_aktivite.SelectedIndex, cinsiyetAl(), int.Parse(txt_yas.Text), float.Parse(txt_kilo.Text), float.Parse(txt_boy.Text), 0, 0, 0);
                    sonucYerlestir(hesapla.suIhtiyacı, hesapla.proteinIhtıyacı, hesapla.karbIhtiyacı, hesapla.yagIhtıyacı, hesapla.bazalMetabolizmaHizi,
                        hesapla.gunlukKaloriIhtiyacı, hesapla.vucutKitleEndeksi, hesapla.idealKilo, hesapla.vucutYagMiktari, hesapla.vucutKasMiktari, hesapla.metabolikSendromRiski,
                        hesapla.vucutYagOrani, hesapla.belKalcaOrani, hesapla.belBoyunOrani, hesapla.belBoyOrani_);
                }
                }
                catch {     
                    MessageBox.Show("Lütfen Tüm Kutucukları Doldurunuz!","Eksik Veri",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }              
            }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cinsiyetAl());
        }

        
        private bool hataKontrol()
        {
            bool hata = false;
            if(rd_erkek.Checked == false && rd_kadin.Checked == false)
            {
                hata = true;
            }
            else if(cmbbx_aktivite.Text == ""){
                hata = true;
            }
            return hata;
        }
        private void chkbox_sadeceKalori_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbox_sadeceKalori.Checked)
            {
                txt_belcevre.Enabled = false;
                txt_kalcacevre.Enabled = false;
                txt_boyun.Enabled = false;
                lbl_belboy.Text = "PASİF";
                lbl_belboyun.Text = "PASİF";
                lbl_bko.Text = "PASİF";
                lbl_vyo.Text = "PASİF";
                lbl_vym.Text = "PASİF";
                lbl_vkm.Text = "PASİF";
            }
            else
            {
                txt_belcevre.Enabled = true;
                txt_kalcacevre.Enabled = true;
                txt_boyun.Enabled = true;
                lbl_belboy.Text = "Hesaplanmadı";
                lbl_belboyun.Text = "Hesaplanmadı";
                lbl_bko.Text = "Hesaplanmadı";
                lbl_vyo.Text = "Hesaplanmadı";
                lbl_vym.Text = "Hesaplanmadı";
                lbl_vkm.Text = "Hesaplanmadı";
            }
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

        }
    }
    }

