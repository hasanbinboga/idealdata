using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class PacalSistem : IdealSistem
    {
        public PacalSistem()
        {
            var Lot = 1;
            var EklemeMarj = 0.500;
            var KapamaMarj = 0.500;

            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatSec("Kapanis");
            var H = Sistem.GrafikFiyatSec("Yuksek");
            var L = Sistem.GrafikFiyatSec("Dusuk");

            var XX = Sistem.RSI(100);
            var X1 = Sistem.MA(XX, "Exp", 2);
            var X2 = Sistem.MA(XX, "Exp", 200);

            var POZLIST = Sistem.Liste(0);
            var MIKTARLIST = Sistem.Liste(0);
            var FIYATLIST = Sistem.Liste(0);
            var AVRFIYATLIST = Sistem.Liste(0);
            var KZLIST = Sistem.Liste(0);
            var Pozisyon = 0.0f;
            var Miktar = 0.0f;
            var SonYon = "";
            var AvrFiyat = 0.0f;
            var Fiyat = 0.0f;
            var ToplamKarZarar = 0.0f;

            for (int i = V.Count - 5000; i < V.Count; i++)
            {
                var AlisSinyal = X1[i - 1] < X2[i - 1] && X1[i] >= X2[i];
                var SatisSinyal = X1[i - 1] > X2[i - 1] && X1[i] <= X2[i];

                POZLIST[i] = Pozisyon;
                AVRFIYATLIST[i] = AVRFIYATLIST[i - 1];
                FIYATLIST[i] = FIYATLIST[i - 1];
                if (AlisSinyal && SonYon != "A")  // alış sinyal
                {
                    Miktar = -Pozisyon + Lot;
                    MIKTARLIST[i] = Miktar;
                    FIYATLIST[i] = C[i];
                    AvrFiyat = C[i];
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = Lot;
                    POZLIST[i] = Pozisyon;
                    SonYon = "A";
                    Sistem.Yon[i] = SonYon;
                }
                else if (SatisSinyal && SonYon != "S")  // satış sinyal
                {
                    Miktar = -Pozisyon - Lot;
                    MIKTARLIST[i] = Miktar;
                    FIYATLIST[i] = C[i];
                    AvrFiyat = C[i];
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = -Lot;
                    POZLIST[i] = Pozisyon;
                    SonYon = "S";
                    Sistem.Yon[i] = SonYon;
                }
                else if (SonYon == "A" && H[i] > AvrFiyat + KapamaMarj)  // alıştan flate
                {
                    Miktar = -Pozisyon;
                    MIKTARLIST[i] = Miktar;
                    Fiyat = Sistem.SayiYuvarla(AvrFiyat + KapamaMarj, 0.025);
                    FIYATLIST[i] = Fiyat;
                    AvrFiyat = Fiyat;
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = 0;
                    POZLIST[i] = Pozisyon;
                    SonYon = "F";
                    Sistem.Yon[i] = SonYon;
                }
                else if (SonYon == "S" && L[i] < AvrFiyat - KapamaMarj)  // satıştan flate
                {
                    Miktar = -Pozisyon;
                    MIKTARLIST[i] = Miktar;
                    Fiyat = Sistem.SayiYuvarla(AvrFiyat - KapamaMarj, 0.025);
                    FIYATLIST[i] = Fiyat;
                    AvrFiyat = Fiyat;
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = 0;
                    POZLIST[i] = Pozisyon;
                    SonYon = "F";
                    Sistem.Yon[i] = SonYon;
                }
                else if (SonYon == "A" && L[i] < AvrFiyat - EklemeMarj)  // alış pozisyon ekle
                {
                    Miktar = Pozisyon * 2;
                    MIKTARLIST[i] = Miktar;
                    Fiyat = Sistem.SayiYuvarla(AvrFiyat - EklemeMarj, 0.025);
                    FIYATLIST[i] = Fiyat;
                    AvrFiyat = (Pozisyon * AvrFiyat + Fiyat * Miktar) / (Pozisyon + Miktar);
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = Pozisyon + Miktar;
                    POZLIST[i] = Pozisyon;
                    Sistem.Yon[i] = SonYon;
                }
                else if (SonYon == "S" && H[i] > AvrFiyat + EklemeMarj)  // satış pozisyon ekle
                {
                    Miktar = Pozisyon * 2;
                    MIKTARLIST[i] = Miktar;
                    Fiyat = Sistem.SayiYuvarla(AvrFiyat + EklemeMarj, 0.025);
                    FIYATLIST[i] = Fiyat;
                    AvrFiyat = (Pozisyon * AvrFiyat + Fiyat * Miktar) / (Pozisyon + Miktar);
                    AVRFIYATLIST[i] = AvrFiyat;
                    Pozisyon = POZLIST[i - 1] + Miktar;
                    POZLIST[i] = Pozisyon;
                    Sistem.Yon[i] = SonYon;
                }
                ToplamKarZarar = ToplamKarZarar - C[i] * MIKTARLIST[i];
                KZLIST[i] = ToplamKarZarar + C[i] * POZLIST[i];
                if (POZLIST[i] != POZLIST[i - 1])
                {
                    if (POZLIST[i] > 0)
                        Sistem.YaziEkle("POZ=" + POZLIST[i].ToString(), 1, i, L[i] - 0.200f, Color.Lime, "Tahoma", 10);
                    else if (POZLIST[i] < 0)
                        Sistem.YaziEkle("POZ=" + POZLIST[i].ToString(), 1, i, H[i] + 0.200f, Color.Red, "Tahoma", 10);
                    else if (POZLIST[i] == 0)
                        Sistem.YaziEkle("POZ=" + POZLIST[i].ToString(), 1, i, C[i] - 0.000f, Color.Gold, "Tahoma", 10);

                }

            }


            Sistem.Cizgiler[0].Deger = X1;
            Sistem.Cizgiler[1].Deger = X2;
            Sistem.Cizgiler[2].Deger = POZLIST;
            Sistem.Cizgiler[3].Deger = MIKTARLIST;
            Sistem.Cizgiler[4].Deger = AVRFIYATLIST;
            Sistem.Cizgiler[5].Deger = FIYATLIST;
            Sistem.Cizgiler[6].Deger = KZLIST;
        }
    }
}
