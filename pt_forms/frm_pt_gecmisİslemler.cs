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
using  System.Windows.Forms.VisualStyles;

namespace gymKing.pt_forms
{
    public partial class frm_pt_gecmisİslemler : Form
    {
        public frm_pt_gecmisİslemler()
        {
            InitializeComponent();
        }

        private void frm_pt_gecmisİslemler_Load(object sender, EventArgs e)
        {
            //imer1.Start();
            chkbx_all.Checked = true;
            cmbbx_isim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbx_soyisim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbx_egitmen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbx_soyisim.Enabled = false;
            bilgiGetir("isim");
            bilgiGetir("soyisim");
            bilgiGetir("eğitmen");
        }
        //SQL CİNSİYET EKLENECEK
        //YENİ FİLTRELER AYARLANACAK
        List<string> degerler = new List<string>();
        private void filtreleVeGetir()
        {
            try
            {
                string arakomut = "ad as 'İsim', soyad as 'Soyisim'  ";

                //Değer Filtreleri
                if (degerler.Count >= 1)
                    arakomut += " ,";
                foreach (string a in degerler)
                {

                    if (degerler.IndexOf(a) == degerler.Count - 1)
                        arakomut += a + " ";
                    
                    else
                        arakomut += a + " ,";
                }

                string komut = $"select {arakomut} from tbl_gecmis_islemler";
                //  Kişi Filtreleri
                if (chkbx_cinsiyet_k.Checked)
                {
                    komut += " where k_cinsiyet != 'erkek' ";
                }
                if (chkbx_cinsiyet_e.Checked)
                {
                    komut += " where k_cinsiyet = 'erkek'  ";
                }
                if(cmbbx_islemTuru.Text != "")
                {
                    if (chkbx_cinsiyet_e.Checked || chkbx_cinsiyet_k.Checked)
                        komut += ($" and islem_turu = '{cmbbx_islemTuru.Text}'");
                    else
                        komut += ($" where islem_turu = '{cmbbx_islemTuru.Text}'");
                }

                if (chkbx_isimSira_az.Checked || chkbx_isimSira_za.Checked || chkbx_islemTarihi_ey.Checked || chkbx_islemTarihi_ye.Checked)
                {
                    komut += " order by";
                    if (chkbx_isimSira_az.Checked)
                        komut += " ad asc";
                    if (chkbx_isimSira_za.Checked)
                        komut += " ad desc";
                    if (chkbx_isimSira_az.Checked == false && chkbx_isimSira_za.Checked == false)
                    {
                        if (chkbx_islemTarihi_ey.Checked)
                            komut += " islem_tarihi asc";
                        if (chkbx_islemTarihi_ye.Checked)
                            komut += " islem_tarihi desc";
                    }
                    else
                    {
                        if (chkbx_islemTarihi_ey.Checked)
                            komut += ", islem_tarihi asc";
                        if (chkbx_islemTarihi_ye.Checked)
                            komut += ", islem_tarihi desc";
                    }

                }

                if (cmbbx_isim.Text != "")
                {
                    komut += $" where ad = '{cmbbx_isim.Text}' ";
                }
                if (cmbbx_soyisim.Text != "")
                {
                    if (cmbbx_isim.Text != "")
                        komut += $"and soyad = '{cmbbx_soyisim.Text}'";
                    else
                        komut += $"where soyad = '{cmbbx_soyisim.Text}'";

                }
                if (cmbbx_egitmen.Text != "")
                {
                    if (cmbbx_isim.Text == "" && cmbbx_soyisim.Text == "")
                        komut += $" where egitmen = '{cmbbx_egitmen.Text}'";
                    else if (cmbbx_isim.Text != "")
                    {
                        komut += $"and egitmen = '{cmbbx_egitmen.Text}' ";
                    }


                }
                SqlConnection cnt = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
                cnt.Open();
                SqlDataAdapter da = new SqlDataAdapter(komut, cnt);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu : "+ex, "Filtre girilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void bilgiGetir(string islem)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            switch (islem)
            {
                case "isim":
                    SqlCommand cmd = new SqlCommand("select distinct ad from tbl_gecmis_islemler ", baglanti);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cmbbx_isim.Items.Add(dr["ad"].ToString());
                    }
                    break;
                case "soyisim":
                    SqlCommand sql = new SqlCommand("select distinct soyad from tbl_gecmis_islemler where ad = @p1 ", baglanti);
                    sql.Parameters.AddWithValue("@p1", cmbbx_isim.Text);
                    SqlDataReader dr2 = sql.ExecuteReader();
                    while (dr2.Read())
                    {
                        cmbbx_soyisim.Items.Add(dr2["soyad"].ToString());
                    }
                    break;
                case "eğitmen":
                    SqlCommand cmd2 = new SqlCommand("select distinct egitmen from tbl_gecmis_islemler ", baglanti);
                    SqlDataReader dr3 = cmd2.ExecuteReader();
                    while (dr3.Read())
                    {
                        cmbbx_egitmen.Items.Add(dr3["egitmen"].ToString());
                    }
                    break;

            }

        }
        private void cmbbx_temizle()
        {
            cmbbx_isim.SelectedIndex = -1;
            cmbbx_soyisim.SelectedIndex = -1;
            cmbbx_egitmen.SelectedIndex = -1;
        }
        private void CheckGroupBox1CheckBoxes()
        {
            // GroupBox1 içindeki CheckBox'ların kontrolü
            foreach (Control control in groupBox1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    if(cmbbx_islemTuru.Text != ""){
                        groupBox2.Enabled = false; // Eğer bir CheckBox tikliyse, GroupBox2 devre dışı
                        cmbbx_isim.SelectedIndex = -1;
                        cmbbx_egitmen.SelectedIndex = -1;
                        cmbbx_soyisim.SelectedIndex = -1 ;
                        return; // Şarta uyulmuşsa döngüyü bitir
                    }
                   
                }
            }
            // Eğer hiçbiri tikli değilse GroupBox2 aktif
            groupBox2.Enabled = true;
        }

        private void CheckGroupBox2ComboBox()
        {
            foreach (Control control in groupBox2.Controls)
            {
                if (control is ComboBox cmbbx && !string.IsNullOrWhiteSpace(cmbbx.Text))
                {
                    groupBox1.Enabled = false; // Eğer bir CheckBox tikliyse, GroupBox2 devre dışı
                    cmbbx_islemTuru.SelectedIndex = -1;
                   
                    return; // Şarta uyulmuşsa döngüyü bitir
                }
            }
            // Eğer hiçbiri tikli değilse GroupBox2 aktif
            groupBox1.Enabled = true;

        }
        private void chkbx_isimSira_az_CheckedChanged(object sender, EventArgs e)
        {

        }

        /* private void frm_pt_guncelKayitlar_Load(object sender, EventArgs e)
         {
             chkbx_all.Checked = true;
             cmbbx_isim.DropDownStyle = ComboBoxStyle.DropDownList;
             cmbbx_soyisim.DropDownStyle = ComboBoxStyle.DropDownList;
             cmbbx_egitmen.DropDownStyle = ComboBoxStyle.DropDownList;
             cmbbx_soyisim.Enabled = false;
             bilgiGetir("isim");
             bilgiGetir("soyisim");
             bilgiGetir("eğitmen");

         }*/

        private void cmbbx_soyisim_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckGroupBox2ComboBox();
        }


        //DEĞERLER İÇİN!
        private void chkbx_si_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkbx_pi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_pi.Checked)
                degerler.Add("pi as 'Günlük Protein İhtiyacı'");
            else
                degerler.Remove("pi as 'Günlük Protein İhtiyacı'");
        }

        private void chkbx_msr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_msr.Checked)
                degerler.Add("msr as 'Metabolik Sendrom Riski'");
            else
                degerler.Remove("msr as 'Metabolik Sendrom Riski'");
        }


        private void chkbx_ik_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_ik.Checked)
                degerler.Add("ik as 'İdeal Kilo (KG)'");
            else
                degerler.Remove("ik as 'İdeal Kilo (KG)'");
        }

        private void degerCheckboxlariniAyarla(GroupBox grp)
        {
            foreach (Control control in grp.Controls)
            {
                if (control is CheckBox chk)
                {
                    // Eğer checkbox işaretli değilse, işaretle
                    if (!chk.Checked)
                    {
                        chk.Checked = true;
                    }
                    // Eğer checkbox işaretli ise, işaretini kaldır
                    else
                    {
                        chk.Checked = false;
                    }
                }
            }
        }
        private void degerCheckboxlariniAyarla(GroupBox grp, GroupBox grp2, GroupBox grp3)
        {
            List<GroupBox> grpbxs = new List<GroupBox> { grp, grp2, grp3 };

            foreach (GroupBox groupBox in grpbxs)
            {
                foreach (Control control in groupBox.Controls)
                {
                    if (control is CheckBox chk)
                    {
                        // Eğer checkbox işaretli değilse, işaretle
                        chk.Checked = !chk.Checked; // Mevcut durumu tersine çevir
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            //degerler.Clear();
            filtreleVeGetir();
            cmbbx_temizle();
            //COMBOBOX İÇİ TEMİZLENECEK +
            //CHECKBOXLAR TEMİZLENECEK +
            //DENEME AMAÇLI YENİ VERİLERLE TEST EDİLECEK!
            //İSTENEN VERİ FİLTRESİ EKLENECEK
        }

        private void chkbx_all_CheckedChanged_1(object sender, EventArgs e)
        {
            degerCheckboxlariniAyarla(grpbx_makrolar, grpbx_hesasplananDegerler, grobx_vucutBilgileri);
        }

        private void chkbx_tum_hesaplananlar_CheckedChanged_1(object sender, EventArgs e)
        {
            degerCheckboxlariniAyarla(grpbx_hesasplananDegerler);
        }

        private void chkbx_tum_vucut_CheckedChanged_1(object sender, EventArgs e)
        {
            degerCheckboxlariniAyarla(grobx_vucutBilgileri);
        }

        private void chkbx_tum_makrolar_CheckedChanged_1(object sender, EventArgs e)
        {
            degerCheckboxlariniAyarla(grpbx_makrolar);
        }

        private void chkbx_isimSira_az_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_isimSira_za.Checked)
            {
                chkbx_isimSira_za.Checked = false;
                chkbx_isimSira_az.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");

            }
        }

        private void chkbx_isimSira_za_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_isimSira_az.Checked)
            {
                chkbx_isimSira_az.Checked = false;
                chkbx_isimSira_za.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");
            }
        }

        private void chkbx_cinsiyet_e_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_cinsiyet_k.Checked)
            {
                chkbx_cinsiyet_e.Checked = false;
                chkbx_cinsiyet_k.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");

            }
        }

        private void chkbx_cinsiyet_k_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_cinsiyet_e.Checked)
            {
                chkbx_cinsiyet_e.Checked = false;
                chkbx_cinsiyet_k.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");

            }
        }

        private void chkbx_islemTarihi_ey_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_islemTarihi_ye.Checked)
            {
                chkbx_islemTarihi_ey.Checked = false;
                chkbx_islemTarihi_ye.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");
            }
        }

        private void chkbx_islemTarihi_ye_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox1CheckBoxes();
            if (chkbx_islemTarihi_ey.Checked)
            {
                chkbx_islemTarihi_ey.Checked = false;
                chkbx_islemTarihi_ye.Checked = false;
                MessageBox.Show("Aynı tür filtreden iki tane seçilemez!");
            }
        }

        void setCheckedFalse()
        {
            cmbbx_soyisim.Enabled = true;
            chkbx_isimSira_az.Checked = false;
            chkbx_isimSira_za.Checked = false;
            chkbx_cinsiyet_e.Checked = false;
            chkbx_cinsiyet_k.Checked = false;
            chkbx_islemTarihi_ye.Checked = false;
            chkbx_islemTarihi_ey.Checked = false;
            cmbbx_islemTuru.SelectedIndex = -1;

        }
        private void cmbbx_isim_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox2ComboBox();
            if (cmbbx_isim.Text == "")
                cmbbx_soyisim.Enabled = false;
            else
            {
                setCheckedFalse();
                bilgiGetir("soyisim");
            }
        }

        private void cmbbx_soyisim_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox2ComboBox();
        }

        private void cmbbx_egitmen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckGroupBox2ComboBox();
            setCheckedFalse();
        }

        private void chkbx_si_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_si.Checked)
                degerler.Add("si as 'Günlük Su İhtiyacı'");
            else
                degerler.Remove("si as 'Günlük Su İhtiyacı'");
        }

        private void chkbx_pi_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_pi.Checked)
                degerler.Add("pi as 'Günlük Protein İhtiyacı'");
            else
                degerler.Remove("pi as 'Günlük Protein İhtiyacı'");
        }

        private void chkbx_msr_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_msr.Checked)
                degerler.Add("msr as 'Metabolik Sendrom Riski'");
            else
                degerler.Remove("msr as 'Metabolik Sendrom Riski'");
        }

        private void chkbx_ki_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_ki.Checked)
                degerler.Add("ki as 'Günlük Karbonhidrat İhtiyacı'");
            else
                degerler.Remove("ki as 'Günlük Karbonhidrat İhtiyacı'");
        }

        private void chkbx_gki_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_gki.Checked)
                degerler.Add("gki as 'Günlük Kalori İhtiyacı'");
            else
                degerler.Remove("gki as 'Günlük Kalori İhtiyacı'");
        }

        private void chkbx_bmh_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_bmh.Checked)
                degerler.Add("bmh as 'Bazal Metabolizma Hızı'");
            else
                degerler.Remove("bmh as 'Bazal Metabolizma Hızı'");
        }

        private void chkbx_yi_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_yi.Checked)
                degerler.Add("yi as 'Günlük Yağ İhtiyacı'");
            else
                degerler.Remove("yi as 'Günlük Yağ İhtiyacı'");
        }

        private void chkbx_kilo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_kilo.Checked)
                degerler.Add("kilo as 'Kilo(KG)'");
            else
                degerler.Remove("kilo as 'Kilo(KG)'");
        }

        private void chkbx_boy_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_boy.Checked)
                degerler.Add("boy as 'Boy(CM)'");
            else
                degerler.Remove("boy as 'Boy(CM)'");
        }

        private void chkbx_yas_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_yas.Checked)
                degerler.Add("yas as 'Yaş'");
            else
                degerler.Remove("yas as 'Yaş'");
        }

        private void chkbx_bel_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_bel.Checked)
                degerler.Add("bel as 'Bel Çevresi(CM)'");
            else
                degerler.Remove("bel as 'Bel Çevresi(CM)'");
        }

        private void chkbx_boyun_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_boyun.Checked)
                degerler.Add("boyun as 'Boyun Çevresi(CM)'");
            else
                degerler.Remove("boyun as 'Boyun Çevresi(CM)'");
        }

        private void chkbx_kalca_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_kalca.Checked)
                degerler.Add("kalca as 'Kalça Çevresi(CM)'");
            else
                degerler.Remove("kalca as 'Kalça Çevresi(CM)'");
        }

        private void chkbx_vki_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_vki.Checked)
                degerler.Add("vki as 'Vücut Kitle Endeksi'");
            else
                degerler.Remove("vki as 'Vücut Kitle Endeksi'");
        }

        private void chkbx_bko_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_bko.Checked)
                degerler.Add("bko as 'Bel Kalça Oranı'");
            else
                degerler.Remove("bko as 'Bel Kalça Oranı'");
        }

        private void chkbx_vym_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_vym.Checked)
                degerler.Add("vym as 'Vücut Yağ Miktarı'");
            else
                degerler.Remove("vym as 'Vücut Yağ Miktarı'");
        }

        private void chkbx_vyo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_vyo.Checked)
                degerler.Add("vyo as 'Vücut Yağ Oranı (%)'");
            else
                degerler.Remove("vyo as 'Vücut Yağ Oranı (%)'");
        }

        private void chkbx_bbo_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_si.Checked)
                degerler.Add("bbo as 'Bel Boy Oranı'");
            else
                degerler.Remove("bbo as 'Bel Boy Oranı'");
        }

        private void chkbx_bboyun_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_bboyun.Checked)
                degerler.Add("bboyun as 'Bel Boyun Oranı'");
            else
                degerler.Remove("bboyun as 'Bel Boyun Oranı'");
        }

        private void chkbx_ik_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkbx_ik.Checked)
                degerler.Add("ik as 'İdeal Kilo (KG)'");
            else
                degerler.Remove("ik as 'İdeal Kilo (KG)'");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_islemGunu.Checked)
                degerler.Add("islem_gunu as 'İşlem Yapılan Gün'");           
            else
                degerler.Remove("islem_gunu as 'İşlem Yapılan Gün'");
        }

        private void chkbx_islemSaati_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_islemSaati.Checked)           
                degerler.Add("islem_saati as 'İşlemin Yapıldığı Saat'");  
            else
                degerler.Remove("islem_saati as 'İşlemin Yapıldığı Saat'");
        }

        private void chkbx_islemTarihi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_islemTarihi.Checked)
                degerler.Add("islem_tarihi as 'İşlemin Yapıldığı Tarih'");
            else
                degerler.Remove("islem_tarihi as 'İslemin Yapıldığı Tarih'");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == false)
                cmbbx_islemTuru.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == false)
                cmbbx_islemTuru.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chkbx_all.Checked = false;
            cmbbx_islemTuru.SelectedIndex = -1;
            cmbbx_isim.SelectedIndex = -1;
            cmbbx_soyisim.SelectedIndex = -1;
            cmbbx_egitmen.SelectedIndex = -1;
            chkbx_isimSira_za.Checked = false;
            chkbx_isimSira_az.Checked = false;
            chkbx_islemTarihi_ey.Checked = false;
            chkbx_islemTarihi_ye.Checked = false;
            chkbx_cinsiyet_e.Checked = false;
            chkbx_cinsiyet_k.Checked = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {

            pictureBox7.BackColor = Color.IndianRed;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
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

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.SkyBlue;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.Gainsboro;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Gainsboro;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form a = this.MdiParent;
            a.WindowState = FormWindowState.Minimized;
        }
    }
}



