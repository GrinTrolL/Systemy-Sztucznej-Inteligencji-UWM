using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wykresy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SmileButton_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            NarysujPunkty();

            NarysujSinus();

            NarysujGlowe();

        }

        private void NarysujPunkty()
        {
            List<double> xPoints = new List<double>
            {
                -1,0,1
            };
            List<double> yPoints = new List<double>
            {
                1,0,1
            };

            wykres_punkty_rysuj(xPoints, yPoints);
        }

        private void NarysujSinus()
        {
            List<double> xPoints = new List<double>
            {
                -1,0,1
            };
            List<double> yPoints = new List<double>
            {
                0,-1,0
            };

            wykres_linie_rysuj(xPoints, yPoints);
        }

        private void NarysujGlowe()
        { 
            var xPoints = new List<double>();

            var yPoints = new List<double>();

            for (double i=0;i<17;i++)
            {
                xPoints.Add(2 * Math.Sin(Math.PI * (i / 8)));
                yPoints.Add(2 * Math.Sin(Math.PI * (i+4)/8));
            }

            wykres_linie_rysuj(xPoints, yPoints);
        }
    }
}
