using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class Momentum : IdealSistem
    {

        public Momentum()
        {
            // parametreleri al
            var PeriyotMomentum = Sistem.Parametreler[0];
            var PeriyotAVR = Sistem.Parametreler[1];
            var Yontem = Sistem.Parametreler[2];

            // Momentum hesapla
            var Momentum = Sistem.Momentum(PeriyotMomentum);
            // ortalama hesapla
            var AVR = Sistem.MA(Momentum, Yontem, PeriyotAVR);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = Momentum;
            Sistem.Cizgiler[0].Aciklama = "Momentum " + PeriyotMomentum;
            Sistem.Cizgiler[1].Deger = AVR;
            Sistem.Cizgiler[1].Aciklama = "AVR " + PeriyotAVR;

            // strateji
            Sistem.KesismeTara(Momentum, AVR);

        }
    }
}
