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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureTimeLimit = new System.Windows.Forms.PictureBox();
            this.pictureTestsFolder = new System.Windows.Forms.PictureBox();
            this.pictureSourceFile = new System.Windows.Forms.PictureBox();
            this.textBoxTimeLimit = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTestsFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSourceFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseStandartIO = new System.Windows.Forms.CheckBox();
            this.checkBoxExactChecking = new System.Windows.Forms.CheckBox();
            this.textBoxCustomCheckerSource = new System.Windows.Forms.TextBox();
            this.radioButtonCustomChecker = new System.Windows.Forms.RadioButton();
            this.radioButtonInternalChecker = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxOutputFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxInputFileName = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRun = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureChecker = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTestsFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSourceFile)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChecker)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureTimeLimit);
            this.groupBox1.Controls.Add(this.pictureTestsFolder);
            this.groupBox1.Controls.Add(this.pictureSourceFile);
            this.groupBox1.Controls.Add(this.textBoxTimeLimit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxTestsFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSourceFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Решение";
            // 
            // pictureTimeLimit
            // 
            this.pictureTimeLimit.Image = global::olympchecker_gui.Icons.OK;
            this.pictureTimeLimit.Location = new System.Drawing.Point(214, 96);
            this.pictureTimeLimit.Name = "pictureTimeLimit";
            this.pictureTimeLimit.Size = new System.Drawing.Size(20, 20);
            this.pictureTimeLimit.TabIndex = 8;
            this.pictureTimeLimit.TabStop = false;
            // 
            // pictureTestsFolder
            // 
            this.pictureTestsFolder.Image = global::olympchecker_gui.Icons.Warning;
            this.pictureTestsFolder.Location = new System.Drawing.Point(442, 62);
            this.pictureTestsFolder.Name = "pictureTestsFolder";
            this.pictureTestsFolder.Size = new System.Drawing.Size(20, 20);
            this.pictureTestsFolder.TabIndex = 7;
            this.pictureTestsFolder.TabStop = false;
            this.toolTip.SetToolTip(this.pictureTestsFolder, "Не введено имя папки");
            // 
            // pictureSourceFile
            // 
            this.pictureSourceFile.Image = global::olympchecker_gui.Icons.Warning;
            this.pictureSourceFile.Location = new System.Drawing.Point(442, 27);
            this.pictureSourceFile.Name = "pictureSourceFile";
            this.pictureSourceFile.Size = new System.Drawing.Size(20, 20);
            this.pictureSourceFile.TabIndex = 6;
            this.pictureSourceFile.TabStop = false;
            this.toolTip.SetToolTip(this.pictureSourceFile, "Не введено имя файла");
            // 
            // textBoxTimeLimit
            // 
            this.textBoxTimeLimit.HidePromptOnLeave = true;
            this.textBoxTimeLimit.Location = new System.Drawing.Point(147, 96);
            this.textBoxTimeLimit.Mask = "0.9";
            this.textBoxTimeLimit.Name = "textBoxTimeLimit";
            this.textBoxTimeLimit.Size = new System.Drawing.Size(61, 20);
            this.textBoxTimeLimit.TabIndex = 2;
            this.textBoxTimeLimit.Text = "10";
            this.textBoxTimeLimit.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.textBoxTimeLimit.TextChanged += new System.EventHandler(this.textBoxTimeLimit_TextChanged);
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
            // textBoxTestsFolder
            // 
            this.textBoxTestsFolder.AllowDrop = true;
            this.textBoxTestsFolder.Location = new System.Drawing.Point(96, 62);
            this.textBoxTestsFolder.Name = "textBoxTestsFolder";
            this.textBoxTestsFolder.Size = new System.Drawing.Size(340, 20);
            this.textBoxTestsFolder.TabIndex = 1;
            this.textBoxTestsFolder.TextChanged += new System.EventHandler(this.textBoxTestsFolder_TextChanged);
            this.textBoxTestsFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxTestsFolder_DragDrop);
            this.textBoxTestsFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxTestsFolder_DragEnter);
            this.textBoxTestsFolder.DoubleClick += new System.EventHandler(this.textBoxTestsFolder_DoubleClick);
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
            this.textBoxSourceFile.Size = new System.Drawing.Size(339, 20);
            this.textBoxSourceFile.TabIndex = 0;
            this.textBoxSourceFile.TextChanged += new System.EventHandler(this.textBoxSourceFile_TextChanged);
            this.textBoxSourceFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFile_DragDrop);
            this.textBoxSourceFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFile_DragEnter);
            this.textBoxSourceFile.DoubleClick += new System.EventHandler(this.textBoxSourceFile_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureChecker);
            this.groupBox2.Controls.Add(this.checkBoxUseStandartIO);
            this.groupBox2.Controls.Add(this.checkBoxExactChecking);
            this.groupBox2.Controls.Add(this.textBoxCustomCheckerSource);
            this.groupBox2.Controls.Add(this.radioButtonCustomChecker);
            this.groupBox2.Controls.Add(this.radioButtonInternalChecker);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxOutputFileName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxInputFileName);
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 171);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проверка";
            // 
            // checkBoxUseStandartIO
            // 
            this.checkBoxUseStandartIO.AutoSize = true;
            this.checkBoxUseStandartIO.Location = new System.Drawing.Point(9, 88);
            this.checkBoxUseStandartIO.Name = "checkBoxUseStandartIO";
            this.checkBoxUseStandartIO.Size = new System.Drawing.Size(266, 17);
            this.checkBoxUseStandartIO.TabIndex = 2;
            this.checkBoxUseStandartIO.Text = "Использовать также стандартный ввод/вывод";
            this.checkBoxUseStandartIO.UseVisualStyleBackColor = true;
            // 
            // checkBoxExactChecking
            // 
            this.checkBoxExactChecking.AutoSize = true;
            this.checkBoxExactChecking.Location = new System.Drawing.Point(173, 112);
            this.checkBoxExactChecking.Name = "checkBoxExactChecking";
            this.checkBoxExactChecking.Size = new System.Drawing.Size(119, 17);
            this.checkBoxExactChecking.TabIndex = 4;
            this.checkBoxExactChecking.Text = "Точное сравнение";
            this.checkBoxExactChecking.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomCheckerSource
            // 
            this.textBoxCustomCheckerSource.AllowDrop = true;
            this.textBoxCustomCheckerSource.Enabled = false;
            this.textBoxCustomCheckerSource.Location = new System.Drawing.Point(173, 135);
            this.textBoxCustomCheckerSource.Name = "textBoxCustomCheckerSource";
            this.textBoxCustomCheckerSource.Size = new System.Drawing.Size(263, 20);
            this.textBoxCustomCheckerSource.TabIndex = 5;
            this.textBoxCustomCheckerSource.TextChanged += new System.EventHandler(this.textBoxCustomCheckerSource_TextChanged);
            this.textBoxCustomCheckerSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCustomCheckerSource_DragDrop);
            this.textBoxCustomCheckerSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCustomCheckerSource_DragEnter);
            this.textBoxCustomCheckerSource.DoubleClick += new System.EventHandler(this.textBoxCustomCheckerSource_DoubleClick);
            // 
            // radioButtonCustomChecker
            // 
            this.radioButtonCustomChecker.AutoSize = true;
            this.radioButtonCustomChecker.Location = new System.Drawing.Point(9, 136);
            this.radioButtonCustomChecker.Name = "radioButtonCustomChecker";
            this.radioButtonCustomChecker.Size = new System.Drawing.Size(158, 17);
            this.radioButtonCustomChecker.TabIndex = 3;
            this.radioButtonCustomChecker.Text = "Проверяющая программа";
            this.radioButtonCustomChecker.UseVisualStyleBackColor = true;
            this.radioButtonCustomChecker.CheckedChanged += new System.EventHandler(this.radioButtonCustomChecker_CheckedChanged);
            // 
            // radioButtonInternalChecker
            // 
            this.radioButtonInternalChecker.AutoSize = true;
            this.radioButtonInternalChecker.Checked = true;
            this.radioButtonInternalChecker.Location = new System.Drawing.Point(9, 111);
            this.radioButtonInternalChecker.Name = "radioButtonInternalChecker";
            this.radioButtonInternalChecker.Size = new System.Drawing.Size(136, 17);
            this.radioButtonInternalChecker.TabIndex = 3;
            this.radioButtonInternalChecker.TabStop = true;
            this.radioButtonInternalChecker.Text = "Встроенная проверка";
            this.radioButtonInternalChecker.UseVisualStyleBackColor = true;
            this.radioButtonInternalChecker.CheckedChanged += new System.EventHandler(this.radioButtonInternalChecker_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Выходной файл";
            // 
            // textBoxOutputFileName
            // 
            this.textBoxOutputFileName.AllowDrop = true;
            this.textBoxOutputFileName.Location = new System.Drawing.Point(101, 62);
            this.textBoxOutputFileName.Name = "textBoxOutputFileName";
            this.textBoxOutputFileName.Size = new System.Drawing.Size(112, 20);
            this.textBoxOutputFileName.TabIndex = 1;
            this.textBoxOutputFileName.Click += new System.EventHandler(this.textBoxOutputFileName_Enter);
            this.textBoxOutputFileName.Enter += new System.EventHandler(this.textBoxOutputFileName_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Входной файл";
            // 
            // textBoxInputFileName
            // 
            this.textBoxInputFileName.AllowDrop = true;
            this.textBoxInputFileName.Location = new System.Drawing.Point(100, 33);
            this.textBoxInputFileName.Name = "textBoxInputFileName";
            this.textBoxInputFileName.Size = new System.Drawing.Size(112, 20);
            this.textBoxInputFileName.TabIndex = 0;
            this.textBoxInputFileName.Click += new System.EventHandler(this.textBoxInputFileName_Enter);
            this.textBoxInputFileName.TextChanged += new System.EventHandler(this.textBoxInputFileName_TextChanged);
            this.textBoxInputFileName.Enter += new System.EventHandler(this.textBoxInputFileName_Enter);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(850, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWorkDirToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openWorkDirToolStripMenuItem
            // 
            this.openWorkDirToolStripMenuItem.Name = "openWorkDirToolStripMenuItem";
            this.openWorkDirToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.openWorkDirToolStripMenuItem.Text = "Открыть рабочую папку";
            this.openWorkDirToolStripMenuItem.Click += new System.EventHandler(this.OpenWorkDirToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(405, 344);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 2;
            this.buttonRun.Text = "Начать";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Control;
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Location = new System.Drawing.Point(499, 27);
            this.output.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(351, 349);
            this.output.TabIndex = 4;
            this.output.TabStop = false;
            this.output.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.ReadOnlyChecked = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Выберите папку, в которой содержатся тесты к задаче";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Ошибка";
            // 
            // pictureChecker
            // 
            this.pictureChecker.Image = global::olympchecker_gui.Icons.Warning;
            this.pictureChecker.Location = new System.Drawing.Point(442, 135);
            this.pictureChecker.Name = "pictureChecker";
            this.pictureChecker.Size = new System.Drawing.Size(20, 20);
            this.pictureChecker.TabIndex = 8;
            this.pictureChecker.TabStop = false;
            this.toolTip.SetToolTip(this.pictureChecker, "Не введено имя папки");
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 380);
            this.Controls.Add(this.output);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OlympChecker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTestsFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSourceFile)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureChecker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox textBoxTimeLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTestsFolder;
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
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.PictureBox pictureTestsFolder;
        private System.Windows.Forms.PictureBox pictureSourceFile;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.PictureBox pictureTimeLimit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxUseStandartIO;
        private System.Windows.Forms.ToolStripMenuItem openWorkDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureChecker;
    }
}