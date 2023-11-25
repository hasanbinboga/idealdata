using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class OptiimizasyonMaRsi : IdealSistem
    {

        public OptiimizasyonMaRsi()
        {
            // kapanış fiyatlarını oku
            var Kapanis = Sistem.GrafikFiyatSec("Kapanis");
            var SonYon = "";
            // taranacak periyot kadar döngü açın
            // kalitesiz kodlama yaparsanız hesaplama süresi çok uzun olabilir
            for (int P1 = 3; P1 < 11; P1++)
            {
                var MA1 = Sistem.MA(Kapanis, "Exp", P1);
                for (int P2 = 15; P2 < 20; P2++)
                {
                    var MA2 = Sistem.MA(Kapanis, "Exp", P2);
                    for (int P3 = 6; P3 < 12; P3++)
                    {
                        var RSI = Sistem.RSI(Kapanis, P3);
                        for (int P4 = 2; P4 < 6; P4++)
                        {
                            var RSIAVR = Sistem.MA(RSI, "Exp", P4);

                            for (int i = 1; i < Kapanis.Count; i++)
                                Sistem.Yon[i] = "";
                            // strateji
                            for (int i = 1; i < Kapanis.Count; i++)
                            {
                                if (RSI[i] > RSIAVR[i] && MA1[i] > MA2[i] && SonYon != "A") // alış
                                {
                                    Sistem.Yon[i] = "A";
                                    SonYon = "A";
                                }
                                else if (RSI[i] < RSIAVR[i] && MA1[i] < MA2[i] && SonYon != "S") // satış
                                {
                                    Sistem.Yon[i] = "S";
                                    SonYon = "S";
                                }
                            }
                            Sistem.Optimizasyon("MA AND RSI", P1, P2, P3, P4);
                        }
                    }
                }
            }

        }
    }
}
