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

            descriptions = RefactorToSpaceSeparator(descriptions);

            var descriptionRows = descriptions.Split('\n');

            descriptionRows = RemoveAllEmptyOccurances(descriptionRows);

            foreach (var descriptionRow in descriptionRows)
            {
                var descriptionRowValues = descriptionRow.Split(' ');

                descriptionRowValues = RemoveAllEmptyOccurances(descriptionRowValues);

                if (descriptionRowValues.Length != 2)
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

            data = RefactorToSpaceSeparator(data);

            var dataRows = data.Split('\n');

            dataRows = RemoveAllEmptyOccurances(dataRows);

            int rowLength = 0;

            foreach (var valueRow in dataRows)
            {
                var valueRowValues = valueRow.Split(' ');

                valueRowValues = RemoveAllEmptyOccurances(valueRowValues);

                if (rowLength != 0)
                {
                    if (valueRowValues.Length != rowLength)
                    {
                        throw new Exception("Plik z wartościami jest błędny. Wiersze nie mają takich samych długości");
                    }
                }

                rowLength = valueRowValues.Length;

                probki.Add(valueRowValues.ToList());
            }

            if (probki[0].Count() != numberOfColumns)
            {
                throw new Exception("Niepoprawna para plików opisu i wartości. Liczba kolumn się różni.");
            }
        }

        private static string RefactorToSpaceSeparator(string text)
        {
            text = text.Replace('\r', ' ');
            text = text.Replace('\t', ' ');

            string oldText = text;
            string newText;

            while (true)
            {
                newText = oldText.Replace("  ", " ");

                if (newText == oldText)
                {
                    return oldText;
                }

                oldText = newText;
            }
        }

        private static string[] RemoveAllEmptyOccurances(string[] texts)
        {
            var list = texts.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(list[i]))
                {
                    list.Remove(list[i]);
                    i--;
                }
            }

            return list.ToArray();
        }
    }
}
