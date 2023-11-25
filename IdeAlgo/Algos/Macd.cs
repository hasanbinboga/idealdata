using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class Macd : IdealSistem
    {

        public Macd()
        {
            // parametreleri al
            var Param1 = Sistem.Parametreler[0];
            var Param2 = Sistem.Parametreler[1];

            // hesapla
            var MACD = Sistem.MACD(Param1, Param2);
            // ortalama
            var AVR = Sistem.MA(MACD, "Exp", 9);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = MACD;
            Sistem.Cizgiler[0].Aciklama = "MACD";
            Sistem.Cizgiler[1].Deger = AVR;
            Sistem.Cizgiler[1].Aciklama = "AVR";

            // strateji
            Sistem.KesismeTara(MACD, AVR);

        }
    }
}
