using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class OtoTrendAlarmRobotu :IdealSistem
    {
        public OtoTrendAlarmRobotu()
        {
            string Periyot = "5";
            string Msg = "";
            string Statu = "";
            var Trendperiyodu = 800; //son 800 bar içindeki trend
            var SonXbar = 50; //son 50 barı dikkate alma

            var Liste = Sistem.YuzeyselListeGetir("IMKBH'");
            for (var i = 0; i < Liste.Count; i++)
            {
                if (Liste[i].IndexType == "100" && Sistem.Saat.CompareTo("10:00:00") > 0)
                {
                    var Sembol = Liste[i].Symbol;
                    var Kod = Liste[i].Root;
                    var V = Sistem.GrafikVerileriniOku(Sembol, Periyot);

                    Statu = " ";
                    var Yukselen = Sistem.OtoTrendYukselen(V, Trendperiyodu, SonXbar);
                    var Dusen = Sistem.OtoTrendDusen(V, Trendperiyodu, SonXbar);

                    if (V[V.Count - 1].Close < V[V.Count - Trendperiyodu].Close && V[V.Count - 1].High > Dusen[Dusen.Count - 1] && Dusen[Dusen.Count - 1] != 0)
                    {
                        Statu = "Yukarı Kırıldı";
                        Msg += Kod + "  Son Fiyat = " + V[V.Count - 1].Close + " " + " Düşen Trend Değeri = " + Dusen[Dusen.Count - 1].ToString("0.00") + "  " + "Durum =" + Statu + "\r\n";
                    }
                    else if (V[V.Count - 1].Close > V[V.Count - Trendperiyodu].Close && V[V.Count - 1].Low < Yukselen[Yukselen.Count - 1] && Yukselen[Yukselen.Count - 1] != 0)
                    {
                        Statu = "Aşağı Kırıldı";
                        Msg += Kod + "  Son Fiyat = " + V[V.Count - 1].Close + " " + " Yükselen Trend Değeri = " + Yukselen[Yukselen.Count - 1].ToString("0.00") + "  " + "Durum =" + Statu + "\r\n";
                    }

                }
            }
            Sistem.Mesaj(Msg);

        }
    }
}
