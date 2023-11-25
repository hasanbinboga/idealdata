using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    public class DemaMaKesisim : IdealSistem
    {
        

        public DemaMaKesisim()
        {
            // kapanış fiyatlarını oku
            var Veriler = Sistem.GrafikFiyatSec("Kapanis");

            // hesapla
            var MA = Sistem.MA(Veriler, "Weighted", 5);
            var DEMA = Sistem.DEMA(5);

            // hesaplanan verileri çizgilere aktar
            Sistem.Cizgiler[0].Deger = MA;
            Sistem.Cizgiler[1].Deger = DEMA;

            // sistem strateji
            Sistem.KesismeTara(MA, DEMA);


            // algo strateji
            if (Sistem.YukariKestiyse(MA, DEMA))  // alış
                Sistem.AlgoIslem = "A";
            if (Sistem.AsagiKestiyse(MA, DEMA))  // satış
                Sistem.AlgoIslem = "S";

            // algo açıklama
            Sistem.AlgoAciklama = "MA=" + MA[Sistem.BarSayisi - 1].ToString("0.00") + "  " +
                                  "DEMA=" + DEMA[Sistem.BarSayisi - 1].ToString("0.00");

        }
    }
}
