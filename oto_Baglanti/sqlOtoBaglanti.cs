﻿using System;
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
            //
        }
        public static string databaseAdi()
        {
            string databaseAdi = "BonusOkul";
            return databaseAdi;
        }
        public static string sqlBaglantiDize()
        {
            string baglantiDize = $"Data Source={pcAdiAl()}\\SQLEXPRESS;Initial Catalog={databaseAdi()};Integrated Security=True;Encrypt=False";
            return baglantiDize;
        }

        public static  bool baglanti_durumu = false;

        public static void baglan()
        {
            SqlConnection baglanti = new SqlConnection(sqlBaglantiDize());
            if(sqlOtoBaglanti.baglanti_durumu == false)
            {
                baglanti.Open();
                sqlOtoBaglanti.baglanti_durumu = true;
            }
            else
            {
                baglanti.Close();
                sqlOtoBaglanti.baglanti_durumu = false;

                
            }
        }

    }
}
