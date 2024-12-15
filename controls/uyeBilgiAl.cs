using gymKing.oto_Baglanti;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.controls
{
    public class uyeBilgiAl : bilgiAl
    {
        public string id;

        public uyeBilgiAl(string id)
        {
            this.id = id;
        }

        public override void bilgi(string id)
        {
            using (SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("select * from tbl_musteriler where m_id = @id", baglanti);
                kmt.Parameters.AddWithValue("@id", int.Parse(id));
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    Ad = dr["m_ad"].ToString();
                    Soyad = dr["m_soyad"].ToString();
                    EMail = dr["m_eMail"].ToString();
                    TelNo = dr["m_telNo"].ToString();
                }
            }
        }



    }
}
