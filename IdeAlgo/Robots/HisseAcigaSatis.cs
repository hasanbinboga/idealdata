using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class HisseAcigaSatis : IdealSistem
    {
        public HisseAcigaSatis()
        {
            var Sembol = "IMKBH'GARAN";
            var LotSize = 1;
            var MySistem = Sistem.SistemGetir("MA2", Sembol, "60");
            if (MySistem == null)
            {
                Sistem.Mesaj(Sistem.Name + "Hatalı Çalışıyor !");
            }
            else
            {
                var EmirSembol = Sembol;
                var Pozisyon = Sistem.PozisyonKontrolOku(Sistem.Name + " , " + EmirSembol);
                var SonYon = "";
                for (int i = 0; i < MySistem.Yon.Count; i++)
                {
                    if (MySistem.Yon[i] != "")
                        SonYon = MySistem.Yon[i];
                }

                // Emir Miktarını Hesapla
                var Miktar = 0.0;
                if (Sistem.Saat.CompareTo("10:00:00") <= 0 || Sistem.Saat.CompareTo("18:04:59") >= 0)  // Seans Başlamadı
                {
                }
                else if (Sistem.Saat.CompareTo("13:59:59") <= 0 && Sistem.Saat.CompareTo("13:00:00") >= 0)  // Seans yok
                {
                }
                else if (SonYon == "F" && Pozisyon != 0)  // Flata Geç
                    Miktar = -Pozisyon;
                else if (SonYon == "A" && Pozisyon != LotSize)  // Al
                    Miktar = LotSize - Pozisyon;
                else if (SonYon == "S" && Pozisyon != -LotSize)  // Sat
                    Miktar = -LotSize - Pozisyon;

                // Emir Gönder
                var Islem = "";
                if (Miktar > 0)
                    Islem = "ALIS";
                if (Miktar < 0)
                    Islem = "SATIS";
                if (Islem != "")
                {
                    Sistem.EmirSembol = EmirSembol;
                    Sistem.EmirSuresi = "KIE"; // GUN, KIE, IKG
                    Sistem.EmirTipi = "Piyasa"; // Piyasa, Limitli, Piyasadan Limite
                    Sistem.EmirSatisTipi = "NORMAL";
                    Sistem.EmirMiktari = Math.Abs(Miktar);
                    Sistem.EmirIslem = Islem;
                    if (Pozisyon > 0 && Math.Abs(Miktar) > Pozisyon && Islem == "SATIS")
                    {
                        Sistem.PozisyonKontrolGuncelle(Sistem.Name + " , " + EmirSembol, Miktar + Pozisyon);
                        Sistem.EmirSatisTipi = "NORMAL";
                        Sistem.EmirMiktari = Pozisyon;
                        Sistem.EmirGonder();
                        System.Threading.Thread.Sleep(200);
                        Sistem.EmirSatisTipi = "ACIGA";
                        Sistem.EmirMiktari = Pozisyon;
                        Sistem.EmirGonder();
                    }
                    else if (Pozisyon == 0 && Islem == "SATIS")
                    {
                        Sistem.PozisyonKontrolGuncelle(Sistem.Name + " , " + EmirSembol, Miktar + Pozisyon);
                        Sistem.EmirSatisTipi = "ACIGA";
                        Sistem.EmirMiktari = -Miktar;
                        Sistem.EmirGonder();
                    }
                    else
                    {
                        Sistem.PozisyonKontrolGuncelle(Sistem.Name + " , " + EmirSembol, Miktar + Pozisyon);
                        Sistem.EmirGonder();
                    }
                }
            }



        }
    }
}
