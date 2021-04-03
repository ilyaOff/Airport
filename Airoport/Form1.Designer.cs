namespace Airoport
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbShedule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDCountRunway = new System.Windows.Forms.NumericUpDown();
            this.cbSepRunway = new System.Windows.Forms.CheckBox();
            this.nUDTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nUDDelayMin = new System.Windows.Forms.NumericUpDown();
            this.nUDDelayMax = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nUDStep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountRunway)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            this.SuspendLayout();
            // 
            // tbShedule
            // 
            this.tbShedule.Location = new System.Drawing.Point(47, 62);
            this.tbShedule.Name = "tbShedule";
            this.tbShedule.Size = new System.Drawing.Size(314, 22);
            this.tbShedule.TabIndex = 0;
            this.tbShedule.Text = "Путь до файла";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Расписание:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество полос:";
            // 
            // nUDCountRunway
            // 
            this.nUDCountRunway.Location = new System.Drawing.Point(47, 126);
            this.nUDCountRunway.Name = "nUDCountRunway";
            this.nUDCountRunway.Size = new System.Drawing.Size(120, 22);
            this.nUDCountRunway.TabIndex = 3;
            // 
            // cbSepRunway
            // 
            this.cbSepRunway.AutoSize = true;
            this.cbSepRunway.Location = new System.Drawing.Point(208, 127);
            this.cbSepRunway.Name = "cbSepRunway";
            this.cbSepRunway.Size = new System.Drawing.Size(153, 21);
            this.cbSepRunway.TabIndex = 4;
            this.cbSepRunway.Text = "Разделение полос";
            this.cbSepRunway.UseVisualStyleBackColor = true;
            // 
            // nUDTimeInterval
            // 
            this.nUDTimeInterval.Location = new System.Drawing.Point(47, 202);
            this.nUDTimeInterval.Name = "nUDTimeInterval";
            this.nUDTimeInterval.Size = new System.Drawing.Size(120, 22);
            this.nUDTimeInterval.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Промежуток между взлетами/посадками";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Отклонение от расписания:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "От";
            // 
            // nUDDelayMin
            // 
            this.nUDDelayMin.Location = new System.Drawing.Point(76, 271);
            this.nUDDelayMin.Name = "nUDDelayMin";
            this.nUDDelayMin.Size = new System.Drawing.Size(45, 22);
            this.nUDDelayMin.TabIndex = 11;
            // 
            // nUDDelayMax
            // 
            this.nUDDelayMax.Location = new System.Drawing.Point(183, 273);
            this.nUDDelayMax.Name = "nUDDelayMax";
            this.nUDDelayMax.Size = new System.Drawing.Size(45, 22);
            this.nUDDelayMax.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "До";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Стартовое время:";
            // 
            // nUDStep
            // 
            this.nUDStep.Location = new System.Drawing.Point(82, 344);
            this.nUDStep.Name = "nUDStep";
            this.nUDStep.Size = new System.Drawing.Size(120, 22);
            this.nUDStep.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Шаг";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(147, 392);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(151, 46);
            this.bStart.TabIndex = 18;
            this.bStart.Text = "Старт";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(183, 314);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(178, 22);
            this.dtpStartTime.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 450);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.nUDStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nUDDelayMax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nUDDelayMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUDTimeInterval);
            this.Controls.Add(this.cbSepRunway);
            this.Controls.Add(this.nUDCountRunway);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стартовое окно";
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountRunway)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbShedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDCountRunway;
        private System.Windows.Forms.CheckBox cbSepRunway;
        private System.Windows.Forms.NumericUpDown nUDTimeInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDDelayMin;
        private System.Windows.Forms.NumericUpDown nUDDelayMax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nUDStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
    }
}

