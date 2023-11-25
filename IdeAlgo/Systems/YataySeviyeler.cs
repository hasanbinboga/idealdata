using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class YataySeviyeler : IdealSistem
    {
        public YataySeviyeler()
        {
            var Seviyeler = new List<float>();
            //istediğiniz kadar destek ve direnç seviyeesi ekleyebilirsiniz. 
            //Seviyeler küçükten büyüğe doğru gitmeli.
            Seviyeler.Add(112.000F);
            Seviyeler.Add(114.000F);
            Seviyeler.Add(116.000F);
            Seviyeler.Add(118.000F);
            Seviyeler.Add(120.000F);
            Seviyeler.Add(122.000F);
            Seviyeler.Add(124.000F);

            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatSec("Kapanis");

            for (int i = 0; i < Seviyeler.Count; i++)
            {
                Sistem.Cizgiler[i + 10].ActiveBool = true;
                Sistem.Cizgiler[i + 10].Deger = Sistem.Liste(Seviyeler[i]);
                Sistem.Cizgiler[i + 10].Panel = 1;
                Sistem.Cizgiler[i + 10].Renk = Color.IndianRed;
                Sistem.Cizgiler[i + 10].Stil = 2;
            }

            var KesimYonu = 0;
            var KesimSeviyesi = 0.0;
            var Adim = 0.250f; //Çizgi kırıldıktan sonra 250 puan daha giderse AL (vey SAT)
            var SonYon = "";
            for (int i = 1; i < V.Count; i++)
            {
                for (int j = 0; j < Seviyeler.Count; j++)
                {
                    if (C[i - 1] < Seviyeler[j] && C[i] >= Seviyeler[j])
                    {
                        KesimYonu = 1;
                        KesimSeviyesi = Seviyeler[j];
                    }
                    else if (C[i - 1] > Seviyeler[j] && C[i] <= Seviyeler[j])
                    {
                        KesimYonu = -1;
                        KesimSeviyesi = Seviyeler[j];
                    }
                }
                if (KesimYonu == 1 && C[i] >= KesimSeviyesi + Adim && SonYon != "A")
                {
                    Sistem.Yon[i] = "A";
                    SonYon = Sistem.Yon[i];
                    KesimYonu = 0;
                }
                if (KesimYonu == -1 && C[i] <= KesimSeviyesi - Adim && SonYon != "S")
                {
                    Sistem.Yon[i] = "S";
                    SonYon = Sistem.Yon[i];
                    KesimYonu = 0;
                }
            } 

        }
    }
}
