using DrawChartExtensionMethods;
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

namespace K_Mean_FCM
{
    public partial class Form1 : Form
    {
        private string _descriptionFile;
        private string _valuesFile;

        public Form1()
        {
            InitializeComponent();
            wykres_czysc();
        }

        private void LoadSpiralTypeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _descriptionFile = openFileDialog.FileName;
            }

            CheckIfFilesChosen();
        }

        private void LoadSpiralDataButton_Click(object sender, EventArgs e)
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
                KMeanButton.Enabled = true;
                FCMButton.Enabled = true;
            }
        }

        private void CleanProgram()
        {
            _descriptionFile = string.Empty;
            _valuesFile = string.Empty;
            KMeanButton.Enabled = false;
            KMedoidButton.Enabled = false;
            FCMButton.Enabled = false;
        }

        void wykres_punkty_rysuj(List<double> wartosci_x, List<double> wartosci_y)
        {
            if (wartosci_x.Count != wartosci_y.Count)
            {
                MessageBox.Show("Podano złe punkty do serii");
                return;
            }

            var series = GetSeries();

            series.ChartType = SeriesChartType.Point;

            for (int i = 0; i < wartosci_x.Count; i++)
            {
                series.Points.AddXY(wartosci_x[i], wartosci_y[i]);
            }

            MainChart.Series.Add(series);
        }
        void StyleSeries(Series series, int seriesNumber)
        {
            var style = ChartExtensionMethods.seriesStyles[seriesNumber % 10];

            series.Color = style.Color;
            series.MarkerStyle = style.MarkerStyle;
            series.BorderDashStyle = style.ChartDashStyle;
            series.Name = $"Seria {seriesNumber}";
        }
        Series GetSeries()
        {
            var series = new Series();

            StyleSeries(series, MainChart.Series.Count);

            return series;
        }
        void wykres_czysc()
        {
            MainChart.Series.Clear();
            MainChart.ChartAreas.Clear();
        }

        private void KMeanButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(GroupsCount.Text, out int groupsCount))
            {
                MessageBox.Show("Niepoprawna liczba grup!");
                return;
            }
            else
            {
                if (groupsCount < 1)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            if (!int.TryParse(IterationCount.Text, out int iterationsCount))
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }
            else
            {
                if (iterationsCount < 1)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            wykres_czysc();

            FileExtensionMethods.wczytaj_baze_probek_z_tekstem(_valuesFile, _descriptionFile, out List<List<string>> values, out List<bool> areSymbols, out List<string> names);

            MainChart.ChartAreas.Add("chart");

            var numery_atr = new List<int>();

            probki_str_na_liczby(values, numery_atr, out List<List<double>> probki_num);

            var points = new List<DoublePoint>();

            for (int i = 0; i < probki_num[0].Count; i++)
            {
                var point = new DoublePoint()
                {
                    X = probki_num[0][i],
                    Y = probki_num[1][i]
                };

                points.Add(point);
            }

            List<DoublePoint> groupCenters = new List<DoublePoint>();

            var rand = new Random();

            for (int i = 0; i < groupsCount; i++)
            {
                var centerPoint = points[rand.Next(0, points.Count - 1)];
                if (groupCenters.Any(dp => dp.X == centerPoint.X && dp.Y == centerPoint.Y))
                {
                    i--;
                    continue;
                }

                groupCenters.Add(centerPoint);
            }

            Dictionary<DoublePoint, List<DoublePoint>> groups = new Dictionary<DoublePoint, List<DoublePoint>>();

            foreach (var groupCenter in groupCenters)
            {
                groups.Add(groupCenter, new List<DoublePoint>());
            }

            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (var point in points)
                {
                    int minimalDestinationGroupIndex = -1;

                    double minimalDistance = -1;

                    for (int j = 0; j < groupCenters.Count; j++)
                    {
                        if (minimalDestinationGroupIndex == -1)
                        {
                            minimalDestinationGroupIndex = 0;
                            minimalDistance = CountEuclideanDistanceOfPoints(point, groupCenters[j]);
                            continue;
                        }

                        var distanceNow = CountEuclideanDistanceOfPoints(point, groupCenters[j]);

                        if (distanceNow < minimalDistance)
                        {
                            minimalDestinationGroupIndex = j;
                            minimalDistance = distanceNow;
                        }
                    }

                    groups[groupCenters[minimalDestinationGroupIndex]].Add(point);
                }

                List<DoublePoint> newGroupCenters = new List<DoublePoint>();
                Dictionary<DoublePoint, List<DoublePoint>> newGroups = new Dictionary<DoublePoint, List<DoublePoint>>();

                for (int j = 0; j < groups.Count; j++)
                {
                    double xSum = 0;
                    double ySum = 0;

                    for (int k = 0; k < groups[groupCenters[j]].Count; k++)
                    {
                        xSum += groups[groupCenters[j]][k].X;
                        ySum += groups[groupCenters[j]][k].Y;
                    }

                    var newCenterPoint = new DoublePoint()
                    {
                        X = xSum != 0 ? xSum / (double)groups[groupCenters[j]].Count : xSum,
                        Y = ySum != 0 ? ySum / (double)groups[groupCenters[j]].Count : ySum
                    };

                    newGroupCenters.Add(newCenterPoint);
                    newGroups.Add(newCenterPoint, new List<DoublePoint>());
                }

                //ZMIANA
                double minimalCountGroup = double.MaxValue;
                double maximalCountGroup = double.MinValue;

                foreach (var group in groups)
                {
                    if (group.Value.Count < minimalCountGroup)
                    {
                        minimalCountGroup = group.Value.Count;
                    }

                    if (group.Value.Count > maximalCountGroup)
                    {
                        maximalCountGroup = group.Value.Count;
                    }
                }

                if (1.1 * minimalCountGroup > maximalCountGroup)
                {
                    break;
                }

                if (i == iterationsCount - 1)
                {
                    break;
                }

                groupCenters = newGroupCenters;
                groups = newGroups;
            }

            foreach (var group in groups)
            {
                List<double> xGroup = new List<double>();
                List<double> yGroup = new List<double>();

                foreach (var point in group.Value)
                {
                    xGroup.Add(point.X);
                    yGroup.Add(point.Y);
                }

                wykres_punkty_rysuj(xGroup, yGroup);
            }

            foreach (var groupCenter in groupCenters)
            {
                wykres_punkty_rysuj(new List<double>() { groupCenter.X }, new List<double>() { groupCenter.Y });
            }

            for (int i = MainChart.Series.Count / 2; i < MainChart.Series.Count; i++)
            {
                MainChart.Series[i].MarkerSize = 20;
            }

        }

        private void FCMButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(GroupsCount.Text, out int groupsCount))
            {
                MessageBox.Show("Niepoprawna liczba grup!");
                return;
            }
            else
            {
                if (groupsCount < 1)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            if (!int.TryParse(IterationCount.Text, out int iterationsCount))
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }
            else
            {
                if (iterationsCount < 1)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            if (!double.TryParse(FuzzyValue.Text, out double fuzziness))
            {
                MessageBox.Show("Niepoprawny stopień rozmycia!");
                return;
            }
            else
            {
                if (fuzziness < 1)
                {
                    MessageBox.Show("Niepoprawny stopień rozmycia!");
                    return;
                }
            }

            wykres_czysc();

            FileExtensionMethods.wczytaj_baze_probek_z_tekstem(_valuesFile, _descriptionFile, out List<List<string>> values, out List<bool> areSymbols, out List<string> names);

            MainChart.ChartAreas.Add("chart");

            var numery_atr = new List<int>();

            probki_str_na_liczby(values, numery_atr, out List<List<double>> probki_num);

            var points = new List<DoublePoint>();

            for (int i = 0; i < probki_num[0].Count; i++)
            {
                var point = new DoublePoint()
                {
                    X = probki_num[0][i],
                    Y = probki_num[1][i]
                };

                points.Add(point);
            }

            List<DoublePoint> groupCenters = new List<DoublePoint>();

            var rand = new Random();

            for (int i = 0; i < groupsCount; i++)
            {
                var centerPoint = points[rand.Next(0, points.Count - 1)];
                if (groupCenters.Any(dp => dp.X == centerPoint.X && dp.Y == centerPoint.Y))
                {
                    i--;
                    continue;
                }

                groupCenters.Add(centerPoint);
            }

            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (var point in points)
                {
                    List<double> destinations = new List<double>();

                    for (int j = 0; j < groupCenters.Count; j++)
                    {
                        destinations.Add(CountEuclideanDistanceOfPoints(point, groupCenters[j]));
                    }

                    double sumOfAffiliation = 0;

                    foreach (var destination in destinations)
                    {
                        if (destination != 0)
                        {
                            sumOfAffiliation += Math.Pow(destination, 1 - fuzziness);
                        }
                    }

                    foreach (var destination in destinations)
                    {
                        //ZMIANA
                        var affiliation = rand.NextDouble();

                        point.Affiliation.Add(affiliation);
                        //if (destination == 0)
                        //{
                        //    point.Affiliation.Add(0);
                        //}
                        //else
                        //{
                        //    point.Affiliation.Add(Math.Pow(destination, 1 - fuzziness) / sumOfAffiliation);
                        //}
                    }

                    double affSum = 0;

                    for (int a=0;a<point.Affiliation.Count;a++)
                    {
                        affSum += point.Affiliation[a];
                    }

                    for (int a = 0; a < point.Affiliation.Count; a++)
                    {
                        point.Affiliation[a] /= affSum;
                    }
                }

                List<DoublePoint> newGroupCenters = new List<DoublePoint>();

                for (int j = 0; j < groupCenters.Count; j++)
                {
                    double affiliationSum = 0;

                    foreach (var point in points)
                    {
                        affiliationSum += Math.Round(Math.Pow(point.Affiliation[j], fuzziness), 9);
                    }

                    double newCenterX = 0;

                    foreach (var point in points)
                    {
                        newCenterX += Math.Round(point.X * Math.Pow(point.Affiliation[j], fuzziness), 9);
                    }

                    newCenterX = newCenterX / affiliationSum;

                    double newCenterY = 0;

                    foreach (var point in points)
                    {
                        newCenterY += Math.Round(point.Y * Math.Pow(point.Affiliation[j], fuzziness), 9);
                    }

                    newCenterY = newCenterY / affiliationSum;

                    var newCenterPoint = new DoublePoint()
                    {
                        X = newCenterX,
                        Y = newCenterY
                    };

                    newGroupCenters.Add(newCenterPoint);
                }

                if (i == iterationsCount - 1)
                {
                    break;
                }

                groupCenters = newGroupCenters;
            }

            List<double> xGroup = new List<double>();
            List<double> yGroup = new List<double>();

            foreach (var point in points)
            {
                xGroup.Add(point.X);
                yGroup.Add(point.Y);
            }

            wykres_punkty_rysuj(xGroup, yGroup);

            foreach (var groupCenter in groupCenters)
            {
                wykres_punkty_rysuj(new List<double>() { groupCenter.X }, new List<double>() { groupCenter.Y });
            }

            for (int i = MainChart.Series.Count / 2; i < MainChart.Series.Count; i++)
            {
                MainChart.Series[i].MarkerSize = 20;
            }
        }

        private void KMedoidButton_Click(object sender, EventArgs e)
        {
            FileExtensionMethods.wczytaj_baze_probek_z_tekstem(_valuesFile, _descriptionFile, out List<List<string>> values, out List<bool> areSymbols, out List<string> names);


        }

        void probki_str_na_liczby(List<List<string>> probki_str, List<int> numery_atr, out List<List<double>> probki_num)
        {
            foreach (var row in probki_str)
            {
                if (row.Count != probki_str[0].Count)
                    throw new Exception();
            }

            Dictionary<int, List<double>> probki_num_index = new Dictionary<int, List<double>>();

            probki_num = new List<List<double>>();

            List<int> notNumbers = new List<int>();

            foreach (var row in probki_str)
            {
                for (int i = 0; i < row.Count; i++)
                {
                    if (!notNumbers.Contains(i))
                    {
                        double number;
                        try
                        {
                            number = double.Parse(row[i], CultureInfo.InvariantCulture);

                            if (!numery_atr.Contains(i))
                            {
                                numery_atr.Add(i);
                            }

                            if (probki_num_index.TryGetValue(i, out List<double> list))
                            {
                                list.Add(number);
                            }
                            else
                            {
                                probki_num_index.Add(i, new List<double>() { number });
                            }
                        }
                        catch
                        {
                            if (!notNumbers.Contains(i))
                            {
                                notNumbers.Add(i);
                                probki_num_index.Remove(i);
                            }
                        }
                    }
                }
            }

            foreach (var list in probki_num_index)
            {
                probki_num.Add(list.Value);
            }
        }

        private double CountEuclideanDistanceOfPoints(DoublePoint one, DoublePoint two)
        {
            var distance = Math.Sqrt((one.X - two.X) * (one.X - two.X) + (one.Y - two.Y) * (one.Y - two.Y));

            return distance;
        }

        private class DoublePoint
        {
            public double X { get; set; }
            public double Y { get; set; }
            public List<double> Affiliation { get; set; }

            public DoublePoint()
            {
                Affiliation = new List<double>();
            }
        }
    }
}
