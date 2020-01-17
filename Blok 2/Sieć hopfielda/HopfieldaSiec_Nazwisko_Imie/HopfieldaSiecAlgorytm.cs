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
        static public List<bool[,]> neurons = new List<bool[,]>();

        /// <summary>
        /// Uruchamiane tylko raz przy starcie programu
        /// </summary>
        /// <param name="szerokosc"></param>
        /// <param name="wysokosc"></param>
        static public void inicjuj(int szerokosc, int wysokosc)        
        {
            int neuronsNumber = szerokosc * wysokosc;

            for (int i=0;i<neuronsNumber;i++)
            {
                var list = new List<double>();

                for (int j=0;j<neuronsNumber;j++)
                {
                    list.Add(0);
                }

                wagi.Add(list);
            }
        }
        static public void nauczObraz(bool[,] obraz)
        {
            for (int i = 0; i < obraz.GetLength(0);i++)
            {
                for (int j=0; j < obraz.GetLength(1);j++)
                {
                    var index = i * obraz.GetLength(0) + j;

                    var wages = wagi[index];

                    var sum = 0;
                    var value = 0;


                    for (int k=0;k<obraz.GetLength(0)*obraz.GetLength(1);k++)
                    {
                        if (index == k)
                            continue;

                        sum+=wages[k]*
                    }

                    if (sum >= 0)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = -1;
                    }
                }
            }
        }

        static public bool rozpoznajObraz(ref bool[,] obraz)
        {  // należy naprawić (rozpoznać) podany obraz
            // ... 
            // zwróc false jeśli nie zmieniono obrazu
            return false; 
        }
 
    }
}
