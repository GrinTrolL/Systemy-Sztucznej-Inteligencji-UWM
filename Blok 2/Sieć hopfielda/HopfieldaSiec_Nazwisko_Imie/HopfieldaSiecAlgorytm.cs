using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldaSiec
{
    static public class HopfieldaSiecAlgorytm
    {
        static public List<List<double>> wagi = new List<List<double>>();
        static public int[,] paletka;

        /// <summary>
        /// Uruchamiane tylko raz przy starcie programu
        /// </summary>
        /// <param name="szerokosc"></param>
        /// <param name="wysokosc"></param>
        static public void inicjuj(int szerokosc, int wysokosc)
        {
            paletka = new int[szerokosc, wysokosc];
            int neuronsNumber = szerokosc * wysokosc;

            for (int i = 0; i < neuronsNumber; i++)
            {
                var list = new List<double>();

                for (int j = 0; j < neuronsNumber; j++)
                {
                    list.Add(0);
                }

                wagi.Add(list);
            }
        }

        static public void nauczObraz(bool[,] obraz)
        {
            for (int i = 0; i < obraz.GetLength(0); i++)
            {
                for (int j = 0; j < obraz.GetLength(1); j++)
                {
                    var index = i * obraz.GetLength(0) + j;

                    double sum = 0;

                    for (int a = 0; a < obraz.GetLength(0); a++)
                    {
                        for (int b = 0; b < obraz.GetLength(1); b++)
                        {
                            if (i == a && j == b)
                                continue;

                            var secondIndex = a * obraz.GetLength(0) + b;

                            double first = paletka[a, b] * wagi[index][secondIndex];

                            sum += first;
                        }
                    }

                    if (Math.Sign(paletka[i, j]) != Math.Sign(sum))
                    {

                        if (obraz[i, j])
                        {
                            paletka[i, j] = 1;
                        }
                        else
                        {
                            paletka[i, j] = -1;
                        }

                        for (int a = 0; a < obraz.GetLength(0); a++)
                        {
                            for (int b = 0; b < obraz.GetLength(1); b++)
                            {
                                if (i == a && j == b)
                                    continue;

                                var secondIndex = a * obraz.GetLength(0) + b;

                                double first = obraz.GetLength(0) * obraz.GetLength(1);

                                double second = 1.0 / first;

                                double third = second * paletka[i, j];

                                double fourth = third * paletka[a, b];

                                wagi[index][secondIndex] += fourth;
                            }
                        }
                    }
                }
            }
        }

        static public bool rozpoznajObraz(ref bool[,] obraz)
        {
            for (int i = 0; i < obraz.GetLength(0); i++)
            {
                for (int j = 0; j < obraz.GetLength(1); j++)
                {
                    var index = i * obraz.GetLength(0) + j;

                    if (obraz[i, j])
                    {
                        paletka[i, j] = 1;
                    }
                    else
                    {
                        paletka[i, j] = -1;
                    }

                    double sum = 0;

                    for (int a = 0; a < obraz.GetLength(0); a++)
                    {
                        for (int b = 0; b < obraz.GetLength(1); b++)
                        {
                            if (i == a && j == b)
                                continue;

                            var secondIndex = a * obraz.GetLength(0) + b;

                            double first = paletka[a, b] * wagi[index][secondIndex];

                            sum += first;
                        }
                    }

                    if (sum >= 0)
                    {
                        obraz[i, j] = true;
                    }
                    else
                    {
                        obraz[i, j] = false;
                    }
                }
            }

            return true;
        }

    }
}
