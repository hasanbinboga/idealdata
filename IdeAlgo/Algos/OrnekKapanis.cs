using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class OrnekKapanis : IdealSistem
    {

        public OrnekKapanis()
        {

            // kapanış fiyatlarını oku
            var KapanisListesi = Sistem.GrafikFiyatSec("Kapanis");

            // hareketli ortalamayı hesapla
            var MA = Sistem.MA(KapanisListesi, "Exp", 20);

            // hesaplanan verileri çizgilere aktar
            Sistem.Cizgiler[0].Deger = MA;

            // strateji
            Sistem.KesismeTara(KapanisListesi, MA);

        }
    }
}
