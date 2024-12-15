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
            SqlDataAdapter da = new SqlDataAdapter("select ad as 'İsim',soyad as 'Soyisim',cinsiyet as 'Cinsiyet',egitmen as 'Eğitmen',tarih as 'İşlem Tarihi' from tbl_guncelKayitlar", con);
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
            SqlDataAdapter da = new SqlDataAdapter($"select kilo,bel,boyun,kalca,boy from tbl_guncelKayitlar where ad = '{ad}' and soyad = '{soyad}' ", con);
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
                    richtxt_yorumlama.AppendText(
                        $"Vücut Yağ Oranınız {dr["vyo"]}% olarak hesaplanmıştır. " +
                        $"Bu oran, vücudunuzdaki yağ dokusunun toplam vücut ağırlığınıza oranını temsil eder. " +
                        $"İdeal bir yağ oranı, sağlıklı bir metabolizma ve hormonal denge için önemlidir. " +
                        $"Yağ oranınız yüksekse, düzenli egzersiz ve dengeli beslenme ile bu oranı düşürmeye çalışabilirsiniz.\n\n");
                }

                if (dr["bko"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Kalça Oranınız {dr["bko"]} olarak hesaplanmıştır. " +
                        $"Bu oran, özellikle kardiyovasküler hastalık riski için önemli bir göstergedir. " +
                        $"Erkekler için ideal bel-kalça oranı genelde 0.90'ın altında, kadınlar için ise 0.85'in altında olmalıdır. " +
                        $"Oranınız yüksekse, bel bölgesindeki yağlanmayı azaltmaya odaklanabilirsiniz.\n\n");
                }

                if (dr["bboy"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boy Oranınız {dr["bboy"]} olarak hesaplanmıştır. " +
                        $"Bu oran, karın bölgesindeki yağlanmayı ve genel sağlık risklerini değerlendirmenize yardımcı olur. " +
                        $"0.50'nin altında bir oran genellikle sağlıklı kabul edilir. " +
                        $"Eğer oranınız yüksekse, düzenli fiziksel aktivite ve sağlıklı beslenme alışkanlıklarını benimsemelisiniz.\n\n");
                }

                if (dr["bboyun"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boyun Oranınız {dr["bboyun"]} olarak hesaplanmıştır. " +
                        $"Bu ölçüm, özellikle obezite riskini değerlendirmek için kullanılan bir yöntemdir. " +
                        $"Oranınız ideal aralıkta değilse, kilo kontrolü ve egzersiz ile bu oranı iyileştirebilirsiniz.\n\n");
                }
            }
            con.Close();

        }
        private void hesaplamalarıYorumla(string ad, string soyad)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT vyo, bko, bboy, bboyun FROM tbl_guncelKayitlar WHERE ad = '{ad}' AND soyad = '{soyad}'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) // Veritabanındaki sonuçları okuyor
            {
                if (dr["vyo"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Vücut Yağ Oranınız {dr["vyo"]}% olarak hesaplanmıştır. " +
                        $"Bu oran, vücudunuzdaki yağ dokusunun toplam vücut ağırlığınıza oranını temsil eder. " +
                        $"İdeal bir yağ oranı, sağlıklı bir metabolizma ve hormonal denge için önemlidir. " +
                        $"Yağ oranınız yüksekse, düzenli egzersiz ve dengeli beslenme ile bu oranı düşürmeye çalışabilirsiniz.\n\n");
                }

                if (dr["bko"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Kalça Oranınız {dr["bko"]} olarak hesaplanmıştır. " +
                        $"Bu oran, özellikle kardiyovasküler hastalık riski için önemli bir göstergedir. " +
                        $"Erkekler için ideal bel-kalça oranı genelde 0.90'ın altında, kadınlar için ise 0.85'in altında olmalıdır. " +
                        $"Oranınız yüksekse, bel bölgesindeki yağlanmayı azaltmaya odaklanabilirsiniz.\n\n");
                }

                if (dr["bboy"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boy Oranınız {dr["bboy"]} olarak hesaplanmıştır. " +
                        $"Bu oran, karın bölgesindeki yağlanmayı ve genel sağlık risklerini değerlendirmenize yardımcı olur. " +
                        $"0.50'nin altında bir oran genellikle sağlıklı kabul edilir. " +
                        $"Eğer oranınız yüksekse, düzenli fiziksel aktivite ve sağlıklı beslenme alışkanlıklarını benimsemelisiniz.\n\n");
                }

                if (dr["bboyun"] != DBNull.Value)
                {
                    richtxt_yorumlama.AppendText(
                        $"Bel-Boyun Oranınız {dr["bboyun"]} olarak hesaplanmıştır. " +
                        $"Bu ölçüm, özellikle obezite riskini değerlendirmek için kullanılan bir yöntemdir. " +
                        $"Oranınız ideal aralıkta değilse, kilo kontrolü ve egzersiz ile bu oranı iyileştirebilirsiniz.\n\n");
                }
            }
            con.Close();

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
    }
}
