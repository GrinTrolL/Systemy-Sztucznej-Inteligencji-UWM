namespace EvolutionStrategies
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Count = new System.Windows.Forms.Button();
            this.MinNumber = new System.Windows.Forms.TextBox();
            this.MaxNumber = new System.Windows.Forms.TextBox();
            this.IterationCount = new System.Windows.Forms.TextBox();
            this.GrowthLevel = new System.Windows.Forms.TextBox();
            this.Dispertion = new System.Windows.Forms.TextBox();
            this.ConsoleLog = new System.Windows.Forms.TextBox();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Mi = new System.Windows.Forms.TextBox();
            this.Lambda = new System.Windows.Forms.TextBox();
            this.MiLambdaCount = new System.Windows.Forms.Button();
            this.ChampionshipSize = new System.Windows.Forms.TextBox();
            this.MutationLevel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(12, 90);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(220, 43);
            this.Count.TabIndex = 0;
            this.Count.Text = "Policz dla jakiego parametru * jaki jest max od (sin(x/10)/sin(x/200))";
            this.Count.UseVisualStyleBackColor = true;
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // MinNumber
            // 
            this.MinNumber.Location = new System.Drawing.Point(12, 12);
            this.MinNumber.Name = "MinNumber";
            this.MinNumber.Size = new System.Drawing.Size(113, 20);
            this.MinNumber.TabIndex = 1;
            this.MinNumber.Tag = "Początek przedziału";
            this.MinNumber.Text = "Początek przedziału";
            // 
            // MaxNumber
            // 
            this.MaxNumber.Location = new System.Drawing.Point(131, 12);
            this.MaxNumber.Name = "MaxNumber";
            this.MaxNumber.Size = new System.Drawing.Size(100, 20);
            this.MaxNumber.TabIndex = 2;
            this.MaxNumber.Text = "Koniec przedziału";
            // 
            // IterationCount
            // 
            this.IterationCount.Location = new System.Drawing.Point(12, 38);
            this.IterationCount.Name = "IterationCount";
            this.IterationCount.Size = new System.Drawing.Size(113, 20);
            this.IterationCount.TabIndex = 3;
            this.IterationCount.Text = "Liczba Iteracji";
            // 
            // GrowthLevel
            // 
            this.GrowthLevel.Location = new System.Drawing.Point(131, 38);
            this.GrowthLevel.Name = "GrowthLevel";
            this.GrowthLevel.Size = new System.Drawing.Size(100, 20);
            this.GrowthLevel.TabIndex = 4;
            this.GrowthLevel.Text = "Wskaźnik przyrostu";
            // 
            // Dispertion
            // 
            this.Dispertion.Location = new System.Drawing.Point(75, 64);
            this.Dispertion.Name = "Dispertion";
            this.Dispertion.Size = new System.Drawing.Size(100, 20);
            this.Dispertion.TabIndex = 5;
            this.Dispertion.Text = "Wielkość rozrzutu";
            // 
            // ConsoleLog
            // 
            this.ConsoleLog.Location = new System.Drawing.Point(13, 278);
            this.ConsoleLog.Multiline = true;
            this.ConsoleLog.Name = "ConsoleLog";
            this.ConsoleLog.Size = new System.Drawing.Size(219, 355);
            this.ConsoleLog.TabIndex = 6;
            // 
            // MainChart
            // 
            chartArea2.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.MainChart.Legends.Add(legend2);
            this.MainChart.Location = new System.Drawing.Point(237, 12);
            this.MainChart.Name = "MainChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.MainChart.Series.Add(series2);
            this.MainChart.Size = new System.Drawing.Size(551, 621);
            this.MainChart.TabIndex = 7;
            this.MainChart.Text = "MainChart";
            // 
            // Mi
            // 
            this.Mi.Location = new System.Drawing.Point(140, 167);
            this.Mi.Name = "Mi";
            this.Mi.Size = new System.Drawing.Size(94, 20);
            this.Mi.TabIndex = 8;
            this.Mi.Text = "Wartość mi";
            // 
            // Lambda
            // 
            this.Lambda.Location = new System.Drawing.Point(140, 140);
            this.Lambda.Name = "Lambda";
            this.Lambda.Size = new System.Drawing.Size(92, 20);
            this.Lambda.TabIndex = 9;
            this.Lambda.Text = "Wartość lambda";
            // 
            // MiLambdaCount
            // 
            this.MiLambdaCount.Location = new System.Drawing.Point(12, 198);
            this.MiLambdaCount.Name = "MiLambdaCount";
            this.MiLambdaCount.Size = new System.Drawing.Size(220, 74);
            this.MiLambdaCount.TabIndex = 10;
            this.MiLambdaCount.Text = "Policz dla jakich parametrów i jaki jest max od (sin(x1*0.05)+sin(x2*0.05)+0.4*si" +
    "n(x1*0.15)*sin(x2*0.15))";
            this.MiLambdaCount.UseVisualStyleBackColor = true;
            this.MiLambdaCount.Click += new System.EventHandler(this.MiLambdaCount_Click);
            // 
            // ChampionshipSize
            // 
            this.ChampionshipSize.Location = new System.Drawing.Point(12, 167);
            this.ChampionshipSize.Name = "ChampionshipSize";
            this.ChampionshipSize.Size = new System.Drawing.Size(122, 20);
            this.ChampionshipSize.TabIndex = 11;
            this.ChampionshipSize.Text = "Wartość turniej_rozmiar";
            // 
            // MutationLevel
            // 
            this.MutationLevel.Location = new System.Drawing.Point(12, 141);
            this.MutationLevel.Name = "MutationLevel";
            this.MutationLevel.Size = new System.Drawing.Size(122, 20);
            this.MutationLevel.TabIndex = 12;
            this.MutationLevel.Text = "Wartość mutacja_poziom";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 645);
            this.Controls.Add(this.MutationLevel);
            this.Controls.Add(this.ChampionshipSize);
            this.Controls.Add(this.MiLambdaCount);
            this.Controls.Add(this.Lambda);
            this.Controls.Add(this.Mi);
            this.Controls.Add(this.MainChart);
            this.Controls.Add(this.ConsoleLog);
            this.Controls.Add(this.Dispertion);
            this.Controls.Add(this.GrowthLevel);
            this.Controls.Add(this.IterationCount);
            this.Controls.Add(this.MaxNumber);
            this.Controls.Add(this.MinNumber);
            this.Controls.Add(this.Count);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Count;
        private System.Windows.Forms.TextBox MinNumber;
        private System.Windows.Forms.TextBox MaxNumber;
        private System.Windows.Forms.TextBox IterationCount;
        private System.Windows.Forms.TextBox GrowthLevel;
        private System.Windows.Forms.TextBox Dispertion;
        private System.Windows.Forms.TextBox ConsoleLog;
        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.TextBox Mi;
        private System.Windows.Forms.TextBox Lambda;
        private System.Windows.Forms.Button MiLambdaCount;
        private System.Windows.Forms.TextBox ChampionshipSize;
        private System.Windows.Forms.TextBox MutationLevel;
    }
}

