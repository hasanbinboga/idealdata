using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ideal;

namespace Tricks
{
    public class OrnekDebug : IdealSistem
    {
        
        public OrnekDebug()
        {
            var KapanisGARAN = Sistem.GrafikFiyatOku("IMKBH'GARAN", "60", "Kapanis");
            Sistem.Debug("KAPANIS GARAN = " + KapanisGARAN[KapanisGARAN.Count - 1].ToString());

            var ChartGARAN = Sistem.GrafikVerileriniOku("IMKBH'GARAN", "G");
            Sistem.Debug("AÇILIŞ GARAN = " + ChartGARAN[ChartGARAN.Count - 1].Open.ToString());

            var RSIGARAN = Sistem.RSI(ChartGARAN, "14");
            Sistem.Debug("RSI GARAN = " + RSIGARAN[RSIGARAN.Count - 1].ToString());
        }
    }
}
