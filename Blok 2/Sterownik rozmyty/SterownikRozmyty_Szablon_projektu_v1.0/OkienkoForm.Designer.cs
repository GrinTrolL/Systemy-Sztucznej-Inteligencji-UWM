namespace SterownikRozmyty
{
    partial class OkienkoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.parkingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.symulacjeWynikiResetButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pojazdWprowadzPozycjeButton = new System.Windows.Forms.Button();
            this.pojazdKierunekTextBox = new System.Windows.Forms.TextBox();
            this.pojazdYTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pojazdXTextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.symulacjeWynikiTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.przyszloscPojazdObrotTextBox = new System.Windows.Forms.TextBox();
            this.przyszloscPojazdKierunekTextBox = new System.Windows.Forms.TextBox();
            this.przyszloscPojazdYTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.przyszloscPojazdXTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ruchDoTyluButton = new System.Windows.Forms.Button();
            this.ruchLekkoWPrawoButton = new System.Windows.Forms.Button();
            this.ruchLekkoWLewoButton = new System.Windows.Forms.Button();
            this.ruchMocnoWPrawoButton = new System.Windows.Forms.Button();
            this.ruchMocnoWLewoButton = new System.Windows.Forms.Button();
            this.ruchDoPrzoduButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.SISeriaTestow2SzybkoButton = new System.Windows.Forms.Button();
            this.SISeriaTestow1SzybkoButton = new System.Windows.Forms.Button();
            this.SISeriaTestow1PowoliButton = new System.Windows.Forms.Button();
            this.SIPodpatrzButton = new System.Windows.Forms.Button();
            this.SICalaPojSciezkaButton = new System.Windows.Forms.Button();
            this.SIPojRuchButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.parkingChart);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "parking";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(410, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 101);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // parkingChart
            // 
            chartArea1.Name = "ChartArea1";
            this.parkingChart.ChartAreas.Add(chartArea1);
            this.parkingChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.parkingChart.Legends.Add(legend1);
            this.parkingChart.Location = new System.Drawing.Point(3, 16);
            this.parkingChart.Name = "parkingChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.parkingChart.Series.Add(series1);
            this.parkingChart.Size = new System.Drawing.Size(398, 176);
            this.parkingChart.TabIndex = 0;
            this.parkingChart.Text = "chart";
            this.parkingChart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.parkingChart_KeyDown);
            // 
            // symulacjeWynikiResetButton
            // 
            this.symulacjeWynikiResetButton.Location = new System.Drawing.Point(9, 73);
            this.symulacjeWynikiResetButton.Name = "symulacjeWynikiResetButton";
            this.symulacjeWynikiResetButton.Size = new System.Drawing.Size(133, 23);
            this.symulacjeWynikiResetButton.TabIndex = 1;
            this.symulacjeWynikiResetButton.Text = "Reset wyników";
            this.symulacjeWynikiResetButton.UseVisualStyleBackColor = true;
            this.symulacjeWynikiResetButton.Click += new System.EventHandler(this.symulacjeWynikiResetButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pojazdWprowadzPozycjeButton);
            this.groupBox2.Controls.Add(this.pojazdKierunekTextBox);
            this.groupBox2.Controls.Add(this.pojazdYTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pojazdXTextBox);
            this.groupBox2.Location = new System.Drawing.Point(422, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "parametry pojazdu";
            // 
            // pojazdWprowadzPozycjeButton
            // 
            this.pojazdWprowadzPozycjeButton.Location = new System.Drawing.Point(71, 86);
            this.pojazdWprowadzPozycjeButton.Name = "pojazdWprowadzPozycjeButton";
            this.pojazdWprowadzPozycjeButton.Size = new System.Drawing.Size(71, 23);
            this.pojazdWprowadzPozycjeButton.TabIndex = 6;
            this.pojazdWprowadzPozycjeButton.Text = "Zastosuj";
            this.pojazdWprowadzPozycjeButton.UseVisualStyleBackColor = true;
            this.pojazdWprowadzPozycjeButton.Click += new System.EventHandler(this.pojazdWprowadzPozycjeButton_Click);
            // 
            // pojazdKierunekTextBox
            // 
            this.pojazdKierunekTextBox.Location = new System.Drawing.Point(71, 63);
            this.pojazdKierunekTextBox.Name = "pojazdKierunekTextBox";
            this.pojazdKierunekTextBox.Size = new System.Drawing.Size(71, 20);
            this.pojazdKierunekTextBox.TabIndex = 5;
            // 
            // pojazdYTextBox
            // 
            this.pojazdYTextBox.Location = new System.Drawing.Point(71, 40);
            this.pojazdYTextBox.Name = "pojazdYTextBox";
            this.pojazdYTextBox.Size = new System.Drawing.Size(71, 20);
            this.pojazdYTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "kierunek =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "y =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "x =";
            // 
            // pojazdXTextBox
            // 
            this.pojazdXTextBox.Location = new System.Drawing.Point(71, 19);
            this.pojazdXTextBox.Name = "pojazdXTextBox";
            this.pojazdXTextBox.Size = new System.Drawing.Size(71, 20);
            this.pojazdXTextBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.symulacjeWynikiTextBox);
            this.groupBox4.Controls.Add(this.symulacjeWynikiResetButton);
            this.groupBox4.Location = new System.Drawing.Point(422, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "wyniki wielu symulacji";
            // 
            // symulacjeWynikiTextBox
            // 
            this.symulacjeWynikiTextBox.Location = new System.Drawing.Point(9, 19);
            this.symulacjeWynikiTextBox.Multiline = true;
            this.symulacjeWynikiTextBox.Name = "symulacjeWynikiTextBox";
            this.symulacjeWynikiTextBox.ReadOnly = true;
            this.symulacjeWynikiTextBox.Size = new System.Drawing.Size(133, 48);
            this.symulacjeWynikiTextBox.TabIndex = 0;
            this.symulacjeWynikiTextBox.Text = "l. sym. skończonych= 0\r\nl. sukcesów= 0\r\nl. porażek= 0";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.przyszloscPojazdObrotTextBox);
            this.groupBox5.Controls.Add(this.przyszloscPojazdKierunekTextBox);
            this.groupBox5.Controls.Add(this.przyszloscPojazdYTextBox);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.przyszloscPojazdXTextBox);
            this.groupBox5.Location = new System.Drawing.Point(12, 210);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(148, 113);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "przewidywana przyszłość";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "OBRÓT=";
            // 
            // przyszloscPojazdObrotTextBox
            // 
            this.przyszloscPojazdObrotTextBox.Location = new System.Drawing.Point(71, 87);
            this.przyszloscPojazdObrotTextBox.Name = "przyszloscPojazdObrotTextBox";
            this.przyszloscPojazdObrotTextBox.ReadOnly = true;
            this.przyszloscPojazdObrotTextBox.Size = new System.Drawing.Size(71, 20);
            this.przyszloscPojazdObrotTextBox.TabIndex = 6;
            // 
            // przyszloscPojazdKierunekTextBox
            // 
            this.przyszloscPojazdKierunekTextBox.Location = new System.Drawing.Point(71, 63);
            this.przyszloscPojazdKierunekTextBox.Name = "przyszloscPojazdKierunekTextBox";
            this.przyszloscPojazdKierunekTextBox.ReadOnly = true;
            this.przyszloscPojazdKierunekTextBox.Size = new System.Drawing.Size(71, 20);
            this.przyszloscPojazdKierunekTextBox.TabIndex = 5;
            // 
            // przyszloscPojazdYTextBox
            // 
            this.przyszloscPojazdYTextBox.Location = new System.Drawing.Point(71, 40);
            this.przyszloscPojazdYTextBox.Name = "przyszloscPojazdYTextBox";
            this.przyszloscPojazdYTextBox.ReadOnly = true;
            this.przyszloscPojazdYTextBox.Size = new System.Drawing.Size(71, 20);
            this.przyszloscPojazdYTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "kierunek =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "y =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "x =";
            // 
            // przyszloscPojazdXTextBox
            // 
            this.przyszloscPojazdXTextBox.Location = new System.Drawing.Point(71, 19);
            this.przyszloscPojazdXTextBox.Name = "przyszloscPojazdXTextBox";
            this.przyszloscPojazdXTextBox.ReadOnly = true;
            this.przyszloscPojazdXTextBox.Size = new System.Drawing.Size(71, 20);
            this.przyszloscPojazdXTextBox.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ruchDoTyluButton);
            this.groupBox6.Controls.Add(this.ruchLekkoWPrawoButton);
            this.groupBox6.Controls.Add(this.ruchLekkoWLewoButton);
            this.groupBox6.Controls.Add(this.ruchMocnoWPrawoButton);
            this.groupBox6.Controls.Add(this.ruchMocnoWLewoButton);
            this.groupBox6.Controls.Add(this.ruchDoPrzoduButton);
            this.groupBox6.Location = new System.Drawing.Point(166, 300);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(314, 77);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ręczny  ruch";
            // 
            // ruchDoTyluButton
            // 
            this.ruchDoTyluButton.Location = new System.Drawing.Point(111, 48);
            this.ruchDoTyluButton.Name = "ruchDoTyluButton";
            this.ruchDoTyluButton.Size = new System.Drawing.Size(83, 23);
            this.ruchDoTyluButton.TabIndex = 6;
            this.ruchDoTyluButton.Text = "do tylu (S)";
            this.ruchDoTyluButton.UseVisualStyleBackColor = true;
            this.ruchDoTyluButton.Click += new System.EventHandler(this.ruchDoTyluButton_Click);
            // 
            // ruchLekkoWPrawoButton
            // 
            this.ruchLekkoWPrawoButton.Location = new System.Drawing.Point(200, 19);
            this.ruchLekkoWPrawoButton.Name = "ruchLekkoWPrawoButton";
            this.ruchLekkoWPrawoButton.Size = new System.Drawing.Size(108, 23);
            this.ruchLekkoWPrawoButton.TabIndex = 4;
            this.ruchLekkoWPrawoButton.Text = "lekko w prawo (E)";
            this.ruchLekkoWPrawoButton.UseVisualStyleBackColor = true;
            this.ruchLekkoWPrawoButton.Click += new System.EventHandler(this.ruchLekkoWPrawoButton_Click);
            // 
            // ruchLekkoWLewoButton
            // 
            this.ruchLekkoWLewoButton.Location = new System.Drawing.Point(6, 19);
            this.ruchLekkoWLewoButton.Name = "ruchLekkoWLewoButton";
            this.ruchLekkoWLewoButton.Size = new System.Drawing.Size(99, 23);
            this.ruchLekkoWLewoButton.TabIndex = 3;
            this.ruchLekkoWLewoButton.Text = "lekko w lewo (Q)";
            this.ruchLekkoWLewoButton.UseVisualStyleBackColor = true;
            this.ruchLekkoWLewoButton.Click += new System.EventHandler(this.ruchLekkoWLewoButton_Click);
            // 
            // ruchMocnoWPrawoButton
            // 
            this.ruchMocnoWPrawoButton.Location = new System.Drawing.Point(200, 48);
            this.ruchMocnoWPrawoButton.Name = "ruchMocnoWPrawoButton";
            this.ruchMocnoWPrawoButton.Size = new System.Drawing.Size(108, 23);
            this.ruchMocnoWPrawoButton.TabIndex = 2;
            this.ruchMocnoWPrawoButton.Text = "mocno w prawo (D)";
            this.ruchMocnoWPrawoButton.UseVisualStyleBackColor = true;
            this.ruchMocnoWPrawoButton.Click += new System.EventHandler(this.ruchMocnoWPrawoButton_Click);
            // 
            // ruchMocnoWLewoButton
            // 
            this.ruchMocnoWLewoButton.Location = new System.Drawing.Point(6, 48);
            this.ruchMocnoWLewoButton.Name = "ruchMocnoWLewoButton";
            this.ruchMocnoWLewoButton.Size = new System.Drawing.Size(99, 23);
            this.ruchMocnoWLewoButton.TabIndex = 1;
            this.ruchMocnoWLewoButton.Text = "mocno w lewo (A)";
            this.ruchMocnoWLewoButton.UseVisualStyleBackColor = true;
            this.ruchMocnoWLewoButton.Click += new System.EventHandler(this.ruchMocnoWLewoButton_Click);
            // 
            // ruchDoPrzoduButton
            // 
            this.ruchDoPrzoduButton.Location = new System.Drawing.Point(111, 19);
            this.ruchDoPrzoduButton.Name = "ruchDoPrzoduButton";
            this.ruchDoPrzoduButton.Size = new System.Drawing.Size(83, 23);
            this.ruchDoPrzoduButton.TabIndex = 0;
            this.ruchDoPrzoduButton.Text = "do przodu (W)";
            this.ruchDoPrzoduButton.UseVisualStyleBackColor = true;
            this.ruchDoPrzoduButton.Click += new System.EventHandler(this.ruchDoPrzoduButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.SISeriaTestow2SzybkoButton);
            this.groupBox7.Controls.Add(this.SISeriaTestow1SzybkoButton);
            this.groupBox7.Controls.Add(this.SISeriaTestow1PowoliButton);
            this.groupBox7.Controls.Add(this.SIPodpatrzButton);
            this.groupBox7.Controls.Add(this.SICalaPojSciezkaButton);
            this.groupBox7.Controls.Add(this.SIPojRuchButton);
            this.groupBox7.Location = new System.Drawing.Point(166, 210);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(250, 89);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Inteligencja Obliczeniowa";
            // 
            // SISeriaTestow2SzybkoButton
            // 
            this.SISeriaTestow2SzybkoButton.Location = new System.Drawing.Point(182, 45);
            this.SISeriaTestow2SzybkoButton.Name = "SISeriaTestow2SzybkoButton";
            this.SISeriaTestow2SzybkoButton.Size = new System.Drawing.Size(68, 23);
            this.SISeriaTestow2SzybkoButton.TabIndex = 5;
            this.SISeriaTestow2SzybkoButton.Text = "seria2 expr";
            this.SISeriaTestow2SzybkoButton.UseVisualStyleBackColor = true;
            this.SISeriaTestow2SzybkoButton.Click += new System.EventHandler(this.SISeriaTestow2SzybkoButton_Click);
            // 
            // SISeriaTestow1SzybkoButton
            // 
            this.SISeriaTestow1SzybkoButton.Location = new System.Drawing.Point(95, 45);
            this.SISeriaTestow1SzybkoButton.Name = "SISeriaTestow1SzybkoButton";
            this.SISeriaTestow1SzybkoButton.Size = new System.Drawing.Size(81, 23);
            this.SISeriaTestow1SzybkoButton.TabIndex = 4;
            this.SISeriaTestow1SzybkoButton.Text = "seria1 szybko";
            this.SISeriaTestow1SzybkoButton.UseVisualStyleBackColor = true;
            this.SISeriaTestow1SzybkoButton.Click += new System.EventHandler(this.SISeriaTestow1SzybkoButton_Click);
            // 
            // SISeriaTestow1PowoliButton
            // 
            this.SISeriaTestow1PowoliButton.Location = new System.Drawing.Point(6, 45);
            this.SISeriaTestow1PowoliButton.Name = "SISeriaTestow1PowoliButton";
            this.SISeriaTestow1PowoliButton.Size = new System.Drawing.Size(83, 23);
            this.SISeriaTestow1PowoliButton.TabIndex = 3;
            this.SISeriaTestow1PowoliButton.Text = "seria1 powoli";
            this.SISeriaTestow1PowoliButton.UseVisualStyleBackColor = true;
            this.SISeriaTestow1PowoliButton.Click += new System.EventHandler(this.SISeriaTestow1PowoliButton_Click);
            // 
            // SIPodpatrzButton
            // 
            this.SIPodpatrzButton.Location = new System.Drawing.Point(87, 16);
            this.SIPodpatrzButton.Name = "SIPodpatrzButton";
            this.SIPodpatrzButton.Size = new System.Drawing.Size(75, 23);
            this.SIPodpatrzButton.TabIndex = 2;
            this.SIPodpatrzButton.Text = "Podpatrz";
            this.SIPodpatrzButton.UseVisualStyleBackColor = true;
            this.SIPodpatrzButton.Click += new System.EventHandler(this.SIPodpatrzButton_Click);
            // 
            // SICalaPojSciezkaButton
            // 
            this.SICalaPojSciezkaButton.Location = new System.Drawing.Point(168, 16);
            this.SICalaPojSciezkaButton.Name = "SICalaPojSciezkaButton";
            this.SICalaPojSciezkaButton.Size = new System.Drawing.Size(75, 23);
            this.SICalaPojSciezkaButton.TabIndex = 1;
            this.SICalaPojSciezkaButton.Text = "Cala ścieżka";
            this.SICalaPojSciezkaButton.UseVisualStyleBackColor = true;
            this.SICalaPojSciezkaButton.Click += new System.EventHandler(this.SICalaPojSciezkaButton_Click);
            // 
            // SIPojRuchButton
            // 
            this.SIPojRuchButton.Location = new System.Drawing.Point(6, 16);
            this.SIPojRuchButton.Name = "SIPojRuchButton";
            this.SIPojRuchButton.Size = new System.Drawing.Size(75, 23);
            this.SIPojRuchButton.TabIndex = 0;
            this.SIPojRuchButton.Text = "Poj. ruch";
            this.SIPojRuchButton.UseVisualStyleBackColor = true;
            this.SIPojRuchButton.Click += new System.EventHandler(this.SIPojRuchButton_Click);
            // 
            // OkienkoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 385);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OkienkoForm";
            this.Text = "OkienkoForm v1.1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OkienkoForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parkingChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart parkingChart;
        private System.Windows.Forms.Button symulacjeWynikiResetButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pojazdKierunekTextBox;
        private System.Windows.Forms.TextBox pojazdYTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pojazdXTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox symulacjeWynikiTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox przyszloscPojazdKierunekTextBox;
        private System.Windows.Forms.TextBox przyszloscPojazdYTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox przyszloscPojazdXTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button ruchLekkoWPrawoButton;
        private System.Windows.Forms.Button ruchLekkoWLewoButton;
        private System.Windows.Forms.Button ruchMocnoWPrawoButton;
        private System.Windows.Forms.Button ruchMocnoWLewoButton;
        private System.Windows.Forms.Button ruchDoPrzoduButton;
        private System.Windows.Forms.Button ruchDoTyluButton;
        private System.Windows.Forms.Button pojazdWprowadzPozycjeButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button SIPodpatrzButton;
        private System.Windows.Forms.Button SICalaPojSciezkaButton;
        private System.Windows.Forms.Button SIPojRuchButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox przyszloscPojazdObrotTextBox;
        private System.Windows.Forms.Button SISeriaTestow1PowoliButton;
        private System.Windows.Forms.Button SISeriaTestow1SzybkoButton;
        private System.Windows.Forms.Button SISeriaTestow2SzybkoButton;
    }
}

