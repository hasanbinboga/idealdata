using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class OrnekHisseOran : IdealSistem
    {
        public OrnekHisseOran()
        {
            var SembolHALKB = "IMKBH'HALKB";
            var SonHALKB = Sistem.SonFiyat(SembolHALKB);
            var SembolGARAN = "IMKBH'GARAN";
            var SonGARAN = Sistem.SonFiyat(SembolGARAN);

            // zaman kontrolu ( bu saat aralıklarında emir gönderilebilsin )
            if (Sistem.SaatAraligi("09:30", "12:30") || Sistem.SaatAraligi("14:15", "17:30"))
            {
                // değerler sıfırdan büyük ise çalışsın
                if (SonHALKB > 0 && SonGARAN > 0)
                {
                    var Oran = SonHALKB / SonGARAN;
                    var Pozisyon = Sistem.PozisyonKontrolOku("Robot002");  // pozisyon kontrolü yap

                    // HALKB al, GARAN sat
                    if (Oran <= 1.70f)
                    {
                        if (Pozisyon != 1000)  // HALKB pozisyon kontrolu yap, 1000 değil ise işlemi gerçekleştir..
                        {
                            Sistem.PozisyonKontrolGuncelle("Robot002", 1000);

                            // HALKB alış emri gönder
                            Sistem.EmirSembol = SembolHALKB;
                            Sistem.EmirIslem = "Alış";
                            Sistem.EmirMiktari = 1000;
                            Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                            Sistem.EmirSuresi = "SEANS";   // SEANS, GUN
                            Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                            Sistem.EmirGonder();

                            // GARAN satış emri gönder
                            Sistem.EmirSembol = SembolGARAN;
                            Sistem.EmirIslem = "Satış";
                            Sistem.EmirMiktari = 1875;
                            Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                            Sistem.EmirSuresi = "SEANS";   // SEANS, GUN    
                            Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                            Sistem.EmirSatisTipi = "NORMAL"; // imkb (NORMAL, ACIGA, VIRMANDAN)
                            Sistem.EmirGonder();
                        }
                    }

                    // HALKB sat, GARAN al
                    if (Oran >= 1.99f)
                    {
                        if (Pozisyon != -1000)
                        {
                            Sistem.PozisyonKontrolGuncelle("Robot002", -1000);

                            // HALKB satış emri gönder
                            Sistem.EmirSembol = SembolHALKB;
                            Sistem.EmirIslem = "Satış";
                            Sistem.EmirMiktari = 1000;
                            Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                            Sistem.EmirSuresi = "SEANS";   // SEANS, GUN    
                            Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                            Sistem.EmirSatisTipi = "NORMAL"; // imkb (NORMAL, ACIGA, VIRMANDAN)
                            Sistem.EmirGonder();

                            // GARAN alış emri gönder
                            Sistem.EmirSembol = SembolGARAN;
                            Sistem.EmirIslem = "Alış";
                            Sistem.EmirMiktari = 1875;
                            Sistem.EmirFiyati = "Aktif";   // aktif fiyat
                            Sistem.EmirSuresi = "SEANS";   // SEANS, GUN
                            Sistem.EmirTipi = "NORMAL";    // NORMAL, KIE, KPY, AFE/KAFE
                            Sistem.EmirGonder();
                        }
                    }
                }
            }

        }
    }
}
