using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class VadeliCiftYon: IdealSistem
    {
        public VadeliCiftYon()
        {
            var Sembol = "VIP'F_XU0300813S0";
            var Kapanislar = Sistem.GrafikFiyatOku(Sembol, "1", "Kapanis");
            var MA1 = Sistem.MA(Kapanislar, "Simple", 5);
            var MA2 = Sistem.MA(Kapanislar, "Simple", 100);

            // pozisyon tablosundan pozisyon miktarını al
            var Pozisyon = Sistem.PozisyonKontrolOku(Sembol);

            // alış
            if (Sistem.YukariKestiyse(MA1, MA2))
            {
                if (Pozisyon == 0)
                {
                    var Miktar = 1;
                    Sistem.PozisyonKontrolGuncelle(Sembol, Pozisyon + Miktar);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Alış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirSuresi = "GUN";      // GUN, SNS, IKG
                    Sistem.EmirTipi = "KPY";        // KPY, KIE, GIE, SAR
                    Sistem.EmirFiyatTipi = "PYS";   // PYS, LMT, EIF, KAP
                    Sistem.EmirGonder();
                }
                else if (Pozisyon < 0)
                {
                    var Miktar = -2 * Pozisyon;
                    Sistem.PozisyonKontrolGuncelle(Sembol, Pozisyon + Miktar);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Alış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirSuresi = "GUN";      // GUN, SNS, IKG
                    Sistem.EmirTipi = "KPY";        // KPY, KIE, GIE, SAR
                    Sistem.EmirFiyatTipi = "PYS";   // PYS, LMT, EIF, KAP
                    Sistem.EmirGonder();
                }
            }

            // satış
            if (Sistem.AsagiKestiyse(MA1, MA2))
            {
                if (Pozisyon == 0)
                {
                    var Miktar = 1;
                    Sistem.PozisyonKontrolGuncelle(Sembol, Pozisyon - Miktar);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Satış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirSuresi = "GUN";      // GUN, SNS, IKG
                    Sistem.EmirTipi = "KPY";        // KPY, KIE, GIE, SAR
                    Sistem.EmirFiyatTipi = "PYS";   // PYS, LMT, EIF, KAP
                    Sistem.EmirGonder();
                }
                else if (Pozisyon > 0)
                {
                    var Miktar = 2 * Pozisyon;
                    Sistem.PozisyonKontrolGuncelle(Sembol, Pozisyon - Miktar);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Satış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirSuresi = "GUN";      // GUN, SNS, IKG
                    Sistem.EmirTipi = "KPY";        // KPY, KIE, GIE, SAR
                    Sistem.EmirFiyatTipi = "PYS";   // PYS, LMT, EIF, KAP
                    Sistem.EmirGonder();
                }
            }


        }
    }
}
