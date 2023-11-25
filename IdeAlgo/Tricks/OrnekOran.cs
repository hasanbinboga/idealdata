using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Tricks;

namespace Systems
{
    class OrnekOran : IdealSistem
    {
 
        public OrnekOran()
        {
            var GrafiktenGelen = Sistem.GrafikVerileri;
            var VerilerISCTR = Sistem.GrafikVerileriniOku("IMKBH'ISCTR", Sistem.Periyot);
            var VerilerHALKB = Sistem.GrafikVerileriniOku("IMKBH'HALKB", Sistem.Periyot);

            // bar sayıları farklı olabileceğinden hizalama yapmak gerekiyor
            var HizalaISCTR = Sistem.GrafikVerilerindeTarihHizala(GrafiktenGelen, VerilerISCTR);
            var HizalaHALKB = Sistem.GrafikVerilerindeTarihHizala(GrafiktenGelen, VerilerHALKB);

            var Oran = Sistem.Liste(GrafiktenGelen.Count, 0);
            for (int i = 0; i < GrafiktenGelen.Count; i++)
            {
                Oran[i] = HizalaISCTR[i].Close / HizalaHALKB[i].Close;
            }

            // 0 nolu çizgi
            Sistem.Cizgiler[0].Deger = Oran;


        }
    }
}
