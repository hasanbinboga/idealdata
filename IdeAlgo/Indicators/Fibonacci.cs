using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    class Fibonacci : IdealSistem
    { 

        public Fibonacci()
        {
            /// fibonachi

            var DD = Sistem.Parametreler[0]; // parametre kısmından kullanılacak değeri gir

            // hazır sistem hesaplama fonksiyonları liste olarak değer döndürür
            var Tepe = Sistem.HHV(DD, "Kapanis");
            var Dip = Sistem.LLV(DD, "Kapanis");

            // sistem fonksiyonu kullanmadan yapılan hesaplamalarda liste yaratıp, döngü kullanmamız gerekiyor
            var BarSayisi = Tepe.Count;  // kolaylık olsun diye grafikteki bar sayısını değişkene aktar
            var Orta = Sistem.Liste(BarSayisi, 0);   // boş liste oluştur
            var FiboUst = Sistem.Liste(BarSayisi, 0);   // boş liste oluştur
            var FiboAlt = Sistem.Liste(BarSayisi, 0);   // boş liste oluştur

            // döngü kullanarak listeleri hesaplat
            for (int i = 0; i < BarSayisi; i++)
            {
                Orta[i] = (Tepe[i] + Dip[i]) / 2;
                FiboAlt[i] = Dip[i] - (Tepe[i] - Dip[i]) * 0.618f;  // c# sentaksında ondalık sayıların sonuna f harfi yazmak gerekiyor
                FiboUst[i] = Tepe[i] + (Tepe[i] - Dip[i]) * 0.618f;
            }

            // listeleri çizgilere aktar
            Sistem.Cizgiler[0].Deger = FiboUst;
            Sistem.Cizgiler[1].Deger = Tepe;
            Sistem.Cizgiler[2].Deger = Orta;
            Sistem.Cizgiler[3].Deger = Dip;
            Sistem.Cizgiler[4].Deger = FiboAlt;


            // strateji template
            //for (int i = 1; i<BarSayisi; i++)
            //{
            //   if ()
            //      Sistem.Yon[i] = "A";  // alış
            //   if ()
            //      Sistem.Yon[i] = "S";  // satış
            //}
        }
    }
}
