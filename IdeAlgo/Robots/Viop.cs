using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class Viop : IdealSistem
    {
        public Viop()
        {
            var LotSize = 1; //işlem adedi

            var MySistem = Sistem.SistemGetir("MA2", "VIP'VIP-X030", "1"); //sistemin adı, grafik sembolü, grafiğin periyodu
            if (MySistem == null)
            {
                Sistem.Mesaj(Sistem.Name + "Hatalı Çalışıyor !");
            }
            else
            {
                var EmirSembol = Sistem.AktifViopKontrat;
                var SonFiyat = Sistem.SonFiyat(EmirSembol);
                var Anahtar = Sistem.Name + "," + EmirSembol;
                double IslemFiyat = 0;
                DateTime IslemTarih;
                var Miktar = 0.0;
                var Rezerv = "";
                var Pozisyon = Sistem.PozisyonKontrolOku(Anahtar, out IslemFiyat, out IslemTarih);

                var SonYon = MySistem.SonYon;//canlı bara dikkat!!!
                if (Sistem.Saat.CompareTo("09:30:00") <= 0 || Sistem.Saat.CompareTo("18:14:59") >= 0)  // seans yok işlem yapma
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
                if (Miktar > 0) { Islem = "ALIS"; Rezerv = "ALIŞ YAPILDI"; }
                if (Miktar < 0) { Islem = "SATIS"; Rezerv = "SATIŞ YAPILDI"; }
                if (Islem != "")
                {
                    Sistem.PozisyonKontrolGuncelle(Anahtar, Miktar + Pozisyon, SonFiyat, Rezerv);
                    Sistem.EmirSembol = EmirSembol;
                    Sistem.EmirIslem = Islem;
                    Sistem.EmirSuresi = "KIE"; // GUN, KIE, IKG
                    Sistem.EmirTipi = "Piyasa"; // Piyasa, Limitli, Piyasadan Limite
                    Sistem.EmirMiktari = Math.Abs(Miktar);
                    Sistem.EmirGonder();
                }
            }



        }
    }
}
