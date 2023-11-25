using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    class OrnekPivot : IdealSistem
    {
         
        public OrnekPivot()
        {
            // haftalık verileri oku
            var HaftalikVeriler = Sistem.GrafikVerileriniOku(Sistem.Sembol, "H");

            // boş veri listeleri yarat
            var PH = Sistem.Liste(0);
            var PL = Sistem.Liste(0);
            var PVT = Sistem.Liste(0);

            // döngü ile haftalık pivot, prohigh, prolow hesapla
            for (int i = 1; i < HaftalikVeriler.Count; i++)
            {
                // pivot önceki barın (H+L+C)/3 değeri
                PVT[i] = (HaftalikVeriler[i - 1].High + HaftalikVeriler[i - 1].Low + HaftalikVeriler[i - 1].Close) / 3;
                // pro high hesapla
                PH[i] = 2 * PVT[i] - HaftalikVeriler[i - 1].Low;
                // pro low hesapla
                PL[i] = 2 * PVT[i] - HaftalikVeriler[i - 1].High;
            }


            // 0 nolu çizgi
            Sistem.Cizgiler[0].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, HaftalikVeriler, PH);
            Sistem.Cizgiler[0].Aciklama = "Pro High , Hafta";
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Renk = Sistem.Renk(255, 0, 0, 255);
            Sistem.Cizgiler[0].Kalinlik = 5;

            // 1 nolu çizgi
            Sistem.Cizgiler[1].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, HaftalikVeriler, PL);
            Sistem.Cizgiler[1].Aciklama = "Pro Low , Hafta";
            Sistem.Cizgiler[1].ActiveBool = true;
            Sistem.Cizgiler[1].Renk = Sistem.Renk(255, 255, 0, 0);
            Sistem.Cizgiler[1].Kalinlik = 5;


            // 2 nolu çizgi
            Sistem.Cizgiler[2].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, HaftalikVeriler, PVT);
            Sistem.Cizgiler[2].Aciklama = "Pro Low , Hafta";
            Sistem.Cizgiler[2].ActiveBool = true;
            Sistem.Cizgiler[2].Renk = Sistem.Renk(255, 0, 0, 0);
            Sistem.Cizgiler[2].Kalinlik = 2;


            // dolgu tamınla
            var DolguRengi = Sistem.Renk(40, 100, 100, 255);
            Sistem.DolguEkle(0, 1, DolguRengi, DolguRengi); 

        }
    }
}
