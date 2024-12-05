using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace gymKing.controls
{
     public class Pt_analizHesaplama
    {
        public float suIhtiyacı { get; set; }
        public float karbIhtiyacı { get; set; }
        public float proteinIhtıyacı { get; set; }
        public float yagIhtıyacı { get; set; }
        public float bazalMetabolizmaHizi {  get; set; }
        public float gunlukKaloriIhtiyacı { get; set; }
        public float vucutKitleEndeksi {  get; set; }
        public float idealKilo {  get; set; }
        public float vucutYagOrani { get; set; }
        public float vucutKasMiktari { get; set; }
        public string metabolikSendromRiski {  get; set; }
        public float vucutYagMiktari { get; set; }
        public float belKalcaOrani { get; set; }
        public float belBoyunOrani { get; set; }

        public float belBoyOrani_ {  get; set; }


        private float bmhHesapla( string cinsiyet,int yas,float boy,float kilo)
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
        private float vyoHesapla(string cinsiyet,float bel,float kalca,float boyun,float boy)
        {
            float vyo = 0;
            switch(cinsiyet)
            {
                case "Kadın":
                    vyo = 495 / (1.29579f - 0.35004f * (float)Math.Log10(bel + kalca - boyun) + 0.22100f * (float)Math.Log10(boy)) - 450;

                    break;
                case "Erkek":
                    vyo = 495 / (1.0324f - 0.19077f * (float)Math.Log10(bel - boyun) + 0.15456f * (float)Math.Log10(boy)) - 450;
                    break;
            }
            return vyo;
        }
        private float belKalcaOran(float bel,float kalca)
        {
            return bel / kalca;
        }
        private float vucutYagMiktari_(float kilo,float vyo)
        {
            return kilo * vyo / 100;
        }
        private float vucutKasMiktari_(float kilo,float vyo)
        {
            return kilo * ((100 - vyo) / 100);
        }

        private string metabolikSendromRiski_(string cinsiyet,float bel,float belboyOrani,float belBoyunOrani)
        {
            bool msr = false;
            string durum = "";
            switch (cinsiyet)
            {
                case "Erkek":
                    if(bel >= 102)
                        msr = true;
                    break;
                case "Kadın":
                    if(bel >= 88)
                        msr = true;
                    break;
            }
            if (belboyOrani > 0.50 && belBoyunOrani > 0.85)
                msr |= true;
            switch (msr)
            {
                case true:
                    durum = "Mevcut";
                    break;
                case false:
                    durum = "Düşük İhtimal";
                    break;
            }
            return durum;
        }
        private float idealKiloHesapla(string cinsiyet,float boy)
        {
            float idealKilo = 0;
            switch(cinsiyet)
            {
                case "Kadın":
                    idealKilo = 45.5f + 2.3f * ((boy / 2.54f) - 60);
                    break;
                case "Erkek":
                    idealKilo = 50 + 2.3f * ((boy / 2.54f) - 60);
                    break;

            }
            return idealKilo;
        }
        private float vkiHesapla(string cinsiyet,float kilo,float boy)
        {
            float vki = 0;
            switch (cinsiyet)
            {
                case "Kadın":
                    vki = kilo / ((float)Math.Pow(boy / 100, 2));
                    break;
                case "Erkek":
                    vki = kilo / ((float)Math.Pow((boy / 100), 2));
                    break;
            }
            return vki;
        }
        private float belBoyunOrani_(float bel,float boyun)
        {
            return bel / boyun;

        }
        private float belBoyOrani(float bel,float boy)
        {
            return bel / boy;

        }
        private void makroHesapla(float kilo, float gki)
        {
            
            suIhtiyacı = ((kilo * 0.3f) * 100) / 1000;
            proteinIhtıyacı = (gki * 0.20f) / 4;
            karbIhtiyacı = (gki * 0.48f) / 4;
            yagIhtıyacı = (gki * 0.32f) / 9;
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
        

        public Pt_analizHesaplama( int aktiviteSeviye,string cinsiyet,int yas,float kilo,float boy,float belC,float boyunC,float kalcaC)
        {
            
            string cinsiyet_ = cinsiyet;
            int yas_ = yas;
            float kilo_ = kilo;
            float boy_ = boy;
            float belC_ = belC;
            float boyun_ = boyunC;
            float kalca_ = kalcaC; 
            float bmh_ = bmhHesapla(cinsiyet, yas_, boy, kilo);
            float gki_ = gki_Katsayi(aktiviteSeviye) * bmh_;
            float vki_ = vkiHesapla(cinsiyet, kilo, boy);
            float ik_ = idealKiloHesapla(cinsiyet, boy);
            makroHesapla(kilo, gki_);
            bazalMetabolizmaHizi = bmh_;
            gunlukKaloriIhtiyacı = gki_;
            vucutKitleEndeksi = vki_;
            idealKilo = ik_;
            vucutYagOrani = vyoHesapla(cinsiyet_, belC_, kalca_, boyun_, boy_);
            vucutYagMiktari = vucutYagMiktari_(kilo_, vucutYagOrani);
            vucutKasMiktari = vucutKasMiktari_(kilo_, vucutYagOrani);
            belKalcaOrani = belKalcaOran(belC, kalca_);
            belBoyOrani_ = belBoyOrani(belC,boy_);
            belBoyunOrani = belBoyunOrani_(belC,boyunC);
            metabolikSendromRiski = metabolikSendromRiski_(cinsiyet, belC_, belBoyOrani_, belBoyunOrani);
                   

            
            


            //TODO FORMÜLLER KAĞIDA GEÇİRİLECEK!!
            




        }


    }
}
