using DrawChartExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EvolutionStrategies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConsoleLog.ScrollBars = ScrollBars.Vertical;
            wykres_czysc();
        }

        private void Count_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            ConsoleLog.Text = string.Empty;

            if (!double.TryParse(MinNumber.Text, out double minNumber))
            {
                MessageBox.Show("Niepoprawna liczba minimalna z przedziału.");
                return;
            }

            if (!double.TryParse(MaxNumber.Text, out double maxNumber))
            {
                MessageBox.Show("Niepoprawna liczba maksymalna z przedziału.");
                return;
            }

            if (minNumber > maxNumber)
            {
                MessageBox.Show("Niepoprawny przedział.");
                return;
            }

            if (!double.TryParse(GrowthLevel.Text, out double growthLevel))
            {
                MessageBox.Show("Niepoprawny wskaźnik przychodu.");
                return;
            }

            if (!double.TryParse(Dispertion.Text, out double dispersion))
            {
                MessageBox.Show("Niepoprawny wskaźnik przychodu.");
                return;
            }

            if (!int.TryParse(IterationCount.Text, out int iterationCount))
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }
            else
            {
                if (iterationCount < 1)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            List<string> logs = new List<string>();

            List<DoublePoint> points = new List<DoublePoint>();

            MainChart.ChartAreas.Add("chart");

            var randomSeed = new Random();

            //double x = GetRandomDecimalFromScale(minNumber, maxNumber, randomSeed);
            //ZMIANA
            double worstF = double.MaxValue;
            double x = -1;

            for (double i = 0; i < 110; i += 10)
            {
                var f = Math.Sin(i / 10) * Math.Sin(i / 200);

                if (worstF > f)
                {
                    worstF = f;
                    x = i;
                }
            }


            double y = double.MinValue;

            for (int i = 0; i < iterationCount; i++)
            {
                double newX = x;

                while (true)
                {
                    var randomNumber = GetRandomDecimalFromScale((-1) * dispersion, dispersion, randomSeed);

                    if (newX + randomNumber >= minNumber && newX + randomNumber <= maxNumber)
                    {
                        newX += randomNumber;
                        break;
                    }
                }

                var newY = Math.Sin(newX / 10) * Math.Sin(newX / 200);

                if (newY >= y)
                {
                    dispersion *= growthLevel;
                    x = newX;
                    y = newY;
                }
                else
                {
                    dispersion /= growthLevel;
                }

                points.Add(new DoublePoint(newX, newY));

                logs.Add($"Iteracja {i + 1} Wartość funkcji przystosowania dla parametru {newX} wyniosła {newY}. Parametr rozrzutu wynosi {dispersion}.");
            }

            points = points.OrderBy(p => p.X).ToList();

            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            foreach (var point in points)
            {
                xs.Add(Math.Round(point.X, 2));
                ys.Add(Math.Round(point.Y, 2));
            }

            ConsoleLog.Text += string.Join(Environment.NewLine, logs);

            wykres_linie_rysuj(xs, ys);
        }

        private void MiLambdaCount_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            ConsoleLog.Text = string.Empty;

            if (!double.TryParse(MinNumber.Text, out double minNumber))
            {
                MessageBox.Show("Niepoprawna liczba minimalna z przedziału.");
                return;
            }

            if (!double.TryParse(MaxNumber.Text, out double maxNumber))
            {
                MessageBox.Show("Niepoprawna liczba maksymalna z przedziału.");
                return;
            }

            if (minNumber > maxNumber)
            {
                MessageBox.Show("Niepoprawny przedział.");
                return;
            }

            if (!int.TryParse(IterationCount.Text, out int iterationCount))
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }
            else
            {
                if (iterationCount < 4)
                {
                    MessageBox.Show("Niepoprawna liczba iteracji!");
                    return;
                }
            }

            if (!double.TryParse(MutationLevel.Text, out double mutationLevel))
            {
                MessageBox.Show("Niepoprawny wskaźnik mutacji.");
                return;
            }

            if (mutationLevel < 0)
            {
                MessageBox.Show("Niepoprawny wskaźnik mutacji.");
                return;
            }

            if (!int.TryParse(Mi.Text, out int mi))
            {
                MessageBox.Show("Niepoprawny wskaźnik mi.");
                return;
            }

            if (mi < 1)
            {
                MessageBox.Show("Niepoprawny wskaźnik mi.");
                return;
            }

            if (!int.TryParse(ChampionshipSize.Text, out int championShipSize))
            {
                MessageBox.Show("Niepoprawny wskaźnik rozmiaru turnieju.");
                return;
            }

            if (championShipSize < 1 || championShipSize > mi)
            {
                MessageBox.Show("Niepoprawny wskaźnik rozmiaru turnieju.");
                return;
            }

            if (!int.TryParse(Lambda.Text, out int lambda))
            {
                MessageBox.Show("Niepoprawny wskaźnik lambda.");
                return;
            }

            if (lambda < mi)
            {
                MessageBox.Show("Niepoprawny wskaźnik lambda.");
                return;
            }

            MainChart.ChartAreas.Add("chart");

            List<DoublePoint> family = new List<DoublePoint>();

            List<DoublePoint> children = new List<DoublePoint>();

            var seed = new Random();

            for (int i = 0; i < mi; i++)
            {
                var x = GetRandomDecimalFromScale(minNumber, maxNumber, seed);
                var y = GetRandomDecimalFromScale(minNumber, maxNumber, seed);
                family.Add(new DoublePoint(x, y));
            }

            for (int i = 0; i < iterationCount; i++)
            {
                foreach (var member in family)
                {
                    member.CountF();
                }

                children = new List<DoublePoint>();
                //ZMIANA
                List<int> secondBestChampion = new List<int>();

                for (int j = 0; j < lambda / 10; j++)
                {
                    secondBestChampion.Add(seed.Next(0, lambda));
                }

                for (int j = 0; j < lambda; j++)
                {
                    List<int> chosenFamilyMembersIndexes = new List<int>();

                    for (int k = 0; k < championShipSize; k++)
                    {
                        var randomIndex = seed.Next(0, family.Count);

                        if (!chosenFamilyMembersIndexes.Contains(randomIndex))
                        {
                            chosenFamilyMembersIndexes.Add(randomIndex);
                        }
                        else
                        {
                            k--;
                        }
                    }

                    List<DoublePoint> chosenFamilyMembers = new List<DoublePoint>();

                    foreach (var index in chosenFamilyMembersIndexes)
                    {
                        chosenFamilyMembers.Add(family[index]);
                    }
                    //ZMIANA
                    if (!secondBestChampion.Contains(j))
                    {
                        int indexOfChampion = -1;

                        double fValue = double.MinValue;

                        for (int k = 0; k < chosenFamilyMembers.Count; k++)
                        {
                            if (chosenFamilyMembers[k].FunctionValue > fValue)
                            {
                                indexOfChampion = k;
                                fValue = chosenFamilyMembers[k].FunctionValue;
                            }
                        }

                        var champion = new DoublePoint(chosenFamilyMembers[indexOfChampion].X, chosenFamilyMembers[indexOfChampion].Y);

                        champion.Mutate(GetRandomDecimalFromScale(-mutationLevel, mutationLevel, seed), GetRandomDecimalFromScale(-mutationLevel, mutationLevel, seed));

                        children.Add(champion);
                    }
                    else
                    {
                        int indexOfChampion = -1;
                        int indexOfSecondChampion = -1;

                        double fValue = double.MinValue;
                        double fSecondValue = double.MinValue;

                        for (int k = 0; k < chosenFamilyMembers.Count; k++)
                        {
                            if (chosenFamilyMembers[k].FunctionValue > fValue)
                            {
                                fSecondValue = fValue;
                                indexOfSecondChampion = indexOfChampion;

                                indexOfChampion = k;
                                fValue = chosenFamilyMembers[k].FunctionValue;
                            }
                            else
                            {
                                if (chosenFamilyMembers[k].FunctionValue > fSecondValue)
                                {
                                    indexOfSecondChampion = k;
                                    fSecondValue = chosenFamilyMembers[k].FunctionValue;
                                }
                            }
                        }

                        var champion = new DoublePoint(chosenFamilyMembers[indexOfSecondChampion].X, chosenFamilyMembers[indexOfSecondChampion].Y);

                        champion.Mutate(GetRandomDecimalFromScale(-mutationLevel, mutationLevel, seed), GetRandomDecimalFromScale(-mutationLevel, mutationLevel, seed));

                        children.Add(champion);
                    }
                }

                foreach (var member in children)
                {
                    member.CountF();
                }

                var joinedPeople = new List<DoublePoint>();

                joinedPeople.AddRange(family);
                joinedPeople.AddRange(children);

                joinedPeople = joinedPeople.OrderByDescending(p => p.FunctionValue).ToList();

                joinedPeople.RemoveRange(mi, joinedPeople.Count - mi);

                if (i != iterationCount - 1)
                {
                    family = joinedPeople;
                }
            }

            var bestChampion = family.OrderByDescending(p => p.FunctionValue).ToList().First();

            bestChampion.CountF();

            ConsoleLog.Text = $"Najlepszy to X1 = {bestChampion.X}, X2 = {bestChampion.Y}, F(X1,X2) = {bestChampion.FunctionValue}";

            List<double> familyxs = new List<double>();
            List<double> familyys = new List<double>();

            foreach (var members in family)
            {
                familyxs.Add(Math.Round(members.X, 2));
                familyys.Add(Math.Round(members.Y, 2));
            }

            wykres_punkty_rysuj(familyxs, familyys);

            List<double> childrenxs = new List<double>();
            List<double> childrenys = new List<double>();

            foreach (var members in children)
            {
                childrenxs.Add(Math.Round(members.X, 2));
                childrenys.Add(Math.Round(members.Y, 2));
            }

            wykres_punkty_rysuj(childrenxs, childrenys);

            MainChart.ChartAreas[0].AxisX.Minimum = minNumber;
            MainChart.ChartAreas[0].AxisX.Maximum = maxNumber;
            MainChart.ChartAreas[0].AxisY.Minimum = minNumber;
            MainChart.ChartAreas[0].AxisY.Maximum = maxNumber;
        }

        private void PSOCount_Click(object sender, EventArgs e)
        {
            wykres_czysc();

            ConsoleLog.Text = string.Empty;

            if (!double.TryParse(MinNumber.Text, out double minNumber))
            {
                MessageBox.Show("Niepoprawna liczba minimalna z przedziału.");
                return;
            }

            if (!double.TryParse(MaxNumber.Text, out double maxNumber))
            {
                MessageBox.Show("Niepoprawna liczba maksymalna z przedziału.");
                return;
            }

            if (minNumber > maxNumber)
            {
                MessageBox.Show("Niepoprawny przedział.");
                return;
            }

            if (!int.TryParse(IterationCount.Text, out int iterationCount))
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }

            if (iterationCount < 4)
            {
                MessageBox.Show("Niepoprawna liczba iteracji!");
                return;
            }

            if (!double.TryParse(InertiaValue.Text, out double inertiaValue))
            {
                MessageBox.Show("Niepoprawna wartość inercji.");
                return;
            }

            if (inertiaValue <= 0 || inertiaValue >= 1)
            {
                MessageBox.Show("Niepoprawna wartość inercji.");
                return;
            }

            if (!double.TryParse(GlobalPull.Text, out double globalPull))
            {
                MessageBox.Show("Niepoprawna wartość przyciągania globalnego.");
                return;
            }

            if (globalPull <= 0 || globalPull >= 1)
            {
                MessageBox.Show("Niepoprawna wartość przyciągania globalnego.");
                return;
            }

            if (!double.TryParse(LocalPull.Text, out double localPull))
            {
                MessageBox.Show("Niepoprawna wartość przyciągania lokalnego.");
                return;
            }

            if (localPull <= 0 || localPull >= 1)
            {
                MessageBox.Show("Niepoprawna wartość przyciągania lokalnego.");
                return;
            }

            if (!int.TryParse(NumberOfPeople.Text, out int numberOfPeople))
            {
                MessageBox.Show("Niepoprawna liczba osobników.");
                return;
            }

            if (numberOfPeople <= 1)
            {
                MessageBox.Show("Niepoprawna liczba osobników.");
                return;
            }

            MainChart.ChartAreas.Add("chart");

            List<DoublePoint> population = new List<DoublePoint>();

            List<List<double>> populationsPulls = new List<List<double>>();

            DoublePoint globalBest;

            var seed = new Random();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var x = GetRandomDecimalFromScale(minNumber, maxNumber, seed);
                var y = GetRandomDecimalFromScale(minNumber, maxNumber, seed);

                var point = new DoublePoint(x, y);

                point.SetLocalOptimum(x, y);

                population.Add(point);
            }

            for (int i = 0; i < 2; i++)
            {
                var iAttributePulls = new List<double>();

                foreach (var member in population)
                {
                    iAttributePulls.Add(0);
                }

                populationsPulls.Add(iAttributePulls);
            }

            for (int i = 0; i < iterationCount; i++)
            {
                List<double> newFValues = new List<double>();

                foreach (var member in population)
                {
                    newFValues.Add(member.GetF());
                }

                var maxIndex = -1;
                var maxFValue = double.MinValue;

                for (int j = 0; j < newFValues.Count; j++)
                {
                    if (newFValues[j] > maxFValue)
                    {
                        maxIndex = j;
                        maxFValue = newFValues[j];
                    }
                }

                globalBest = population[maxIndex];

                for (int j = 0; j < newFValues.Count; j++)
                {
                    population[j].SetFIfBetter(newFValues[j]);
                }

                var newPopulationPulls = new List<List<double>>();

                for (int k = 0; k < 2; k++)
                {
                    var newIAttributePulls = new List<double>();

                    for (int j = 0; j < population.Count; j++)
                    {
                        var rndGlob = seed.NextDouble();
                        var rndLocal = seed.NextDouble();
                        //ZMIANA
                        if (j == maxIndex)
                        {
                            populationsPulls[k][j] = 0;
                        }

                        var newPullValue = populationsPulls[k][j] * inertiaValue +
                                              (globalBest.GetAttribute(k) - population[j].GetAttribute(k)) * globalPull * rndGlob +
                                              (population[j].GetBestAttribute(k) - population[j].GetAttribute(k)) * localPull * rndLocal;

                        population[j].SetAttribute(k, population[j].GetAttribute(k) + newPullValue);

                        newIAttributePulls.Add(newPullValue);
                    }

                    newPopulationPulls.Add(newIAttributePulls);
                }

                populationsPulls = newPopulationPulls;
            }

            MainChart.ChartAreas[0].AxisX.Minimum = minNumber;
            MainChart.ChartAreas[0].AxisX.Maximum = maxNumber;
            MainChart.ChartAreas[0].AxisY.Minimum = minNumber;
            MainChart.ChartAreas[0].AxisY.Maximum = maxNumber;

            List<double> xs = new List<double>();
            List<double> ys = new List<double>();

            foreach (var point in population)
            {
                xs.Add(Math.Round(point.X, 2));
                ys.Add(Math.Round(point.Y, 2));
            }

            wykres_punkty_rysuj(xs, ys);
        }

        private double GetRandomDecimalFromScale(double min, double max, Random seed)
        {

            double x = seed.Next((int)Math.Floor(min), (int)Math.Floor(max));

            while (true)
            {
                var decimalPart = seed.NextDouble();

                if (x + decimalPart >= min && x + decimalPart <= max)
                {
                    x += decimalPart;
                    break;
                }
            }

            return x;
        }

        void wykres_linie_rysuj(List<double> wartosci_x, List<double> wartosci_y)
        {
            if (wartosci_x.Count != wartosci_y.Count)
            {
                MessageBox.Show("Podano złe punkty do serii");
                return;
            }

            var series = GetSeries();

            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < wartosci_x.Count; i++)
            {
                series.Points.AddXY(wartosci_x[i], wartosci_y[i]);
            }

            MainChart.Series.Add(series);
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

        public class DoublePoint
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double FunctionValue { get; set; }
            public double BestX { get; set; }
            public double BestY { get; set; }

            public DoublePoint(double x, double y)
            {
                X = x;
                Y = y;
            }

            public void CountF()
            {
                FunctionValue = Math.Sin(X * 0.05) + Math.Sin(Y * 0.05) + 0.4 * Math.Sin(X * 0.15) * Math.Sin(Y * 0.15);
            }

            public double GetF()
            {
                return Math.Sin(X * 0.05) + Math.Sin(Y * 0.05) + 0.4 * Math.Sin(X * 0.15) * Math.Sin(Y * 0.15);
            }

            public void SetFIfBetter(double newF)
            {
                if (newF > FunctionValue)
                {
                    BestX = X;
                    BestY = Y;
                    FunctionValue = newF;
                }
            }

            public void Mutate(double mutationLevelX, double mutationLevelY)
            {
                X += mutationLevelX;
                Y += mutationLevelY;
            }

            public void SetLocalOptimum(double x, double y)
            {
                BestX = x;
                BestY = y;
            }

            public double GetAttribute(int i)
            {
                if (i == 0)
                {
                    return X;
                }
                else
                {
                    return Y;
                }
            }

            public double GetBestAttribute(int i)
            {
                if (i == 0)
                {
                    return BestX;
                }
                else
                {
                    return BestY;
                }
            }


            public void SetAttribute(int i, double value)
            {
                if (i == 0)
                {
                    X = value;
                }
                else
                {
                    Y = value;
                }
            }
        }
    }
}
