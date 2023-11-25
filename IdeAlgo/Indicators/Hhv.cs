using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    class Hhv : IdealSistem
    {
        
        public Hhv()
        {
            var MOV = Sistem.MA(3, "Simple", "Kapanis");
            var X1 = Sistem.HHV(14, "Yuksek");
            var X2 = Sistem.LLV(14, "Yuksek");

            // X3 - boş liste oluştur 
            var X3 = Sistem.Liste(0);
            // X3 - hesapla
            for (int i = 0; i < Sistem.BarSayisi; i++)
                X3[i] = (MOV[i] - X2[i]) / (X1[i] - X2[i]);

            // strateji
            Sistem.KesismeTara(X3, 0.5);

            // çizligeri göster
            Sistem.Cizgiler[0].Deger = X3;
            Sistem.Cizgiler[1].Deger = Sistem.Liste(0.5);

        }
    }
}
