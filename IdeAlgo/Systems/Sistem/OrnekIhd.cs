using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Systems.Sistem
{
    class OrnekIhd : IdealSistem
    {
        public OrnekIhd()
        {
            var Bar = Sistem.GrafikVerileri;   // tüm bar varilerini içeren listeyi Bar değişkenine ata
            var BarSayisi = Sistem.BarSayisi;  // grafikteki bar sayısını değişkene aktar

            // hazır sistem hesaplama fonksiyonları liste olarak değer döndürür
            var HHV = Sistem.HHV(13, "Yuksek");
            var LLV = Sistem.LLV(13, "Dusuk");

            // sistem fonksiyonu kullanmadan yapılan hesaplamalarda liste yaratıp, döngü kullanmamız gerekiyor
            var Part1 = Sistem.Liste(BarSayisi, 0);   // C - (.5 * ( HHV + LLV)
            var Part2 = Sistem.Liste(BarSayisi, 0);   // HHV - LLV

            // döngü kullanarak listeleri hesaplat
            for (int i = 100; i < BarSayisi; i++)
            {
                Part1[i] = Bar[i].Close - 0.5f * (HHV[i] + LLV[i]); // C - (.5 * ( HHV + LLV);
                Part2[i] = HHV[i] - LLV[i]; // HHV - LLV
            }

            // sistem fonksiyonlarını kullanarak hareketli ortalama listelerini oluştur
            var Part1Mov = Sistem.MA(Sistem.MA(Part1, "Exp", 25), "Exp", 2);
            var Part2Mov = Sistem.MA(Sistem.MA(Part2, "Exp", 25), "Exp", 2);

            // boş indikator listesi tanımla ve hesapla
            var IND = Sistem.Liste(BarSayisi, 0);   // boş liste
            for (int i = 100; i < BarSayisi; i++)
            {
                IND[i] = 100 * (Part1Mov[i] / (0.5f * Part2Mov[i]));
            }
            // indikator ortalama listesi
            var AVR = Sistem.MA(IND, "Exp", 5);

            // listeleri çizgilere aktar
            Sistem.Cizgiler[0].Deger = IND;
            Sistem.Cizgiler[1].Deger = AVR;

            // strateji
            Sistem.KesismeTara(IND, AVR);

        }
    }
}
