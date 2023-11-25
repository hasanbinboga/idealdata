using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class MaHl : IdealSistem
    {
        public MaHl()
        {
            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatOku(V, "Kapanis");
            var HH = Sistem.HHV(30, "Yuksek");
            var LL = Sistem.LLV(30, "Dusuk");

            var MA = Sistem.MA(C, "Exp", 110);
            var MAMA = Sistem.MA(MA, "Exp", 110);

            var SonYon = "";
            var Sinyal = "";
            double SonFiyat = 0.0;
            for (int i = 100; i < V.Count; i++)
            {
                // Strateji
                if (HH[i] > HH[i - 1] && MA[i] > MAMA[i]) Sinyal = "A";
                else if (LL[i] < LL[i - 1] && MA[i] < MAMA[i]) Sinyal = "S";

                // Yön Kalıbı
                if (Sinyal == "A" && SonYon != "A")
                {
                    Sistem.Yon[i] = "A";
                    SonYon = Sistem.Yon[i];
                    SonFiyat = V[i].Close;
                }
                if (Sinyal == "S" && SonYon != "S")
                {
                    Sistem.Yon[i] = "S";
                    SonYon = Sistem.Yon[i];
                    SonFiyat = V[i].Close;
                }
                if (Sinyal == "F" && SonYon != "F")
                {
                    Sistem.Yon[i] = "F";
                    SonYon = Sistem.Yon[i];
                    SonFiyat = V[i].Close;
                }
            }

        }
    }
}
