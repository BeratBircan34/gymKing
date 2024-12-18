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
using System.Data.SqlClient;
using gymKing.oto_Baglanti;
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
        SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
        private void frm_vucutAnaliz_Load(object sender, EventArgs e)
        {
            ApplyNumericValidationToTextBoxes();
            //  pt_islemKontrol dnm = new pt_islemKontrol(false);
            btn_metin();
            if(btntemizle.Text == "Belleği Temizle")
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_geciciBellek",baglanti);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_yas.Text = dr[0].ToString();
                    txt_kilo.Text = dr[1].ToString();
                    txt_boy.Text = dr[2].ToString();
                    txt_belcevre.Text = dr[3].ToString();
                    txt_kalcacevre.Text = dr[4].ToString();
                    txt_boyun.Text = dr[5].ToString();
                    lbl_gki.Text = dr[6].ToString();
                    lbl_bmh.Text = dr[7].ToString();
                    lbl_msr.Text = dr[8].ToString();
                    lbl_si.Text = dr[9].ToString();
                    lbl_pi.Text = dr[10].ToString();
                    lbl_ki.Text = dr[11].ToString();
                    lbl_yi.Text = dr[12].ToString();
                    lbl_vkm.Text = dr[13].ToString();
                    lbl_vym.Text = dr[14].ToString();
                    lbl_vke.Text = dr[15].ToString();
                    lbl_ik.Text = dr[16].ToString();
                    lbl_vyo.Text = dr[17].ToString();
                    lbl_belboy.Text = dr[18].ToString();
                    lbl_bko.Text = dr[19].ToString();
                    lbl_belboyun.Text = dr[20].ToString();
                    cmbbx_aktivite.SelectedIndex = int.Parse(dr["aktiviyeSeviyesi"].ToString());
                    chkbox_sadeceKalori.Checked = bool.Parse(dr["sadeceKalori"].ToString());
                    string cinsiyet = dr["cinsiyet"].ToString();
                    if(cinsiyet.ToLower() == "erkek")
                        rd_erkek.Checked = true;
                    else
                        rd_kadin.Checked = true;
                }
                baglanti.Close();
            }
            
        }
        
        private string cinsiyetAl()
        {
            string cinsiyet = "";
            if(rd_erkek.Checked)
                cinsiyet = rd_erkek.Text;
            if(rd_kadin.Checked)
                cinsiyet = rd_kadin.Text.ToLower();
            return cinsiyet;
        }
        private void sonucYerlestir(float suİhtiyaci,float proteinİhtiyaci,float karbonhidratİhtiyaci, float yağİhtiyaci,
            float bazalMetabolizmaHizi, float gunlukKaloriİhtiyaci, float vucutKitleEndeksi, float idealKilo,
            float vucutYagMiktari, float vucutKasMiktari, string metabolikSendromRiski, float vucutYagOrani, float belKalcaOrani,
            float belBoyunOrani,float belBoyOrani)
        {
            lbl_si.Text = suİhtiyaci.ToString("00.00");
            lbl_pi.Text = proteinİhtiyaci.ToString("00.00");
            lbl_yi.Text = yağİhtiyaci.ToString("00.00");
            lbl_ki.Text = karbonhidratİhtiyaci.ToString("00.00");
            lbl_bmh.Text = bazalMetabolizmaHizi.ToString("00.00");
            lbl_gki.Text = gunlukKaloriİhtiyaci.ToString("00.00") ;
            lbl_vke.Text = vucutKitleEndeksi.ToString("00.00");
            lbl_ik.Text = idealKilo.ToString("00.00") ;
            lbl_msr.Text = metabolikSendromRiski;
            if (chkbox_sadeceKalori.Checked == false)
            {
                lbl_vym.Text = vucutYagMiktari.ToString("00.00") ;
                lbl_vkm.Text = vucutKasMiktari.ToString("00.00") ;
                lbl_vyo.Text = vucutYagOrani.ToString("00.00");
                lbl_bko.Text = belKalcaOrani.ToString("00.00");
                lbl_belboyun.Text = belBoyunOrani.ToString("00.00");
                lbl_belboy.Text = belBoyOrani.ToString("00.00");
            }
            

        }
        private void btn_metin()
        {
            if (pt_islemKontrol.islemYapildiMi == true)
            {
                btntemizle.Text = "Belleği Temizle";
            }
            else
            {
                btntemizle.Text = "Kutucukları Temizle";
            }

        }

        private void islemKontrol(bool tf)
        {
            pt_islemKontrol kontrol = new pt_islemKontrol(tf);
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
                        islemKontrol(true);
                        btn_metin();
                        veriYolla();



                    }
                else
                {
                    Pt_analizHesaplama hesapla = new Pt_analizHesaplama(cmbbx_aktivite.SelectedIndex, cinsiyetAl(), int.Parse(txt_yas.Text), float.Parse(txt_kilo.Text), float.Parse(txt_boy.Text), 0, 0, 0);
                    sonucYerlestir(hesapla.suIhtiyacı, hesapla.proteinIhtıyacı, hesapla.karbIhtiyacı, hesapla.yagIhtıyacı, hesapla.bazalMetabolizmaHizi,
                        hesapla.gunlukKaloriIhtiyacı, hesapla.vucutKitleEndeksi, hesapla.idealKilo, hesapla.vucutYagMiktari, hesapla.vucutKasMiktari, hesapla.metabolikSendromRiski,
                        hesapla.vucutYagOrani, hesapla.belKalcaOrani, hesapla.belBoyunOrani, hesapla.belBoyOrani_);
                        islemKontrol(true);
                        btn_metin();
                        veriYolla();
                    }
                }
                catch(Exception ex) {     
                    MessageBox.Show("Lütfen Tüm Kutucukları Doldurunuz!","Eksik Veri",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(ex.Message);
                }
            }
          
            }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cinsiyetAl());
        }

        private void veriYolla()
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand(
                "UPDATE tbl_gecicibellek " +
                "SET yas = @pyas, kilo = @pkilo, boy = @boy, bel = @bel, kalca = @kalca, boyun = @boyun, gki = @gki, bmh = @bmh, msr = @msr, si = @si, pi = @pi, ki = @ki, yi = @yi, vkm = @vkm, vym = @vym, vki = @vki, ik = @ik ," +
                "vyo = @vyo ,bbo = @bbo , bko = @bko , bboyun = @bboyun ,cinsiyet = @cins, aktiviyeSeviyesi = @p1,sadeceKalori = @p2" ,baglanti
            );
            kmt.Parameters.AddWithValue("@pyas", txt_yas.Text);
            kmt.Parameters.AddWithValue("@pkilo",txt_kilo.Text);
            kmt.Parameters.AddWithValue("@boy",txt_boy.Text);
            kmt.Parameters.AddWithValue("@bel",txt_belcevre.Text);
            kmt.Parameters.AddWithValue("@kalca",txt_kalcacevre.Text);
            kmt.Parameters.AddWithValue("@boyun",txt_boyun.Text);
            kmt.Parameters.AddWithValue("@gki",lbl_gki.Text);
            kmt.Parameters.AddWithValue("@bmh", lbl_bmh.Text);
            kmt.Parameters.AddWithValue("@msr",lbl_msr.Text);
            kmt.Parameters.AddWithValue("@si",lbl_si.Text);
            kmt.Parameters.AddWithValue("@pi",lbl_pi.Text);
            kmt.Parameters.AddWithValue("@ki",lbl_ki.Text);
            kmt.Parameters.AddWithValue("@yi",lbl_yi.Text);
            kmt.Parameters.AddWithValue("@vkm",lbl_vkm.Text);
            kmt.Parameters.AddWithValue("@vym",lbl_vym.Text);
            kmt.Parameters.AddWithValue("@vki",lbl_vke.Text);
            kmt.Parameters.AddWithValue("@ik",lbl_ik.Text);
            kmt.Parameters.AddWithValue("@vyo",lbl_vyo.Text);
            kmt.Parameters.AddWithValue("@bbo",lbl_belboy.Text);
            kmt.Parameters.AddWithValue("@bko",lbl_bko.Text);
            kmt.Parameters.AddWithValue("@bboyun",lbl_belboyun.Text);
            kmt.Parameters.AddWithValue("@cins", cinsiyetAl() );
            kmt.Parameters.AddWithValue("@p1", cmbbx_aktivite.SelectedIndex);
            kmt.Parameters.AddWithValue("@p2", chkbox_sadeceKalori.Checked);
            kmt.ExecuteNonQuery();

            baglanti.Close();
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
        
        islemKontrol(false);
        if(btntemizle.Text == "Belleği Temizle")
            {
                btntemizle.Text = "Kutucukları Temizle";
                
            }
            cmbbx_aktivite.SelectedIndex = -1;
            rd_erkek.Checked = false;
            rd_kadin.Checked = false;
            txt_yas.Text = string.Empty;
            txt_kilo.Text = string.Empty;
            txt_kalcacevre.Text = string.Empty;
            txt_boyun.Text = string.Empty;
            txt_boy.Text = string.Empty;
            txt_belcevre.Text = string.Empty; ;
            chkbox_sadeceKalori.Checked = false;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form mdiParent = this.MdiParent;
            mdiParent.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
    }
    }

