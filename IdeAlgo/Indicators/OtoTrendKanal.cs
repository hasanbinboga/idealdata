using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Indicators
{
    public class OtoTrendKanal :IdealSistem
    {
        public OtoTrendKanal()
        {
            var Pe = 140;

            var C = Sistem.GrafikFiyatSec("Kapanis");
            var Bars = Sistem.BarSayisi - 1;
            var LinearReg = Sistem.LinearReg(Pe);
            var LinRegSlope = Sistem.LinearRegSlope(C, Pe);
            var Y1 = Sistem.Liste(0);
            var Y = Sistem.Liste(0);
            var U = Sistem.Liste(0);
            float US = 0.0f;
            var Z = LinearReg[Bars];
            var highestsince = Sistem.Liste(-1);
            var lowestsince = Sistem.Liste(1);

            var L1 = Sistem.Liste(0);
            var L2 = Sistem.Liste(0);
            var L3 = Sistem.Liste(0);

            for (int i = 0; i < Sistem.BarSayisi; i++)
            {
                Y1[i] = (Bars - Pe + 1 <= i) ? -1 : 0;
                Y[i] = Bars - i;
                U[i] = Z - LinRegSlope[Bars] * Y[i];
                if (Y1[i] != 0)
                {
                    highestsince[i] = (float)Math.Max(highestsince[i - 1], -1 * Y1[i] * (C[i] - U[i]));
                    lowestsince[i] = (float)Math.Min(lowestsince[i - 1], -1 * Y1[i] * (C[i] - U[i]));
                }
            }

            for (int i = 0; i < Sistem.BarSayisi; i++)
            {
                if (Y1[i] != 0)
                    US = (float)(highestsince[Bars] + Math.Abs(lowestsince[Bars])) / 2;

                L1[i] = (-1 * Y1[i]) * (U[i] + US);
                L2[i] = -1 * Y1[i] * U[i];
                L3[i] = (-1 * Y1[i]) * (U[i] - US);
            }

            Sistem.Cizgiler[0].Deger = L1;
            Sistem.Cizgiler[1].Deger = L2;
            Sistem.Cizgiler[2].Deger = L3;


        }
    }
}
