using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Tricks
{
    class ZemineVeriYazmak : IdealSistem
    {
        public ZemineVeriYazmak()
        {
            var Sembol1 = "FX'USDTRY";
            var Sembol2 = "FX'EURUSD";
            var Derinlik = Sistem.DerinlikVerisiOku(Sistem.Sembol);
            var Alis = Derinlik.Bids[0].Price;
            var ALot = Derinlik.Bids[0].Size;
            var AEmir = Derinlik.Bids[0].OrderCount;
            var Satis = Derinlik.Asks[0].Price;
            var SLot = Derinlik.Asks[0].Size;
            var SEmir = Derinlik.Asks[0].OrderCount;

            Sistem.ZeminYazisiEkle("Derinlik 1.Kademe Bilgileri", 1, 450, 20, Color.Cyan, "Tahoma", 13);
            Sistem.ZeminYazisiEkle("XU100 = " + " " + Sistem.SonFiyat("IMKBX'XU100"), 1, 160, 80, Color.Gray, "Tahoma", 15);
            Sistem.ZeminYazisiEkle("USDTRY= " + " " + Sistem.SonFiyat(Sembol1), 1, 160, 20, Color.Gray, "Tahoma", 15);
            Sistem.ZeminYazisiEkle("EURUSD= " + " " + Sistem.SonFiyat(Sembol2), 1, 160, 50, Color.Gray, "Tahoma", 15);
            Sistem.ZeminYazisiEkle("Alış = " + " " + Alis.ToString(), 1, 400, 60, Color.Gold, "Tahoma", 12);
            Sistem.ZeminYazisiEkle("Alış Lot = " + " " + ALot.ToString(), 1, 400, 80, Color.Gold, "Tahoma", 12);
            Sistem.ZeminYazisiEkle("Alış Emir= " + " " + AEmir.ToString(), 1, 400, 100, Color.Gold, "Tahoma", 12);
            Sistem.ZeminYazisiEkle("Satış = " + " " + Satis.ToString(), 1, 600, 60, Color.Gold, "Tahoma", 12);
            Sistem.ZeminYazisiEkle("Satış Lot = " + " " + SLot.ToString(), 1, 600, 80, Color.Gold, "Tahoma", 12);
            Sistem.ZeminYazisiEkle("Satış Emir= " + " " + SEmir.ToString(), 1, 600, 100, Color.Gold, "Tahoma", 12);

        }
    }
}
