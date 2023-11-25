using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class Sistem_Cpr : IdealSistem
    {
        public Sistem_Cpr()
        {
            /**********************************************************************
           * 
           * 
           *                   Hasan BİNBOĞA
           *                   Ornek Sistem Şablonu
           *                   01/04/2020
           * 
           * 
           **********************************************************************/
            #region Sabitler ve Değişkenler

            var barCount = 0;
            var twoDaysRelation = "";
            var trendPrediction = "";
            var cur = 0;
            var prev = 0;

            #endregion

            #region Parametre Al
            var periyot = "H";
            if (string.IsNullOrEmpty(Sistem.Parametreler[0]) == false)
            {
                periyot = Sistem.Parametreler[0];
            }
            #endregion

            #region Veri Al

            var veriList = Sistem.GrafikVerileriniOku(Sistem.Sembol, periyot);
            barCount = veriList.Count;
            #endregion

            #region Hesapla

            // boş veri listeleri yarat
            var r1 = Sistem.Liste(barCount, 0);
            var tc = Sistem.Liste(barCount, 0);
            var p = Sistem.Liste(barCount, 0);
            var bc = Sistem.Liste(barCount, 0);
            var s1 = Sistem.Liste(barCount, 0); 
            var trend = Sistem.Liste(barCount, 0f);

            // döngü ile haftalık pivot, prohigh, prolow hesapla
            for (int i = 1; i < barCount; i++)
            {
                // pivot önceki barın (H+L+C)/3 değeri
                p[i] = (veriList[i - 1].High + veriList[i - 1].Low + veriList[i - 1].Close) / 3;
                var pLow = (veriList[i - 1].High + veriList[i - 1].Low) / 2;
                var pHigh = (p[i] - pLow) + p[i];
                bc[i] = pLow < pHigh ? pLow : pHigh;
                tc[i] = pHigh > pLow ? pHigh : pLow;

                r1[i] = (2 * p[i]) - veriList[i - 1].Low;
                s1[i] = (2 * p[i]) - veriList[i - 1].High;

                #region  Trend histogram için hesapla

                //Two Days Range Relations Hesapla
                cur = i;
                prev = i - 1;

                // Higher Value Control
                if (bc[cur] > tc[prev])
                {
                    trend[i] = 3;
                }
                // Overlapping Higher Value Control
                else if (tc[cur] > tc[prev] && bc[cur] > bc[prev])
                {
                    trend[i] = 2;
                }
                // Lower Value Control
                else if (tc[cur] < bc[prev])
                {
                    trend[i] = -3;
                }
                // Overlapping Lower Value Control
                else if (tc[cur] < tc[prev] && bc[cur] < bc[prev])
                {
                    trend[i] = -2;
                }
                // Unchanged value Control
                else if (Math.Abs(tc[cur] - tc[prev]) <= 0.1f &&
                         Math.Abs(bc[cur] - bc[prev]) <= 0.1f)
                {
                    trend[i] = 0;
                }
                // Outside Value Control
                else if (tc[cur] >= tc[prev] && bc[cur] <= bc[prev])
                {
                    trend[i] = 1;
                } 
                // Inside Value Control
                else if (tc[cur] <= tc[prev] && bc[cur] >= bc[prev])
                {
                    trend[i] = -1;
                }
                else
                {
                    trend[i] = -500;
                }
                #endregion

            }

            #region Son günün değerini ekrana yazdırmak için hesapla

            //Two Days Range Relations Hesapla
            cur = barCount - 1;
            prev = barCount - 2;

            // Higher Value Control
            if (bc[cur] > tc[prev])
            {
                twoDaysRelation = "Higher Value";
                trendPrediction = "Bullish";
            }
            // Overlapping Higher Value Control
            else if (tc[cur] > tc[prev] && bc[cur] > bc[prev])
            {
                twoDaysRelation = "Overlapping Higher Value";
                trendPrediction = "Moderately Bullish";
            }
            // Lower Value Control
            else if (tc[cur] < bc[prev])
            {
                twoDaysRelation = "Lower Value";
                trendPrediction = "Bearish";
            }
            // Overlapping Lower Value Control
            else if (tc[cur] < tc[prev] && bc[cur] < bc[prev])
            {
                twoDaysRelation = "Overlapping Lower Value";
                trendPrediction = "Moderately Bearish";
            }
            // Unchanged value Control
            else if (Math.Abs(tc[cur] - tc[prev]) <= 0.1f &&
                     Math.Abs(bc[cur] - bc[prev]) <= 0.1f)
            {
                twoDaysRelation = "Unchanged value";
                trendPrediction = "Sideways/Breakout";
            }
            // Outside Value Control
            else if (tc[cur] >= tc[prev] && bc[cur] <= bc[prev])
            {
                twoDaysRelation = "Outside Value";
                trendPrediction = "Sideways";
            } 
            // Inside Value Control
            else if (tc[cur] <= tc[prev] && bc[cur] >= bc[prev])
            {
                twoDaysRelation = "Inside Value";
                trendPrediction = "Breakout";
            }
            else
            {
                twoDaysRelation = "Unknown";
                trendPrediction = "Unknown";
            }
            #endregion

            #endregion

            #region Grafik Pivot Çiz Trend Yaz


            // R1
            Sistem.Cizgiler[0].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, r1);
            Sistem.Cizgiler[0].Aciklama = "R1, Günlük";
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Renk = Sistem.Renk(255, 16, 109, 29);
            Sistem.Cizgiler[0].Kalinlik = 2;
            
            //TC
            Sistem.Cizgiler[1].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, tc);
            Sistem.Cizgiler[1].Aciklama = "TC, Günlük";
            Sistem.Cizgiler[1].ActiveBool = true;
            Sistem.Cizgiler[1].Renk = Sistem.Renk(255, 255, 241, 87);
            Sistem.Cizgiler[1].Kalinlik = 2;

            //P
            Sistem.Cizgiler[2].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, p);
            Sistem.Cizgiler[2].Aciklama = "Pivot, Günlük";
            Sistem.Cizgiler[2].ActiveBool = true;
            Sistem.Cizgiler[2].Renk = Sistem.Renk(255, 13, 118, 226);
            Sistem.Cizgiler[2].Kalinlik = 3;


            // BC
            Sistem.Cizgiler[3].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, bc);
            Sistem.Cizgiler[3].Aciklama = "BC, Günlük";
            Sistem.Cizgiler[3].ActiveBool = true;
            Sistem.Cizgiler[3].Renk = Sistem.Renk(255, 255, 241, 87);
            Sistem.Cizgiler[3].Kalinlik = 2;


            // S1
            Sistem.Cizgiler[4].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, s1); 
            Sistem.Cizgiler[4].Aciklama = "S1, Günlük";
            Sistem.Cizgiler[4].ActiveBool = true;
            Sistem.Cizgiler[4].Renk = Sistem.Renk(255, 229, 131, 36);
            Sistem.Cizgiler[4].Kalinlik = 2;


            // Two Days Range Oscilator
            Sistem.Cizgiler[5].Deger = Sistem.DonemCevir(Sistem.GrafikVerileri, veriList, trend);
            Sistem.Cizgiler[5].Aciklama = "Two Days Range Oscilator";
            Sistem.Cizgiler[5].ActiveBool = true;  
            Sistem.Cizgiler[5].Renk = Sistem.Renk(255, 168, 231, 251);
            Sistem.Cizgiler[5].Kalinlik = 2;
            Sistem.Cizgiler[5].Panel = 2;

            /*************Grafik zeminine yazı ekle*********************/ 
            // Grafik arka zeminine yazı eklemenizi sağlar.
            // Sistem.ZeminYazisiEkle(Metin, Panel, X, Y, Renk, FontAdi, FontBoyutu);
            var yesil = Sistem.Renk(100, 90, 240, 50);

            Sistem.ZeminYazisiEkle("Two Days Relation: " + twoDaysRelation, 1, 10, 200, yesil, "Arial", 10);
            Sistem.ZeminYazisiEkle("Trend Prediction: " + trendPrediction, 1, 10, 220, yesil, "Arial", 10);

            #endregion

        }
    }
}
