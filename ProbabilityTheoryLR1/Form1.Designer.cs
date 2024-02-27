namespace ProbabilityTheoryLR1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            ProgressBar = new ProgressBar();
            ComboBox = new ComboBox();
            label1 = new Label();
            PictureBox = new PictureBox();
            Label_n = new Label();
            Label_m = new Label();
            Number_n = new NumericUpDown();
            Number_m = new NumericUpDown();
            Percentage = new Label();
            Button = new Button();
            ErrorLabel = new Label();
            Information = new Label();
            ClearResults = new Button();
            OpenResults = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Number_n).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Number_m).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 5;
            timer1.Tick += timer1_Tick;
            // 
            // ProgressBar
            // 
            ProgressBar.Location = new Point(12, 345);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(690, 29);
            ProgressBar.TabIndex = 0;
            ProgressBar.Visible = false;
            // 
            // ComboBox
            // 
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.FormattingEnabled = true;
            ComboBox.Items.AddRange(new object[] { "Сочетание без повторов", "Размещение без повтора", "Размещение с повтором" });
            ComboBox.Location = new Point(12, 50);
            ComboBox.Name = "ComboBox";
            ComboBox.Size = new Size(213, 28);
            ComboBox.TabIndex = 1;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 2;
            label1.Text = "Тип комбинации\r\n";
            // 
            // PictureBox
            // 
            PictureBox.InitialImage = null;
            PictureBox.Location = new Point(282, 57);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(420, 210);
            PictureBox.TabIndex = 3;
            PictureBox.TabStop = false;
            // 
            // Label_n
            // 
            Label_n.AutoSize = true;
            Label_n.Location = new Point(12, 118);
            Label_n.Name = "Label_n";
            Label_n.Size = new Size(17, 20);
            Label_n.TabIndex = 4;
            Label_n.Text = "n";
            Label_n.Visible = false;
            // 
            // Label_m
            // 
            Label_m.AutoSize = true;
            Label_m.Location = new Point(12, 171);
            Label_m.Name = "Label_m";
            Label_m.Size = new Size(22, 20);
            Label_m.TabIndex = 4;
            Label_m.Text = "m";
            Label_m.Visible = false;
            // 
            // Number_n
            // 
            Number_n.Location = new Point(12, 141);
            Number_n.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            Number_n.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Number_n.Name = "Number_n";
            Number_n.Size = new Size(150, 27);
            Number_n.TabIndex = 5;
            Number_n.Value = new decimal(new int[] { 1, 0, 0, 0 });
            Number_n.Visible = false;
            Number_n.ValueChanged += Number_n_ValueChanged;
            // 
            // Number_m
            // 
            Number_m.Location = new Point(12, 194);
            Number_m.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            Number_m.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Number_m.Name = "Number_m";
            Number_m.Size = new Size(150, 27);
            Number_m.TabIndex = 5;
            Number_m.Value = new decimal(new int[] { 1, 0, 0, 0 });
            Number_m.Visible = false;
            Number_m.ValueChanged += Number_m_ValueChanged;
            // 
            // Percentage
            // 
            Percentage.AutoSize = true;
            Percentage.Location = new Point(12, 322);
            Percentage.Name = "Percentage";
            Percentage.Size = new Size(50, 20);
            Percentage.TabIndex = 6;
            Percentage.Text = "label4";
            Percentage.Visible = false;
            // 
            // Button
            // 
            Button.Location = new Point(12, 256);
            Button.Name = "Button";
            Button.Size = new Size(150, 38);
            Button.TabIndex = 7;
            Button.Text = "Рассчитать";
            Button.UseVisualStyleBackColor = true;
            Button.Visible = false;
            Button.Click += Button_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(168, 265);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(58, 20);
            ErrorLabel.TabIndex = 8;
            ErrorLabel.Text = "n <= m";
            ErrorLabel.Visible = false;
            // 
            // Information
            // 
            Information.AutoSize = true;
            Information.Location = new Point(282, 281);
            Information.Name = "Information";
            Information.Size = new Size(227, 40);
            Information.TabIndex = 9;
            Information.Text = "Все результаты помещаются\r\nв results.txt в папке программы\r\n";
            Information.Visible = false;
            // 
            // ClearResults
            // 
            ClearResults.Location = new Point(528, 281);
            ClearResults.Name = "ClearResults";
            ClearResults.Size = new Size(174, 48);
            ClearResults.TabIndex = 10;
            ClearResults.Text = "Очистить results.txt";
            ClearResults.UseVisualStyleBackColor = true;
            ClearResults.Visible = false;
            ClearResults.Click += ClearResults_Click;
            // 
            // OpenResults
            // 
            OpenResults.Location = new Point(528, 12);
            OpenResults.Name = "OpenResults";
            OpenResults.Size = new Size(174, 39);
            OpenResults.TabIndex = 11;
            OpenResults.Text = "Открыть results.txt";
            OpenResults.UseVisualStyleBackColor = true;
            OpenResults.Click += OpenResults_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(714, 386);
            Controls.Add(OpenResults);
            Controls.Add(ClearResults);
            Controls.Add(Information);
            Controls.Add(ErrorLabel);
            Controls.Add(Button);
            Controls.Add(Percentage);
            Controls.Add(Number_m);
            Controls.Add(Number_n);
            Controls.Add(Label_m);
            Controls.Add(Label_n);
            Controls.Add(PictureBox);
            Controls.Add(label1);
            Controls.Add(ComboBox);
            Controls.Add(ProgressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(732, 433);
            MinimumSize = new Size(732, 433);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ermakov LR 1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)Number_n).EndInit();
            ((System.ComponentModel.ISupportInitialize)Number_m).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private ProgressBar ProgressBar;
        private ComboBox ComboBox;
        private Label label1;
        private PictureBox PictureBox;
        private Label Label_n;
        private Label Label_m;
        private NumericUpDown Number_n;
        private NumericUpDown Number_m;
        private Label Percentage;
        private Button Button;
        private Label ErrorLabel;
        private Label Information;
        private Button ClearResults;
        private Button OpenResults;
    }
}
