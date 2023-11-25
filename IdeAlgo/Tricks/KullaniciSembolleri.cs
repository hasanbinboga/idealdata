using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Tricks
{
    class KullaniciSembolleri : IdealSistem
    {
        
        public KullaniciSembolleri()
        {
            var SUSD = Sistem.YuzeyselVeriOku("SERPIY'SUSD");
            var SGLDD = Sistem.YuzeyselVeriOku("SERPIY'SGLDD");
            var SEURO = Sistem.YuzeyselVeriOku("SERPIY'SEURO");
            var GLD = Sistem.YuzeyselVeriOku("KIYM'GLD");
            var SLV = Sistem.YuzeyselVeriOku("KIYM'SLV");
            var SAHOL = Sistem.YuzeyselVeriOku("IMKBH'SAHOL");
            var EURUSD = Sistem.YuzeyselVeriOku("FX'EURUSD");
            var AKGM = Sistem.YuzeyselVeriOku("INTUSD'AKGM");
            var DBTR = Sistem.YuzeyselVeriOku("INTUSD'DBTR");
            var DENZ = Sistem.YuzeyselVeriOku("INTUSD'DENZ");
            var FBIT = Sistem.YuzeyselVeriOku("INTUSD'FBIT");
            var CITT = Sistem.YuzeyselVeriOku("INTUSD'CITT");
            var GATS = Sistem.YuzeyselVeriOku("INTUSD'GATS");
            var HALK = Sistem.YuzeyselVeriOku("INTUSD'HALK");
            var ISBT = Sistem.YuzeyselVeriOku("INTUSD'ISBT");
            var JPTL = Sistem.YuzeyselVeriOku("INTUSD'JPTL");
            var OYAK = Sistem.YuzeyselVeriOku("INTUSD'OYAK");
            var TEBX = Sistem.YuzeyselVeriOku("INTUSD'TEBX");
            var VBAX = Sistem.YuzeyselVeriOku("INTUSD'VBAX");
            var YAPI = Sistem.YuzeyselVeriOku("INTUSD'YAPI");
            var ZBKA = Sistem.YuzeyselVeriOku("INTUSD'ZBKA");
            var TRLFX = Sistem.YuzeyselVeriOku("INTUSD'TRLFX");
            var NICKEL = Sistem.YuzeyselVeriOku("KIYM'NICKEL");



            // CEYREK
            var CEYREK = Sistem.SembolTanimla("DFN'CEYREK", 3);
            CEYREK.Description = "Çeyrek Altın";
            CEYREK.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 1.58);
            CEYREK.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 1.67);
            if (CEYREK.BidPrice > 0 && CEYREK.AskPrice > 0)
            {
                CEYREK.LastPrice = (CEYREK.BidPrice + CEYREK.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(CEYREK);
            }

            // YARIM
            var YARIM = Sistem.SembolTanimla("DFN'YARIM", 2);
            YARIM.Description = "Yarım Altın";
            YARIM.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 3.18);
            YARIM.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 3.35);
            if (YARIM.BidPrice > 0 && YARIM.AskPrice > 0)
            {
                YARIM.LastPrice = (YARIM.BidPrice + YARIM.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(YARIM);
            }


            // ECEYREK
            var ECEYREK = Sistem.SembolTanimla("DFN'ECEYREK", 2);
            ECEYREK.Description = "Çeyrek Altın";
            ECEYREK.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 1.60);
            ECEYREK.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 1.63);
            if (ECEYREK.BidPrice > 0 && ECEYREK.AskPrice > 0)
            {
                ECEYREK.LastPrice = (ECEYREK.BidPrice + ECEYREK.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(ECEYREK);
            }

            // EYARIM
            var EYARIM = Sistem.SembolTanimla("DFN'EYARIM", 2);
            EYARIM.Description = "Yarım Altın";
            EYARIM.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 3.2);
            EYARIM.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 3.26);
            if (EYARIM.BidPrice > 0 && EYARIM.AskPrice > 0)
            {
                EYARIM.LastPrice = (EYARIM.BidPrice + EYARIM.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(EYARIM);
            }


            // EZIYNET
            var EZIYNET = Sistem.SembolTanimla("DFN'EZIYNET", 2);
            EZIYNET.Description = "EZIYNET Altın";
            EZIYNET.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 6.36);
            EZIYNET.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 6.48);
            if (EZIYNET.BidPrice > 0 && EZIYNET.AskPrice > 0)
            {
                EZIYNET.LastPrice = (EZIYNET.BidPrice + EZIYNET.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(EZIYNET);
            }


            // BESLI
            var BESLI = Sistem.SembolTanimla("DFN'BESLI", 2);
            BESLI.Description = "Beşli Altın";
            BESLI.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 33);
            BESLI.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 33.7);
            if (BESLI.BidPrice > 0 && BESLI.AskPrice > 0)
            {
                BESLI.LastPrice = (BESLI.BidPrice + BESLI.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(BESLI);
            }

            // ZIYNET
            var ZIYNET = Sistem.SembolTanimla("DFN'ZIYNET", 2);
            ZIYNET.Description = "Ziynet Altın";
            ZIYNET.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 6.35);
            ZIYNET.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 6.6);
            if (ZIYNET.BidPrice > 0 && ZIYNET.AskPrice > 0)
            {
                ZIYNET.LastPrice = (ZIYNET.BidPrice + ZIYNET.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(ZIYNET);
            }

            // DOVIZSEPET
            var DOVIZSEPET = Sistem.SembolTanimla("DFN'DOVIZSEPET", 4);
            DOVIZSEPET.Description = "Döviz Sepeti";
            DOVIZSEPET.BidPrice = (SUSD.BidPrice + SEURO.BidPrice) / 2;
            DOVIZSEPET.AskPrice = (SUSD.AskPrice + SEURO.AskPrice) / 2;
            if (DOVIZSEPET.BidPrice > 0 && DOVIZSEPET.AskPrice > 0)
            {
                DOVIZSEPET.LastPrice = (DOVIZSEPET.BidPrice + DOVIZSEPET.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(DOVIZSEPET);
            }


            // BILEZIK
            var BILEZIK = Sistem.SembolTanimla("DFN'BILEZIK", 2);
            BILEZIK.Description = "18 Ayar Bilezik";
            BILEZIK.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 910);
            BILEZIK.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 950);
            if (BILEZIK.BidPrice > 0 && BILEZIK.AskPrice > 0)
            {
                BILEZIK.LastPrice = (BILEZIK.BidPrice + BILEZIK.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(BILEZIK);
            }

            // AYAR22
            var AYAR22 = Sistem.SembolTanimla("DFN'AYAR22", 2);
            AYAR22.Description = "22 Ayar Bilezik Gramı";
            AYAR22.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 930);
            AYAR22.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 1000);
            if (AYAR22.BidPrice > 0 && AYAR22.AskPrice > 0)
            {
                AYAR22.LastPrice = (AYAR22.BidPrice + AYAR22.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(AYAR22);
            }

            // AYAR24
            var AYAR24 = Sistem.SembolTanimla("DFN'AYAR24", 2);
            AYAR24.Description = "24 Ayar Bilezik Gramı";
            AYAR24.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 1010);
            AYAR24.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 1030);
            if (AYAR24.BidPrice > 0 && AYAR24.AskPrice > 0)
            {
                AYAR24.LastPrice = (AYAR24.BidPrice + AYAR24.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(AYAR24);
            }

            // GLDUSD ALTIN KİLO FİYATI

            var GLDUSD = Sistem.SembolTanimla("DFN'GLDUSD", 2);
            GLDUSD.Description = "ALTIN KİLO FİYATI";
            GLDUSD.BidPrice = Convert.ToSingle((GLD.BidPrice) * 31.99);
            GLDUSD.AskPrice = Convert.ToSingle((GLD.AskPrice) * 31.99);
            if (GLDUSD.BidPrice > 0 && GLDUSD.AskPrice > 0)
            {
                GLDUSD.LastPrice = (GLDUSD.BidPrice + GLDUSD.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(GLDUSD);
                Sistem.GrafikGuncelle(GLDUSD);
            }


            // IKIBUCUK
            var IKIBUCUK = Sistem.SembolTanimla("DFN'IKIBUCUK", 3);
            IKIBUCUK.Description = "Çeyrek Altın";
            IKIBUCUK.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 16.40);
            IKIBUCUK.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 16.50);
            if (IKIBUCUK.BidPrice > 0 && IKIBUCUK.AskPrice > 0)
            {
                IKIBUCUK.LastPrice = (IKIBUCUK.BidPrice + IKIBUCUK.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(IKIBUCUK);
            }


            // ATA
            var ATA = Sistem.SembolTanimla("DFN'ATA", 2);
            ATA.Description = "Yarım Altın";
            ATA.BidPrice = Convert.ToSingle(((SGLDD.BidPrice - 10) * SUSD.BidPrice / 0.995) / 1000 * 6.73);
            ATA.AskPrice = Convert.ToSingle(((SGLDD.AskPrice + 10) * SUSD.AskPrice / 0.995) / 1000 * 6.78);
            if (ATA.BidPrice > 0 && ATA.AskPrice > 0)
            {
                ATA.LastPrice = (ATA.BidPrice + ATA.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(ATA);
            }

            // AKBANK EURO KOTASYONU
            var a = Sistem.SembolTanimla("DFN'AKGM-E", 4);
            a.Description = "AKBANK EURO KOTASYONU";
            a.BidPrice = Convert.ToSingle((AKGM.BidPrice) * EURUSD.LastPrice);
            a.AskPrice = Convert.ToSingle((AKGM.AskPrice) * EURUSD.LastPrice);
            if (a.BidPrice > 0 && a.AskPrice > 0)
            {
                a.LastPrice = (a.BidPrice + a.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(a);

            }

            // DEUTSCHEBANK EURO KOTASYONU
            var b = Sistem.SembolTanimla("DFN'DBTR-E", 4);
            b.Description = "DEUTSCHEBANK EURO KOTASYONU";
            b.BidPrice = Convert.ToSingle((DBTR.BidPrice) * EURUSD.LastPrice);
            b.AskPrice = Convert.ToSingle((DBTR.AskPrice) * EURUSD.LastPrice);
            if (b.BidPrice > 0 && b.AskPrice > 0)
            {
                b.LastPrice = (b.BidPrice + b.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(b);

            }

            // DENİZBANK EURO KOTASYONU
            var c = Sistem.SembolTanimla("DFN'DENZ-E", 4);
            c.Description = "DENİZBANK EURO KOTASYONU";
            c.BidPrice = Convert.ToSingle((DENZ.BidPrice) * EURUSD.LastPrice);
            c.AskPrice = Convert.ToSingle((DENZ.AskPrice) * EURUSD.LastPrice);
            if (c.BidPrice > 0 && c.AskPrice > 0)
            {
                c.LastPrice = (c.BidPrice + c.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(c);

            }

            // FİNANSBANK EURO KOTASYONU
            var d = Sistem.SembolTanimla("DFN'FBIT-E", 4);
            d.Description = "FİNANSBANK EURO KOTASYONU";
            d.BidPrice = Convert.ToSingle((FBIT.BidPrice) * EURUSD.LastPrice);
            d.AskPrice = Convert.ToSingle((FBIT.AskPrice) * EURUSD.LastPrice);
            if (d.BidPrice > 0 && d.AskPrice > 0)
            {
                d.LastPrice = (d.BidPrice + d.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(d);

            }

            // CITIBANK EURO KOTASYONU
            var e = Sistem.SembolTanimla("DFN'CITT-E", 4);
            e.Description = "CITIBANK EURO KOTASYONU";
            e.BidPrice = Convert.ToSingle((CITT.BidPrice) * EURUSD.LastPrice);
            e.AskPrice = Convert.ToSingle((CITT.AskPrice) * EURUSD.LastPrice);
            if (e.BidPrice > 0 && e.AskPrice > 0)
            {
                e.LastPrice = (e.BidPrice + e.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(e);

            }

            // GARANTİ BANKASI EURO KOTASYONU
            var f = Sistem.SembolTanimla("DFN'GATS-E", 4);
            f.Description = "GARANTİ BANKASI EURO KOTASYONU";
            f.BidPrice = Convert.ToSingle((GATS.BidPrice) * EURUSD.LastPrice);
            f.AskPrice = Convert.ToSingle((GATS.AskPrice) * EURUSD.LastPrice);
            if (f.BidPrice > 0 && f.AskPrice > 0)
            {
                f.LastPrice = (f.BidPrice + f.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(f);

            }

            // HALKBANK EURO KOTASYONU
            var g = Sistem.SembolTanimla("DFN'HALK-E", 4);
            g.Description = "HALKBANK EURO KOTASYONU";
            g.BidPrice = Convert.ToSingle((HALK.BidPrice) * EURUSD.LastPrice);
            g.AskPrice = Convert.ToSingle((HALK.AskPrice) * EURUSD.LastPrice);
            if (g.BidPrice > 0 && g.AskPrice > 0)
            {
                g.LastPrice = (g.BidPrice + g.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(g);

            }

            // İŞ BANKASI EURO KOTASYONU
            var h = Sistem.SembolTanimla("DFN'ISBT-E", 4);
            h.Description = "İŞ BANKASI EURO KOTASYONU";
            h.BidPrice = Convert.ToSingle((ISBT.BidPrice) * EURUSD.LastPrice);
            h.AskPrice = Convert.ToSingle((ISBT.AskPrice) * EURUSD.LastPrice);
            if (h.BidPrice > 0 && h.AskPrice > 0)
            {
                h.LastPrice = (h.BidPrice + h.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(h);

            }

            // JP MORGAN EURO KOTASYONU
            var i = Sistem.SembolTanimla("DFN'JPTL-E", 4);
            i.Description = "JP MORGAN EURO KOTASYONU";
            i.BidPrice = Convert.ToSingle((JPTL.BidPrice) * EURUSD.LastPrice);
            i.AskPrice = Convert.ToSingle((JPTL.AskPrice) * EURUSD.LastPrice);
            if (i.BidPrice > 0 && i.AskPrice > 0)
            {
                i.LastPrice = (i.BidPrice + i.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(i);

            }

            // ING BANK EURO KOTASYONU
            var j = Sistem.SembolTanimla("DFN'OYAK-E", 4);
            j.Description = "ING BANK EURO KOTASYONU";
            j.BidPrice = Convert.ToSingle((OYAK.BidPrice) * EURUSD.LastPrice);
            j.AskPrice = Convert.ToSingle((OYAK.AskPrice) * EURUSD.LastPrice);
            if (j.BidPrice > 0 && j.AskPrice > 0)
            {
                j.LastPrice = (j.BidPrice + j.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(j);
            }

            // TEB BANK EURO KOTASYONU
            var k = Sistem.SembolTanimla("DFN'TEBX-E", 4);
            k.Description = "TEB BANK EURO KOTASYONU";
            k.BidPrice = Convert.ToSingle((TEBX.BidPrice) * EURUSD.LastPrice);
            k.AskPrice = Convert.ToSingle((TEBX.AskPrice) * EURUSD.LastPrice);
            if (k.BidPrice > 0 && k.AskPrice > 0)
            {
                k.LastPrice = (k.BidPrice + k.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(k);
            }

            // VAKIFBANK EURO KOTASYONU
            var l = Sistem.SembolTanimla("DFN'VBAX-E", 4);
            l.Description = "VAKIFBANK EURO KOTASYONU";
            l.BidPrice = Convert.ToSingle((VBAX.BidPrice) * EURUSD.LastPrice);
            l.AskPrice = Convert.ToSingle((VBAX.AskPrice) * EURUSD.LastPrice);
            if (l.BidPrice > 0 && l.AskPrice > 0)
            {
                l.LastPrice = (l.BidPrice + l.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(l);
            }

            // YAPI KREDİ BANKASI EURO KOTASYONU
            var m = Sistem.SembolTanimla("DFN'YAPI-E", 4);
            m.Description = "YAPI KREDİ BANKASI EURO KOTASYONU";
            m.BidPrice = Convert.ToSingle((YAPI.BidPrice) * EURUSD.LastPrice);
            m.AskPrice = Convert.ToSingle((YAPI.AskPrice) * EURUSD.LastPrice);
            if (m.BidPrice > 0 && m.AskPrice > 0)
            {
                m.LastPrice = (m.BidPrice + m.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(m);
            }

            // ZİRAAT BANKASI EURO KOTASYONU
            var n = Sistem.SembolTanimla("DFN'ZBKA-E", 4);
            n.Description = "ZİRAAT BANKASI EURO KOTASYONU";
            n.BidPrice = Convert.ToSingle((ZBKA.BidPrice) * EURUSD.LastPrice);
            n.AskPrice = Convert.ToSingle((ZBKA.AskPrice) * EURUSD.LastPrice);
            if (n.BidPrice > 0 && n.AskPrice > 0)
            {
                n.LastPrice = (n.BidPrice + n.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(n);
            }

            // INTERBANK PIY.YAP EURO KOTASYONU
            var o = Sistem.SembolTanimla("DFN'TRLFX-E", 4);
            o.Description = "INTERBANK PIY.YAP EURO KOTASYONU";
            o.BidPrice = Convert.ToSingle((TRLFX.BidPrice) * EURUSD.LastPrice);
            o.AskPrice = Convert.ToSingle((TRLFX.AskPrice) * EURUSD.LastPrice);
            if (o.BidPrice > 0 && o.AskPrice > 0)
            {
                o.LastPrice = (o.BidPrice + o.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(o);
            }


            // NICKELT
            var NICKELT = Sistem.SembolTanimla("DFN'NICKELT", 3);
            NICKELT.Description = "Hesaplanan Nickel / Ton";
            NICKELT.BidPrice = Convert.ToSingle(NICKEL.BidPrice / 0.454);
            NICKELT.AskPrice = Convert.ToSingle(NICKEL.AskPrice / 0.454);
            if (NICKELT.BidPrice > 0 && NICKELT.AskPrice > 0)
            {
                NICKELT.LastPrice = (NICKELT.BidPrice + NICKELT.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(NICKELT);
            }


            // SLVUSD GUMUS KİLO FİYATI

            var SLVUSD = Sistem.SembolTanimla("DFN'SLVUSD", 2);
            SLVUSD.Description = "GUMUS KILO FİYATI";
            SLVUSD.BidPrice = Convert.ToSingle((SLV.BidPrice) * 32.15);
            SLVUSD.AskPrice = Convert.ToSingle((SLV.AskPrice) * 32.15);
            if (SLVUSD.BidPrice > 0 && SLVUSD.AskPrice > 0)
            {
                SLVUSD.LastPrice = (SLVUSD.BidPrice + SLVUSD.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(SLVUSD);
                Sistem.GrafikGuncelle(SLVUSD);
            }

            // GLDEURO ALTIN EURO FIYATI

            var GLDEURO = Sistem.SembolTanimla("DFN'GLDEURO", 2);
            GLDEURO.Description = "ALTIN EURO FİYATI";
            GLDEURO.BidPrice = Convert.ToSingle((GLD.BidPrice * 31.99) / (EURUSD.BidPrice));
            GLDEURO.AskPrice = Convert.ToSingle((GLD.AskPrice * 31.99) / (EURUSD.AskPrice));
            if (GLDEURO.BidPrice > 0 && GLDEURO.AskPrice > 0)
            {
                GLDEURO.LastPrice = (GLDEURO.BidPrice + GLDEURO.AskPrice) / 2;
                Sistem.YuzeyselGuncelle(GLDEURO);
                Sistem.GrafikGuncelle(GLDEURO);
            }

        }
    }
}
