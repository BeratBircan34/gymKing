using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using gymKing.oto_Baglanti;
namespace gymKing.controls
{
    public class pt_gecici_Bellek
    {
        public string suIhtiyacı { get; set; }//
        public string karbIhtiyacı { get; set; }//
        public string proteinIhtıyacı { get; set; }//
        public string yagIhtıyacı { get; set; }//
        public string bazalMetabolizmaHizi { get; set; }//
        public string gunlukKaloriIhtiyacı { get; set; }//
        public string vucutKitleEndeksi { get; set; }//
        public string idealKilo { get; set; }//
        public string vucutYagOrani { get; set; }//
        public string vucutKasMiktari { get; set; } //
        public string metabolikSendromRiski { get; set; }//
        public string vucutYagMiktari { get; set; }//
        public string belKalcaOrani { get; set; }//
        public string belBoyunOrani { get; set; }//
        public string belBoyOrani_ { get; set; }//

        public string yas {  get; set; }//

        public string kilo { get; set; }//
        
        public string boy { get; set; }//

        public string boyun { get; set; }//
        public string bel { get; set;}//

        public string kalca { get; set; } //

        public pt_gecici_Bellek()
        {
            SqlConnection baglanti = new SqlConnection(sqlOtoBaglanti.sqlBaglantiDize());
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from tbl_gecicibellek",baglanti);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                yas = dr["yas"].ToString();
                kilo = dr["kilo"].ToString() ;
                boy = dr["boy"].ToString();
                bel = dr["bel"].ToString();
                kalca = dr["kalca"].ToString().ToLower() ;
                boyun = dr["boyun"].ToString();
                gunlukKaloriIhtiyacı = dr["gki"].ToString();
                bazalMetabolizmaHizi = dr["bmh"].ToString();
                metabolikSendromRiski = dr["msr"].ToString();
                vucutKitleEndeksi = dr["vki"].ToString();
                vucutYagMiktari = dr["vym"].ToString();
                suIhtiyacı = dr["si"].ToString();
                proteinIhtıyacı = dr["pi"].ToString();
                karbIhtiyacı = dr["ki"].ToString();
                yagIhtıyacı = dr["yi"].ToString ();
                idealKilo = dr["ik"].ToString () ;
                vucutYagOrani = dr["vyo"].ToString ().ToLower () ;
                belKalcaOrani = dr["bko"].ToString();
                belBoyOrani_ = dr["bbo"].ToString() ;
                belBoyunOrani = dr["bboyun"].ToString ( );
                vucutKasMiktari = dr["vkm"].ToString( );
            }

        }
    }
}
