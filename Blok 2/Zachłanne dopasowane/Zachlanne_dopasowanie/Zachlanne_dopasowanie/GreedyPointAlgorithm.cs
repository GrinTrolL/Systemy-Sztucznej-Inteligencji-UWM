using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyPoint_Nazwisko_Imie
{
    static public class GreedyPointAlgorithm
    {
        static List<bool[,]> bazaObrazow = new List<bool[,]>();

        static public void dodajObrazDoBazy(bool[,] obraz)
        {
            bazaObrazow.Add(obraz);
        }

        static public int rozpoznajObraz(bool[,] obraz)
        {
            if (bazaObrazow.Count == 0)
                return -1;

            List<double> marks = new List<double>();

            foreach (var obrazZBazy in bazaObrazow)
            {
                var mark = miara_podobieństwa_obustronnego(obraz, obrazZBazy);

                marks.Add(mark);
            }

            for (int i=0;i<marks.Count;i++)
            {
                for (int j=i+1;j<marks.Count;j++)
                {
                    if (marks[i] == marks[j] && marks.IndexOf(marks.Max()) == i)
                        return -1;
                }
            }

            return marks.IndexOf(marks.Max()) + 1;
        }

        static public double miara_podobieństwa_obustronnego(bool[,] testMap, bool[,] bitMap)
        {
            var TB = miara_niepodobieństwa(testMap, bitMap);
            var BT = miara_niepodobieństwa(bitMap, testMap);
            return -(TB + BT);
        }

        static public double miara_niepodobieństwa(bool[,] testMap, bool[,] bitMap)
        {
            var mark = (double)0;

            for (int a = 0; a < testMap.GetLength(0); a++)
            {
                for (int b = 0; b < testMap.GetLength(1); b++)
                {
                    if (testMap[a, b])
                    {
                        var distanceMin = double.PositiveInfinity;

                        for (int i = 0; i < bitMap.GetLength(0); i++)
                        {
                            for (int j = 0; j < bitMap.GetLength(1); j++)
                            {
                                if (bitMap[i, j])
                                {
                                    var xDistance = a - i;
                                    var yDistance = b - j;

                                    var distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

                                    if (distance < distanceMin)
                                    {
                                        distanceMin = distance;
                                    }
                                }
                            }
                        }

                        mark += distanceMin;
                    }
                }
            }

            return mark;
        }

    }
}
