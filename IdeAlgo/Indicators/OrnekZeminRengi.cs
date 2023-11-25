using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Indicators
{
    class OrnekZeminRengi : IdealSistem
    {

        public OrnekZeminRengi()
        {
            // kapanış fiyatlarını oku
            var Veriler = Sistem.GrafikFiyatSec("Kapanis");

            // hareketli ortalamaları hesapla
            var MA1 = Sistem.MA(Veriler, "Exp", 5);
            var MA2 = Sistem.MA(Veriler, "Exp", 22);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = MA1;
            Sistem.Cizgiler[1].Deger = MA2;

            // strateji
            Sistem.KesismeTara(MA1, MA2);

            // zemin yazısı
            var Renk1 = Sistem.Renk(50, 255, 50, 50);
            Sistem.ZeminYazisiEkle("iDeal", 1, 300, 100, Renk1, "Tahoma", 72);

            var Renk2 = Sistem.Renk(50, 80, 255, 80);
            Sistem.ZeminYazisiEkle("Professional", 1, 120, 200, Renk2, "Tahoma", 72);

            var Renk3 = Sistem.Renk(50, 50, 100, 200);
            Sistem.ZeminYazisiEkle("Trading Platform", 1, 50, 300, Renk3, "Tahoma", 72);



        }
    }
}
