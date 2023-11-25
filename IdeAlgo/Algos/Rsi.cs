using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Rsi : IdealSistem
    {
        public Rsi()
        {
            // parametreleri al
            var PeriyotRSI = Sistem.Parametreler[0];
            var PeriyotAVR = Sistem.Parametreler[1];
            var Yontem = Sistem.Parametreler[2];

            // RSI hesapla
            var RSI = Sistem.RSI(PeriyotRSI);
            // ortalama hesapla
            var AVR = Sistem.MA(RSI, Yontem, PeriyotAVR);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = RSI;
            Sistem.Cizgiler[0].Aciklama = "RSI " + PeriyotRSI;
            Sistem.Cizgiler[1].Deger = AVR;
            Sistem.Cizgiler[1].Aciklama = "AVR " + PeriyotAVR;

            // strateji
            Sistem.KesismeTara(RSI, AVR);

        }
    }
}
