using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Queries
{
    public class AylikGetiriTablosu : IdealSistem
    {
         

        public AylikGetiriTablosu()
        {
            var baslangicYil = 2003;

            var vAy = Sistem.GrafikVerileriniOku(Sistem.Sembol, "A");
            var cAy = Sistem.GrafikFiyatOku(vAy, "Kapanis");

            var vyil = Sistem.GrafikVerileriniOku(Sistem.Sembol, "Y");
            var yillar = new Dictionary<int, int>();


            // Tablo Yarat
            var tabloAd = "Aylık Getiri Tablosu "; //İSİM VER
            var sutunGenislik = new int[16] { 75, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45, 45 }; //SÜTUN SAYISI VE SÜTUN GENİŞLİKLERİ
            for (int i = 0; i < sutunGenislik.Length; i++)
                sutunGenislik[i] = 70;
            var sutunHizala = new int[16] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }; //HİZALAMA (1=ORTALA)
            var sutunBaslik = new string[16] { "Yıl", "Yıl %", "Küm %", "", "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" }; //BAŞLIKLAR
            Sistem.Tablo(tabloAd, 50, 100, 1180, 400, 16, 300, sutunGenislik, sutunHizala, sutunBaslik, 1, 12); //TABLOYU EKRANA GETİR

            // Ayları Yazdır
            int satir = 0;
            int sutun = vAy[1].Date.Month - 1;
            Sistem.TabloYazdir(tabloAd, 0, 0, vAy[0].Date.Year.ToString(), Color.Gold, Color.Black);
            yillar[vAy[0].Date.Year] = satir;
            for (int i = 1; i < vAy.Count; i++)
            {
                Sistem.TabloYazdir(tabloAd, sutun + 4, satir, "", Color.Gold, Color.Black);
                if (cAy[i] > 0 && cAy[i - 1] > 0)
                {
                    float Yuzde = 100 * (cAy[i] - cAy[i - 1]) / cAy[i - 1];
                    var Renk = Yuzde < 0 ? Color.Red : Color.Green;
                    Sistem.TabloYazdir(tabloAd, sutun + 4, satir, Yuzde.ToString("0.00"), Renk, Color.White);
                }
                sutun++;
                if (vAy[i].Date.Month == 12)
                {
                    satir++;
                    sutun = 0;
                }
                if (vAy[i].Date.Month == 1)
                {
                    Sistem.TabloYazdir(tabloAd, 0, satir, vAy[i].Date.Year.ToString(), Color.Gold, Color.Black);
                    yillar[vAy[i].Date.Year] = satir;
                }
            }
            // Yılları Yazdır
            for (int i = 0; i < vyil.Count; i++)
            {
                var yil = vyil[i].Date.Year;
                float yuzde = 100 * (vyil[i].Close - vyil[i].Open) / vyil[i].Open;
                satir = yillar[yil];
                var renk = yuzde < 0 ? Color.Red : Color.Green;
                Sistem.TabloYazdir(tabloAd, 1, satir, yuzde.ToString("0.00"), renk, Color.White);
            }
            // Yillar Kumulatif Getiri
            int baslangicBar = 0;
            for (int i = 0; i < vyil.Count; i++)
            {
                if (vyil[i].Date.Year == baslangicYil)
                {
                    baslangicBar = i;
                    break;
                }
            }
            float baslangicDeger = vyil[baslangicBar].Open;
            for (int i = baslangicBar; i < vyil.Count; i++)
            {
                var Yil = vyil[i].Date.Year;
                float yuzde = 100 * (vyil[i].Close - baslangicDeger) / baslangicDeger;
                satir = yillar[Yil];
                var Renk = yuzde < 0 ? Color.Red : Color.Green;
                Sistem.TabloYazdir(tabloAd, 2, satir, yuzde.ToString("0.00"), Renk, Color.White);
            }


        }
    }
}
