using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Indicators
{
    class OtoTrend :IdealSistem
    {
        public OtoTrend()
        {
            var YKS1 = Sistem.OtoTrendYukselen(1200, 10); //İlk değer son kaç bar içinde trend aranıyor, ikinci değer, son kaç barı dikkate alma
            Sistem.Cizgiler[0].Deger = YKS1;

            var DSN1 = Sistem.OtoTrendDusen(1600, 10);
            Sistem.Cizgiler[1].Deger = DSN1;

            var DSN2 = Sistem.OtoTrendDusen(200, 3);
            Sistem.Cizgiler[2].Deger = DSN2;

        }
    }
}
