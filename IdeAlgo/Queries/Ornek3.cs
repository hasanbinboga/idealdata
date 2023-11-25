using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Queries
{
    class Ornek3 : IdealSistem
    {
        public Ornek3()
        {
            //20-20 ve 100'lük ortalamasına %1 yaklaşmış senetleri bulmak...

            var MARJ = 0.01f; // %1 yaklaşma

            Sistem.SorguBaslik[0] = "MA-20";
            Sistem.SorguBaslik[1] = "MA-50";
            Sistem.SorguBaslik[2] = "MA-100";
            Sistem.SorguBaslik[3] = "Fark12";
            Sistem.SorguBaslik[4] = "Fark13";
            Sistem.SorguBaslik[5] = "Fark23";


            var MA1 = Sistem.MA(20, "Simple", "Kapanis");
            var MA2 = Sistem.MA(50, "Simple", "Kapanis");
            var MA3 = Sistem.MA(100, "Simple", "Kapanis");
            var C = Sistem.GrafikFiyatOku(Sistem.GrafikVerileri, "Kapanis");
            var Limit = MARJ * C[C.Count - 1];


            // filtrele
            var Fark12 = Math.Abs(MA1[MA1.Count - 1] - MA2[MA2.Count - 1]);
            var Fark13 = Math.Abs(MA1[MA1.Count - 1] - MA3[MA3.Count - 1]);
            var Fark23 = Math.Abs(MA2[MA2.Count - 1] - MA3[MA3.Count - 1]);

            if (Fark12 < Limit && Fark13 < Limit && Fark23 < Limit)
            {
                Sistem.SorguDeger[0] = MA1[MA1.Count - 1];
                Sistem.SorguDeger[1] = MA2[MA2.Count - 1];
                Sistem.SorguDeger[2] = MA3[MA3.Count - 1];
                Sistem.SorguDeger[3] = Fark12;
                Sistem.SorguDeger[4] = Fark13;
                Sistem.SorguDeger[5] = Fark23;
                Sistem.SorguAciklama = "MA YAKLAŞIM";
                Sistem.SorguEkle();
            }
        }
    }
}
