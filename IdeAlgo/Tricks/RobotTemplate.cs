using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tricks
{
    class RobotTemplate : IdealSistem
    {
        public RobotTemplate()
        {
            /**********************************************************************
            * 
            * 
            *                   Hasan BİNBOĞA
            *                   Ornek Robot Şablonu
            *                   01/04/2020
            * 
            * 
            **********************************************************************/

            #region Parametreleri oku
            // İlk olarak Sisteme girdi olarak alınacak parametreler okunur.
            //Sistem Parametre listesi boş değildir. 
            //Ama sizin almak istediğiniz parametrenin değerini kontrol etmeniz gereklidir.

            //İlk olarak parametrelere varsayılan değerler atanır.

            //Örnek string (metin) veri tipinde parametre
            var parametre1 = !string.IsNullOrEmpty(Sistem.Parametreler[0]) ? Sistem.Parametreler[0] : "default";

            //Örnek double (reel sayı) veri tipinde parametre
            double parametre2;
            double.TryParse(Sistem.Parametreler[1], out parametre2);
            //Sıfır değerinin kabul edilmemesi durumunda default 1.4 değeri atanıyor.
            parametre2 = parametre2 <= 0f ? 1.4f : parametre2;

            //Örnek integer (tamsayı) veri tipinde parametre
            int parametre3;
            int.TryParse(Sistem.Parametreler[0], out parametre3);
            //Sıfır değerinin kabul edilmemesi durumunda default 4 değeri atanıyor.
            parametre3 = parametre3 <= 0 ? 4 : parametre3;
            #endregion

            #region Grafik Verilerini Oku

            // Sisteminiz içinde hesaplamalar yaparken veya döngülerde kullanmak için 
            // iDeal veri terminalinin içinde bulunan bilgilerden yararlanabilirsiniz.

            // iDeal veri terminali içinden kullanmak istediğiniz bilgiyi üç bölümden veri okutabilirsiniz
            // 1- Grafik Verileri
            // 2- Derinlik Verileri
            // 3- Yüzeysel Veriler

            /**********************************************************************/
            // 1- Grafik Fiyat Verileri
            // Grafik Sistemi yazarken doğrudan çalıştığınız grafiğin verilerini seçip işlem yapabilirsiniz

            // Grafik ekranındaki aktif endeksin aktif periyottaki kapanış değerlerini seçip, 
            // KapanisListesi isimli bir listesine  atanıyor.
            var kapanisListesi = Sistem.GrafikFiyatSec("Kapanis");

            // Diğer değerler için “Kapanis” yerine Acilis ,Yuksek ,Dusuk ,Hacim,Lot,OHLC/4,Ortalama yazılabilir.
            var acilisListesi = Sistem.GrafikFiyatSec("Acilis");
            var yuksekListesi = Sistem.GrafikFiyatSec("Yuksek");
            var dusukListesi = Sistem.GrafikFiyatSec("Dusuk");
            var hacimListesi = Sistem.GrafikFiyatSec("Hacim");
            var lotListesi = Sistem.GrafikFiyatSec("Lot");
            var ohlcListesi = Sistem.GrafikFiyatSec("OHLC/4");
            var ortalamaListesi = Sistem.GrafikFiyatSec("Ortalama");

            // O an açık olan grafikteki zaman periyodu ve endekse göre verileri almak için aşağıdaki tanımlama yapılabilir.
            var grafikVerileri = Sistem.GrafikVerileri;

            // İdeal Linq kütüphanesini desteklemediği için Take, skip, where 
            // gibi linq operatörleri kullanamıyoruz. 
            // Bu nedenle foreach döngüsü aşağıdaki gibi kullanılabilir.
            //int i = 0;
            //foreach (var lot in lotListesi)
            //{
            //    if (i < 10)
            //    {

            //        Sistem.Debug("Lot adedi:" + lot);
            //        i++;
            //    }
            //    else { break; }
            //}

            // Yada for döngüsü ile erişim sağlanabilir.
            //for (int j = 0; j < 3; j++)
            //{
            //    Sistem.Debug("Lot adedi:" + lotListesi[j]);
            //}

            // Aktif grafik ekranı dışındaki bir endeksin belirli bir periyottaki verilerini 
            // almak için aşağıdaki metodu kullanabilirsiniz.

            // Günlük EUR/USD grafik veriler sistemden alarak eurUsdVeriList listesine atanır.
            var eurUsdVeriList = Sistem.GrafikVerileriniOku("FX'EURUSD", "G");

            // Ardından grafikten bağımsız olarak fiyat bilgileri okunabilir.
            // Örneğin EUR/USD ortalama fiyatlarını şu şekilde alabiliriz.
            var eurUsdOrtalamaFiyatListesi = Sistem.GrafikFiyatOku(eurUsdVeriList, "Ortalama");

            //for (int j = 0; j < 3; j++)
            //{
            //    Sistem.Debug("Ortalama EUR/USD Fiyat:" + eurUsdOrtalamaFiyatListesi[j]);

            //}

            // İstediğiniz sembolün, belirlediğiniz periyodunun grafiğini sunucudan indirmenizi sağlar, 
            // böylece kullandığınız grafik verilerinde eksik veya yanlış olma durumunu önleyebilirsiniz.
            // Örnek
            var iscTrSembol = "IMKBH'ISCTR";
            Sistem.GrafikVerisiIndir(iscTrSembol, "G");

            /***************************************************************/
            // 2- Derinlik Verileri

            // Derinlik verileri kullanmak istediğimiz sembolü tanımlıyoruz.
            var sembol = Sistem.Sembol;

            //Sembolün tüm derinlik verilerini okuyup Derinlik isminde bir değişkene atıyoruz.
            var derinlik = Sistem.DerinlikVerisiOku(sembol);


            // Alış Kademelerindeki ilk fiyat (en iyi alış kademesi) bilgisi enIyiAlisFiyati isimli bir değişkene atıyoruz.
            var enIyiAlisFiyati = derinlik.Bids[0].Price;

            // Alış Kademelerindeki ilk Lot (en iyi alıştaki Lot Miktarı) bilgisi enIyiAlisFiyatLotAdet isimli bir değişkene atıyoruz.
            var enIyiAlisFiyatLotAdet = derinlik.Bids[0].Size;

            // Satış Kademelerindeki ilk fiyat (en iyi satış kademesi) bilgisi enIyiSatisFiyati isimli bir değişkene atıyoruz.
            var enIyiSatisFiyati = derinlik.Asks[0].Price;

            // Satış Kademelerindeki ilk Lot (en iyi satıştaki Lot Miktarı) bilgisi enIyiSatisFiyatLotAdet isimli bir değişkene atıyoruz.
            var enIyiSatisFiyatLotAdet = derinlik.Asks[0].Size;

            Sistem.Debug("En iyi alış bilgileri - Fiyat: " + enIyiAlisFiyati + " Lot: " + enIyiAlisFiyatLotAdet);

            Sistem.Debug("En iyi satış bilgileri - Fiyat: " + enIyiSatisFiyati + " Lot: " + enIyiSatisFiyatLotAdet);

            foreach (var alisFiyat in derinlik.Bids)
            {
                // Time hhmmss formatındadır bunu Time veri tipine çevirmek için  
                var timeSpan = new TimeSpan(
                    Convert.ToInt32(alisFiyat.Time.Substring(0, 2)),
                    Convert.ToInt32(alisFiyat.Time.Substring(2, 2)),
                    Convert.ToInt32(alisFiyat.Time.Substring(4, 2)));

                Sistem.Debug("Alış Fiyatı bilgileri - ColPrice: " + alisFiyat.ColPrice + " Emir Sayısı: " + alisFiyat.OrderCount +
                             " Alış Fiyatı: " + alisFiyat.Price + " Rate: " + alisFiyat.Rate + " Hacim: " + alisFiyat.Size +
                             "Time:" + timeSpan + " GetImkbVolume: " + alisFiyat.GetImkbVolume());

            }
            /***************************************************************/
            // 3- Yüzeysel Veriler
            // Belirtilen sembol ile ilişkili hızlı veri erişimi için kullanılan metotlardır.

            //Tüm yüzeysel verilere ulaşmak için
            var yuzeyselVeriler = Sistem.YuzeyselVeriOku(Sistem.Sembol);

            // Yüzeysel Verilere tek tek metot bazında ulaşmak için
            var kapanisGunMetot = Sistem.OncekiKapanisGun(Sistem.Sembol);

            Sistem.Debug("Gün sonu kapanış  Sistem.OncekiKapanisGun(Sistem.Sembol):" + kapanisGunMetot +
                         " yuzeyselVeriler.PrevCloseDay: " + yuzeyselVeriler.PrevCloseDay);


            var altiAylikKapanis = Sistem.OncekiKapanisAltiAy(Sistem.Sembol);

            Sistem.Debug("Son altı aylık kapanış  Sistem.OncekiKapanisAltiAy(Sistem.Sembol): " + altiAylikKapanis +
                        " yuzeyselVeriler.PrevCloseMonth6: " + yuzeyselVeriler.PrevCloseMonth6);



            #endregion

            #region İndikatör dereğlerini oku

            /********************************************************/
            // Hareketli ortalama indikatörü için Sistem.MA kullanılabilir.
            // MA metodu olarak şunlar kullanılabilir: Simple, Exponantial, Weighted, Wilder, TimeSeries, Triangular, Variable, Volume
            // Ayrıca fiyat listesi olarak açılış, kapanış, yüksek, düşük,
            // Ağırlıklı ortalama, (H+L)/2 veya (H+L+C)/3 fiyatları kullanılabilir.

            var basitMa = Sistem.MA(kapanisListesi, "Simple", 5);

            // Sistem.MA2 ve Sistem.MA3; MA’nın MA’sını 2 ve 3 kere almaya yarayan bir fonksiyondur.
            var basitMa2 = Sistem.MA2(kapanisListesi, "Simple", 5);
            var basitMa3 = Sistem.MA3(kapanisListesi, "Simple", 5);

            var hacimHizaliMa = Sistem.MA(kapanisListesi, "Volume", 5);

            Sistem.Debug("Kapanış 0: " + kapanisListesi[kapanisListesi.Count - 1]);
            Sistem.Debug("MA Simple: " + basitMa[basitMa.Count - 1] +
                         " MA2 Simple : " + basitMa2[basitMa2.Count - 1] +
                         " MA3 Simple : " + basitMa3[basitMa3.Count - 1]);
            Sistem.Debug("MA Değerleri Simple: " + basitMa[basitMa.Count - 1] + " Volume Adj: " + hacimHizaliMa[hacimHizaliMa.Count - 1]);



            /********************************************************/

            // Belirtilen periyottaki Zirve değerlerini algoritmanızda kullanabilirsiniz.
            var zirveList = Sistem.Zirve("15");

            var sonZirve = 0f;
            var cnt = 0;
            for (int i = zirveList.Count - 1; i >= 0; i--)
            {
                if (zirveList[i] != sonZirve)
                {
                    Sistem.Debug("Zirve " + cnt + ": " + zirveList[i]);

                    sonZirve = zirveList[i];
                    cnt++;
                    if (cnt > 2) { break; }
                }
            }

            /********************************************************/

            // Benzer şekilde belirtilen periyottaki dip değerlerini okumak mümkündür.
            Sistem.Dip("15");







            #endregion

            #region Parametre, grafik verileri ve indikatör değerleri ile işlemleri yap.

            /********************************************************/
            // Heikin Ashi barlarını hesaplatarak sistem içinde kullanmak için 
            var closeHeikin = Sistem.Liste(0);
            var openHeikin = Sistem.Liste(0);

            // Heikin'e Çevir
            for (var i = 1; i < grafikVerileri.Count; i++)
            {
                closeHeikin[i] = (grafikVerileri[i].Open + grafikVerileri[i].High + grafikVerileri[i].Low + grafikVerileri[i].Close) / 4;
                openHeikin[i] = (grafikVerileri[i - 1].Open + grafikVerileri[i - 1].Close) / 2;
                grafikVerileri[i].High = Math.Max(grafikVerileri[i].High, grafikVerileri[i].Close);
                grafikVerileri[i].High = Math.Max(grafikVerileri[i].High, grafikVerileri[i].Open);
                grafikVerileri[i].Low = Math.Min(grafikVerileri[i].Low, grafikVerileri[i].Close);
                grafikVerileri[i].Low = Math.Min(grafikVerileri[i].Low, grafikVerileri[i].Open);
            }

            var heikinWma = Sistem.MA(closeHeikin, "Weighted", 14);



            /********************************************************************/
            // Üzerinde çalıştığınız grafiğin Bar sayısını okumanızı sağlar
            var barSayisi = Sistem.BarSayisi;

            // Üzerinde çalıştığınız grafiğin ait olduğu Sembol bilgisini almanızı sağlar
            var grafikSembol = Sistem.Sembol;


            /********************************************************************/
            //Aşağıdaki metot ile bir liste için toplan değeri hesaplatabilirsiniz.
            Sistem.Sum(kapanisListesi);

            // Aşağıdaki Sum metodu, listenizin tüm elamanları için işlem yaparak, 
            // her elamanın kendinden önceki “n” kadar elamanın toplamını içeren yeni bir liste döndürür.
            var n = 10;
            Sistem.Sum(kapanisListesi, n);


            /********************************************************************/
            // Farklı periyotlardaki verilerin o anki periyoda uygulanması ile ilgili çok Önemli bir özellik bulunmaktadır.
            // Üst Dönem Verileri alt dönem grafiklerde çizdirebilmeniz için listeleri ayarlar.
            // Örneğin ekranda 5dk periyodunda grafik görünmekteyken bu grafik üzerine haftalık periyottaki
            // grafik verilerini almak için aşağıdaki yöntem kullanılabilir.
            var haftaVeriler = Sistem.GrafikVerileriniOku(Sistem.Sembol, "H");
            var haftaYuksek = Sistem.GrafikFiyatOku(Sistem.Sembol, "H", "Yuksek");
            var haftaDusuk = Sistem.GrafikFiyatOku(Sistem.Sembol, "H", "Dusuk");
            var haftaClose = Sistem.GrafikFiyatOku(Sistem.Sembol, "H", "Kapanis");

            // Sistem.DonemCevir(Veriler, UstDonemVerileri, UstDonemCevrilecekData):
            var haftaDonusumClose = Sistem.DonemCevir(Sistem.GrafikVerileri, haftaVeriler, haftaClose);
            var haftaDonusumLow = Sistem.DonemCevir(Sistem.GrafikVerileri, haftaVeriler, haftaDusuk);
            var haftaDonusumHigh = Sistem.DonemCevir(Sistem.GrafikVerileri, haftaVeriler, haftaYuksek);


            /********************************************************************/
            // Geliştireceğiniz sistem birden fazla sembolün korelasyonuna dayanabilir.
            // Bunun için ilgilendiğiniz tüm sembollerin aynı zaman dilimindeki  verilerini temel alarak
            // gerekli hesaplamalkarın yapılması gereklidir. 
            // Bu hesaplamayı yapabilmeniz için veri listesindeki elemanların tarih bazında hizalanması gereklidir.
            // Bu amaçla geliştirilen Sistem.GrafikVerilerindeTarihHizala metodunu kullanabilirsiniz. 
            // !!!ÖNEMLİ: Her iki sembole ait veri seti aynı periyotta olmalıdır.

            // Örneğin değişik saatlerde işlem gören piyasalardaki ürünlerin grafiklerini inceleyebilirsiniz.
            // Aşağıdaki örnek VIOP30 ile BIST30 endekslerinin aynı zaman dilimindeki verilerini nasıl alabileceğimizi
            // göstermektedir.
            var viopSembol = "VIP'VIP-X030";
            var viopVeri = Sistem.GrafikVerileriniOku(viopSembol, Sistem.Periyot);            var bistSembol = "IMKBX'XU030";
            var bistVeri = Sistem.GrafikVerileriniOku(bistSembol, Sistem.Periyot);

            bistVeri = Sistem.GrafikVerilerindeTarihHizala(viopVeri, bistVeri);

            var viopClose = Sistem.Liste(viopVeri.Count, 0);
            for (int i = 0; i < viopVeri.Count; i++)
            {
                viopClose[i] = viopVeri[i].Close;
            }

            var bistClose = Sistem.Liste(bistVeri.Count, 0);

            for (int i = 0; i < bistVeri.Count; i++)
            {
                bistClose[i] = bistVeri[i].Close;
            }

            /*****************Sözcük Listesi işlemleri*********************/
            // Sistem yazarken sözcük tablosu oluşturmanızı ve değer atayarak güncellemenizi sağlar.
            // Temel olarak Dictionary tipinde key-vaule pairs listesidir.
            // Sözcük listesinden değer okumak için;
            // Sistem.SozcukTablosunuOku(Anahtar);
            // Sözcük listesini güncellemek için;
            // Sistem.SozcukTablosunuGuncelle(Anahtar, Deger);
            //Örneğin
            Sistem.SozcukTablosunuGuncelle("Durum", "Satış trendi devam ediyor.");

            var durum = Sistem.SozcukTablosunuOku("Durum");
            // durum değişkeni: 'Satış trendi devam ediyor.' olacaktır.


            /*****************Sayı Listesi İşlemleri**********************/
            // Sözcük listesine benzer şekilde, sistem yazarken sayı tablosu oluşturmanızı ve 
            // değer atayarak güncellemenizi sağlar.
            // Temel olarak Dictionary tipinde key-vaule pairs listesidir.
            // Sayı listesinden değer okumak için;
            // Sistem.SayiTablosunuOku(Anahtar);
            // Sayı listesini güncellemek için;
            // Sistem.SayiTablosunuGuncelle(Anahtar, Deger);
            //Örneğin
            Sistem.SayiTablosunuGuncelle("SonIslemFiyat", 105.500f);

            var sonIslemFiyat = Sistem.SayiTablosunuOku("SonIslemFiyat");
            // sonIslemFiyat değişkeni: 105.5 olacaktır.

            Sistem.SayiTablosunuGuncelle("KacDefa", 2);
            var sayim = Sistem.SayiTablosunuOku("KacDefa");
            // sayim değişkeni: 2 olacaktır. 

            #endregion

            #region Piyasa emri için Karar Ver

            /******************************************************************/
            // İki listenin birbirlerini aşağıdan veya yukarıdan kesme durumlarını 
            // inceler ve o noktalarda işlem yaptırmanızı sağlar.
            // Sistem.YukariKestiyse(Liste1, Liste2);
            // Sistem.AsagiKestiyse(Liste1, Liste2);

            // alış
            if (Sistem.YukariKestiyse(heikinWma, closeHeikin))
            {
                //Yukarı doğru kestiğinde bu bölüm devreye girer.
            }
            // satış
            if (Sistem.AsagiKestiyse(heikinWma, closeHeikin))
            {
                //Aşağıya doğru kestiğinde bu bölüm devreye girer.
            }
            /****************************************************************/
            // Karar verme süreçlerinde zaman kontrolü yapmak istediğinizde 
            // aşağıdaki metotları kullanabilirsiniz.


            Sistem.ZamanKontrolGuncelle(viopSembol);
            //İçerisinde zaman verisi tutabileceğiniz bir tablo oluşturur
            Sistem.ZamanKontrolSaniye(viopSembol);
            Sistem.ZamanKontrolDakika(viopSembol); 

            // Örnek
            // Aşağıdaki Robot sisteminde zamanı bir tabloda tutarak her 
            // 60 saniyede bir emir gönderen robot yapısı gösterilmiştir.
            if (Sistem.ZamanKontrolSaniye(viopSembol) >= 60)
            {
                Sistem.ZamanKontrolGuncelle(viopSembol);
                var Miktar = 1;
                Sistem.EmirSembol = viopSembol;
                Sistem.EmirIslem = "Alış";
                Sistem.EmirMiktari = Miktar;
                Sistem.EmirFiyati = "Aktif"; // aktif fiyat
                Sistem.EmirSuresi = "SEANS"; // SEANS, GUN
                Sistem.EmirTipi = "NORMAL"; // NORMAL, KIE, KPY, AFE/KAFE
                Sistem.EmirGonder();
            }

            // Sistem veya Robot yazarken, sistemin çalışma zamanının , hafta sonu olup olmamasını kontrol etmenizi sağlar
            // Sistem.HaftaSonu;
            if (Sistem.HaftaSonu == false)
            {
                //Buraya yazacağınız kodlar, hafta için bir günde iseniz çalışır.
            }
            /*******************************************/
            // Sistem.BaglantiVar
            // Yazdığınız Sistem veya Robotun iDeal programını veri yayını alıp almama durumunu kontrol etmenizi sağlar.
            // Örnek
            if (Sistem.BaglantiVar == true)
            {
                //Buraya yazacağınız kodlar, iDeal programı yayın aldığı sürece çalışır.
            }
            #endregion

            #region Piyasa Emri ver

            /*****************************************************************/
            // Robot yazarken kullanacağınız emir göndermek için Sistem.EmirGonder metodunu kullanabilirsiniz. 
            // Robotunuzda istediğiniz şartlar oluştuğunda aşağıdaki gibi emir hazırlayıp gönderebilirsiniz.
            var miktar = 2;
            Sistem.EmirSembol = viopSembol;
            Sistem.EmirIslem = "Satış";
            Sistem.EmirMiktari = miktar;
            Sistem.EmirFiyati = "Aktif";
            Sistem.EmirSuresi = "SEANS"; // SEANS, GUN
            Sistem.EmirTipi = "NORMAL"; // NORMAL, KIE, KPY, AFE/KAFE
            Sistem.EmirSatisTipi = "NORMAL"; // imkb (NORMAL, ACIGA, VIRMANDAN)
            Sistem.EmirGonder();

            /*****************************************************************/
            // Robot sistemlerinde, alım veya satım pozisyon durumunuzu tutması için kullanılır.
            // Sistem.PozisyonKontrolGuncelle(Sembol, Lot);
            // Sistem.PozisyonKontrolOku(Sembol);
            // Örnek
            var garanSembol = "IMKBH'GARAN";
            var garanPozisyon = Sistem.PozisyonKontrolOku(garanSembol);
            Sistem.Debug("GARAN Pozisyon: " + garanPozisyon);
            var lot = 1;
            Sistem.PozisyonKontrolGuncelle(garanSembol, lot);


            #endregion
        }
    }
}
