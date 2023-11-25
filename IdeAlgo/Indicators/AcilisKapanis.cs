using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    class AcilisKapanis :IdealSistem
    {
     
        public AcilisKapanis()
        {
            var AcilisListe = Sistem.GrafikFiyatSec("Acilis");
            var KapanisListe = Sistem.GrafikFiyatSec("Kapanis");

            // döngü ile hesapla
            for (int i = 1; i < AcilisListe.Count; i++)
            {
                if (AcilisListe[i] > KapanisListe[i])
                    Sistem.Cizgiler[0].Deger[i] = 1.0f;
                else if (AcilisListe[i] < KapanisListe[i])
                    Sistem.Cizgiler[0].Deger[i] = -1f;
                else
                    Sistem.Cizgiler[0].Deger[i] = 0f;
            }


            // 0 nolu çizgi
            Sistem.Cizgiler[0].Panel = 2;
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Aciklama = "Açılış vs Kapanış , Yontem 1";

        }
    }
}
