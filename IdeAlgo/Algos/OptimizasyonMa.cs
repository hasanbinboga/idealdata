using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class OptimizasyonMa : IdealSistem
    {

        public OptimizasyonMa()
        {

            // kapanış fiyatlarını oku
            var Kapanis = Sistem.GrafikFiyatSec("Kapanis");

            // hareketli ortalamaları hesapla
            for (int KucukPeriyot = 5; KucukPeriyot < 20; KucukPeriyot++)
            {
                for (int BuyukPeriyot = 20; BuyukPeriyot < 60; BuyukPeriyot++)
                {
                    if (KucukPeriyot < BuyukPeriyot)
                    {
                        var MA1 = Sistem.MA(Kapanis, "Exp", KucukPeriyot);
                        var MA2 = Sistem.MA(Kapanis, "Exp", BuyukPeriyot);
                        Sistem.KesismeTara(MA1, MA2);
                        Sistem.Optimizasyon("MA", KucukPeriyot, BuyukPeriyot);
                    }
                }
            } 
        }
    }
}
