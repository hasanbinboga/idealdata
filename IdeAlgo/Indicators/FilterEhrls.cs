using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    public class FilterEhrls : IdealSistem
    {
        
        public FilterEhrls()
        {
            var ti = 15;
            var pr = Sistem.GrafikFiyatSec("OrtaNokta");

            // coef - boş liste oluştur 
            var coef = new List<float>(new float[Sistem.BarSayisi]);

            // sonuç - boş liste oluştur 
            var sonuc = new List<float>(new float[Sistem.BarSayisi]);

            // coef hesapla
            for (int i = 5; i < Sistem.BarSayisi; i++)
                coef[i] = Math.Abs(pr[i] - pr[i - 5]);

            // sonuç hesapla
            for (int i = ti; i < Sistem.BarSayisi; i++)
            {
                coef[i] = Math.Abs(pr[i] - pr[i - 5]);
                float deger1 = 0;
                float deger2 = 0;
                for (int k = i - ti; k < i; k++)
                {
                    deger1 += Convert.ToSingle(coef[k] * pr[k]);
                    deger2 += Convert.ToSingle(coef[k]);
                }
                sonuc[i] = deger1 / deger2;

            }
            Sistem.Cizgiler[0].Deger = sonuc;

        }
    }
}
