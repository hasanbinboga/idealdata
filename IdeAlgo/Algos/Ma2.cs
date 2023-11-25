using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Algos
{
    class Ma2 : IdealSistem
    {

        public Ma2()
        {
            // parametreleri al
            var Yontem = Sistem.Parametreler[0];
            var Periyot1 = Sistem.Parametreler[1];
            var Periyot2 = Sistem.Parametreler[2];

            // kapanış fiyatlarını oku
            var Veriler = Sistem.GrafikFiyatSec("Kapanis");

            // hareketli ortalamaları hesapla
            var MA1 = Sistem.MA(Veriler, Yontem, Periyot1);
            var MA2 = Sistem.MA(Veriler, Yontem, Periyot2);

            // hesaplanan verileri çizgilere aktar ve açıklama ekle
            Sistem.Cizgiler[0].Deger = MA1;
            Sistem.Cizgiler[0].Aciklama = "MA " + Periyot1;
            Sistem.Cizgiler[1].Deger = MA2;
            Sistem.Cizgiler[1].Aciklama = "MA " + Periyot2;

            // strateji
            for (int i = 1; i < Sistem.BarSayisi; i++)
            {
                if (MA1[i - 1] < MA2[i - 1] && MA1[i] > MA2[i]) // 1.ortalama 2.ortalamanın üstüne çıkarsa
                    Sistem.Yon[i] = "A";  // alış
                if (MA1[i - 1] > MA2[i - 1] && MA1[i] < MA2[i]) // 1.ortalama 2.ortalamanın altına inerse
                    Sistem.Yon[i] = "S";  // satış
            }

        }
    }
}
