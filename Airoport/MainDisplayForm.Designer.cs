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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pRunways = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pAirQueue = new System.Windows.Forms.Panel();
            this.LVSchedue = new System.Windows.Forms.ListView();
            this.chRanway = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAirplane = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nUDStep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.bEnd = new System.Windows.Forms.Button();
            this.bNextStep = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bExit = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.pRunways.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            this.gbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pRunways
            // 
            this.pRunways.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pRunways.BackColor = System.Drawing.SystemColors.Highlight;
            this.pRunways.Controls.Add(this.chart1);
            this.pRunways.Location = new System.Drawing.Point(360, 15);
            this.pRunways.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pRunways.Name = "pRunways";
            this.pRunways.Size = new System.Drawing.Size(717, 337);
            this.pRunways.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(485, 2);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(229, 130);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
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
            this.LVSchedue.Size = new System.Drawing.Size(292, 148);
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
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(360, 370);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(229, 130);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            // 
            // nUDStep
            // 
            this.nUDStep.Location = new System.Drawing.Point(9, 46);
            this.nUDStep.Name = "nUDStep";
            this.nUDStep.Size = new System.Drawing.Size(91, 22);
            this.nUDStep.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Шаг";
            // 
            // bEnd
            // 
            this.bEnd.Location = new System.Drawing.Point(218, 16);
            this.bEnd.Name = "bEnd";
            this.bEnd.Size = new System.Drawing.Size(74, 52);
            this.bEnd.TabIndex = 20;
            this.bEnd.Text = "До конца";
            this.bEnd.UseVisualStyleBackColor = true;
            // 
            // bNextStep
            // 
            this.bNextStep.Location = new System.Drawing.Point(106, 16);
            this.bNextStep.Name = "bNextStep";
            this.bNextStep.Size = new System.Drawing.Size(106, 52);
            this.bNextStep.TabIndex = 21;
            this.bNextStep.Text = "Следующий шаг";
            this.bNextStep.UseVisualStyleBackColor = true;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(9, 97);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(101, 52);
            this.bStop.TabIndex = 22;
            this.bStop.Text = "Закончить";
            this.bStop.UseVisualStyleBackColor = true;
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
            this.gbButtons.Controls.Add(this.label8);
            this.gbButtons.Controls.Add(this.bExit);
            this.gbButtons.Controls.Add(this.nUDStep);
            this.gbButtons.Controls.Add(this.bStop);
            this.gbButtons.Controls.Add(this.bEnd);
            this.gbButtons.Controls.Add(this.bNextStep);
            this.gbButtons.Location = new System.Drawing.Point(15, 370);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(293, 168);
            this.gbButtons.TabIndex = 24;
            this.gbButtons.TabStop = false;
            // 
            // MainDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 576);
            this.Controls.Add(this.gbButtons);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.LVSchedue);
            this.Controls.Add(this.pAirQueue);
            this.Controls.Add(this.pRunways);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Моделирование";
            this.Load += new System.EventHandler(this.MainDisplayForm_Load);
            this.pRunways.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            this.gbButtons.ResumeLayout(false);
            this.gbButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pRunways;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pAirQueue;
        private System.Windows.Forms.ListView LVSchedue;
        private System.Windows.Forms.ColumnHeader chRanway;
        private System.Windows.Forms.ColumnHeader chAirplane;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.NumericUpDown nUDStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bEnd;
        private System.Windows.Forms.Button bNextStep;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.GroupBox gbButtons;
    }
}