using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Systems.Sistem
{
    class SistemleriBirlestir : IdealSistem
    {
        public SistemleriBirlestir()
        {

            var ParametreList = new List<string>();
            //Çift tırnak içine, sistem adı, grafik periyodu, işlem adedi bilgilerinizi girin
            ParametreList.Add("Sistem1 , 1, 1");
            ParametreList.Add("Sistem2, 1, 1");
            ParametreList.Add("Sistem3 , 1, 2");
            ParametreList.Add("Sistem4 , 1, 1");

            var V = Sistem.GrafikVerileri;
            var C = Sistem.GrafikFiyatOku(V, "Kapanis");
            for (int i = 300; i < V.Count; i++)
            {
                if (V[i].Date.Month != V[i - 1].Date.Month)
                    Sistem.DikeyCizgiEkle(i, Color.DimGray, 2, 2);
            }
            var SistemList = new List<string>();
            var PeriyotList = new List<string>();
            var LotList = new List<float>();
            for (int i = 0; i < ParametreList.Count; i++)
            {
                var FieldArray = ParametreList[i].Split(',');
                SistemList.Add(FieldArray[0].Trim());
                PeriyotList.Add(FieldArray[1].Trim());
                LotList.Add(Convert.ToSingle(FieldArray[2].Trim()));
            }
            var ViopData = Sistem.GrafikVerileri;
            var TarihDictionary = new Dictionary<DateTime, int>();
            for (int i = 0; i < ViopData.Count; i++)
                TarihDictionary[ViopData[i].Date] = i;

            // yön listelerini oluştur
            List<List<string>> Yonler = new List<List<string>>();
            //for (int i = 0; i < ParametreList.Count; i++)
            //    Yonler.Add(System.Linq.Enumerable.Repeat("", ViopData.Count).ToList());
            for (int i = 0; i < ParametreList.Count; i++)
            {
                var BosList = new List<string>();
                for (int j = 0; j < ViopData.Count; j++)
                    BosList.Add("");
                Yonler.Add(BosList);
            }

            // yönleri bul
            for (int i = 0; i < ParametreList.Count; i++)
            {
                var SembolSistem = Sistem.SistemGetir(SistemList[i], Sistem.Sembol, PeriyotList[i]);
                if (SembolSistem == null) continue;
                for (int j = 0; j < SembolSistem.GrafikVerileri.Count; j++)
                {
                    var Tarih = SembolSistem.GrafikVerileri[j].Date;
                    if (TarihDictionary.ContainsKey(Tarih))
                        Yonler[i][TarihDictionary[Tarih]] = SembolSistem.Yon[j];
                }
            }

            // pozisyon hesapla
            var SonPozDictionary = new Dictionary<string, int>();
            var PozList = Sistem.Liste(0);
            for (int i = 0; i < Yonler.Count; i++)
            {
                var SonPozStr = "";
                for (int j = V.Count - 1; j > 0; j--)
                {
                    if (Yonler[i][j] != "")
                    {
                        SonPozStr = Yonler[i][j];
                        break;
                    }
                }
                int SonPozLot = 0;
                if (SonPozStr == "A")
                    SonPozLot = Convert.ToInt32(LotList[i]);
                else if (SonPozStr == "S")
                    SonPozLot = -Convert.ToInt32(LotList[i]);
                SonPozDictionary[SistemList[i]] = SonPozLot;


                float Poz = 0;
                for (int j = 0; j < V.Count; j++)
                {
                    if (Yonler[i][j] == "A")
                        Poz = LotList[i];
                    else if (Yonler[i][j] == "S")
                        Poz = -LotList[i];
                    else if (Yonler[i][j] == "F")
                        Poz = 0;

                    PozList[j] += Convert.ToInt32(Poz);
                }
            }
            Sistem.Cizgiler[0].Deger = PozList;
            Sistem.Cizgiler[1].Deger = Sistem.Liste(0);
            Sistem.DolguEkle(0, 1, Color.FromArgb(120, 0, 255, 0), Color.FromArgb(120, 255, 0, 0));

            Sistem.Dortgen(1, 10, 30, 280, 100, Color.Gold, Color.Orange, Color.Gold);
            Sistem.Dortgen(1, 10, 130, 280, 230, Color.Black, Color.Black, Color.Gold);

            int Counter = 0;
            foreach (var item in SonPozDictionary)
            {
                var RenkPoz = Color.Gold;
                if (item.Value > 0)
                    RenkPoz = Color.LimeGreen;
                else if (item.Value < 0)
                    RenkPoz = Color.Red;
                Counter++;
                Sistem.GradientYaziEkle(item.Key, 1, 30, 120 + Counter * 25, RenkPoz, RenkPoz, "Tahoma", 18);
                Sistem.GradientYaziEkle(" :   " + Math.Abs(item.Value).ToString("0"), 1, 100, 120 + Counter * 25, RenkPoz, RenkPoz, "Tahoma", 18);
            }
            // al sat renklendir
            var SonYon = "";
            for (int i = 0; i < V.Count; i++)
            {
                if (PozList[i] > 0 && SonYon != "A")
                    Sistem.Yon[i] = "A";
                else if (PozList[i] < 0 && SonYon != "S")
                    Sistem.Yon[i] = "S";
                else if (PozList[i] == 0 && SonYon != "F")
                    Sistem.Yon[i] = "F";

                if (Sistem.Yon[i] != "")
                    SonYon = Sistem.Yon[i];
            }

            // kar zarar hesapla
            var Kasa = 0.0f;
            var KZList = Sistem.Liste(0);
            for (int i = 1; i < V.Count; i++)
            {
                if (PozList[i] != PozList[i - 1])
                    Kasa += -(PozList[i] - PozList[i - 1]) * C[i];
                KZList[i] = Kasa + (PozList[i] * C[i]);
            }
            //for (int i = 1; i < V.Count; i++)
            //{
            //    KZList[i] *= 100;
            //}
            //Sistem.Cizgiler[2].Deger = KZList;
            var GetiriKZGunSonu = Sistem.Liste(0);
            GetiriKZGunSonu[GetiriKZGunSonu.Count - 1] = KZList[KZList.Count - 1];
            for (int i = KZList.Count - 2; i >= 0; i--)
            {
                GetiriKZGunSonu[i] = GetiriKZGunSonu[i + 1];
                if (V[i].Date.Day != V[i + 1].Date.Day)
                    GetiriKZGunSonu[i] = KZList[i];
            }
            Sistem.Cizgiler[2].Deger = KZList;

            // yazılar
            Sistem.GradientYaziEkle("Birleşik", 1, 40, 50, Color.Black, Color.Black, "Tahoma", 40);
            var Sure = (DateTime.Now - V[0].Date).TotalDays / 30.4;

            // Gün
            var DateGunBarNo = 0;
            for (int i = V.Count - 2; i > 0; i--)
            {
                if (V[i].Date.Day != V[V.Count - 1].Date.Day)
                {
                    DateGunBarNo = i;
                    break;
                }
            }
            var GetiriGun = Math.Round((KZList[KZList.Count - 1] - KZList[DateGunBarNo]), 1);

            // 1 ay
            var Date1Ay = DateTime.Now.AddDays(-30);
            var Date1AyBarNo = 0;
            for (int i = V.Count - 1; i > 0; i--)
            {
                if (V[i].Date <= Date1Ay)
                {
                    Date1AyBarNo = i;
                    break;
                }
            }
            var Getiri1Ay = Math.Round((KZList[KZList.Count - 1] - KZList[Date1AyBarNo]), 1);

            // 2 ay
            var Date2Ay = DateTime.Now.AddDays(-60);
            var Date2AyBarNo = 0;
            for (int i = V.Count - 1; i > 0; i--)
            {
                if (V[i].Date <= Date2Ay)
                {
                    Date2AyBarNo = i;
                    break;
                }
            }
            var Getiri2Ay = Math.Round((KZList[KZList.Count - 1] - KZList[Date2AyBarNo]), 1);

            // 3 ay
            var Date3Ay = DateTime.Now.AddDays(-90);
            var Date3AyBarNo = 0;
            for (int i = V.Count - 1; i > 0; i--)
            {
                if (V[i].Date <= Date3Ay)
                {
                    Date3AyBarNo = i;
                    break;
                }
            }
            var Getiri3Ay = Math.Round((KZList[KZList.Count - 1] - KZList[Date3AyBarNo]), 1);


            var GetiriKZAy = Sistem.Liste(0);
            for (int i = 1; i < V.Count; i++)
            {
                if (V[i].Date.Month == V[i - 1].Date.Month)
                    GetiriKZAy[i] = GetiriKZAy[i - 1];
                else
                    GetiriKZAy[i] = KZList[i - 1];
            }
            Sistem.Cizgiler[3].Deger = GetiriKZAy;
            Sistem.DolguEkle(2, 3, Color.FromArgb(80, 0, 255, 0), Color.FromArgb(80, 255, 0, 0));

            Sistem.Dortgen(3, 10, 30, 280, 50, Color.Gold, Color.Orange, Color.Gold);
            Sistem.Dortgen(3, 10, 80, 280, 230, Color.Black, Color.Black, Color.Gold);

            Sistem.GradientYaziEkle(Sure.ToString("0.0") + " Ay", 3, 30, 40, Color.Black, Color.Black, "Calibri", 18);
            Sistem.GradientYaziEkle((KZList[KZList.Count - 1]).ToString("0.000"), 3, 180, 40, Color.Black, Color.Black, "Calibri", 18);
            Sistem.GradientYaziEkle("30 Gün", 3, 30, 90, Color.Silver, Color.Silver, "Calibri", 18);
            Sistem.GradientYaziEkle(Getiri1Ay.ToString("0.000"), 3, 180, 90, Color.Gold, Color.Gold, "Calibri", 18);
            Sistem.GradientYaziEkle("60 Gün", 3, 30, 120, Color.Silver, Color.Silver, "Calibri", 18);
            Sistem.GradientYaziEkle(Getiri2Ay.ToString("0.000"), 3, 180, 120, Color.Gold, Color.Gold, "Calibri", 18);
            Sistem.GradientYaziEkle("90 Gün", 3, 30, 150, Color.Silver, Color.Silver, "Calibri", 18);
            Sistem.GradientYaziEkle(Getiri3Ay.ToString("0.000"), 3, 180, 150, Color.Gold, Color.Gold, "Calibri", 18);

            var Renk = Color.Gold;
            if (GetiriGun > 0)
                Renk = Color.LimeGreen;
            else if (GetiriGun < 0)
                Renk = Color.Red;
            Sistem.GradientYaziEkle("BU GÜN", 3, 30, 220, Renk, Renk, "Calibri", 18);
            Sistem.GradientYaziEkle(GetiriGun.ToString("0.000"), 3, 180, 220, Renk, Renk, "Calibri", 18);


            var SonPoz = PozList[PozList.Count - 1];
            Renk = Color.Gold;
            if (SonPoz > 0)
                Renk = Color.LimeGreen;
            else if (SonPoz < 0)
                Renk = Color.Red;
            Sistem.GradientYaziEkle("POZ", 3, 30, 260, Renk, Renk, "Calibri", 18);
            Sistem.GradientYaziEkle(SonPoz.ToString("0"), 3, 180, 260, Renk, Renk, "Calibri", 18);

        }
    }
}
