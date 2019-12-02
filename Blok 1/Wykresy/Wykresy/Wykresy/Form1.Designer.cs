using DrawChartExtensionMethods;
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
            MainChart.ChartAreas.Clear();
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
            var style = ChartExtensionMethods.seriesStyles[seriesNumber%10];

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
            this.IrysDescriptionButton = new System.Windows.Forms.Button();
            this.IrysDataButton = new System.Windows.Forms.Button();
            this.IrysLoadButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.MainChart.Size = new System.Drawing.Size(1130, 539);
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
            // IrysDescriptionButton
            // 
            this.IrysDescriptionButton.Location = new System.Drawing.Point(741, 13);
            this.IrysDescriptionButton.Name = "IrysDescriptionButton";
            this.IrysDescriptionButton.Size = new System.Drawing.Size(211, 35);
            this.IrysDescriptionButton.TabIndex = 2;
            this.IrysDescriptionButton.Text = "Wybierz opis Irysa";
            this.IrysDescriptionButton.UseVisualStyleBackColor = true;
            this.IrysDescriptionButton.Click += new System.EventHandler(this.IrysDescriptionButton_Click);
            // 
            // IrysDataButton
            // 
            this.IrysDataButton.Location = new System.Drawing.Point(958, 13);
            this.IrysDataButton.Name = "IrysDataButton";
            this.IrysDataButton.Size = new System.Drawing.Size(184, 35);
            this.IrysDataButton.TabIndex = 3;
            this.IrysDataButton.Text = "Wybierz dane Irysa";
            this.IrysDataButton.UseVisualStyleBackColor = true;
            this.IrysDataButton.Click += new System.EventHandler(this.IrysDataButton_Click);
            // 
            // IrysLoadButton
            // 
            this.IrysLoadButton.Enabled = false;
            this.IrysLoadButton.Location = new System.Drawing.Point(741, 54);
            this.IrysLoadButton.Name = "IrysLoadButton";
            this.IrysLoadButton.Size = new System.Drawing.Size(401, 23);
            this.IrysLoadButton.TabIndex = 4;
            this.IrysLoadButton.Text = "Wczytaj dane Irysa";
            this.IrysLoadButton.UseVisualStyleBackColor = true;
            this.IrysLoadButton.Click += new System.EventHandler(this.IrysLoadButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(386, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 65);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IrysLoadButton);
            this.Controls.Add(this.IrysDataButton);
            this.Controls.Add(this.IrysDescriptionButton);
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
        private System.Windows.Forms.Button IrysDescriptionButton;
        private Button IrysDataButton;
        private Button IrysLoadButton;
        private Button button1;
    }
}

