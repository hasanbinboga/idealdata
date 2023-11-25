using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Robots
{
    class RobotPivotHeikin : IdealSistem
    {
        public RobotPivotHeikin()
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

            var periyot = "G";
            var barCount = Sistem.BarSayisi;
            var cur = 0;
            var prev = 0;
            // Heikin Ashi barlarını hesaplatarak sistem içinde kullanmak için 
            var closeHeikin = Sistem.Liste(barCount, 0);
            var openHeikin = Sistem.Liste(barCount, 0);

            var gunlukR1 = Sistem.Liste(0);
            var gunlukTc = Sistem.Liste(0);
            var gunlukP = Sistem.Liste(0);
            var gunlukBc = Sistem.Liste(0);
            var gunlukS1 = Sistem.Liste(0);

            var r1 = Sistem.Liste(0);
            var tc = Sistem.Liste(0);
            var p = Sistem.Liste(0);
            var bc = Sistem.Liste(0);
            var s1 = Sistem.Liste(0);

            var gunlukTrendOsc = Sistem.Liste(0); 
            var trendOsc = Sistem.Liste(0); 
            var hacimOsc = Sistem.Liste(barCount, 0);
            var heikinOsc = Sistem.Liste(barCount, 0);

            #endregion

        

            #region Veri Al

            var grafikVerileri = Sistem.GrafikVerileri;
            var gunlukVeriList = Sistem.GrafikVerileriniOku(Sistem.Sembol, periyot);
            var nviList = Sistem.NegativeVolumeIndex();
            var pviList = Sistem.PositiveVolumeIndex(); 

            #endregion
             
            #region Pivot Değerlerini ve TwoDaysRelation değerlerini hesapla
             
            // döngü ile günlük bar sayısı kadar  pivot, phigh, plow hesapla
            for (int i = 1; i < gunlukVeriList.Count; i++)
            {
                // pivot önceki barın (H+L+C)/3 değeri
                gunlukP[i] = (gunlukVeriList[i - 1].High + gunlukVeriList[i - 1].Low + gunlukVeriList[i - 1].Close) / 3;
                var pLow = (gunlukVeriList[i - 1].High + gunlukVeriList[i - 1].Low) / 2;
                var pHigh = (gunlukP[i] - pLow) + gunlukP[i];
                gunlukBc[i] = pLow < pHigh ? pLow : pHigh;
                gunlukTc[i] = pHigh > pLow ? pHigh : pLow;

                gunlukR1[i] = (2 * gunlukP[i]) - gunlukVeriList[i - 1].Low;
                gunlukS1[i] = (2 * gunlukP[i]) - gunlukVeriList[i - 1].High;

                #region  Trend histogram için hesapla
                //Two Days Range Relations Hesapla
                cur = i;
                prev = i-1;


                // Higher Value Control
                if (gunlukBc[cur] > gunlukTc[prev])
                {
                    gunlukTrendOsc[cur] = 3; // Bullish
                }
                // Overlapping Higher Value Control
                else if (gunlukTc[cur] > gunlukTc[prev] && gunlukBc[cur] > gunlukBc[prev])
                {
                    gunlukTrendOsc[cur] = 2; //Modarate Bullish
                }
                // Lower Value Control
                else if (gunlukTc[cur] < gunlukBc[prev])
                {
                    gunlukTrendOsc[cur] = -3; //Bearish
                }
                // Overlapping Lower Value Control
                else if (gunlukTc[cur] < gunlukTc[prev] && gunlukBc[cur] < gunlukBc[prev])
                {
                    gunlukTrendOsc[cur] = -2; //Moderate Bearish
                }
                // Unchanged value Control
                else if (Math.Abs(gunlukTc[cur] - gunlukTc[prev]) <= 0.1f &&
                         Math.Abs(gunlukBc[cur] - gunlukBc[prev]) <= 0.1f)
                {
                    gunlukTrendOsc[cur] = 0; // Sideways/Breakout
                }
                // Outside Value Control
                else if (gunlukTc[cur] >= gunlukTc[prev] && gunlukBc[cur] <= gunlukBc[prev])
                {
                    gunlukTrendOsc[cur] = 1; // Sideways
                }
                // Inside Value Control
                else if (gunlukTc[cur] <= gunlukTc[prev] && gunlukBc[cur] >= gunlukBc[prev])
                {
                    gunlukTrendOsc[cur] = -1; // Breakout
                }
                else
                {
                    gunlukTrendOsc[cur] = -500; //Unknown
                }
                #endregion
            }

            // Günlük bar sayısına göre hesaplanmış pivot değerlerini 5 dakikalık periyoda dönüştür.
            trendOsc = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukTrendOsc);
            r1 = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukR1);
            tc = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukTc);
            p = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukP);
            bc = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukBc);
            s1 = Sistem.DonemCevir(Sistem.GrafikVerileri, gunlukVeriList, gunlukS1);

            #endregion 
             

            for (int i = 1; i < Sistem.BarSayisi; i++)
            {
                #region Hacim için Hesaplama

                cur = i;
                prev = cur - 1;
                if (Math.Abs(pviList[cur] - pviList[prev]) < 0.01f &&
                    nviList[cur] - nviList[prev] <= -2.0f)
                {
                    hacimOsc[cur] = -1; // Sat
                }
                else if (Math.Abs(nviList[cur] - nviList[prev]) < 0.01f &&
                   pviList[cur] - pviList[prev] <= -1.0f)
                {
                    hacimOsc[cur] = -1; // Sat
                }
                else if (Math.Abs(pviList[cur] - pviList[prev]) < 0.01f &&
                         nviList[cur] - nviList[prev] >= 2.0f)
                {
                    hacimOsc[cur] = 1; // Al
                }
                else if (Math.Abs(nviList[cur] - nviList[prev]) < 0.01f &&
                         pviList[cur] - pviList[prev] >= -1.0f)
                {
                    hacimOsc[cur] = 1; // Al
                }
                else
                {
                    hacimOsc[cur] = 0; //Bekle
                }

                #endregion

                #region Heikin ve HeikinWMA Hesaplama

                // Heikin'e Çevir

                closeHeikin[i] = (grafikVerileri[i].Open + grafikVerileri[i].High + grafikVerileri[i].Low + grafikVerileri[i].Close) / 4;
                openHeikin[i] = (grafikVerileri[i - 1].Open + grafikVerileri[i - 1].Close) / 2;
                grafikVerileri[i].High = Math.Max(grafikVerileri[i].High, grafikVerileri[i].Close);
                grafikVerileri[i].High = Math.Max(grafikVerileri[i].High, grafikVerileri[i].Open);
                grafikVerileri[i].Low = Math.Min(grafikVerileri[i].Low, grafikVerileri[i].Close);
                grafikVerileri[i].Low = Math.Min(grafikVerileri[i].Low, grafikVerileri[i].Open); 
               
                #endregion
            }

            // Heikin WMA hesaplat.
            var heikinWma = Sistem.MA(closeHeikin, "Weighted", 14);  

            #region İşleme Karar Ver


            for (int i = 1; i < barCount; i++)
            {
                cur = i;
                prev = i - 1;

                // heikin WMA aşağı kestiyse
                if (closeHeikin[cur] <= closeHeikin[prev] && heikinWma[cur] >= heikinWma[prev])
                {
                    heikinOsc[cur] = -1; // Sat
                }
                // heikin WMA yukarı kestiyse
                else if (closeHeikin[cur] >= closeHeikin[prev] && heikinWma[cur] <= heikinWma[prev])
                {
                    heikinOsc[cur] = 1; // Al
                }
                else
                {
                    heikinOsc[cur] = 0; //Bekle
                }

                //Bullish trend
                if (trendOsc[cur] == 3 || trendOsc[cur] == 2)
                {
                    if (grafikVerileri[cur].Close > s1[cur] && heikinOsc[cur] == 1 && hacimOsc[cur] == 1)
                    {
                        Sistem.Yon[cur] = "A"; // Al
                    }
                }

                //Bearish trend
                else if (trendOsc[cur] == -3 || trendOsc[cur] == -2)
                {
                    if (grafikVerileri[cur].Close < r1[cur] && heikinOsc[cur] == -1 && hacimOsc[cur] == -1)
                    {
                        Sistem.Yon[cur] = "S"; // Sat
                    }
                }
                //Breakout
                else if (trendOsc[cur] == -1 || trendOsc[cur] == 0)
                {
                    if (grafikVerileri[cur].Close > s1[cur] && heikinOsc[cur] == 1 && hacimOsc[cur] == 1)
                    {
                        Sistem.Yon[cur] = "A"; // Al
                    }
                    else if (grafikVerileri[cur].Close < r1[cur] && heikinOsc[cur] == -1 && hacimOsc[cur] == -1)
                    {
                        Sistem.Yon[cur] = "S"; // Sat
                    }
                } 
                // Sideways
                else if(trendOsc[cur] == 1)
                {
                    Sistem.Yon[cur] = "OK"; // Kapat
                }


            }  

            #endregion


        }
    }
}
