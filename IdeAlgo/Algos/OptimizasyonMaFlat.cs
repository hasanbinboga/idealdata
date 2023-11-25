using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class OptimizasyonMaFlat : IdealSistem
    {

        public OptimizasyonMaFlat()
        {

            // kapanış fiyatlarını oku
            var C = Sistem.GrafikFiyatSec("Kapanis");

            // hareketli ortalamaları hesapla
            for (int KucukPeriyot = 50; KucukPeriyot < 101; KucukPeriyot++)
            {
                for (int BuyukPeriyot = 200; BuyukPeriyot < 251; BuyukPeriyot++)
                {
                    if (KucukPeriyot >= BuyukPeriyot) continue;
                    var MA1 = Sistem.MA(C, "Exp", KucukPeriyot);
                    var MA2 = Sistem.MA(C, "Exp", BuyukPeriyot);

                    // önceki taramadaki pozisyonları temizle
                    for (int i = 1; i < C.Count; i++)
                        Sistem.Yon[i] = "";

                    // strateji
                    var SonYon = "";
                    double Fiyat = 0;
                    for (int i = 1; i < Sistem.BarSayisi; i++)
                    {
                        if (MA1[i - 1] < MA2[i - 1] && MA1[i] >= MA2[i] && SonYon != "A") // AL
                        {
                            Sistem.Yon[i] = "A";  // alış
                            SonYon = Sistem.Yon[i];
                            Fiyat = C[i];
                        }
                        else if (MA1[i - 1] > MA2[i - 1] && MA1[i] <= MA2[i] && SonYon != "S") // SAT
                        {
                            Sistem.Yon[i] = "S";  // satış
                            SonYon = Sistem.Yon[i];
                            Fiyat = C[i];
                        }
                        else if (SonYon == "A" && C[i] > Fiyat * 1.05)   // % 5 kar realizasyonu
                        {
                            Sistem.Yon[i] = "F";  // flat
                            SonYon = Sistem.Yon[i];
                        }
                        else if (SonYon == "A" && C[i] < Fiyat * 0.98)   // % 2 stop
                        {
                            Sistem.Yon[i] = "F";  // flat
                            SonYon = Sistem.Yon[i];
                        }
                        else if (SonYon == "S" && C[i] < Fiyat * 0.95)   // % 5 kar realizasyonu
                        {
                            Sistem.Yon[i] = "F";  // flat
                            SonYon = Sistem.Yon[i];
                        }
                        else if (SonYon == "S" && C[i] > Fiyat * 1.02)   // % 2 stop
                        {
                            Sistem.Yon[i] = "F";  // flat
                            SonYon = Sistem.Yon[i];
                        }
                    }

                    Sistem.Optimizasyon("MA", KucukPeriyot, BuyukPeriyot);

                }
            }

        }
    }
}
