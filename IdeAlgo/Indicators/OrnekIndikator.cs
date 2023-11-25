using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Indicators
{
    class OrnekIndikator : IdealSistem
    {
        
        public OrnekIndikator()
        {
            var Sembol1 = Sistem.Sembol;
            var Veriler1 = Sistem.GrafikVerileri;

            var Sembol2 = "IMKBX'XU100";
            var Veriler2 = Sistem.GrafikVerileriniOku(Sembol2, Sistem.Periyot);
            Veriler2 = Sistem.GrafikVerilerindeTarihHizala(Veriler1, Veriler2);
            var data2 = Sistem.GrafikFiyatOku(Veriler2, "Kapanis");

            var Sembol3 = "VIP'VIP-X030";
            var Veriler3 = Sistem.GrafikVerileriniOku(Sembol3, Sistem.Periyot);
            Veriler3 = Sistem.GrafikVerilerindeTarihHizala(Veriler1, Veriler3);
            var data3 = Sistem.GrafikFiyatOku(Veriler3, "Kapanis");

            var Sembol4 = "FX'EURUSD";
            var Veriler4 = Sistem.GrafikVerileriniOku(Sembol4, Sistem.Periyot);
            Veriler4 = Sistem.GrafikVerilerindeTarihHizala(Veriler1, Veriler4);
            var data4 = Sistem.GrafikFiyatOku(Veriler4, "Kapanis");

            var Sembol5 = "IMKBH'HALKB";
            var Veriler5 = Sistem.GrafikVerileriniOku(Sembol5, Sistem.Periyot);
            Veriler5 = Sistem.GrafikVerilerindeTarihHizala(Veriler1, Veriler5);
            var data5 = Sistem.GrafikFiyatOku(Veriler5, "Kapanis");


            // hesaplanan verileri çizgilere aktar
            Sistem.Cizgiler[0].Deger = data2;
            Sistem.Cizgiler[0].Aciklama = Sembol2;

            Sistem.Cizgiler[1].Deger = data3;
            Sistem.Cizgiler[1].Aciklama = Sembol3;

            Sistem.Cizgiler[2].Deger = data4;
            Sistem.Cizgiler[2].Aciklama = Sembol4;

            Sistem.Cizgiler[3].Deger = data5;
            Sistem.Cizgiler[3].Aciklama = Sembol5;
            // zemin yazısı
            var Renk1 = Sistem.Renk(70, 255, 50, 50);
            Sistem.ZeminYazisiEkle("iDeal", 1, 500, 50, Renk1, "Tahoma", 50);

            var Renk2 = Sistem.Renk(80, 80, 200, 80);
            Sistem.ZeminYazisiEkle("Professional", 1, 320, 100, Renk2, "Tahoma", 50);

            var Renk3 = Sistem.Renk(70, 50, 100, 50);
            Sistem.ZeminYazisiEkle("Trading Platform", 1, 150, 150, Renk3, "Tahoma", 50);


            var Renk4 = Sistem.Renk(70, 50, 50, 180);
            Sistem.ZeminYazisiEkle("HALK BANKASI", 2, 300, 30, Renk4, "Tahoma", 30);

            var Renk5 = Sistem.Renk(70, 50, 100, 200);
            Sistem.ZeminYazisiEkle("BIST 100", 3, 300, 30, Renk5, "Tahoma", 30);

            var Renk6 = Sistem.Renk(70, 50, 100, 200);
            Sistem.ZeminYazisiEkle("VIOP ENDEKS 30", 4, 300, 30, Renk6, "Tahoma", 30);

            var Renk7 = Sistem.Renk(70, 50, 100, 200);
            Sistem.ZeminYazisiEkle("EURO/DOLAR", 5, 300, 30, Renk7, "Tahoma", 30);





            // strateji
            for (int i = 1; i < Veriler1.Count; i++)
            {
                //if ()
                //   Sistem.Yon[i] = "A";  // alış
                //if ()
                //   Sistem.Yon[i] = "S";  // satış
            }

        }
    }
}
