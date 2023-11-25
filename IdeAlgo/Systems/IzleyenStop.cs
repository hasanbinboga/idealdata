using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Systems
{
    class IzleyenStop : IdealSistem
    {

        public IzleyenStop()
        {
            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatSec("Kapanis");

            var XX = C;
            var X1 = Sistem.MA(XX, "Exp", 10);
            var X2 = Sistem.MA(XX, "Exp", 50);

            var YY = Sistem.RSI(100);
            var Y1 = Sistem.MA(YY, "Exp", 10);
            var Y2 = Sistem.MA(YY, "Exp", 200);

            var ZZ = Sistem.IMI(80);
            var Z1 = Sistem.MA(ZZ, "Exp", 10);
            var Z2 = Sistem.MA(ZZ, "Exp", 200);


            var IZLEYENSTOP = Sistem.Liste(0);
            var KARAL = Sistem.Liste(0);


            var SonYon = "";
            var FlatOncesiYon = "";
            for (int i = 1; i < Sistem.BarSayisi; i++)
            {
                var IndikatorAlis = X1[i] > X2[i] && Y1[i] > Y2[i] && Z1[i] > Z2[i];
                var IndikatorSatis = X1[i] < X2[i] && Y1[i] < Y2[i] && Z1[i] < Z2[i];

                IZLEYENSTOP[i] = Sistem.IzleyenStopYuzde(1.5, i);
                if (IZLEYENSTOP[i] == 0) IZLEYENSTOP[i] = C[i];

                KARAL[i] = Sistem.KarAlYuzde(2.5, i);
                if (KARAL[i] == 0) KARAL[i] = C[i];

                if ((C[i] < IZLEYENSTOP[i] || C[i] >= KARAL[i]) && SonYon == "A")  // alıştan flate
                {
                    FlatOncesiYon = SonYon;
                    SonYon = "F";
                    Sistem.Yon[i] = "F";
                }
                else if ((C[i] > IZLEYENSTOP[i] || C[i] <= KARAL[i]) && SonYon == "S")  // satıştan flate
                {
                    FlatOncesiYon = SonYon;
                    SonYon = "F";
                    Sistem.Yon[i] = "F";
                }
                else if (IndikatorAlis && SonYon != "A" && FlatOncesiYon != "A") // alış
                {
                    FlatOncesiYon = "";
                    SonYon = "A";
                    Sistem.Yon[i] = "A";
                }
                else if (IndikatorSatis && SonYon != "S" && FlatOncesiYon != "S") // satış
                {
                    FlatOncesiYon = "";
                    SonYon = "S";
                    Sistem.Yon[i] = "S";
                }
            }

            Sistem.Cizgiler[0].Deger = X1;
            Sistem.Cizgiler[1].Deger = X2;
            Sistem.Cizgiler[2].Deger = IZLEYENSTOP;
            Sistem.Cizgiler[3].Deger = C;
            Sistem.Cizgiler[4].Deger = KARAL;


            Sistem.DolguEkle(3, 2, Color.Green, Color.Red);
        }
    }
}
