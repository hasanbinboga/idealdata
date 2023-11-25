using System;
using Tricks;

namespace Indicators
{
    public class PivotParametrik : IdealSistem
    {

        public PivotParametrik()
        {
            var periyot = "H";
            if (Sistem.Parametreler != null && Sistem.Parametreler.Count > 0)
            {
                periyot = Sistem.Parametreler[0];
            }
            
            // haftalık verileri oku
            var gunlukVeriler = Sistem.GrafikVerileriniOku(Sistem.Sembol, periyot);

            // boş veri listeleri yarat
            var p = Sistem.Liste(0);
            var bc = Sistem.Liste(0);
            var tc = Sistem.Liste(0);
            var r1 = Sistem.Liste(0);
            var r2 = Sistem.Liste(0);
            var r3 = Sistem.Liste(0);
            var r4 = Sistem.Liste(0);
            var s1 = Sistem.Liste(0);
            var s2 = Sistem.Liste(0);
            var s3 = Sistem.Liste(0);
            var s4 = Sistem.Liste(0);

            // döngü ile haftalık pivot, prohigh, prolow hesapla
            for (int i = 1; i < gunlukVeriler.Count; i++)
            {
                // pivot önceki barın (H+L+C)/3 değeri
                p[i] =  (gunlukVeriler[i - 1].High + gunlukVeriler[i - 1].Low + gunlukVeriler[i - 1].Close) / 3;
                bc[i] =  (gunlukVeriler[i - 1].High + gunlukVeriler[i - 1].Low ) / 2;
                tc[i] = (p[i] - bc[i]) + p[i];

                r1[i] = (2*p[i]) - gunlukVeriler[i - 1].Low;
                r2[i] = p[i] + (gunlukVeriler[i - 1].High - gunlukVeriler[i-1].Low);
                r3[i] = r1[i] + (gunlukVeriler[i - 1].High - gunlukVeriler[i-1].Low);
                r4[i] = r3[i] + (r2[i] - r1[i]);

                s1[i] = (2 * p[i]) - gunlukVeriler[i - 1].High;
                s2[i] = p[i] - (gunlukVeriler[i - 1].High - gunlukVeriler[i - 1].Low);
                s3[i] = s1[i] - (gunlukVeriler[i - 1].High - gunlukVeriler[i - 1].Low);
                s4[i] = s3[i] - (s1[i] - s2[i]);

                //// pro high hesapla
                //PH[i] = 2 * PVT[i] - gunlukVeriler[i - 1].Low;
                //// pro low hesapla
                //PL[i] = 2 * PVT[i] - gunlukVeriler[i - 1].High;
            }


            //R4  
            Sistem.Cizgiler[0].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, r4);
            Sistem.Cizgiler[0].Aciklama = "R4, Günlük";
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Renk = Sistem.Renk(255, 11, 252, 45);
            Sistem.Cizgiler[0].Kalinlik = 2;

            //R3  
            Sistem.Cizgiler[1].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, r3);
            Sistem.Cizgiler[1].Aciklama = "R3, Günlük";
            Sistem.Cizgiler[1].ActiveBool = true;
            Sistem.Cizgiler[1].Renk = Sistem.Renk(255, 22, 203, 47);
            Sistem.Cizgiler[1].Kalinlik = 2;

            //R2 
            Sistem.Cizgiler[2].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, r2);
            Sistem.Cizgiler[2].Aciklama = "R2, Günlük";
            Sistem.Cizgiler[2].ActiveBool = true;
            Sistem.Cizgiler[2].Renk = Sistem.Renk(255, 23, 153, 41);
            Sistem.Cizgiler[2].Kalinlik = 2;

            // R1
            Sistem.Cizgiler[3].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, r1);
            Sistem.Cizgiler[3].Aciklama = "R1, Günlük";
            Sistem.Cizgiler[3].ActiveBool = true;
            Sistem.Cizgiler[3].Renk = Sistem.Renk(255, 16, 109, 29);
            Sistem.Cizgiler[3].Kalinlik = 2;

            //TC
            Sistem.Cizgiler[4].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, tc);
            Sistem.Cizgiler[4].Aciklama = "TC, Günlük";
            Sistem.Cizgiler[4].ActiveBool = true;
            Sistem.Cizgiler[4].Renk = Sistem.Renk(255, 255, 241, 87);
            Sistem.Cizgiler[4].Kalinlik = 2;

            //P
            Sistem.Cizgiler[5].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, p);
            Sistem.Cizgiler[5].Aciklama = "Pivot, Günlük";
            Sistem.Cizgiler[5].ActiveBool = true;
            Sistem.Cizgiler[5].Renk = Sistem.Renk(255, 13, 118, 226);
            Sistem.Cizgiler[5].Kalinlik = 3;


            // BC
            Sistem.Cizgiler[6].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, bc);
            Sistem.Cizgiler[6].Aciklama = "BC, Günlük";
            Sistem.Cizgiler[6].ActiveBool = true;
            Sistem.Cizgiler[6].Renk = Sistem.Renk(255, 255, 241, 87);
            Sistem.Cizgiler[6].Kalinlik = 2;


            // S1
            Sistem.Cizgiler[7].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, s1);
            Sistem.Cizgiler[7].Aciklama = "S1, Günlük";
            Sistem.Cizgiler[7].ActiveBool = true;
            Sistem.Cizgiler[7].Renk = Sistem.Renk(255, 229, 131, 36);
            Sistem.Cizgiler[7].Kalinlik = 2;

            //S2 
            Sistem.Cizgiler[8].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, s2);
            Sistem.Cizgiler[8].Aciklama = "S2, Günlük";
            Sistem.Cizgiler[8].ActiveBool = true;
            Sistem.Cizgiler[8].Renk = Sistem.Renk(255, 238, 92, 13);
            Sistem.Cizgiler[8].Kalinlik = 2;

            //S3  
            Sistem.Cizgiler[9].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, s3);
            Sistem.Cizgiler[9].Aciklama = "S3, Günlük";
            Sistem.Cizgiler[9].ActiveBool = true;
            Sistem.Cizgiler[9].Renk = Sistem.Renk(255, 236, 59, 25);
            Sistem.Cizgiler[9].Kalinlik = 2;

            //S4  
            Sistem.Cizgiler[10].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriler, s4);
            Sistem.Cizgiler[10].Aciklama = "S4, Günlük";
            Sistem.Cizgiler[10].ActiveBool = true;
            Sistem.Cizgiler[10].Renk = Sistem.Renk(255, 245, 7, 7);
            Sistem.Cizgiler[10].Kalinlik = 2;

            // dolgu tanımla
            var DolguRengi = Sistem.Renk(40, 100, 100, 255);
            Sistem.DolguEkle(0, 1, DolguRengi, DolguRengi);


        }
    }
}
