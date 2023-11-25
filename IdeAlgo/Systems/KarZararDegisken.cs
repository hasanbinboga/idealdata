using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricks;


namespace Systems
{
    class KarZararDegisken : IdealSistem
    {

        public KarZararDegisken()
        {
            var SistemAdi = "Sistemim1";

            var Seviyeler = new List<float>();
            Seviyeler.Add(68);
            Seviyeler.Add(70);
            Seviyeler.Add(72);
            Seviyeler.Add(76);
            Seviyeler.Add(78);
            //Seviyeler.Add(80);
            //Seviyeler.Add(82);

            var V = Sistem.GrafikVerileri;
            var OrjinalSistem = Sistem.SistemGetir(SistemAdi, Sistem.Sembol, Sistem.Periyot);
            var GetiriList = OrjinalSistem.GetiriKZ;
            Sistem.Cizgiler[0].Deger = GetiriList;

            for (int i = 0; i < Seviyeler.Count; i++)
            {
                Sistem.Cizgiler[i + 10].ActiveBool = true;
                Sistem.Cizgiler[i + 10].Deger = Sistem.Liste(Seviyeler[i]);
                Sistem.Cizgiler[i + 10].Panel = 2;
                Sistem.Cizgiler[i + 10].Renk = Color.IndianRed;
                Sistem.Cizgiler[i + 10].Stil = 2;
            }

            var StatuListesi = Sistem.Liste(0);
            var SonStatu = 0;
            for (int i = 1; i < V.Count; i++)
            {
                for (int j = 0; j < Seviyeler.Count; j++)
                {
                    if (GetiriList[i - 1] > Seviyeler[j] && GetiriList[i] <= Seviyeler[j])
                    {
                        SonStatu = 0;
                        break;
                    }
                    if (GetiriList[i - 1] < Seviyeler[j] && GetiriList[i] >= Seviyeler[j])
                    {
                        SonStatu = 1;
                        break;
                    }
                }
                StatuListesi[i] = SonStatu;
            }

            var RenkListesi = new List<Color>();
            for (int i = 0; i < Sistem.BarSayisi; i++)
                RenkListesi.Add(Color.Gray);
            for (int i = 1; i < V.Count; i++)
            {
                if (StatuListesi[i] == 0)
                    RenkListesi[i] = Color.Gray;
                else if (StatuListesi[i] == 1)
                    RenkListesi[i] = Color.Cyan;
            }
            Sistem.Cizgiler[0].RenkListesi = RenkListesi;

            var OrjinalPozisyonList = Sistem.Liste(0);
            var Yon = "";
            for (int i = 0; i < V.Count; i++)
            {
                if (OrjinalSistem.Yon[i] == "A")
                    Yon = "A";
                else if (OrjinalSistem.Yon[i] == "S")
                    Yon = "S";
                else if (OrjinalSistem.Yon[i] == "F")
                    Yon = "F";

                if (Yon == "A")
                    OrjinalPozisyonList[i] = 1;
                else if (Yon == "S")
                    OrjinalPozisyonList[i] = -1;
                else if (Yon == "F")
                    OrjinalPozisyonList[i] = 0;
            }
            var YeniPozisyonList = Sistem.Liste(0);
            var SonYon = "";
            for (int i = 0; i < V.Count; i++)
            {
                if (StatuListesi[i] == 0)
                {
                    if (SonYon != "F")
                    {
                        Sistem.Yon[i] = "F";
                        SonYon = Sistem.Yon[i];
                    }
                }
                else
                {
                    if (SonYon != "A" && OrjinalPozisyonList[i] == 1)
                    {
                        Sistem.Yon[i] = "A";
                        SonYon = Sistem.Yon[i];
                    }
                    if (SonYon != "S" && OrjinalPozisyonList[i] == -1)
                    {
                        Sistem.Yon[i] = "S";
                        SonYon = Sistem.Yon[i];
                    }
                    if (SonYon != "F" && OrjinalPozisyonList[i] == 0)
                    {
                        Sistem.Yon[i] = "F";
                        SonYon = Sistem.Yon[i];
                    }
                }
            }




        }
    }
}
