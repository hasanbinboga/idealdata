using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Systems
{
    public class KarZarar : IdealSistem
    {

        public KarZarar()
        {
            var A1 = Sistem.MA(50, "Simple", "Kapanis");
            var A2 = Sistem.MA(100, "Simple", "Kapanis");

            var SonYon = "";
            for (int i = 1; i < Sistem.BarSayisi; i++)
            {
                if (A1[i] > A2[i] && SonYon != "A")
                {
                    Sistem.Yon[i] = "A";
                    SonYon = Sistem.Yon[i];
                }
                else if (A1[i] < A2[i] && SonYon != "S")
                {
                    Sistem.Yon[i] = "S";
                    SonYon = Sistem.Yon[i];
                }
            }

            Sistem.GetiriHesapla("01/01/2010", 0.00); //Belli bir tarihten itibaren Getiri eğirisi çizdirilir, işlemlerde 0 puan kayma dikkate alınır.


            Sistem.Cizgiler[0].Deger = A1;
            Sistem.Cizgiler[1].Deger = A2;
            Sistem.Cizgiler[2].Deger = Sistem.GetiriKZ;
            Sistem.Cizgiler[3].Deger = Sistem.GetiriMiktar;
            Sistem.Cizgiler[4].Deger = Sistem.GetiriPozisyon;
        }
    }
}
