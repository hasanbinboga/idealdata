using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tricks;

namespace Systems
{
    class Sistem_Dom : IdealSistem
    {
        public Sistem_Dom()
        {
            /**********************************************************************
            * 
            * 
            *                   Hasan BİNBOĞA
            *                   Ornek Sistem Şablonu
            *                   23/03/2020
            * 
            * 
            **********************************************************************/

            #region Sabit ve Değişkenler

            var sembolList = new List<string>();
            var sinyalList = Sistem.Liste(0);
            #endregion

            #region Parametreleri oku
            // Kullanıcının belirttiği sembolleri oku.
            foreach (var currSym in Sistem.Parametreler)
            {
                if (string.IsNullOrEmpty(currSym.Trim()) == false)
                {
                    sembolList.Add(currSym);
                }
            }
            if (sembolList.Count == 0)
            {
                sembolList.Add("VIP-X030");
            }
            #endregion

            #region Grafik Verilerini Oku 

            var nviList = Sistem.NegativeVolumeIndex();
            var pviList = Sistem.PositiveVolumeIndex();
            var grafikVeriList = Sistem.GrafikVerileri;
            //var islemList = Sistem.ViopIslemleriniOku();
            var islemList = Sistem.SembolIslemleriniOku(Sistem.Sembol, "01.04.2020");
            
            #endregion

            #region Hesaplama

            for (int i = 0; i < islemList.Count; i++)
            {
                if (islemList[i].Size >= 50)
                {
                    // Alım İşlemleri
                    if (islemList[i].GetDirection() == 1)
                    {
                        
                    }
                    Sistem.Debug(//"İşlem  " + i + " :" + islemList[i].Price + 
                                //" Sembol: " + islemList[i].Symbol + 
                              //  " Buyer: " + islemList[i].BuyerCode+
                                " Size: " + islemList[i].Size+
                                " Direction: " + islemList[i].GetDirection() +
                                //" Vol: " + islemList[i].Vol+
                                //" Fiyat:" + islemList[i].Price + 
                                " Deleted: " + islemList[i].Deleted +
                                //" Tip: " + islemList[i].Tip+
                                " Ask: " + islemList[i].Ask+
                                " Bid: " + islemList[i].Bid+
                                //" TradeID: " + islemList[i].TradeID+
                                " Time: " + islemList[i].GetTimeString());
                }
                
            }
             
           

            for (int i = 1; i < Sistem.BarSayisi; i++)
            {
                var barTarih = grafikVeriList[i].Date.ToString("dd.MM.yyyy");
                var currId = i;
                var prevId = i - 1;
                if (Math.Abs(pviList[currId] - pviList[prevId]) < 0.01f && 
                    nviList[currId] - nviList[prevId] <= -2.0f)
                {
                    sinyalList[i] = -1;
                }
                else if (Math.Abs(nviList[currId] - nviList[prevId]) < 0.01f &&
                   pviList[currId] - pviList[prevId] <= -1.0f)
                {
                    sinyalList[i] = -1;
                }
                else if (Math.Abs(pviList[currId] - pviList[prevId]) < 0.01f &&
                         nviList[currId] - nviList[prevId] >= 2.0f)
                {
                    sinyalList[i] = 1;
                }
                else if (Math.Abs(nviList[currId] - nviList[prevId]) < 0.01f &&
                         pviList[currId] - pviList[prevId] >= -1.0f)
                {
                    sinyalList[i] = 1;
                }
                else
                {
                    sinyalList[i] = 0;
                }

            }

            #endregion

            #region Sistem çıktılarını ekrana çizdir.

            /*************SINYAL*****************/
            Sistem.Cizgiler[0].Deger = sinyalList;
            Sistem.Cizgiler[0].Aciklama = "NVI-PVI Sinyal";
            Sistem.Cizgiler[0].Panel = 2;
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Kalinlik = 2;
            Sistem.Cizgiler[0].Renk = Color.BlueViolet;
            #endregion
        }
    }
}
