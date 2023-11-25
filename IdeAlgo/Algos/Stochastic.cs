using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Stochastic : IdealSistem
    {
        public Stochastic()
        {
            // STOCHASTIC hesapla
            var STOCKHASTIC = Sistem.StochasticOsc(5, 3);
            // ortalama hesapla
            var AVR = Sistem.MA(STOCKHASTIC, "Simple", 9);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = STOCKHASTIC;
            Sistem.Cizgiler[1].Deger = AVR;

            // strateji
            Sistem.KesismeTara(STOCKHASTIC, AVR);

        }
    }
}
