using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Toma : IdealSistem
    {
        public Toma()
        {
            // parametreleri al
            var Periyot = Sistem.Parametreler[0];
            var Yuzde = Sistem.Parametreler[1];

            // TOMA hesapla
            var TOMA = Sistem.TOMA(Periyot, Yuzde);
            // EMA hesapla
            var Veriler = Sistem.GrafikFiyatSec("Kapanis");
            var EMA = Sistem.MA(Veriler, "Exp", Periyot);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = TOMA;
            Sistem.Cizgiler[1].Deger = EMA;

            // strateji
            Sistem.KesismeTara(EMA, TOMA);

        }
    }
}
