using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class TrixFilter : IdealSistem
    {
        public TrixFilter()
        {
            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatOku(V, "Kapanis");

            var Trix = Sistem.TRIX(260);
            var TrixMA = Sistem.MA(Trix, "Exp", 50);

            var SonYon = "";
            var Sinyal = "";
            double SonFiyat = 0.0;

            for (int i = 100; i < V.Count; i++)
            {
                // Strateji
                if (Trix[i] > TrixMA[i]) Sinyal = "A";
                else if (Trix[i] < TrixMA[i]) Sinyal = "S";


                bool FiltreUP = (C[i] >= SonFiyat * 1.003 || C[i] <= SonFiyat);
                bool FiltreDN = (C[i] >= SonFiyat || C[i] <= SonFiyat * 0.997);

                // Yön Kalıbı
                if (Sinyal == "A" && SonYon != "A" && FiltreUP)
                {
                    Sistem.Yon[i] = "A";
                    SonYon = Sistem.Yon[i];
                    SonFiyat = V[i].Close;
                }
                if (Sinyal == "S" && SonYon != "S" && FiltreDN)
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
