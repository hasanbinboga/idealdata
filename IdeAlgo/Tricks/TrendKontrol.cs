using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricks
{
    class TrendKontrol: IdealSistem
    {
        public TrendKontrol()
        {
            var TrendListesi = new List<string>();
            // Trendleri Ekle  SEMBOL      PERIYOT  1.TARIH        1.SAAT      1.FIYAT    2.TARIH        2.SAAT      2.FIYAT
            TrendListesi.Add("IMKBH'GARAN  ;  G  ;  23/02/2017  ;  00:00:00  ;   9.10  ;  04/02/2018  ;  00:00:00  ;   9.20");
            TrendListesi.Add("IMKBH'SAHOL  ;  G  ;  19/05/2017  ;  00:00:00  ;  10.10  ;  01/03/2018  ;  00:00:00  ;  12.20");



            // Trendleri Kontrol ET  
            // Deger ile trendin son bardaki değeri gelir.
            // Trend yukarı kestiyse Sonuc = "Y" 
            // Trend aşağı kestiyse Sonuc = "A"
            // Trend kırılmadıysa Sonuc = ""
            string Mesaj = "";
            foreach (var item in TrendListesi)
            {
                decimal Deger;
                var Sonuc = Sistem.TrendKontrol(item, out Deger);
                if (Sonuc != null)
                {
                    Mesaj += Sonuc + "   " + Deger.ToString() + "\r\n";
                }
            }
            Sistem.Mesaj(Mesaj);


        }
    }
}
