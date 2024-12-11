using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.controls
{
    public class uyeBilgiAl
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string eMail { get; set; }
        public string telNo { get; set; }




        public uyeBilgiAl(string id)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from tbl_musteriler where m_id = @id", baglanti);
            kmt.Parameters.AddWithValue("@id", int.Parse(id));
            SqlDataReader dr = kmt.ExecuteReader();
            dr.Read();
            ad = dr["m_ad"].ToString();
            soyad = dr["m_soyad"].ToString();
            eMail = dr["m_eMail"].ToString();
            telNo = dr["m_telNo"].ToString();
            baglanti.Close();
        }





    }
}
