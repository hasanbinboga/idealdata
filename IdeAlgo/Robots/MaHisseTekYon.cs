using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class MaHisseTekYon: IdealSistem
    {
        public MaHisseTekYon()
        {
            var Sembol = "IMKBH'GARAN";
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
                    Sistem.PozisyonKontrolGuncelle(Sembol, Miktar);
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
            if (Sistem.AsagiKestiyse(MA1, MA2))
            {
                if (Pozisyon > 0)
                {
                    var Miktar = Pozisyon;
                    Sistem.PozisyonKontrolGuncelle(Sembol, 0);
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
