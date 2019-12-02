using LoadFileMethods;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Odczyt_Probek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _descriptionFile = string.Empty;
        private string _valuesFile = string.Empty;

        private List<List<string>> values;
        private List<bool> areSymbols;
        private List<string> names;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddDescriptionButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _descriptionFile = openFileDialog.FileName;
            }

            CheckIfFilesChosen();
        }

        private void AddValuesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                _valuesFile = openFileDialog.FileName;
            }

            CheckIfFilesChosen();
        }

        private void CheckIfFilesChosen()
        {
            if (!string.IsNullOrWhiteSpace(_descriptionFile) && !string.IsNullOrWhiteSpace(_valuesFile))
            {
                LoadDataButton.IsEnabled = true;
            }
        }

        private void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileExtensionMethods.wczytaj_baze_probek_z_tekstem(_valuesFile, _descriptionFile, out values, out areSymbols, out names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                CleanProgram();

                return;
            }

            values.ForEach(row =>
            {
                for (int i = 0; i < row.Count; i++)
                {
                    if (areSymbols[i])
                    {
                        row[i] = $"\"{row[i]}\"";
                    }
                }
            });

            //ZMIANA
            for (int i=0;i<values.Count;i++)
            {
                for (int j=0;j<values[i].Count;j++)
                {
                    if (!areSymbols[j])
                    {
                        values[i][j] = (double.Parse(values[i][j], CultureInfo.InvariantCulture) + i).ToString();
                    }
                }
            }

            DataTable data = new DataTable();

            foreach (var name in names)
            {
                data.Columns.Add(name);
            }

            foreach (var row in values)
            {
                DataRow dataRow = data.NewRow();
                for (int i=0; i<names.Count;i++)
                {
                    dataRow[i] = row[i];
                }
                data.Rows.Add(dataRow);
            }


            LoadedDataGrid.ItemsSource = data.DefaultView;

            CleanProgram();
        }

        private void CleanProgram()
        {
            _descriptionFile = string.Empty;
            _valuesFile = string.Empty;
            LoadDataButton.IsEnabled = false;
        }

    }
}
