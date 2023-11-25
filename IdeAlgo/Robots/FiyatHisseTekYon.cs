using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class FiyatHisseTekYon :IdealSistem
    {
        public FiyatHisseTekYon()
        {
            var Sembol = "IMKBH'EREGL";
            var SembolDeger = Sistem.SonFiyat(Sembol);

            // pozisyon tablosundan pozisyon miktarını al
            var Pozisyon = Sistem.PozisyonKontrolOku(Sembol);

            // alış
            if (SembolDeger <= 2.10)
            {
                if (Pozisyon == 0)
                {
                    var Miktar = 1;
                    Sistem.PozisyonKontrolGuncelle(Sembol, Miktar);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Alış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                    Sistem.EmirSuresi = "SEANS";   // SEANS, GUN
                    Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                    Sistem.EmirGonder();
                }
            }

            // satış
            if (SembolDeger >= 2.50)
            {
                if (Pozisyon > 0)
                {
                    var Miktar = Pozisyon;
                    Sistem.PozisyonKontrolGuncelle(Sembol, 0);
                    Sistem.EmirSembol = Sembol;
                    Sistem.EmirIslem = "Satış";
                    Sistem.EmirMiktari = Miktar;
                    Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                    Sistem.EmirSuresi = "SEANS";   // SEANS, GUN    
                    Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                    Sistem.EmirSatisTipi = "NORMAL"; // imkb (NORMAL, ACIGA, VIRMANDAN)
                    Sistem.EmirGonder();
                }
            }




        }
    }
}
