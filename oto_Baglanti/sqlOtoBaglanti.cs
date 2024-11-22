using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace gymKing.oto_Baglanti
{
    public class sqlOtoBaglanti
    {   
        public static string pcAdiAl()
        {
            string pcAdi = Environment.MachineName;
            return pcAdi;
            
        }
        public static string databaseAdi()
        {
            string databaseAdi = "gymKing_db";
            return databaseAdi;
        }
        public static string sqlBaglantiDize()
        {
            string baglantiDize = $"Data Source={pcAdiAl()}\\SQLEXPRESS;Initial Catalog={databaseAdi()};Integrated Security=True;Encrypt=False";
            return baglantiDize;
        }
    }
}
