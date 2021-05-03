namespace Airoport
{
    partial class MainDisplayForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRunwayMap = new System.Windows.Forms.Panel();
            this.pRunway0 = new System.Windows.Forms.Panel();
            this.pAirQueue = new System.Windows.Forms.Panel();
            this.LVSchedue = new System.Windows.Forms.ListView();
            this.chRanway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Delay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTypeAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCompanyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCountRequestDone = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nUDStep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.bEnd = new System.Windows.Forms.Button();
            this.bNextStep = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.bParams = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chDelay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.chAvgRunwayWork = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDelay = new System.Windows.Forms.TextBox();
            this.tbLandingQueueLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTakeOffQueueLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbCurrentTime = new System.Windows.Forms.TextBox();
            this.gbStatistic = new System.Windows.Forms.GroupBox();
            this.tbDoneRequest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pRunwayMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chCountRequestDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            this.gbButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAvgRunwayWork)).BeginInit();
            this.gbStatistic.SuspendLayout();
            this.SuspendLayout();
            // 
            // pRunwayMap
            // 
            this.pRunwayMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRunwayMap.AutoScroll = true;
            this.pRunwayMap.AutoScrollMinSize = new System.Drawing.Size(500, 340);
            this.pRunwayMap.BackColor = System.Drawing.SystemColors.Highlight;
            this.pRunwayMap.Controls.Add(this.pRunway0);
            this.pRunwayMap.Location = new System.Drawing.Point(360, 15);
            this.pRunwayMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pRunwayMap.Name = "pRunwayMap";
            this.pRunwayMap.Size = new System.Drawing.Size(744, 289);
            this.pRunwayMap.TabIndex = 0;
            // 
            // pRunway0
            // 
            this.pRunway0.BackColor = System.Drawing.Color.Black;
            this.pRunway0.Location = new System.Drawing.Point(15, 0);
            this.pRunway0.Name = "pRunway0";
            this.pRunway0.Size = new System.Drawing.Size(200, 319);
            this.pRunway0.TabIndex = 2;
            // 
            // pAirQueue
            // 
            this.pAirQueue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pAirQueue.Location = new System.Drawing.Point(15, 15);
            this.pAirQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pAirQueue.Name = "pAirQueue";
            this.pAirQueue.Size = new System.Drawing.Size(321, 223);
            this.pAirQueue.TabIndex = 1;
            // 
            // LVSchedue
            // 
            this.LVSchedue.AllowColumnReorder = true;
            this.LVSchedue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LVSchedue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRanway,
            this.chAirplane,
            this.chState,
            this.chTime,
            this.Delay,
            this.chDirection,
            this.chTypeAirplane,
            this.chCompanyName});
            this.LVSchedue.FullRowSelect = true;
            this.LVSchedue.HideSelection = false;
            this.LVSchedue.Location = new System.Drawing.Point(15, 242);
            this.LVSchedue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LVSchedue.Name = "LVSchedue";
            this.LVSchedue.Size = new System.Drawing.Size(320, 202);
            this.LVSchedue.TabIndex = 3;
            this.LVSchedue.UseCompatibleStateImageBehavior = false;
            this.LVSchedue.View = System.Windows.Forms.View.Details;
            // 
            // chRanway
            // 
            this.chRanway.Text = "№ Полосы";
            this.chRanway.Width = 66;
            // 
            // chAirplane
            // 
            this.chAirplane.Text = "Самолёт";
            this.chAirplane.Width = 56;
            // 
            // chState
            // 
            this.chState.Text = "Статус";
            this.chState.Width = 46;
            // 
            // chTime
            // 
            this.chTime.Text = "Время";
            this.chTime.Width = 45;
            // 
            // Delay
            // 
            this.Delay.DisplayIndex = 7;
            this.Delay.Text = "Задержка";
            // 
            // chDirection
            // 
            this.chDirection.Text = "Направление";
            // 
            // chTypeAirplane
            // 
            this.chTypeAirplane.Text = "Тип самолёта";
            // 
            // chCompanyName
            // 
            this.chCompanyName.DisplayIndex = 4;
            this.chCompanyName.Text = "Компания";
            // 
            // chCountRequestDone
            // 
            chartArea1.Name = "ChartArea1";
            this.chCountRequestDone.ChartAreas.Add(chartArea1);
            this.chCountRequestDone.Location = new System.Drawing.Point(6, 40);
            this.chCountRequestDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chCountRequestDone.Name = "chCountRequestDone";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "SeriesTakeOff";
            series1.YValuesPerPoint = 6;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Name = "SeriesLanding";
            this.chCountRequestDone.Series.Add(series1);
            this.chCountRequestDone.Series.Add(series2);
            this.chCountRequestDone.Size = new System.Drawing.Size(240, 170);
            this.chCountRequestDone.TabIndex = 4;
            this.chCountRequestDone.Text = "chart2";
            // 
            // nUDStep
            // 
            this.nUDStep.Location = new System.Drawing.Point(171, 18);
            this.nUDStep.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nUDStep.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUDStep.Name = "nUDStep";
            this.nUDStep.Size = new System.Drawing.Size(91, 22);
            this.nUDStep.TabIndex = 19;
            this.nUDStep.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nUDStep.ValueChanged += new System.EventHandler(this.nUDStep_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Шаг, от 5 до 30 минут";
            // 
            // bEnd
            // 
            this.bEnd.Location = new System.Drawing.Point(161, 43);
            this.bEnd.Name = "bEnd";
            this.bEnd.Size = new System.Drawing.Size(101, 52);
            this.bEnd.TabIndex = 20;
            this.bEnd.Text = "До конца";
            this.bEnd.UseVisualStyleBackColor = true;
            this.bEnd.Click += new System.EventHandler(this.bEnd_Click);
            // 
            // bNextStep
            // 
            this.bNextStep.Location = new System.Drawing.Point(9, 43);
            this.bNextStep.Name = "bNextStep";
            this.bNextStep.Size = new System.Drawing.Size(124, 52);
            this.bNextStep.TabIndex = 21;
            this.bNextStep.Text = "Следующий шаг";
            this.bNextStep.UseVisualStyleBackColor = true;
            this.bNextStep.Click += new System.EventHandler(this.bNextStep_Click);
            // 
            // bPause
            // 
            this.bPause.Location = new System.Drawing.Point(9, 97);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(124, 52);
            this.bPause.TabIndex = 22;
            this.bPause.Text = "Прервать моделирование";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // bParams
            // 
            this.bParams.Location = new System.Drawing.Point(161, 97);
            this.bParams.Name = "bParams";
            this.bParams.Size = new System.Drawing.Size(101, 52);
            this.bParams.TabIndex = 23;
            this.bParams.Text = "Новый эксперимент";
            this.bParams.UseVisualStyleBackColor = true;
            this.bParams.Click += new System.EventHandler(this.bParams_Click);
            // 
            // gbButtons
            // 
            this.gbButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbButtons.Controls.Add(this.bParams);
            this.gbButtons.Controls.Add(this.nUDStep);
            this.gbButtons.Controls.Add(this.bPause);
            this.gbButtons.Controls.Add(this.bEnd);
            this.gbButtons.Controls.Add(this.bNextStep);
            this.gbButtons.Controls.Add(this.label8);
            this.gbButtons.Location = new System.Drawing.Point(15, 441);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(321, 178);
            this.gbButtons.TabIndex = 24;
            this.gbButtons.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Количество обслужанных заявок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Задержка";
            // 
            // chDelay
            // 
            chartArea2.Name = "ChartArea1";
            this.chDelay.ChartAreas.Add(chartArea2);
            this.chDelay.Location = new System.Drawing.Point(252, 40);
            this.chDelay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chDelay.Name = "chDelay";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.IsVisibleInLegend = false;
            series3.Name = "SeriesTakeOff";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Blue;
            series4.Name = "SeriesLanding";
            this.chDelay.Series.Add(series3);
            this.chDelay.Series.Add(series4);
            this.chDelay.Size = new System.Drawing.Size(240, 170);
            this.chDelay.TabIndex = 26;
            this.chDelay.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Средняя занятость полос";
            // 
            // chAvgRunwayWork
            // 
            chartArea3.Name = "ChartArea1";
            this.chAvgRunwayWork.ChartAreas.Add(chartArea3);
            this.chAvgRunwayWork.Location = new System.Drawing.Point(498, 40);
            this.chAvgRunwayWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chAvgRunwayWork.Name = "chAvgRunwayWork";
            series5.ChartArea = "ChartArea1";
            series5.Name = "Series1";
            this.chAvgRunwayWork.Series.Add(series5);
            this.chAvgRunwayWork.Size = new System.Drawing.Size(240, 170);
            this.chAvgRunwayWork.TabIndex = 28;
            this.chAvgRunwayWork.Text = "Средняя занятость полос";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Текущая задержка";
            // 
            // tbDelay
            // 
            this.tbDelay.Location = new System.Drawing.Point(252, 255);
            this.tbDelay.Name = "tbDelay";
            this.tbDelay.Size = new System.Drawing.Size(100, 22);
            this.tbDelay.TabIndex = 31;
            // 
            // tbLandingQueueLength
            // 
            this.tbLandingQueueLength.Location = new System.Drawing.Point(605, 231);
            this.tbLandingQueueLength.Name = "tbLandingQueueLength";
            this.tbLandingQueueLength.Size = new System.Drawing.Size(100, 22);
            this.tbLandingQueueLength.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Длина очереди на посадку";
            // 
            // tbTakeOffQueueLength
            // 
            this.tbTakeOffQueueLength.Location = new System.Drawing.Point(605, 259);
            this.tbTakeOffQueueLength.Name = "tbTakeOffQueueLength";
            this.tbTakeOffQueueLength.Size = new System.Drawing.Size(100, 22);
            this.tbTakeOffQueueLength.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Длина очереди на взлёт";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbCurrentTime
            // 
            this.tbCurrentTime.Location = new System.Drawing.Point(357, 12);
            this.tbCurrentTime.Name = "tbCurrentTime";
            this.tbCurrentTime.ReadOnly = true;
            this.tbCurrentTime.Size = new System.Drawing.Size(73, 22);
            this.tbCurrentTime.TabIndex = 32;
            this.tbCurrentTime.Text = "Время";
            // 
            // gbStatistic
            // 
            this.gbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatistic.Controls.Add(this.tbDoneRequest);
            this.gbStatistic.Controls.Add(this.label7);
            this.gbStatistic.Controls.Add(this.chDelay);
            this.gbStatistic.Controls.Add(this.label1);
            this.gbStatistic.Controls.Add(this.tbTakeOffQueueLength);
            this.gbStatistic.Controls.Add(this.chCountRequestDone);
            this.gbStatistic.Controls.Add(this.label6);
            this.gbStatistic.Controls.Add(this.label2);
            this.gbStatistic.Controls.Add(this.tbLandingQueueLength);
            this.gbStatistic.Controls.Add(this.chAvgRunwayWork);
            this.gbStatistic.Controls.Add(this.label5);
            this.gbStatistic.Controls.Add(this.label3);
            this.gbStatistic.Controls.Add(this.tbDelay);
            this.gbStatistic.Controls.Add(this.label4);
            this.gbStatistic.Location = new System.Drawing.Point(360, 309);
            this.gbStatistic.Name = "gbStatistic";
            this.gbStatistic.Size = new System.Drawing.Size(744, 310);
            this.gbStatistic.TabIndex = 36;
            this.gbStatistic.TabStop = false;
            // 
            // tbDoneRequest
            // 
            this.tbDoneRequest.Location = new System.Drawing.Point(252, 229);
            this.tbDoneRequest.Name = "tbDoneRequest";
            this.tbDoneRequest.Size = new System.Drawing.Size(100, 22);
            this.tbDoneRequest.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Количество обслужанных заявок";
            // 
            // MainDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 631);
            this.Controls.Add(this.tbCurrentTime);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.LVSchedue);
            this.Controls.Add(this.pAirQueue);
            this.Controls.Add(this.pRunwayMap);
            this.Controls.Add(this.gbStatistic);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование";
            this.Load += new System.EventHandler(this.MainDisplayForm_Load);
            this.pRunwayMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chCountRequestDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAvgRunwayWork)).EndInit();
            this.gbStatistic.ResumeLayout(false);
            this.gbStatistic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pRunwayMap;
        private System.Windows.Forms.Panel pAirQueue;
        private System.Windows.Forms.ListView LVSchedue;
        private System.Windows.Forms.ColumnHeader chRanway;
        private System.Windows.Forms.ColumnHeader chAirplane;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chCountRequestDone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bEnd;
        private System.Windows.Forms.Button bNextStep;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Button bParams;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Panel pRunway0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAvgRunwayWork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDelay;
        private System.Windows.Forms.TextBox tbLandingQueueLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTakeOffQueueLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUDStep;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbCurrentTime;
        private System.Windows.Forms.GroupBox gbStatistic;
        private System.Windows.Forms.TextBox tbDoneRequest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader Delay;
        private System.Windows.Forms.ColumnHeader chDirection;
        private System.Windows.Forms.ColumnHeader chTypeAirplane;
        private System.Windows.Forms.ColumnHeader chCompanyName;
    }
}