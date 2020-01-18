using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SterownikRozmyty
{
    public struct SymulacjaParametry
    {
        public static readonly int x_min = -100, x_max = 100, x_zasieg = 200;
        public static readonly int y_min = -100, y_max = 0, y_zasieg = 100;
        public static readonly int rampa_lewy = -30, rampa_prawy = +30, rampa_dol = -10, rampa_gora = 0;
        public static readonly int rampa_kat_docelowy_min = -20, rampa_kat_docelowy_max = +20;
        public static readonly int obrot_min = -20, obrot_max = +20;
        public static readonly int kat_min = -180, kat_max = +180, kat_zasieg = 360;
        public static readonly double ruch_skok = 5.0;
    }

    public struct PojazdPolozenie
    {
        public int x, y;
        public int kat; //-180...+180 stopni

        public void przemieszczenieDoPrzodu(double krok, int kat_obrotu)
        {
            double kat_rad;
            kat += kat_obrotu;
            while (kat < -180)
                kat += 360;
            while (kat > +180)
                kat -= 360;

            kat_rad = kat * Math.PI / 180.0;

            x -= (int) Math.Round(krok * Math.Sin(-kat_rad));
            y += (int) Math.Round(krok * Math.Cos(-kat_rad));
        }
    }

    public partial class OkienkoForm : Form
    {
        protected PojazdPolozenie pojazd_polozenie;
        protected int symulacje_wyniki_sukcesy = 0;
        protected int symulacje_wyniki_porazki = 0;
        protected Random rkg;
        
        public OkienkoForm()
        {
            InitializeComponent();

            rkg = new Random(1234);

            losuj_pozycje();

            parking_rysuj(pojazd_polozenie);
            pojazdu_parametry_wypisz(pojazd_polozenie);

            SterownikRozmyty_Algorytm.inicjuj();
        }

        public void symulacja_pojedynczy_krok(int obrot)
        {
            bool czy_koniec, czy_sukces;
            symulacja_pojedynczy_krok(obrot, out czy_koniec, out czy_sukces);
        }

        public void symulacja_pojedynczy_krok(int obrot, out bool czy_koniec, out bool czy_sukces)
        {
            if (obrot < SymulacjaParametry.obrot_min)
                obrot = SymulacjaParametry.obrot_min;
            else if (obrot > SymulacjaParametry.obrot_max)
                obrot = SymulacjaParametry.obrot_max;
            this.pojazd_polozenie.przemieszczenieDoPrzodu(SymulacjaParametry.ruch_skok, obrot);
            sprawdz_pozycje(out czy_koniec, out czy_sukces);
            if (czy_koniec)
            {
                if (czy_sukces)
                    symulacje_wyniki_sukcesy++;
                else
                    symulacje_wyniki_porazki++;
                losuj_pozycje();
            }
            odswiez_wszystko();
        }

        public void sprawdz_pozycje(out bool czy_koniec, out bool czy_sukces)
        {
            sprawdz_pozycje(this.pojazd_polozenie, out czy_koniec, out czy_sukces);
        }

        public void sprawdz_pozycje(PojazdPolozenie pol_pot, out bool czy_koniec, out bool czy_sukces)
        {
            if (pol_pot.x < SymulacjaParametry.x_min)
            {
                czy_sukces = false; czy_koniec = true;
            }
            else if (pol_pot.x > SymulacjaParametry.x_max)
            {
                czy_sukces = false; czy_koniec = true;
            }
            else if (pol_pot.y < SymulacjaParametry.y_min)
            {
                czy_sukces = false; czy_koniec = true;
            }
            else if (pol_pot.y > SymulacjaParametry.y_max)
            {
                czy_sukces = false; czy_koniec = true;
            }
            else if (pol_pot.x >= SymulacjaParametry.rampa_lewy
                && pol_pot.x <= SymulacjaParametry.rampa_prawy
                && pol_pot.y >= SymulacjaParametry.rampa_dol
                && pol_pot.y <= SymulacjaParametry.rampa_gora
                && pol_pot.kat >= SymulacjaParametry.rampa_kat_docelowy_min
                && pol_pot.kat <= SymulacjaParametry.rampa_kat_docelowy_max
                )
            {
                czy_sukces = true; czy_koniec = true;
            }
            else
            {
                czy_sukces = false; czy_koniec = false;
            }
        }

        private void losuj_pozycje()
        {
            pojazd_polozenie.x = (int)( SymulacjaParametry.x_min + SymulacjaParametry.x_zasieg * rkg.NextDouble());
            pojazd_polozenie.y = (int)( SymulacjaParametry.y_min + SymulacjaParametry.y_zasieg * rkg.NextDouble());
            pojazd_polozenie.kat = (int)( SymulacjaParametry.kat_min + SymulacjaParametry.kat_zasieg * rkg.NextDouble());
        }

        private void odswiez_wszystko()
        {
            parking_rysuj(pojazd_polozenie);
            pojazdu_parametry_wypisz(pojazd_polozenie);
            symulacje_wyniki_wypisz();

            przyszloscPojazdXTextBox.Text = "";
            przyszloscPojazdYTextBox.Text = "";
            przyszloscPojazdKierunekTextBox.Text = "";
            przyszloscPojazdObrotTextBox.Text = "";
        }

        private void symulacje_wyniki_wypisz()
        {
            symulacjeWynikiTextBox.Text = String.Format(" l.sym. skończonych= {0}\r\n l. sukcesów= {1}\r\n l. porażek= {2}",
                symulacje_wyniki_sukcesy + symulacje_wyniki_porazki, symulacje_wyniki_sukcesy, symulacje_wyniki_porazki);                       
        }

        private void pojazdu_parametry_wypisz(PojazdPolozenie pol)
        {
            pojazdu_parametry_wypisz(pol.x, pol.y, pol.kat);
        }

        private void pojazdu_parametry_wypisz(int pojazd_x, int pojazd_y, double pojazd_kat)
        {
            pojazdXTextBox.Text = pojazd_x.ToString();
            pojazdYTextBox.Text = pojazd_y.ToString();
            pojazdKierunekTextBox.Text = pojazd_kat.ToString();
        }

        private void parking_rysuj(PojazdPolozenie pol)
        {
            parking_rysuj(pol.x, pol.y, pol.kat);
        }

        private void parking_rysuj(int x, int y, double kat)
        {
            double x_srodek, y_srodek;
            double pojazd_kat_rad;
            x_srodek = (SymulacjaParametry.x_min + SymulacjaParametry.x_max) / 2.0;
            y_srodek = (SymulacjaParametry.y_min + SymulacjaParametry.y_max) / 2.0;
            pojazd_kat_rad = kat * Math.PI / 180.0;

            System.Windows.Forms.DataVisualization.Charting.ChartArea przestrzen;
            System.Windows.Forms.DataVisualization.Charting.Chart wykres;

            wykres = parkingChart;
            przestrzen = wykres.ChartAreas[0];
            wykres.Series.Clear();

            przestrzen.AxisX.Title = "x"; przestrzen.AxisY.Title = "y";
            przestrzen.AxisX.Minimum = SymulacjaParametry.x_min;
            przestrzen.AxisX.Maximum = SymulacjaParametry.x_max;
            przestrzen.AxisY.Minimum = SymulacjaParametry.y_min;
            przestrzen.AxisY.Maximum = SymulacjaParametry.y_max;
            przestrzen.AxisX.Interval = SymulacjaParametry.x_zasieg / 8.0;
            przestrzen.AxisY.Interval = SymulacjaParametry.y_zasieg / 4.0;

            {
                System.Windows.Forms.DataVisualization.Charting.Series granica;
                wykres.Series.Add("granice parkingu");
                granica = wykres.Series.Last();
                granica.IsVisibleInLegend = false;
                granica.ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                granica.Color = Color.Black;
                granica.BorderWidth = 2;
                granica.Points.AddXY(SymulacjaParametry.x_min, SymulacjaParametry.y_max);
                granica.Points.AddXY(SymulacjaParametry.x_min, SymulacjaParametry.y_min);
                granica.Points.AddXY(SymulacjaParametry.x_max, SymulacjaParametry.y_min); 
                granica.Points.AddXY(SymulacjaParametry.x_max, SymulacjaParametry.y_max);
                granica.Points.AddXY(SymulacjaParametry.x_min, SymulacjaParametry.y_max);
            }
            {
                System.Windows.Forms.DataVisualization.Charting.Series siatka;                
                
                wykres.Series.Add("siatka na parkingu");
                siatka = wykres.Series.Last();
                siatka.IsVisibleInLegend = false;
                siatka.ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                siatka.Color = Color.Blue;
                siatka.BorderWidth = 1;
                siatka.Points.AddXY(x_srodek, y_srodek);
                siatka.Points.AddXY(SymulacjaParametry.x_min, y_srodek);
                siatka.Points.AddXY(SymulacjaParametry.x_max, y_srodek);
                siatka.Points.AddXY(x_srodek, y_srodek);
                siatka.Points.AddXY(x_srodek, SymulacjaParametry.y_min);
                siatka.Points.AddXY(x_srodek, SymulacjaParametry.y_max);
                siatka.Points.AddXY(x_srodek, y_srodek);
            }
            {
                System.Windows.Forms.DataVisualization.Charting.Series siatka;

                wykres.Series.Add("siatka na rampe");
                siatka = wykres.Series.Last();
                siatka.IsVisibleInLegend = false;
                siatka.ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                siatka.BorderDashStyle =
                    System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
                siatka.Color = Color.Red;
                siatka.BorderWidth = 1;
                siatka.Points.AddXY(SymulacjaParametry.rampa_lewy,  SymulacjaParametry.rampa_gora);
                siatka.Points.AddXY(SymulacjaParametry.rampa_lewy,  SymulacjaParametry.rampa_dol);
                siatka.Points.AddXY(SymulacjaParametry.rampa_prawy, SymulacjaParametry.rampa_dol);
                siatka.Points.AddXY(SymulacjaParametry.rampa_prawy, SymulacjaParametry.rampa_gora);
                siatka.Points.AddXY(SymulacjaParametry.rampa_lewy,  SymulacjaParametry.rampa_gora);
            }
            {
                System.Windows.Forms.DataVisualization.Charting.Series pojazd_seria;
                List<Tuple<double, double>> punkty;

                wykres.Series.Add("pojazd");
                pojazd_seria = wykres.Series.Last();
                pojazd_seria.IsVisibleInLegend = false;
                //pojazd_seria.LegendText = String.Format("kier.poj.= {0,6:N1}", kat);
                pojazd_seria.ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                pojazd_seria.Color = Color.Green;
                pojazd_seria.BorderWidth = 1;

                punkty = new List<Tuple<double, double>>();
                punkty.Add(new Tuple<double, double>(0, 0));
                punkty.Add(new Tuple<double, double>(0, SymulacjaParametry.y_zasieg / 20));
                punkty.Add(new Tuple<double, double>(SymulacjaParametry.x_zasieg / 30, -SymulacjaParametry.y_zasieg / 30));
                punkty.Add(new Tuple<double, double>(0, 0));
                punkty.Add(new Tuple<double, double>(-SymulacjaParametry.x_zasieg / 30, -SymulacjaParametry.y_zasieg / 30));
                punkty.Add(new Tuple<double, double>(0, SymulacjaParametry.y_zasieg / 20));
                
                for (int p_nr = 0; p_nr  < punkty.Count; p_nr++)
                { //obrot i przesinięcie punktów dot. pojazdu
                    double p_x_stary, p_x_nowy, p_y_stary, p_y_nowy;
                    p_x_stary = punkty[p_nr].Item1;
                    p_y_stary = punkty[p_nr].Item2;

                    //obrót najpierw
                    p_x_nowy = p_x_stary * Math.Cos(-pojazd_kat_rad) - p_y_stary * Math.Sin(-pojazd_kat_rad);
                    p_y_nowy = p_x_stary * Math.Sin(-pojazd_kat_rad) + p_y_stary * Math.Cos(-pojazd_kat_rad);
                    p_x_stary = p_x_nowy; p_y_stary = p_y_nowy;

                    //pozniej przesunięcie
                    p_x_nowy = p_x_stary + x;
                    p_y_nowy = p_y_stary + y;
                    p_x_stary = p_x_nowy; p_y_stary = p_y_nowy;

                    punkty[p_nr] = new Tuple<double, double>(p_x_nowy, p_y_nowy);
                }

                foreach (Tuple<double, double> pkt in punkty)
                    pojazd_seria.Points.AddXY(pkt.Item1, pkt.Item2);
                punkty.Clear();
            }

        }

        private void ruchDoPrzoduButton_Click(object sender, EventArgs e)
        {
            symulacja_pojedynczy_krok(0);
        }

        private void ruchMocnoWLewoButton_Click(object sender, EventArgs e)
        {
            symulacja_pojedynczy_krok(SymulacjaParametry.obrot_min);
        }

        private void ruchLekkoWLewoButton_Click(object sender, EventArgs e)
        {
            symulacja_pojedynczy_krok(SymulacjaParametry.obrot_min / 2);
        }

        private void ruchMocnoWPrawoButton_Click(object sender, EventArgs e)
        {
            symulacja_pojedynczy_krok(SymulacjaParametry.obrot_max);
        }

        private void ruchLekkoWPrawoButton_Click(object sender, EventArgs e)
        {
            symulacja_pojedynczy_krok(SymulacjaParametry.obrot_max / 2);
        }

        private void ruchDoTyluButton_Click(object sender, EventArgs e)
        {
            bool czy_koniec, czy_sukces;

            this.pojazd_polozenie.przemieszczenieDoPrzodu(-SymulacjaParametry.ruch_skok, 0);
            sprawdz_pozycje(out czy_koniec, out czy_sukces);
            if (czy_koniec)
            {
                if (czy_sukces)
                    symulacje_wyniki_sukcesy++;
                else
                    symulacje_wyniki_porazki++;
                losuj_pozycje();
            }
            odswiez_wszystko();
        }
        
        private void parkingChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                ruchDoPrzoduButton_Click(sender, null);
            else if(e.KeyCode == Keys.A)
                ruchMocnoWLewoButton_Click(sender, null);
            else if (e.KeyCode == Keys.Q)
                ruchLekkoWLewoButton_Click(sender, null);
            else if (e.KeyCode == Keys.E)
                ruchLekkoWPrawoButton_Click(sender, null);
            else if (e.KeyCode == Keys.D)
                ruchMocnoWPrawoButton_Click(sender, null);
            else if (e.KeyCode == Keys.S)
                ruchDoTyluButton_Click(sender, null);
        }

        private void symulacjeWynikiResetButton_Click(object sender, EventArgs e)
        {
            symulacje_wyniki_porazki = 0;
            symulacje_wyniki_sukcesy = 0;
            losuj_pozycje();
            odswiez_wszystko();
        }

        private void pojazdWprowadzPozycjeButton_Click(object sender, EventArgs e)
        {
            bool sukces = true;
            bool czy_koniec, czy_cel_osiagniety;
            PojazdPolozenie potPol;

            sukces &= Int32.TryParse(pojazdXTextBox.Text, out potPol.x);
            sukces &= Int32.TryParse(pojazdYTextBox.Text, out potPol.y);
            sukces &= Int32.TryParse(pojazdKierunekTextBox.Text, out potPol.kat);

            while (potPol.kat < -180)
                potPol.kat += 360;
            while (potPol.kat > +180)
                potPol.kat -= 360;

            sprawdz_pozycje(potPol, out czy_koniec, out czy_cel_osiagniety );
            if (czy_koniec)
                sukces = false;

            if (!sukces)
                return;

            this.pojazd_polozenie = potPol;
            odswiez_wszystko();
        }

        /// <summary>
        /// zwraca true jeśli ok
        /// </summary>
        /// <param name="pojazd_polozenie"></param>
        /// <param name="obrot"></param>
        /// <returns></returns>
        private bool SISprobujUzyc(PojazdPolozenie pojazd_polozenie, out int obrot)
        {
            bool rezultat;
            try
            {
                obrot = Int32.MinValue;
                SterownikRozmyty_Algorytm.zwroc_odpowiedz(this.pojazd_polozenie, out obrot);
                if (obrot < SymulacjaParametry.obrot_min)
                    throw new Exception("obrot < SymulacjaParametry.obrot_min");
                else if (obrot > SymulacjaParametry.obrot_max)
                    throw new Exception("obrot > SymulacjaParametry.obrot_max");
                rezultat = true;
            }
            catch( Exception exc)
            {
                rezultat = false;
                obrot = 0;
            }
            return rezultat;
        }

        private void SIPodpatrzButton_Click(object sender, EventArgs e)
        {
            int obrot;
            PojazdPolozenie pol_pot = this.pojazd_polozenie;
            if (SISprobujUzyc(pol_pot, out obrot))
            {
                pol_pot.przemieszczenieDoPrzodu(SymulacjaParametry.ruch_skok, obrot);
                przyszloscPojazdXTextBox.Text = pol_pot.x.ToString();
                przyszloscPojazdYTextBox.Text = pol_pot.y.ToString();
                przyszloscPojazdKierunekTextBox.Text = pol_pot.kat.ToString();
                przyszloscPojazdObrotTextBox.Text = obrot.ToString();
            }
            else
            {
                przyszloscPojazdXTextBox.Text = "!?";
                przyszloscPojazdYTextBox.Text = "?!";
                przyszloscPojazdKierunekTextBox.Text = ":-(";
                przyszloscPojazdObrotTextBox.Text = obrot.ToString();
            }
        }

        private void OkienkoForm_KeyDown(object sender, KeyEventArgs e)
        {
            parkingChart_KeyDown(sender, e);
        }

        private void SIPojRuchButton_Click(object sender, EventArgs e)
        {
            int obrot;
            if (SISprobujUzyc(pojazd_polozenie, out obrot))
            {
                symulacja_pojedynczy_krok(obrot);
            }
            else
            {
                przyszloscPojazdXTextBox.Text = "!?";
                przyszloscPojazdYTextBox.Text = "?!";
                przyszloscPojazdKierunekTextBox.Text = ":-(";
                przyszloscPojazdObrotTextBox.Text = obrot.ToString();
            }
        }

        private void SICalaPojSciezkaButton_Click(object sender, EventArgs e)
        {
            for (int krok = 0; krok < 100; krok++)
            {
                bool czy_koniec, czy_sukces;
                int obrot;
                if (!SISprobujUzyc(pojazd_polozenie, out obrot))
                { //błąd
                    przyszloscPojazdXTextBox.Text = "!?";
                    przyszloscPojazdYTextBox.Text = "?!";
                    przyszloscPojazdKierunekTextBox.Text = ":-(";
                    przyszloscPojazdObrotTextBox.Text = obrot.ToString();
                    break;
                }

                symulacja_pojedynczy_krok(obrot, out czy_koniec, out czy_sukces);

                if (czy_koniec)
                {
                    przyszloscPojazdObrotTextBox.Text = (czy_sukces) ? ("sukces") : ("porażka");
                    break;
                }
                this.Refresh();
                System.Threading.Thread.Sleep(100);
            } // for(krok)
        }

        private void SISeriaTestow1PowoliButton_Click(object sender, EventArgs e)
        {
            const int l_serii = 100;
            const int los_ziarno = 1234;

            rkg = new Random(los_ziarno);

            symulacje_wyniki_porazki = 0;
            symulacje_wyniki_sukcesy = 0;            

            for (int seria = 0; seria < l_serii; seria++)
            {
                losuj_pozycje();
                this.Refresh();

                for (int krok = 0; krok < 100; krok++)
                {
                    bool czy_koniec, czy_sukces;
                    int obrot;
                    if (!SISprobujUzyc(pojazd_polozenie, out obrot))
                    { //błąd
                        przyszloscPojazdXTextBox.Text = "!?";
                        przyszloscPojazdYTextBox.Text = "?!";
                        przyszloscPojazdKierunekTextBox.Text = ":-(";
                        przyszloscPojazdObrotTextBox.Text = obrot.ToString();
                        break;
                    }

                    symulacja_pojedynczy_krok(obrot, out czy_koniec, out czy_sukces);

                    if (czy_koniec)
                    {
                        przyszloscPojazdObrotTextBox.Text = (czy_sukces) ? ("sukces") : ("porażka");
                        break;
                    }
                    this.Refresh();
                    System.Threading.Thread.Sleep(100);
                } // for(krok)
            } // for(seria)
        }

        private void SISeriaTestow1SzybkoButton_Click(object sender, EventArgs e)
        {
            const int l_serii = 100;
            const int los_ziarno = 1234;

            rkg = new Random(los_ziarno);

            symulacje_wyniki_porazki = 0;
            symulacje_wyniki_sukcesy = 0;
            
            for (int seria = 0; seria < l_serii; seria++)
            {
                losuj_pozycje();
                this.Refresh();

                for (int krok = 0; krok < 100; krok++)
                {
                    bool czy_koniec, czy_sukces;
                    int obrot;
                    if (!SISprobujUzyc(pojazd_polozenie, out obrot))
                    { //błąd
                        przyszloscPojazdXTextBox.Text = "!?";
                        przyszloscPojazdYTextBox.Text = "?!";
                        przyszloscPojazdKierunekTextBox.Text = ":-(";
                        przyszloscPojazdObrotTextBox.Text = obrot.ToString();
                        break;
                    }

                    symulacja_pojedynczy_krok(obrot, out czy_koniec, out czy_sukces);

                    if (czy_koniec)
                    {
                        przyszloscPojazdObrotTextBox.Text = (czy_sukces) ? ("sukces") : ("porażka");
                        break;
                    }
                    if (krok % 3 == 0) // odświeżanie co 3 kroki
                        this.Refresh();
                    //System.Threading.Thread.Sleep(100);
                } // for(krok)
            } // for(seria)
        }

        private void SISeriaTestow2SzybkoButton_Click(object sender, EventArgs e)
        {
            const int l_serii = 300;
            const int los_ziarno = 12;

            rkg = new Random(los_ziarno);

            symulacje_wyniki_porazki = 0;
            symulacje_wyniki_sukcesy = 0;
            
            for (int seria = 0; seria < l_serii; seria++)
            {
                losuj_pozycje();
                this.Refresh();

                for (int krok = 0; krok < 100; krok++)
                {
                    bool czy_koniec, czy_sukces;
                    int obrot;
                    if (!SISprobujUzyc(pojazd_polozenie, out obrot))
                    { //błąd
                        przyszloscPojazdXTextBox.Text = "!?";
                        przyszloscPojazdYTextBox.Text = "?!";
                        przyszloscPojazdKierunekTextBox.Text = ":-(";
                        przyszloscPojazdObrotTextBox.Text = obrot.ToString();
                        break;
                    }

                    symulacja_pojedynczy_krok(obrot, out czy_koniec, out czy_sukces);

                    if (czy_koniec)
                    {
                        przyszloscPojazdObrotTextBox.Text = (czy_sukces) ? ("sukces") : ("porażka");
                        break;
                    }
                    //if (krok % 3 == 0) // odświeżanie co 3 kroki
                    //    this.Refresh();
                    //System.Threading.Thread.Sleep(100);
                } // for(krok)
            } // for(seria)
        }
                
    }
}
