using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Algos
{
    class Parabolic : IdealSistem
    {
        public Parabolic()
        {
            // parametreleri al
            var Param1 = Sistem.Parametreler[0];
            var Param2 = Sistem.Parametreler[1];

            // hesapla
            var Veriler = Sistem.GrafikFiyatSec("Kapanis");
            var Parabolic = Sistem.Parabolic(Param1, Param2);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = Parabolic;
            Sistem.Cizgiler[0].Aciklama = "Parabolic";

            // strateji
            Sistem.KesismeTara(Veriler, Parabolic);

        }
    }
}
