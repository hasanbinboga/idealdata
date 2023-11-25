using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Queries
{
    class Ornek : IdealSistem
    {
        public Ornek()
        {

            Sistem.SorguBaslik[0] = "Açılış";
            Sistem.SorguBaslik[1] = "Yüksek";
            Sistem.SorguBaslik[2] = "Düşük";
            Sistem.SorguBaslik[3] = "Kapanış";
            Sistem.SorguBaslik[4] = "Hacim";
            Sistem.SorguBaslik[6] = "RSI 14";
            Sistem.SorguBaslik[7] = "MOM 12";


            var RSI = Sistem.RSI(14);
            var MOM = Sistem.Momentum(12);
            var SonRSI = RSI[Sistem.BarSayisi - 1];
            var SonMOM = MOM[Sistem.BarSayisi - 1];


            // filtrele
            if (SonRSI < 40.0F || SonRSI > 60.0F)
            {
                Sistem.SorguDeger[0] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].Open;
                Sistem.SorguDeger[1] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].High;
                Sistem.SorguDeger[2] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].Low;
                Sistem.SorguDeger[3] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].Close;
                Sistem.SorguDeger[4] = Sistem.GrafikVerileri[Sistem.BarSayisi - 1].Vol;
                Sistem.SorguDeger[6] = SonRSI;
                Sistem.SorguDeger[7] = SonMOM;

                if (SonRSI < 30.0F)
                    Sistem.SorguAciklama = "Aşırı Satım";
                else if (SonRSI > 70.0F)
                    Sistem.SorguAciklama = "Aşırı Alım";
                else
                    Sistem.SorguAciklama = "Normal";

                Sistem.SorguEkle();
            } 

        }
    }
}
