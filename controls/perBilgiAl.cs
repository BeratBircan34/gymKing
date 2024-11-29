using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using gymKing.oto_Baglanti;
namespace gymKing.controls
{
    public class perBilgiAl
    {
        public string ad {  get; set; }
        public string soyad { get; set; }
        public string eMail {  get; set; }
        public string telNo { get; set; }


        public perBilgiAl(string id)
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from tbl_per_bilgiler where perId = @id", baglanti);
            kmt.Parameters.AddWithValue("@id", int.Parse(id));
            SqlDataReader dr = kmt.ExecuteReader();
            dr.Read();
            ad = dr["ad"].ToString();
            soyad = dr["soyad"].ToString() ;
            eMail = dr["email"].ToString() ;
            telNo = dr["telNo"].ToString();
            baglanti.Close();
        }


    }
}
