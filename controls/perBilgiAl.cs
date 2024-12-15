using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using gymKing.oto_Baglanti;
namespace gymKing.controls
{
    public class perBilgiAl : bilgiAl
    {
        public string id;

        public perBilgiAl(string id)
        {
            this.id = id;
        }

        public override void bilgi(string id)
        {
            using (SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize()))
            {
                baglanti.Open();
                SqlCommand kmt = new SqlCommand("select * from tbl_per_bilgiler where perId = @id", baglanti);
                kmt.Parameters.AddWithValue("@id", int.Parse(id));
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    Ad = dr["ad"].ToString();
                    Soyad = dr["soyad"].ToString();
                    EMail = dr["email"].ToString();
                    TelNo = dr["telNo"].ToString();
                }
            }

        }
    }
}
