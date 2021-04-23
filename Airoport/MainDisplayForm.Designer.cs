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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRunways = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pRunway0 = new System.Windows.Forms.Panel();
            this.pAirQueue = new System.Windows.Forms.Panel();
            this.LVSchedue = new System.Windows.Forms.ListView();
            this.chRanway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCountRequestDone = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nUDStep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.bEnd = new System.Windows.Forms.Button();
            this.bNextStep = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chDelay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.chAvgRunwayWork = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbCurrentTime = new System.Windows.Forms.TextBox();
            this.pRunways.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCountRequestDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            this.gbButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAvgRunwayWork)).BeginInit();
            this.SuspendLayout();
            // 
            // pRunways
            // 
            this.pRunways.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRunways.AutoScroll = true;
            this.pRunways.AutoScrollMinSize = new System.Drawing.Size(500, 340);
            this.pRunways.BackColor = System.Drawing.SystemColors.Highlight;
            this.pRunways.Controls.Add(this.pictureBox1);
            this.pRunways.Controls.Add(this.pRunway0);
            this.pRunways.Location = new System.Drawing.Point(360, 15);
            this.pRunways.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pRunways.Name = "pRunways";
            this.pRunways.Size = new System.Drawing.Size(717, 340);
            this.pRunways.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::Airoport.Properties.Resources.ПассажирскийПосадка;
            this.pictureBox1.Location = new System.Drawing.Point(164, 221);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 65);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pRunway0
            // 
            this.pRunway0.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pRunway0.Location = new System.Drawing.Point(34, 3);
            this.pRunway0.Name = "pRunway0";
            this.pRunway0.Size = new System.Drawing.Size(109, 319);
            this.pRunway0.TabIndex = 2;
            // 
            // pAirQueue
            // 
            this.pAirQueue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pAirQueue.Location = new System.Drawing.Point(15, 15);
            this.pAirQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pAirQueue.Name = "pAirQueue";
            this.pAirQueue.Size = new System.Drawing.Size(293, 185);
            this.pAirQueue.TabIndex = 1;
            // 
            // LVSchedue
            // 
            this.LVSchedue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LVSchedue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chRanway,
            this.chAirplane,
            this.chState,
            this.chTime});
            this.LVSchedue.HideSelection = false;
            this.LVSchedue.Location = new System.Drawing.Point(15, 204);
            this.LVSchedue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LVSchedue.Name = "LVSchedue";
            this.LVSchedue.Size = new System.Drawing.Size(292, 216);
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
            // chCountRequestDone
            // 
            this.chCountRequestDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.chCountRequestDone.ChartAreas.Add(chartArea1);
            this.chCountRequestDone.Location = new System.Drawing.Point(357, 390);
            this.chCountRequestDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chCountRequestDone.Name = "chCountRequestDone";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chCountRequestDone.Series.Add(series1);
            this.chCountRequestDone.Size = new System.Drawing.Size(226, 130);
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
            5,
            0,
            0,
            0});
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
            // 
            // bNextStep
            // 
            this.bNextStep.Location = new System.Drawing.Point(9, 43);
            this.bNextStep.Name = "bNextStep";
            this.bNextStep.Size = new System.Drawing.Size(124, 52);
            this.bNextStep.TabIndex = 21;
            this.bNextStep.Text = "Следующий шаг";
            this.bNextStep.UseVisualStyleBackColor = true;
            // 
            // bPause
            // 
            this.bPause.Location = new System.Drawing.Point(9, 97);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(124, 52);
            this.bPause.TabIndex = 22;
            this.bPause.Text = "Прервать моделирование";
            this.bPause.UseVisualStyleBackColor = true;
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(161, 97);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(101, 52);
            this.bExit.TabIndex = 23;
            this.bExit.Text = "Выход";
            this.bExit.UseVisualStyleBackColor = true;
            // 
            // gbButtons
            // 
            this.gbButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbButtons.Controls.Add(this.bExit);
            this.gbButtons.Controls.Add(this.nUDStep);
            this.gbButtons.Controls.Add(this.bPause);
            this.gbButtons.Controls.Add(this.bEnd);
            this.gbButtons.Controls.Add(this.bNextStep);
            this.gbButtons.Controls.Add(this.label8);
            this.gbButtons.Location = new System.Drawing.Point(15, 425);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(293, 178);
            this.gbButtons.TabIndex = 24;
            this.gbButtons.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Количество обслужанных заявок";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Задержка";
            // 
            // chDelay
            // 
            this.chDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea2.Name = "ChartArea1";
            this.chDelay.ChartAreas.Add(chartArea2);
            this.chDelay.Location = new System.Drawing.Point(598, 390);
            this.chDelay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chDelay.Name = "chDelay";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.chDelay.Series.Add(series2);
            this.chDelay.Size = new System.Drawing.Size(226, 130);
            this.chDelay.TabIndex = 26;
            this.chDelay.Text = "chart1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(839, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Средняя занятость полос";
            // 
            // chAvgRunwayWork
            // 
            this.chAvgRunwayWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea3.Name = "ChartArea1";
            this.chAvgRunwayWork.ChartAreas.Add(chartArea3);
            this.chAvgRunwayWork.Location = new System.Drawing.Point(839, 390);
            this.chAvgRunwayWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chAvgRunwayWork.Name = "chAvgRunwayWork";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.chAvgRunwayWork.Series.Add(series3);
            this.chAvgRunwayWork.Size = new System.Drawing.Size(226, 130);
            this.chAvgRunwayWork.TabIndex = 28;
            this.chAvgRunwayWork.Text = "Средняя занятость полос";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Задержка";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(436, 537);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 31;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(803, 539);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(609, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Длина очереди на посадку";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.Location = new System.Drawing.Point(803, 567);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(609, 570);
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
            this.tbCurrentTime.Size = new System.Drawing.Size(73, 22);
            this.tbCurrentTime.TabIndex = 32;
            this.tbCurrentTime.Text = "Время";
            // 
            // MainDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 615);
            this.Controls.Add(this.tbCurrentTime);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chAvgRunwayWork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chDelay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.chCountRequestDone);
            this.Controls.Add(this.LVSchedue);
            this.Controls.Add(this.pAirQueue);
            this.Controls.Add(this.pRunways);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование";
            this.Load += new System.EventHandler(this.MainDisplayForm_Load);
            this.pRunways.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCountRequestDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAvgRunwayWork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pRunways;
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
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Panel pRunway0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chAvgRunwayWork;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUDStep;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbCurrentTime;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}