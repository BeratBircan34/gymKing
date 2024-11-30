using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gymKing.controls
{
     public class Pt_analizHesaplama
    {
        private float bmhHesapla(string cinsiyet,int yas,float boy,float kilo)
        {
            float bmh = 0;
            switch (cinsiyet)
            {
                case "Kadın":
                    bmh = 447.593f + (9.247f * kilo) + (3.098f * boy) - (4.330f * yas);
                    break;
                case "Erkek":
                    bmh = 88.362f + (13.397f * kilo) + (4.799f * boy) - (5.677f * yas);
                    break;

            }
            return bmh;
        }
        private float gki_Katsayi(int sayi)
        {
            float d = 0;
            switch (sayi)
            {
                case 0:
                    d = 1.2f;
                    break;
                case 1:
                    d = 1.375f;
                    break;
                case 2:
                    d = 1.55f;
                    break;
                case 3:
                    d = 1.725f;
                    break;
                case 4:
                    d = 1.9f;
                    break;
            }
            return d;
        }
        public Pt_analizHesaplama(int aktiviteSeviye,string cinsiyet,int yas,float kilo,float boy,float belC,float boyunC,float kalcaC)
        {
            
            string cinsiyet_ = cinsiyet;
            int yas_ = yas;
            float kilo_ = kilo;
            float boy_ = boy;
            float belC_ = belC;
            float boyun_ = boyunC;
            float kalca_ = kalcaC;
            float gki = gki_Katsayi(aktiviteSeviye)*bmhHesapla(cinsiyet,yas,boy,kilo);
            //TODO FORMÜLLER KAĞIDA GEÇİRİLECEK!!
            




        }


    }
}
