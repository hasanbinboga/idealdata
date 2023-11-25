using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Trix : IdealSistem
    {
        public Trix()
        {
            // parametreleri al
            var PeriyotTRIX = Sistem.Parametreler[0];
            var PeriyotAVR = Sistem.Parametreler[1];
            var Yontem = Sistem.Parametreler[2];

            // TRIX hesapla
            var TRIX = Sistem.TRIX(PeriyotTRIX);
            // ortalama hesapla
            var AVR = Sistem.MA(TRIX, Yontem, PeriyotAVR);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = TRIX;
            Sistem.Cizgiler[0].Aciklama = "TRIX " + PeriyotTRIX;
            Sistem.Cizgiler[1].Deger = AVR;
            Sistem.Cizgiler[1].Aciklama = "AVR " + PeriyotAVR;

            // strateji
            Sistem.KesismeTara(TRIX, AVR);

        }
    }
}
