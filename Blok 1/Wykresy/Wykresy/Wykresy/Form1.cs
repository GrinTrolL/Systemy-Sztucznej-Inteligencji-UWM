using LoadFileMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wykresy
{
    public partial class Form1 : Form
    {
        private string _descriptionFile = string.Empty;
        private string _valuesFile = string.Empty;

        //private List<List<string>> values;

        //private List<bool> areSymbols;

        //private List<string> names;

        public Form1()
        {
            InitializeComponent();

            wykres_czysc();
        }

        private void SmileButton_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            MainChart.ChartAreas.Add("chart");

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

        private void IrysDescriptionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _descriptionFile = openFileDialog.FileName;
            }

            CheckIfFilesChosen();
        }

        private void IrysDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _valuesFile = openFileDialog.FileName;
            }

            CheckIfFilesChosen();
        }

        private void CheckIfFilesChosen()
        {
            if (!string.IsNullOrWhiteSpace(_descriptionFile) && !string.IsNullOrWhiteSpace(_valuesFile))
            {
                IrysLoadButton.Enabled = true;
            }
        }

        private void CleanProgram()
        {
            _descriptionFile = string.Empty;
            _valuesFile = string.Empty;
            IrysLoadButton.Enabled = false;
        }

        private void IrysLoadButton_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            MainChart.ChartAreas.Add(new ChartArea()
            {
                Name = "TopLeft",
                Position = new ElementPosition(0, 0, 45, 50)

            });
            MainChart.ChartAreas.Add(new ChartArea()
            {
                Name = "TopRight",
                Position = new ElementPosition(45, 0, 45, 50)

            });
            MainChart.ChartAreas.Add(new ChartArea()
            {
                Name = "BottomLeft",
                Position = new ElementPosition(0, 50, 45, 50)

            });
            MainChart.ChartAreas.Add(new ChartArea()
            {
                Name = "BottomRight",
                Position = new ElementPosition(45, 50, 45, 50)

            });

            try
            {
                FileExtensionMethods.wczytaj_baze_probek_z_tekstem(_valuesFile, _descriptionFile, out List<List<string>> values, out List<bool> areSymbols, out List<string> names);

                List<List<double>> attributes = new List<List<double>>();

                for (int i = 0; i < values[0].Count - 1; i++)
                {
                    attributes.Add(new List<double>());
                }

                List<string> classes = new List<string>();

                foreach (var row in values)
                {
                    for (int i = 0; i < row.Count - 1; i++)
                    {
                        double number;
                        try
                        {
                            number = double.Parse(row[i], CultureInfo.InvariantCulture);
                            attributes[i].Add(number);
                        }
                        catch
                        {
                            throw new Exception("Dane z pliku nie są w formacie double.");
                        }
                    }

                    
                    if (!classes.Contains(row[row.Count-1]))
                    {
                        classes.Add(row[row.Count - 1]);
                    }
                }

                Dictionary<string, List<int>> indexesPerClass = new Dictionary<string, List<int>>();

                foreach (var classe in classes)
                {
                    List<int> indexes = new List<int>();
                    for (int i=0;i<values.Count;i++)
                    {
                        if (values[i][values[i].Count-1] == classe)
                        {
                            indexes.Add(i);
                        }
                    }
                    indexesPerClass.Add(classe, indexes);
                }

                PaintArea(indexesPerClass, attributes, 2, 3);
                PaintArea(indexesPerClass, attributes, 1, 3);
                PaintArea(indexesPerClass, attributes, 0, 3);
                PaintArea(indexesPerClass, attributes, 1, 2);

                for (int i=0;i<MainChart.Series.Count;i++)
                {
                    MainChart.Series[i].ChartArea = MainChart.ChartAreas[i / 3].Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                CleanProgram();

                return;
            }
        }

        void PaintArea(Dictionary<string, List<int>> indexesPerClass, List<List<double>> attributes, int xAttributeIndex, int yAttributeIndex)
        {
            foreach (var entry in indexesPerClass)
            {
                var x = new List<double>();
                var y = new List<double>();
                foreach (var index in entry.Value)
                {
                    x.Add(attributes[xAttributeIndex][index]);
                    y.Add(attributes[yAttributeIndex][index]);
                }
                wykres_punkty_rysuj(x, y);
            }
        }

        //ZMIANA
        private void button1_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            MainChart.ChartAreas.Add("chart");

            NarysujKolo();

            MainChart.ChartAreas[0].AxisX.Minimum = -1;
            MainChart.ChartAreas[0].AxisX.Maximum = 1;
            MainChart.ChartAreas[0].AxisY.Minimum = -1;
            MainChart.ChartAreas[0].AxisY.Maximum = 1;
        }

        private void NarysujKolo()
        {
            var xPoints = new List<double>();

            var yPoints = new List<double>();

            for (double i = 0; i < 17; i++)
            {
                xPoints.Add(Math.Sin(Math.PI * (i / 8)));
                yPoints.Add(Math.Sin(Math.PI * (i + 4) / 8));
            }

            wykres_linie_rysuj(xPoints, yPoints);
        }
    }
}
