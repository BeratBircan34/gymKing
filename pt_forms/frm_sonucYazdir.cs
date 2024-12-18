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
    public partial class frm_sonucYazdir : Form
    {
        public frm_sonucYazdir()
        {
            InitializeComponent();
        }

        private void frm_sonucYazdir_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select ad as 'İsim',soyad as 'Soyisim',k_cinsiyet as 'Cinsiyet',egitmen as 'Eğitmen',tarih as 'İşlem Tarihi' from tbl_guncelKayitlar", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_kisiler.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection con = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
        private void vucutBilgileriniGonder(string ad, string soyad)
        {
            
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"SELECT kilo, bel, boyun, kalca, boy FROM tbl_guncelKayitlar WHERE LTRIM(RTRIM(ad)) = '{ad.Trim()}' AND LTRIM(RTRIM(soyad)) = '{soyad.Trim()}'", con);

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dgv_vucut.DataSource = dataTable;
            con.Close();
        }

        private void makroGonder(string ad,string soyad)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select si as 'Su İhtiyacı',pi as 'Protein İhtiyacı',ki as 'Karbonhidrat İhtiyacı',yi as 'Yağ İhtiyacı',bazalMetabolizma as 'Bazal Metabolizma Hızı',gunlukKalori as 'Günlük Kalori İhtiyacı' from tbl_guncelKayitlar where ad = '{ad}' and soyad = '{soyad}' ", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dgv_makro.DataSource = dataTable;
            con.Close();
        }

        private void oranlar(string ad,string soyad)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select vyo as 'Vücut Yağ Oranı',bko as 'Bel Kalça Oranı',bboy as 'Bel-Boy Oranı',bboyun as 'Bel-Boyun Oranı' from  tbl_guncelKayitlar where ad = '{ad}' and soyad = '{soyad}' ", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dgv_oranlar.DataSource = dataTable;
            con.Close();
        }

        private void hesaplamalar(string ad,string soyad)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select vki as 'Vücut Kitle Endeksi',vym as 'Vücut Yağ Miktarı',ik as 'İdeal Kilo',metabolikSRisk as 'Metabolik Sendrom Riski' from tbl_guncelKayitlar where ad = '{ad}' and soyad = '{soyad}' ", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dgv_hesaplamalar.DataSource = dataTable;
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Başlık satırına tıklamayı önlemek için
            {
                // DataGridView'deki seçilen hücreden adı ve soyadı al
                string ad = dgv_kisiler.Rows[e.RowIndex].Cells["İsim"].Value.ToString();
                string soyad = dgv_kisiler.Rows[e.RowIndex].Cells["Soyisim"].Value.ToString();



                // Veritabanından bilgileri çekmek için metodu çağır
                richtxt_yorumlama.Clear();
                vucutBilgileriniGonder(ad, soyad);
                makroGonder(ad, soyad);
                makroYorumla(ad, soyad);
                oranlar(ad, soyad);
                hesaplamalar(ad, soyad);
                oranlarıYorumla(ad, soyad);
                hesaplamalarıYorumla(ad, soyad);
            }
        }
        private void makroYorumla(string ad,string soyad)
        {
            con.Open ();
            SqlCommand cmd = new SqlCommand($"SELECT si, pi, ki, yi , bazalMetabolizma, gunlukKalori  FROM tbl_guncelKayitlar WHERE ad = '{ad}' AND soyad = '{soyad}'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["bazalMetabolizma"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bazal Metabolizma Hızınız {dr["bazalMetabolizma"]} Kalori/Günde'dir. " +
                        $"Vücudunuzun hayati fonksiyonlarını ideal şekilde gerçekleştirmesi için gerekli miktardır.\n" +
                        $"Bu miktardan az almanız gündelik hayatınızı kötü etkiler.\n\n");
                }

                if (dr["gunlukKalori"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Günlük Kalori İhtiyacınız {dr["gunlukKalori"]} Kaloridir. " +
                        $"Bu miktar Bazal Metabolizma Hızınız ve günlük aktivite seviyenize göre hesaplanır. " +
                        $"Bu miktardan yukarı kalori almanız kilo almanıza, daha az almanız kilo vermenize yarar.\n\n");
                }

                if (dr["si"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Günlük su ihtiyacınız {dr["si"]} litre'dir. Bu miktardan az su içmemeye özen gösterin.\n\n");
                }

                if (dr["pi"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Günlük protein ihtiyacınız {dr["pi"]} gramdır. " +
                        $"Bu miktar vücudunuzun anabolik yapısına katkıda bulunacak en ideal miktardır. " +
                        $"İmkanınız el veriyorsa fazlasını alabilirsiniz ancak altına inmemeye özen gösterin.\n\n");
                }

                if (dr["ki"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Günlük Karbonhidrat ihtiyacınız {dr["ki"]} gramdır. " +
                        $"Glikojen depolarınızın dolmasına yardımcı olur.\n\n");
                }

                if (dr["yi"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Günlük yağ ihtiyacınız {dr["yi"]} gramdır. " +
                        $"Hormonal fonksiyonlarınız ve günlük yaşamınız için en ideal miktardır. " +
                        $"Daha fazla almanız yağlanmanıza, daha az almanız hormonal denge bozukluğuna neden olabilir.\n\n");
                }

            }
            con.Close ();
        }
        private void oranlarıYorumla(string ad,string soyad)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT vyo, bko, bboy, bboyun FROM tbl_guncelKayitlar WHERE ad = '{ad}' AND soyad = '{soyad}'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) // Veritabanındaki sonuçları okuyor
            {
                if (dr["vyo"] != DBNull.Value)
                {
                    double vyo = Convert.ToDouble(dr["vyo"]);
                    richtxt_yorumlama.AppendText(
                        $"Vücut Yağ Oranınız %{vyo} olarak hesaplanmıştır. " +
                        $"Bu oran, vücudunuzdaki yağ dokusunun toplam vücut ağırlığınıza oranını temsil eder. " +
                        $"İdeal bir yağ oranı, sağlıklı bir metabolizma ve hormonal denge için önemlidir. ");

                    // Kullanıcının yağ oranına göre yorum yap
                    if (vyo < 15)
                        richtxt_yorumlama.AppendText("Yağ oranınız oldukça düşük. Kas kütlenizi artırmaya odaklanabilirsiniz.\n\n");
                    else if (vyo >= 15 && vyo <= 25)
                        richtxt_yorumlama.AppendText("Yağ oranınız ideal aralıkta. Mevcut sağlıklı yaşam tarzınızı sürdürmeye devam edin.\n\n");
                    else
                        richtxt_yorumlama.AppendText("Yağ oranınız yüksek seviyede. Egzersiz ve beslenme düzeninizi gözden geçirmelisiniz.\n\n");
                }

                if (dr["bko"] != DBNull.Value)
                {
                    double bko = Convert.ToDouble(dr["bko"]);
                    richtxt_yorumlama.AppendText(
                        $"Bel-Kalça Oranınız {bko} olarak hesaplanmıştır. " +
                        $"Bu oran, özellikle kardiyovasküler hastalık riski için önemli bir göstergedir. ");

                    // Kullanıcının bel-kalça oranına göre yorum yap
                    if (bko < 0.85)
                        richtxt_yorumlama.AppendText("Oranınız sağlıklı kabul edilmektedir.\n\n");
                    else if (bko >= 0.85 && bko < 1.0)
                        richtxt_yorumlama.AppendText("Oranınız hafifçe yüksek. Yağlanmayı azaltmaya odaklanabilirsiniz.\n\n");
                    else
                        richtxt_yorumlama.AppendText("Oranınız yüksek seviyede. Özellikle bel bölgesindeki yağlanmayı azaltmanız gerekiyor.\n\n");
                }

                if (dr["bboy"] != DBNull.Value)
                {
                    double bboy = Convert.ToDouble(dr["bboy"]);
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boy Oranınız {bboy} olarak hesaplanmıştır. " +
                        $"Bu oran, karın bölgesindeki yağlanmayı ve genel sağlık risklerini değerlendirmenize yardımcı olur. ");

                    // Kullanıcının bel-boy oranına göre yorum yap
                    if (bboy < 0.50)
                        richtxt_yorumlama.AppendText("Oranınız sağlıklı bir aralıkta.\n\n");
                    else
                        richtxt_yorumlama.AppendText("Oranınız yüksek. Fiziksel aktivite ve diyet ile bu oranı iyileştirmeye çalışmalısınız.\n\n");
                }

                if (dr["bboyun"] != DBNull.Value)
                {
                    double bboyun = Convert.ToDouble(dr["bboyun"]);
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boyun Oranınız {bboyun} olarak hesaplanmıştır. " +
                        $"Bu ölçüm, özellikle obezite riskini değerlendirmek için kullanılan bir yöntemdir. ");

                    // Kullanıcının bel-boyun oranına göre yorum yap
                    if (bboyun < 0.40)
                        richtxt_yorumlama.AppendText("Oranınız ideal aralıkta. Sağlıklı yaşam tarzınızı koruyun.\n\n");
                    else
                        richtxt_yorumlama.AppendText("Oranınız yüksek. Egzersiz ve kilo kontrolüne odaklanmalısınız.\n\n");
                }

            }
            con.Close();

        }
        private void hesaplamalarıYorumla(string ad, string soyad)
        {
            string query = "SELECT vki AS 'Vücut Kitle Endeksi', vym AS 'Vücut Yağ Miktarı', ik AS 'İdeal Kilo', metabolikSRisk AS 'Metabolik Sendrom Riski' " +
               "FROM tbl_guncelKayitlar WHERE ad = @ad AND soyad = @soyad";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) // Birden fazla satırı okuma döngüsü
                        {
                            // Vücut Kitle Endeksi kontrolü
                            if (dr["Vücut Kitle Endeksi"] != DBNull.Value)
                            {
                                double vki = Convert.ToDouble(dr["Vücut Kitle Endeksi"]);
                                richtxt_yorumlama.AppendText(
                                    $"Vücut Kitle Endeksiniz {vki} olarak hesaplanmıştır. ");

                                if (vki < 18.5)
                                    richtxt_yorumlama.AppendText("Zayıf kategorisindesiniz. Kilo almanız önerilir.\n\n");
                                else if (vki >= 18.5 && vki < 25)
                                    richtxt_yorumlama.AppendText("Normal kilodasınız. Sağlıklı yaşam tarzınızı sürdürün.\n\n");
                                else if (vki >= 25 && vki < 30)
                                    richtxt_yorumlama.AppendText("Fazla kilolusunuz. Egzersiz ve beslenme düzenine dikkat etmelisiniz.\n\n");
                                else
                                    richtxt_yorumlama.AppendText("Obezite seviyesindesiniz. Kilo vermeye yönelik adımlar atmalısınız.\n\n");
                            }

                            // Vücut Yağ Miktarı kontrolü
                            if (dr["Vücut Yağ Miktarı"] != DBNull.Value)
                            {
                                double vym = Convert.ToDouble(dr["Vücut Yağ Miktarı"]);
                                richtxt_yorumlama.AppendText(
                                    $"Vücut Yağ Miktarınız {vym} kg olarak hesaplanmıştır. ");

                                if (vym < 10)
                                    richtxt_yorumlama.AppendText("Yağ miktarınız düşük seviyede.\n\n");
                                else if (vym >= 10 && vym <= 20)
                                    richtxt_yorumlama.AppendText("Yağ miktarınız ideal aralıkta.\n\n");
                                else
                                    richtxt_yorumlama.AppendText("Yağ miktarınız yüksek. Yağ oranınızı düşürmeye çalışmalısınız.\n\n");
                            }

                            // İdeal Kilo kontrolü
                            if (dr["İdeal Kilo"] != DBNull.Value)
                            {
                                double ik = Convert.ToDouble(dr["İdeal Kilo"]);
                                richtxt_yorumlama.AppendText(
                                    $"İdeal Kilonuz {ik} kg olarak hesaplanmıştır.\n\n");
                            }

                            // Metabolik Sendrom Riski kontrolü
                            if (dr["Metabolik Sendrom Riski"] != DBNull.Value)
                            {
                                string metabolikSRisk = dr["Metabolik Sendrom Riski"].ToString();
                                richtxt_yorumlama.AppendText(
                                    $"Metabolik Sendrom Riskiniz: {metabolikSRisk}. ");

                                if (metabolikSRisk.ToLower() == "yüksek")
                                    richtxt_yorumlama.AppendText("Sağlığınızı korumak için acil önlemler almalısınız.\n\n");
                                else if (metabolikSRisk.ToLower() == "orta")
                                    richtxt_yorumlama.AppendText("Risk seviyeniz orta. Sağlıklı yaşam alışkanlıklarına odaklanın.\n\n");
                                else
                                    richtxt_yorumlama.AppendText("Risk seviyeniz düşük. Mevcut durumunuzu koruyun.\n\n");
                            }
                        }
                    }
                con.Close();
                }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rdbtn_pdf.Checked)
            {
                PDFExporter.ExportFormToPdf(this);
            }
            if (rdbtn_word.Checked)
            {
                WordExport we = new WordExport();
                we.CreateDocument(this);
            }
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form mdiparentForm = this.MdiParent;
            mdiparentForm.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.SkyBlue;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.Gainsboro;

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.IndianRed;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Gainsboro;
        }

        private void dgv_vucut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_oranlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_hesaplamalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
