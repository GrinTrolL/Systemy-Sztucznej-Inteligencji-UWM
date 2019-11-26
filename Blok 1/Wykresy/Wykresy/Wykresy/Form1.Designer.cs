using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wykresy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private string _descriptionFile = string.Empty;
        private string _valuesFile = string.Empty;

        private List<List<string>> values;

        private List<bool> areSymbols;

        private List<string> names;

        private List<SeriesProperties> seriesStyles = new List<SeriesProperties>()
        {
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Blue,
                MarkerStyle = MarkerStyle.Circle
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Yellow,
                MarkerStyle = MarkerStyle.Circle
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDotDot,
                Color = Color.Red,
                MarkerStyle = MarkerStyle.Cross
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Gold,
                MarkerStyle = MarkerStyle.Diamond
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Solid,
                Color = Color.LightCyan,
                MarkerStyle = MarkerStyle.Square
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDot,
                Color = Color.MediumOrchid,
                MarkerStyle = MarkerStyle.Star10
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Olive,
                MarkerStyle = MarkerStyle.Star4
                },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.DashDot,
                Color = Color.RosyBrown,
                MarkerStyle = MarkerStyle.Star5
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dot,
                Color = Color.Snow,
                MarkerStyle = MarkerStyle.Star6
            },
            new SeriesProperties
            {
                ChartDashStyle = ChartDashStyle.Dash,
                Color = Color.Purple,
                MarkerStyle = MarkerStyle.Triangle
            }
        };

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        void wykres_czysc()
        {
            MainChart.Series.Clear();
        }
        void wykres_linie_rysuj(List<double> wartosci_y)
        {
            var series = GetSeries();

            series.ChartType = SeriesChartType.Spline;

            foreach (var value in wartosci_y)
            {
                series.Points.AddY(value);
            }

            MainChart.Series.Add(series);

        }
        void wykres_linie_rysuj(List<double> wartosci_x, List<double> wartosci_y)
        {
            if (wartosci_x.Count != wartosci_y.Count)
            {
                MessageBox.Show("Podano złe punkty do serii");
                return;
            }

            var series = GetSeries();

            series.ChartType = SeriesChartType.Line;

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

            for (int i=0;i<wartosci_x.Count;i++)
            {
                series.Points.AddXY(wartosci_x[i], wartosci_y[i]);
            }

            MainChart.Series.Add(series);
        }

        void StyleSeries(Series series, int seriesNumber)
        {
            var style = seriesStyles[seriesNumber];

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


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SmileButton = new System.Windows.Forms.Button();
            this.IrysButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MainChart.Legends.Add(legend1);
            this.MainChart.Location = new System.Drawing.Point(12, 83);
            this.MainChart.Name = "MainChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.MainChart.Series.Add(series1);
            this.MainChart.Size = new System.Drawing.Size(776, 355);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // SmileButton
            // 
            this.SmileButton.Location = new System.Drawing.Point(13, 13);
            this.SmileButton.Name = "SmileButton";
            this.SmileButton.Size = new System.Drawing.Size(367, 64);
            this.SmileButton.TabIndex = 1;
            this.SmileButton.Text = "Narysuj buźkę";
            this.SmileButton.UseVisualStyleBackColor = true;
            this.SmileButton.Click += new System.EventHandler(this.SmileButton_Click);
            // 
            // IrysButton
            // 
            this.IrysButton.Location = new System.Drawing.Point(387, 13);
            this.IrysButton.Name = "IrysButton";
            this.IrysButton.Size = new System.Drawing.Size(211, 35);
            this.IrysButton.TabIndex = 2;
            this.IrysButton.Text = "button2";
            this.IrysButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(401, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IrysButton);
            this.Controls.Add(this.SmileButton);
            this.Controls.Add(this.MainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Button SmileButton;
        private System.Windows.Forms.Button IrysButton;
        private Button button1;
        private Button button2;
    }
}

