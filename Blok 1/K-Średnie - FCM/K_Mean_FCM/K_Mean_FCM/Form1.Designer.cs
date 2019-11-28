namespace K_Mean_FCM
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadSpiralTypeButton = new System.Windows.Forms.Button();
            this.KMeanButton = new System.Windows.Forms.Button();
            this.FCMButton = new System.Windows.Forms.Button();
            this.KMedoidButton = new System.Windows.Forms.Button();
            this.LoadSpiralDataButton = new System.Windows.Forms.Button();
            this.IterationCount = new System.Windows.Forms.TextBox();
            this.GroupsCount = new System.Windows.Forms.TextBox();
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
            this.MainChart.Text = "MainChart";
            // 
            // LoadSpiralTypeButton
            // 
            this.LoadSpiralTypeButton.Location = new System.Drawing.Point(12, 12);
            this.LoadSpiralTypeButton.Name = "LoadSpiralTypeButton";
            this.LoadSpiralTypeButton.Size = new System.Drawing.Size(227, 81);
            this.LoadSpiralTypeButton.TabIndex = 1;
            this.LoadSpiralTypeButton.Text = "Wybierz plik typów spirali";
            this.LoadSpiralTypeButton.UseVisualStyleBackColor = true;
            this.LoadSpiralTypeButton.Click += new System.EventHandler(this.LoadSpiralTypeButton_Click);
            // 
            // KMeanButton
            // 
            this.KMeanButton.Enabled = false;
            this.KMeanButton.Location = new System.Drawing.Point(479, 12);
            this.KMeanButton.Name = "KMeanButton";
            this.KMeanButton.Size = new System.Drawing.Size(310, 23);
            this.KMeanButton.TabIndex = 3;
            this.KMeanButton.Text = "Pogrupuj za pomocą k-średnich";
            this.KMeanButton.UseVisualStyleBackColor = true;
            this.KMeanButton.Click += new System.EventHandler(this.KMeanButton_Click);
            // 
            // FCMButton
            // 
            this.FCMButton.Enabled = false;
            this.FCMButton.Location = new System.Drawing.Point(478, 41);
            this.FCMButton.Name = "FCMButton";
            this.FCMButton.Size = new System.Drawing.Size(309, 23);
            this.FCMButton.TabIndex = 4;
            this.FCMButton.Text = "Pogrupuj za pomocą FCM";
            this.FCMButton.UseVisualStyleBackColor = true;
            this.FCMButton.Click += new System.EventHandler(this.FCMButton_Click);
            // 
            // KMedoidButton
            // 
            this.KMedoidButton.Enabled = false;
            this.KMedoidButton.Location = new System.Drawing.Point(480, 70);
            this.KMedoidButton.Name = "KMedoidButton";
            this.KMedoidButton.Size = new System.Drawing.Size(309, 23);
            this.KMedoidButton.TabIndex = 5;
            this.KMedoidButton.Text = "Pogrupuj za pomocą k-medoidów";
            this.KMedoidButton.UseVisualStyleBackColor = true;
            this.KMedoidButton.Click += new System.EventHandler(this.KMedoidButton_Click);
            // 
            // LoadSpiralDataButton
            // 
            this.LoadSpiralDataButton.Location = new System.Drawing.Point(245, 12);
            this.LoadSpiralDataButton.Name = "LoadSpiralDataButton";
            this.LoadSpiralDataButton.Size = new System.Drawing.Size(228, 81);
            this.LoadSpiralDataButton.TabIndex = 6;
            this.LoadSpiralDataButton.Text = "Wybierz plik danych spirali";
            this.LoadSpiralDataButton.UseVisualStyleBackColor = true;
            this.LoadSpiralDataButton.Click += new System.EventHandler(this.LoadSpiralDataButton_Click);
            // 
            // IterationCount
            // 
            this.IterationCount.Location = new System.Drawing.Point(795, 12);
            this.IterationCount.Name = "IterationCount";
            this.IterationCount.Size = new System.Drawing.Size(118, 20);
            this.IterationCount.TabIndex = 7;
            this.IterationCount.Text = "Ilość iteracji";
            // 
            // GroupsCount
            // 
            this.GroupsCount.Location = new System.Drawing.Point(794, 41);
            this.GroupsCount.Name = "GroupsCount";
            this.GroupsCount.Size = new System.Drawing.Size(100, 20);
            this.GroupsCount.TabIndex = 8;
            this.GroupsCount.Text = "Ilość grup";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 450);
            this.Controls.Add(this.GroupsCount);
            this.Controls.Add(this.IterationCount);
            this.Controls.Add(this.LoadSpiralDataButton);
            this.Controls.Add(this.KMedoidButton);
            this.Controls.Add(this.FCMButton);
            this.Controls.Add(this.KMeanButton);
            this.Controls.Add(this.LoadSpiralTypeButton);
            this.Controls.Add(this.MainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Button LoadSpiralTypeButton;
        private System.Windows.Forms.Button KMeanButton;
        private System.Windows.Forms.Button FCMButton;
        private System.Windows.Forms.Button KMedoidButton;
        private System.Windows.Forms.Button LoadSpiralDataButton;
        private System.Windows.Forms.TextBox IterationCount;
        private System.Windows.Forms.TextBox GroupsCount;
    }
}

