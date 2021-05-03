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
            this.nUDCountRunways = new System.Windows.Forms.NumericUpDown();
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
            this.label9 = new System.Windows.Forms.Label();
            this.nUDCountLandingRunways = new System.Windows.Forms.NumericUpDown();
            this.lSepRunway1 = new System.Windows.Forms.Label();
            this.lSepRunway2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountRunways)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountLandingRunways)).BeginInit();
            this.SuspendLayout();
            // 
            // tbShedule
            // 
            this.tbShedule.Location = new System.Drawing.Point(47, 62);
            this.tbShedule.Name = "tbShedule";
            this.tbShedule.Size = new System.Drawing.Size(265, 22);
            this.tbShedule.TabIndex = 0;
            this.tbShedule.Text = "D:\\Users\\Илья\\Desktop\\Расписание.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Расписание";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Количество полос (от 2 до 10)";
            // 
            // nUDCountRunways
            // 
            this.nUDCountRunways.Location = new System.Drawing.Point(47, 126);
            this.nUDCountRunways.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDCountRunways.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDCountRunways.Name = "nUDCountRunways";
            this.nUDCountRunways.Size = new System.Drawing.Size(120, 22);
            this.nUDCountRunways.TabIndex = 3;
            this.nUDCountRunways.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUDCountRunways.ValueChanged += new System.EventHandler(this.nUDCountRunway_ValueChanged);
            // 
            // cbSepRunway
            // 
            this.cbSepRunway.AutoSize = true;
            this.cbSepRunway.Location = new System.Drawing.Point(47, 164);
            this.cbSepRunway.Name = "cbSepRunway";
            this.cbSepRunway.Size = new System.Drawing.Size(153, 21);
            this.cbSepRunway.TabIndex = 4;
            this.cbSepRunway.Text = "Разделение полос";
            this.cbSepRunway.UseVisualStyleBackColor = true;
            this.cbSepRunway.CheckedChanged += new System.EventHandler(this.cbSepRunway_CheckedChanged);
            // 
            // nUDTimeInterval
            // 
            this.nUDTimeInterval.Location = new System.Drawing.Point(506, 57);
            this.nUDTimeInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDTimeInterval.Name = "nUDTimeInterval";
            this.nUDTimeInterval.Size = new System.Drawing.Size(136, 22);
            this.nUDTimeInterval.TabIndex = 5;
            this.nUDTimeInterval.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Промежуток между взлетами/посадками";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Отклонение от расписания (от -120 до 120 минут)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "От";
            // 
            // nUDDelayMin
            // 
            this.nUDDelayMin.Location = new System.Drawing.Point(383, 129);
            this.nUDDelayMin.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nUDDelayMin.Minimum = new decimal(new int[] {
            120,
            0,
            0,
            -2147483648});
            this.nUDDelayMin.Name = "nUDDelayMin";
            this.nUDDelayMin.Size = new System.Drawing.Size(69, 22);
            this.nUDDelayMin.TabIndex = 11;
            this.nUDDelayMin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // nUDDelayMax
            // 
            this.nUDDelayMax.Location = new System.Drawing.Point(506, 129);
            this.nUDDelayMax.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nUDDelayMax.Name = "nUDDelayMax";
            this.nUDDelayMax.Size = new System.Drawing.Size(65, 22);
            this.nUDDelayMax.TabIndex = 13;
            this.nUDDelayMax.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "До";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Стартовое время";
            // 
            // nUDStep
            // 
            this.nUDStep.Location = new System.Drawing.Point(506, 205);
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
            this.nUDStep.Size = new System.Drawing.Size(136, 22);
            this.nUDStep.TabIndex = 17;
            this.nUDStep.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Шаг, от 5 до 30 минут";
            // 
            // bStart
            // 
            this.bStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bStart.Location = new System.Drawing.Point(277, 270);
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
            this.dtpStartTime.Location = new System.Drawing.Point(490, 172);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(152, 22);
            this.dtpStartTime.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = " от 0 до 10 минут";
            // 
            // nUDCountLandingRunways
            // 
            this.nUDCountLandingRunways.Enabled = false;
            this.nUDCountLandingRunways.Location = new System.Drawing.Point(47, 236);
            this.nUDCountLandingRunways.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDCountLandingRunways.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDCountLandingRunways.Name = "nUDCountLandingRunways";
            this.nUDCountLandingRunways.Size = new System.Drawing.Size(120, 22);
            this.nUDCountLandingRunways.TabIndex = 22;
            this.nUDCountLandingRunways.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCountLandingRunways.ValueChanged += new System.EventHandler(this.nUDCountLandingRunways_ValueChanged);
            // 
            // lSepRunway1
            // 
            this.lSepRunway1.AutoSize = true;
            this.lSepRunway1.Enabled = false;
            this.lSepRunway1.Location = new System.Drawing.Point(44, 188);
            this.lSepRunway1.Name = "lSepRunway1";
            this.lSepRunway1.Size = new System.Drawing.Size(218, 17);
            this.lSepRunway1.TabIndex = 21;
            this.lSepRunway1.Text = "Количество полос под посадку ";
            // 
            // lSepRunway2
            // 
            this.lSepRunway2.AutoSize = true;
            this.lSepRunway2.Enabled = false;
            this.lSepRunway2.Location = new System.Drawing.Point(44, 207);
            this.lSepRunway2.Name = "lSepRunway2";
            this.lSepRunway2.Size = new System.Drawing.Size(268, 17);
            this.lSepRunway2.TabIndex = 23;
            this.lSepRunway2.Text = "(от 1 до 9, меньше общего количества)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 340);
            this.Controls.Add(this.lSepRunway2);
            this.Controls.Add(this.nUDCountLandingRunways);
            this.Controls.Add(this.lSepRunway1);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.nUDCountRunways);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbShedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры моделирования";
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountRunways)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTimeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDDelayMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCountLandingRunways)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bStart;
        public System.Windows.Forms.NumericUpDown nUDCountRunways;
        public System.Windows.Forms.CheckBox cbSepRunway;
        public System.Windows.Forms.NumericUpDown nUDTimeInterval;
        public System.Windows.Forms.NumericUpDown nUDDelayMin;
        public System.Windows.Forms.NumericUpDown nUDDelayMax;
        public System.Windows.Forms.NumericUpDown nUDStep;
        public System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.NumericUpDown nUDCountLandingRunways;
        private System.Windows.Forms.Label lSepRunway1;
        private System.Windows.Forms.Label lSepRunway2;
        public System.Windows.Forms.TextBox tbShedule;
    }
}

