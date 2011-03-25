namespace olympchecker_gui
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTimeLimit = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTestsDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSourceFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxExactChecking = new System.Windows.Forms.CheckBox();
            this.textBoxCustomCheckerSource = new System.Windows.Forms.TextBox();
            this.radioButtonCustomChecker = new System.Windows.Forms.RadioButton();
            this.radioButtonInternalChecker = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOutputFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxInputFileName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTimeLimit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxTestsDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSourceFile);
            this.groupBox1.Location = new System.Drawing.Point(9, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Решение";
            // 
            // textBoxTimeLimit
            // 
            this.textBoxTimeLimit.HidePromptOnLeave = true;
            this.textBoxTimeLimit.Location = new System.Drawing.Point(147, 92);
            this.textBoxTimeLimit.Mask = "90.9";
            this.textBoxTimeLimit.Name = "textBoxTimeLimit";
            this.textBoxTimeLimit.Size = new System.Drawing.Size(89, 20);
            this.textBoxTimeLimit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ограничение времени (с)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Папка тестов";
            // 
            // textBoxTestsDirectory
            // 
            this.textBoxTestsDirectory.AllowDrop = true;
            this.textBoxTestsDirectory.Location = new System.Drawing.Point(97, 62);
            this.textBoxTestsDirectory.Name = "textBoxTestsDirectory";
            this.textBoxTestsDirectory.Size = new System.Drawing.Size(357, 20);
            this.textBoxTestsDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходный код";
            // 
            // textBoxSourceFile
            // 
            this.textBoxSourceFile.AllowDrop = true;
            this.textBoxSourceFile.Location = new System.Drawing.Point(97, 27);
            this.textBoxSourceFile.Name = "textBoxSourceFile";
            this.textBoxSourceFile.Size = new System.Drawing.Size(357, 20);
            this.textBoxSourceFile.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxExactChecking);
            this.groupBox2.Controls.Add(this.textBoxCustomCheckerSource);
            this.groupBox2.Controls.Add(this.radioButtonCustomChecker);
            this.groupBox2.Controls.Add(this.radioButtonInternalChecker);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxOutputFileName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxInputFileName);
            this.groupBox2.Location = new System.Drawing.Point(10, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проверка";
            // 
            // checkBoxExactChecking
            // 
            this.checkBoxExactChecking.AutoSize = true;
            this.checkBoxExactChecking.Location = new System.Drawing.Point(173, 102);
            this.checkBoxExactChecking.Name = "checkBoxExactChecking";
            this.checkBoxExactChecking.Size = new System.Drawing.Size(119, 17);
            this.checkBoxExactChecking.TabIndex = 7;
            this.checkBoxExactChecking.Text = "Точное сравнение";
            this.checkBoxExactChecking.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomCheckerSource
            // 
            this.textBoxCustomCheckerSource.AllowDrop = true;
            this.textBoxCustomCheckerSource.Enabled = false;
            this.textBoxCustomCheckerSource.Location = new System.Drawing.Point(173, 125);
            this.textBoxCustomCheckerSource.Name = "textBoxCustomCheckerSource";
            this.textBoxCustomCheckerSource.Size = new System.Drawing.Size(280, 20);
            this.textBoxCustomCheckerSource.TabIndex = 6;
            // 
            // radioButtonCustomChecker
            // 
            this.radioButtonCustomChecker.AutoSize = true;
            this.radioButtonCustomChecker.Location = new System.Drawing.Point(9, 126);
            this.radioButtonCustomChecker.Name = "radioButtonCustomChecker";
            this.radioButtonCustomChecker.Size = new System.Drawing.Size(158, 17);
            this.radioButtonCustomChecker.TabIndex = 5;
            this.radioButtonCustomChecker.Text = "Проверяющая программа";
            this.radioButtonCustomChecker.UseVisualStyleBackColor = true;
            this.radioButtonCustomChecker.CheckedChanged += new System.EventHandler(this.radioButtonCustomChecker_CheckedChanged);
            // 
            // radioButtonInternalChecker
            // 
            this.radioButtonInternalChecker.AutoSize = true;
            this.radioButtonInternalChecker.Checked = true;
            this.radioButtonInternalChecker.Location = new System.Drawing.Point(9, 101);
            this.radioButtonInternalChecker.Name = "radioButtonInternalChecker";
            this.radioButtonInternalChecker.Size = new System.Drawing.Size(136, 17);
            this.radioButtonInternalChecker.TabIndex = 4;
            this.radioButtonInternalChecker.TabStop = true;
            this.radioButtonInternalChecker.Text = "Встроенная проверка";
            this.radioButtonInternalChecker.UseVisualStyleBackColor = true;
            this.radioButtonInternalChecker.CheckedChanged += new System.EventHandler(this.radioButtonInternalChecker_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Выходной файл";
            // 
            // textBoxOutputFileName
            // 
            this.textBoxOutputFileName.AllowDrop = true;
            this.textBoxOutputFileName.Location = new System.Drawing.Point(97, 62);
            this.textBoxOutputFileName.Name = "textBoxOutputFileName";
            this.textBoxOutputFileName.Size = new System.Drawing.Size(112, 20);
            this.textBoxOutputFileName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Входной файл";
            // 
            // textBoxInputFileName
            // 
            this.textBoxInputFileName.AllowDrop = true;
            this.textBoxInputFileName.Location = new System.Drawing.Point(96, 33);
            this.textBoxInputFileName.Name = "textBoxInputFileName";
            this.textBoxInputFileName.Size = new System.Drawing.Size(112, 20);
            this.textBoxInputFileName.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(802, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OlympChecker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox textBoxTimeLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTestsDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSourceFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonCustomChecker;
        private System.Windows.Forms.RadioButton radioButtonInternalChecker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxOutputFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxInputFileName;
        private System.Windows.Forms.TextBox textBoxCustomCheckerSource;
        private System.Windows.Forms.CheckBox checkBoxExactChecking;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}