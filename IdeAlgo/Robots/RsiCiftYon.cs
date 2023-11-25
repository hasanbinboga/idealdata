using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class RsiCiftYon : IdealSistem
    {
        public RsiCiftYon()
        {
            // parametreleri al
            var UstSeviye = Sistem.Parametreler[0];
            var AltSeviye = Sistem.Parametreler[1];


            var Sembol = "VIP'F_XU0301013S0";
            var Veriler = Sistem.GrafikVerileriniOku(Sembol, "1");
            var RSI = Sistem.RSI(Veriler, 65);

            // pozisyon tablosundan pozisyon miktarını al
            var Pozisyon = Sistem.PozisyonKontrolOku(Sembol);

            // alış
            if (Sistem.YukariKestiyse(RSI, UstSeviye))
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
            if (Sistem.AsagiKestiyse(RSI, AltSeviye))
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
