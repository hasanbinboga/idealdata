using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Queries
{
    class Ornek2: IdealSistem
    {
        public Ornek2()
        {
            Sistem.SorguBaslik[0] = "Kapanış";
            Sistem.SorguBaslik[1] = "RSI 14";
            Sistem.SorguBaslik[2] = "PD/DD";
            Sistem.SorguBaslik[3] = "F/K";
            Sistem.SorguOndalik[3] = 2;
            Sistem.SorguBaslik[4] = "1.Alış Lot";
            Sistem.SorguOndalik[4] = 0;
            Sistem.SorguBaslik[5] = "1.Satış Lot";
            Sistem.SorguOndalik[5] = 0;
            Sistem.SorguBaslik[6] = "5_Gün Ort";
            Sistem.SorguBaslik[7] = "22Gün Ort";
            Sistem.SorguBaslik[8] = "Gün %";
            Sistem.SorguBaslik[9] = "Hafta %";
            Sistem.SorguBaslik[10] = "Ay %";
            Sistem.SorguBaslik[11] = "Yıl %";


            var RSI = Sistem.RSI(14);
            var MA5 = Sistem.MA(5, "Simple", "Kapanis");
            var MA22 = Sistem.MA(22, "Simple", "Kapanis");
            var SonRSI = RSI[Sistem.BarSayisi - 1];
            var SonMA5 = MA5[Sistem.BarSayisi - 1];
            var SonMA22 = MA22[Sistem.BarSayisi - 1];


            var FK = (float)Sistem.YuzeyselVeri.PriceEarningValue;
            var PDDD = (float)Sistem.YuzeyselVeri.PiyDegDefDeg;
            var ALISLOT = (float)Sistem.DerinlikVeri.Bids[0].Size;
            var SATISLOT = (float)Sistem.DerinlikVeri.Asks[0].Size;


            var Sembol = "IMKBH'GARAN";
            var Derinlik = Sistem.DerinlikVerisiOku(Sembol);
            var AlisFiyatKademe0 = Derinlik.Bids[0].Price;
            var AlisLotKademe0 = Derinlik.Bids[0].Size;
            var SatisLotKademe3 = Derinlik.Bids[3].Size;


            // filtrele
            if (FK > 0)
            {
                Sistem.SorguDeger[0] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].Close;
                Sistem.SorguDeger[1] = SonRSI;
                Sistem.SorguDeger[2] = PDDD;
                Sistem.SorguDeger[3] = FK;
                Sistem.SorguDeger[4] = ALISLOT;
                Sistem.SorguDeger[5] = SATISLOT;
                Sistem.SorguDeger[6] = SonMA5;
                Sistem.SorguDeger[7] = SonMA22;
                Sistem.SorguDeger[8] = (float)Sistem.YuzeyselVeri.NetPerDay;
                Sistem.SorguDeger[9] = (float)Sistem.YuzeyselVeri.NetPerWeek;
                Sistem.SorguDeger[10] = (float)Sistem.YuzeyselVeri.NetPerMonth;
                Sistem.SorguDeger[11] = (float)Sistem.YuzeyselVeri.NetPerYear;


                if (FK < 10.0F)
                    Sistem.SorguAciklama = "Kazanç Durumu İyi";
                else if (FK > 10.0F && FK < 30.0F)
                    Sistem.SorguAciklama = "Kazanç Durumu Orta";
                else
                    Sistem.SorguAciklama = "Kazanç Durumu Kötü";

                Sistem.SorguEkle();
            }



        }
    }
}
