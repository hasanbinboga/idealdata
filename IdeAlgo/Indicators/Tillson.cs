using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Indicators
{
    class Tillson : IdealSistem
    {
        public Tillson()
        {
            var period = 9;
            float a = 0.71f;

            var C = Sistem.GrafikFiyatSec("Kapanis");
            var H = Sistem.GrafikFiyatSec("Yuksek");
            var L = Sistem.GrafikFiyatSec("Dusuk");

            var x = Sistem.Liste(0);
            for (int i = 1; i < Sistem.BarSayisi; i++)
                x[i] = (H[i] + L[i] + 2 * C[i]) / 4;

            var e1 = Sistem.MA(x, "Exp", period);
            var e2 = Sistem.MA(e1, "Exp", period);
            var e3 = Sistem.MA(e2, "Exp", period);
            var e4 = Sistem.MA(e3, "Exp", period);
            var e5 = Sistem.MA(e4, "Exp", period);
            var e6 = Sistem.MA(e5, "Exp", period);

            var c1 = -a * a * a;
            var c2 = 3 * a * a + 3 * a * a * a;
            var c3 = -6 * a * a - 3 * a - 3 * a * a * a;
            var c4 = 1 + 3 * a + a * a * a + 3 * a * a;

            var T3 = Sistem.Liste(Sistem.BarSayisi, 0);
            for (int i = 1; i < Sistem.BarSayisi; i++)
                T3[i] = c1 * e6[i] + c2 * e5[i] + c3 * e4[i] + c4 * e3[i];

            Sistem.Cizgiler[0].Deger = T3;
            Sistem.Cizgiler[0].Aciklama = "T3";



        }
    }
}
