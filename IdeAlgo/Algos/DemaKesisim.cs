using Tricks;

namespace Algos
{
    public class DemaKesisim : IdealSistem
    {

        public DemaKesisim()
        {
            // hesapla
            var dema1 = Sistem.DEMA(5);
            var dema2 = Sistem.DEMA(21);

            // hesaplanan verileri çizgilere aktar
            Sistem.Cizgiler[0].Deger = dema1;
            Sistem.Cizgiler[1].Deger = dema2;

            // sistem strateji
            Sistem.KesismeTara(dema1, dema2);


            // algo strateji
            if (Sistem.YukariKestiyse(dema1, dema2))  // alış
                Sistem.AlgoIslem = "A";
            if (Sistem.AsagiKestiyse(dema1, dema2))  // satış
                Sistem.AlgoIslem = "S";

            // algo açıklama
            Sistem.AlgoAciklama = "DEMA1=" + dema1[Sistem.BarSayisi - 1].ToString("0.00") + "  " +
                                  "DEMA2=" + dema2[Sistem.BarSayisi - 1].ToString("0.00");

        }
    }
}
