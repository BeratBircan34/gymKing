using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.yonetici_forms
{
    public class perBilgiCek
    {
        public DataTable VeriCek()
        {
            // Veritabanına bağlanarak verileri çekme
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();

            string query = "SELECT * FROM tbl_per_bilgiler"; // Örnek SQL sorgusu
            SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

            baglanti.Close();

            return dt;
        }
    }
}
