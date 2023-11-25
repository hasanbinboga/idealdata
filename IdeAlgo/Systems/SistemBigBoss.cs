using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ideal;
using Tricks;

namespace Systems
{
    class SistemBigBoss : IdealSistem
    {
        public SistemBigBoss()
        {
            /**********************************************************************
 * 
 * 
 *                   Hasan BİNBOĞA
 *                   Big Boss Osilatör
 *                   03/04/2020
 * 
 * 
 **********************************************************************/

            #region Sabit ve Değişkenler

            var sembol = "F_XU0300420";
            var sinyalList = Sistem.Liste(0);
            #endregion


            #region Grafik Verilerini Oku 

            var grafikVeriList = Sistem.GrafikVerileri;


            #endregion

            #region Hesaplama

            var sonJ = 1;
            //var islemList = Sistem.SembolIslemleriniOku(sembol, "");
            for (int i = 3; i >= 0; i--)
            {
                var tarih = DateTime.Today.AddDays(-1 * i);
                var islemList = Sistem.SembolIslemleriniOku(Sistem.Sembol, tarih.ToString("dd.MM.yyyy"));

                if (islemList.Count == 0)
                {
                    continue;
                }

                var sonK = 0;
                for (int j = sonJ; j < grafikVeriList.Count; j++)
                {
                    if (grafikVeriList[j].Date < tarih.Date)
                    {
                        continue;
                    }
                    if (grafikVeriList[j].Date > tarih.Date.AddDays(1))
                    {
                        sonJ = j;
                        break;
                    }

                    var startTime = grafikVeriList[j - 1].Date.TimeOfDay;
                    var endTime = j + 1 >= Sistem.BarSayisi - 2 ? new TimeSpan(23, 59, 59) : grafikVeriList[j + 1].Date.TimeOfDay;


                    if (startTime > endTime)
                    {
                        endTime = new TimeSpan(23, 59, 59);
                    }


                    var alisTotal = 0;
                    var satisTotal = 0;


                    for (int k = sonK; k < islemList.Count; k++)
                    {
                        var timeStr = islemList[k].GetTimeString();
                        var h = Convert.ToInt32(timeStr.Substring(0, 2));
                        var m = Convert.ToInt32(timeStr.Substring(3, 2));
                        var s = Convert.ToInt32(timeStr.Substring(6, 2));
                        var islemTime = new TimeSpan(h, m, s);
                        if (islemTime < startTime)
                        {
                            continue;
                        }

                        if (islemTime > endTime)
                        {
                            sonK = k;
                            break;
                        }

                        if (islemList[k].Size >= 50 && islemList[k].Deleted == "N")
                        {
                            // Alım İşlemleri
                            if (islemList[k].GetDirection() == 1)
                            {
                                alisTotal += (int)islemList[k].Size;
                            }
                            if (islemList[k].GetDirection() == 2)
                            {
                                satisTotal += (int)islemList[k].Size;
                            }
                        }
                       
                        

                    } 

                    if (alisTotal > satisTotal)
                    {
                        sinyalList[j] = alisTotal;
                    }
                    else if (satisTotal > alisTotal)
                    {
                        sinyalList[j] = -1 * satisTotal;
                    }
                    else
                    {
                        sinyalList[j] = 0;
                    }
                }
            }



            #endregion

            #region Sistem çıktılarını ekrana çizdir.

            /*************SINYAL*****************/
            Sistem.Cizgiler[0].Deger = sinyalList;
            Sistem.Cizgiler[0].Aciklama = "BigBoss Sinyal";
            Sistem.Cizgiler[0].Panel = 2;
            Sistem.Cizgiler[0].ActiveBool = true;
            Sistem.Cizgiler[0].Kalinlik = 2;
            Sistem.Cizgiler[0].Renk = Color.AliceBlue;
            #endregion
        }
    }
}
