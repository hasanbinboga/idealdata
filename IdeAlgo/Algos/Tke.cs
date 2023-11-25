using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Tke : IdealSistem
    {
        public Tke()
        {
            var STOFK = Sistem.StochasticOsc(14, 6);
            var RSI = Sistem.RSI(14);
            var CCI = Sistem.CommodityChannelIndex(14);
            var MFI = Sistem.MoneyFlowIndex(14);
            var WR = Sistem.WilliamsR(14);
            var MOM = Sistem.Momentum(12);
            var ULT = Sistem.UltimateOsc(7, 14, 28);

            for (int i = 0; i < Sistem.BarSayisi; i++)
            {
                Sistem.Cizgiler[0].Deger[i] = (STOFK[i] + RSI[i] + CCI[i] + MFI[i] + WR[i] + MOM[i] + ULT[i]) / 7;
                Sistem.Cizgiler[2].Deger[i] = 80;
                Sistem.Cizgiler[3].Deger[i] = 20;
            }

            // ortalama
            Sistem.Cizgiler[1].Deger = Sistem.MA(Sistem.Cizgiler[0].Deger, "Exp", 9);


            // strateji
            Sistem.KesismeTara(Sistem.Cizgiler[0].Deger, Sistem.Cizgiler[1].Deger);

        }
    }
}
