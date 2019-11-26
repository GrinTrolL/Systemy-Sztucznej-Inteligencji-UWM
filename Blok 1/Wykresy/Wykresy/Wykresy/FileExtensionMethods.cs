using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LoadFileMethods
{
    public static class FileExtensionMethods
    {
        public static void wczytaj_baze_probek_z_tekstem(string nazwa_pliku_z_wartosciami, 
                                                         string nazwa_pliku_z_opisem_atr,
                                                         out List<List<string>> probki, 
                                                         out List<bool> czy_atr_symb, 
                                                         out List<string> nazwy_atr)
        {
            probki = new List<List<string>>();
            czy_atr_symb = new List<bool>();
            nazwy_atr = new List<string>();

            var descriptions = File.ReadAllText(nazwa_pliku_z_opisem_atr);

            descriptions = descriptions.Replace("\r", "");

            var descriptionRows = descriptions.Split('\n');

            foreach (var descriptionRow in descriptionRows)
            {
                var descriptionRowValues = descriptionRow.Split('\t').ToList();

                RemoveAllEmptyOccurences(descriptionRowValues);

                if (descriptionRowValues.Count == 0)
                {
                    continue;
                }

                if (descriptionRowValues.Count != 2)
                {
                    throw new Exception("Niepoprawny plik z opisem atrybutów. Liczba kolumn jest różna od 2");
                }

                var ifSymbol = descriptionRowValues[1] == "s";

                var name = descriptionRowValues[0];

                czy_atr_symb.Add(ifSymbol);

                nazwy_atr.Add(name);
            }

            var numberOfColumns = nazwy_atr.Count;

            var data = File.ReadAllText(nazwa_pliku_z_wartosciami);

            data = data.Replace("\r", "");

            var dataRows = data.Split('\n');

            if (dataRows.Any(r => r.Split(' ').Length != dataRows[0].Split(' ').Length))
            {
                throw new Exception("Plik z wartościami jest błędny. Wiersze nie mają takich samych długości");
            }

            foreach (var valueRow in dataRows)
            {
                var valueRowValues = valueRow.Split(' ').ToList();

                probki.Add(valueRowValues);
            }

            if (probki[0].Count() != numberOfColumns)
            {
                throw new Exception("Niepoprawna para plików opisu i wartości. Liczba kolumn się różni.");
            }
        }

        private static void RemoveAllEmptyOccurences(List<string> list)
        {
            for (int i=0;i<list.Count;i++)
            {
                if (string.IsNullOrWhiteSpace(list[i]))
                {
                    list.Remove(list[i]);
                    i--;
                }
            }
        }
        private static void RemoveAllEmptyOccurences(List<List<string>> lists)
        {
            foreach (var list in lists)
            {
                RemoveAllEmptyOccurences(list);
            }
        }
    }
}
