using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class OrnekGaranGun : IdealSistem
    {
        public OrnekGaranGun()
        {
            var Sembol = "IMKBH'GARAN";
            var Bar = Sistem.GrafikVerileriniOku(Sembol, "G");  // tüm bar varilerini içeren listeyi Bar değişkenine ata
            var BarSayisi = Bar.Count;  // grafikteki bar sayısını değişkene aktar

            // hazır sistem hesaplama fonksiyonları liste olarak değer döndürür
            var HHV = Sistem.HHV(Bar, 13, "Yuksek");
            var LLV = Sistem.LLV(Bar, 13, "Dusuk");

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

            // IŞLEM YAP
            // pozisyon tablosundan pozisyon miktarını al
            var Pozisyon = Sistem.PozisyonKontrolOku("ROBOT_001 " + Sembol);

            // alış
            if (Sistem.YukariKestiyse(IND, AVR))
            {
                if (Pozisyon == 0)
                {
                    var Miktar = 1000;
                    Sistem.PozisyonKontrolGuncelle("ROBOT_001 " + Sembol, 0);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Alış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirFiyati = "Aktif";
                    Sistem.EmirSuresi = "SEANS";   // SEANS, GUN
                    Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                    Sistem.EmirGonder();
                }
            }

            // satış
            if (Sistem.AsagiKestiyse(IND, AVR))
            {
                if (Pozisyon > 0)
                {
                    var Miktar = Pozisyon;
                    Sistem.PozisyonKontrolGuncelle("ROBOT_001 " + Sembol, 0);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Satış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirFiyati = "Aktif";
                    Sistem.EmirSuresi = "SEANS";   // SEANS, GUN
                    Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                    Sistem.EmirSatisTipi = "NORMAL"; // imkb (NORMAL, ACIGA, VIRMANDAN)
                    Sistem.EmirGonder();
                }
            }

        }
    }
}
