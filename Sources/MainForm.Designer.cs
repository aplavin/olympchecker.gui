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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Подготовка", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Тестирование", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Результаты", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAutodetect = new System.Windows.Forms.Label();
            this.picProblemFolder = new System.Windows.Forms.PictureBox();
            this.btnClearProblemFolder = new System.Windows.Forms.Button();
            this.tbProblemFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picSourceFile = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.picTimeLimit = new System.Windows.Forms.PictureBox();
            this.picTestsFolder = new System.Windows.Forms.PictureBox();
            this.tbTimeLimit = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTestsFolder = new System.Windows.Forms.TextBox();
            this.picChecker = new System.Windows.Forms.PictureBox();
            this.cbUseStandartIO = new System.Windows.Forms.CheckBox();
            this.tbCustomCheckerSource = new System.Windows.Forms.TextBox();
            this.rbCustomChecker = new System.Windows.Forms.RadioButton();
            this.rbInternalChecker = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOutputFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInputFileName = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkDirItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUpdatesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRun = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.btnSwitchSize = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProblemFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestsFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecker)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAutodetect);
            this.groupBox2.Controls.Add(this.picProblemFolder);
            this.groupBox2.Controls.Add(this.btnClearProblemFolder);
            this.groupBox2.Controls.Add(this.tbProblemFolder);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.picSourceFile);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbSourceFile);
            this.groupBox2.Controls.Add(this.picTimeLimit);
            this.groupBox2.Controls.Add(this.picTestsFolder);
            this.groupBox2.Controls.Add(this.tbTimeLimit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbTestsFolder);
            this.groupBox2.Controls.Add(this.picChecker);
            this.groupBox2.Controls.Add(this.cbUseStandartIO);
            this.groupBox2.Controls.Add(this.tbCustomCheckerSource);
            this.groupBox2.Controls.Add(this.rbCustomChecker);
            this.groupBox2.Controls.Add(this.rbInternalChecker);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbOutputFileName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbInputFileName);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задача";
            // 
            // lblAutodetect
            // 
            this.lblAutodetect.Location = new System.Drawing.Point(6, 229);
            this.lblAutodetect.Name = "lblAutodetect";
            this.lblAutodetect.Size = new System.Drawing.Size(456, 72);
            this.lblAutodetect.TabIndex = 21;
            this.lblAutodetect.Text = "Местоположение тестов и способ проверки ответа определяются автоматически по инфо" +
                "рмации в папке задачи.";
            this.lblAutodetect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAutodetect.Visible = false;
            // 
            // picProblemFolder
            // 
            this.picProblemFolder.Location = new System.Drawing.Point(442, 194);
            this.picProblemFolder.Name = "picProblemFolder";
            this.picProblemFolder.Size = new System.Drawing.Size(20, 20);
            this.picProblemFolder.TabIndex = 22;
            this.picProblemFolder.TabStop = false;
            // 
            // btnClearProblemFolder
            // 
            this.btnClearProblemFolder.Image = global::olympchecker_gui.Icons.Clear;
            this.btnClearProblemFolder.Location = new System.Drawing.Point(412, 192);
            this.btnClearProblemFolder.Name = "btnClearProblemFolder";
            this.btnClearProblemFolder.Size = new System.Drawing.Size(24, 23);
            this.btnClearProblemFolder.TabIndex = 20;
            this.btnClearProblemFolder.UseVisualStyleBackColor = true;
            this.btnClearProblemFolder.Click += new System.EventHandler(this.btnClearProblemFolder_Click);
            // 
            // tbProblemFolder
            // 
            this.tbProblemFolder.AllowDrop = true;
            this.tbProblemFolder.Location = new System.Drawing.Point(97, 194);
            this.tbProblemFolder.Name = "tbProblemFolder";
            this.tbProblemFolder.Size = new System.Drawing.Size(311, 20);
            this.tbProblemFolder.TabIndex = 19;
            this.tbProblemFolder.TextChanged += new System.EventHandler(this.tbProblemFolder_TextChanged);
            this.tbProblemFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbProblemFolder_DragDrop);
            this.tbProblemFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbProblemFolder_DragEnter);
            this.tbProblemFolder.DoubleClick += new System.EventHandler(this.tbProblemFolder_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Папка задачи";
            // 
            // picSourceFile
            // 
            this.picSourceFile.Image = global::olympchecker_gui.Icons.Warning;
            this.picSourceFile.Location = new System.Drawing.Point(442, 19);
            this.picSourceFile.Name = "picSourceFile";
            this.picSourceFile.Size = new System.Drawing.Size(20, 20);
            this.picSourceFile.TabIndex = 17;
            this.picSourceFile.TabStop = false;
            this.toolTip.SetToolTip(this.picSourceFile, "Не введено имя файла");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Файл решения";
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.AllowDrop = true;
            this.tbSourceFile.Location = new System.Drawing.Point(97, 19);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(339, 20);
            this.tbSourceFile.TabIndex = 15;
            this.tbSourceFile.TextChanged += new System.EventHandler(this.textBoxSourceFile_TextChanged);
            this.tbSourceFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFile_DragDrop);
            this.tbSourceFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxSourceFile_DragEnter);
            this.tbSourceFile.DoubleClick += new System.EventHandler(this.textBoxSourceFile_DoubleClick);
            // 
            // picTimeLimit
            // 
            this.picTimeLimit.Image = global::olympchecker_gui.Icons.OK;
            this.picTimeLimit.Location = new System.Drawing.Point(241, 50);
            this.picTimeLimit.Name = "picTimeLimit";
            this.picTimeLimit.Size = new System.Drawing.Size(20, 20);
            this.picTimeLimit.TabIndex = 14;
            this.picTimeLimit.TabStop = false;
            // 
            // picTestsFolder
            // 
            this.picTestsFolder.Image = global::olympchecker_gui.Icons.Warning;
            this.picTestsFolder.Location = new System.Drawing.Point(442, 229);
            this.picTestsFolder.Name = "picTestsFolder";
            this.picTestsFolder.Size = new System.Drawing.Size(20, 20);
            this.picTestsFolder.TabIndex = 13;
            this.picTestsFolder.TabStop = false;
            this.toolTip.SetToolTip(this.picTestsFolder, "Не введено имя папки");
            // 
            // tbTimeLimit
            // 
            this.tbTimeLimit.HidePromptOnLeave = true;
            this.tbTimeLimit.Location = new System.Drawing.Point(174, 50);
            this.tbTimeLimit.Mask = "0.9";
            this.tbTimeLimit.Name = "tbTimeLimit";
            this.tbTimeLimit.Size = new System.Drawing.Size(61, 20);
            this.tbTimeLimit.TabIndex = 10;
            this.tbTimeLimit.Text = "10";
            this.tbTimeLimit.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.tbTimeLimit.TextChanged += new System.EventHandler(this.textBoxTimeLimit_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ограничение по времени (с)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Папка тестов";
            // 
            // tbTestsFolder
            // 
            this.tbTestsFolder.AllowDrop = true;
            this.tbTestsFolder.Location = new System.Drawing.Point(97, 229);
            this.tbTestsFolder.Name = "tbTestsFolder";
            this.tbTestsFolder.Size = new System.Drawing.Size(339, 20);
            this.tbTestsFolder.TabIndex = 9;
            this.tbTestsFolder.TextChanged += new System.EventHandler(this.textBoxTestsFolder_TextChanged);
            this.tbTestsFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxTestsFolder_DragDrop);
            this.tbTestsFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxTestsFolder_DragEnter);
            this.tbTestsFolder.DoubleClick += new System.EventHandler(this.textBoxTestsFolder_DoubleClick);
            // 
            // picChecker
            // 
            this.picChecker.Image = global::olympchecker_gui.Icons.Warning;
            this.picChecker.Location = new System.Drawing.Point(442, 281);
            this.picChecker.Name = "picChecker";
            this.picChecker.Size = new System.Drawing.Size(20, 20);
            this.picChecker.TabIndex = 8;
            this.picChecker.TabStop = false;
            this.toolTip.SetToolTip(this.picChecker, "Не введено имя папки");
            this.picChecker.Visible = false;
            // 
            // cbUseStandartIO
            // 
            this.cbUseStandartIO.AutoSize = true;
            this.cbUseStandartIO.Location = new System.Drawing.Point(9, 141);
            this.cbUseStandartIO.Name = "cbUseStandartIO";
            this.cbUseStandartIO.Size = new System.Drawing.Size(266, 17);
            this.cbUseStandartIO.TabIndex = 2;
            this.cbUseStandartIO.Text = "Использовать также стандартный ввод/вывод";
            this.cbUseStandartIO.UseVisualStyleBackColor = true;
            // 
            // tbCustomCheckerSource
            // 
            this.tbCustomCheckerSource.AllowDrop = true;
            this.tbCustomCheckerSource.Enabled = false;
            this.tbCustomCheckerSource.Location = new System.Drawing.Point(173, 281);
            this.tbCustomCheckerSource.Name = "tbCustomCheckerSource";
            this.tbCustomCheckerSource.Size = new System.Drawing.Size(263, 20);
            this.tbCustomCheckerSource.TabIndex = 5;
            this.tbCustomCheckerSource.TextChanged += new System.EventHandler(this.textBoxCustomCheckerSource_TextChanged);
            this.tbCustomCheckerSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCustomCheckerSource_DragDrop);
            this.tbCustomCheckerSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCustomCheckerSource_DragEnter);
            this.tbCustomCheckerSource.DoubleClick += new System.EventHandler(this.textBoxCustomCheckerSource_DoubleClick);
            // 
            // rbCustomChecker
            // 
            this.rbCustomChecker.AutoSize = true;
            this.rbCustomChecker.Location = new System.Drawing.Point(9, 282);
            this.rbCustomChecker.Name = "rbCustomChecker";
            this.rbCustomChecker.Size = new System.Drawing.Size(158, 17);
            this.rbCustomChecker.TabIndex = 3;
            this.rbCustomChecker.Text = "Проверяющая программа";
            this.rbCustomChecker.UseVisualStyleBackColor = true;
            this.rbCustomChecker.CheckedChanged += new System.EventHandler(this.radioButtonCustomChecker_CheckedChanged);
            // 
            // rbInternalChecker
            // 
            this.rbInternalChecker.AutoSize = true;
            this.rbInternalChecker.Checked = true;
            this.rbInternalChecker.Location = new System.Drawing.Point(9, 257);
            this.rbInternalChecker.Name = "rbInternalChecker";
            this.rbInternalChecker.Size = new System.Drawing.Size(136, 17);
            this.rbInternalChecker.TabIndex = 3;
            this.rbInternalChecker.TabStop = true;
            this.rbInternalChecker.Text = "Встроенная проверка";
            this.rbInternalChecker.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Выходной файл";
            // 
            // tbOutputFileName
            // 
            this.tbOutputFileName.AllowDrop = true;
            this.tbOutputFileName.Location = new System.Drawing.Point(97, 106);
            this.tbOutputFileName.Name = "tbOutputFileName";
            this.tbOutputFileName.Size = new System.Drawing.Size(112, 20);
            this.tbOutputFileName.TabIndex = 1;
            this.tbOutputFileName.Click += new System.EventHandler(this.textBoxOutputFileName_Enter);
            this.tbOutputFileName.Enter += new System.EventHandler(this.textBoxOutputFileName_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Входной файл";
            // 
            // tbInputFileName
            // 
            this.tbInputFileName.AllowDrop = true;
            this.tbInputFileName.Location = new System.Drawing.Point(97, 80);
            this.tbInputFileName.Name = "tbInputFileName";
            this.tbInputFileName.Size = new System.Drawing.Size(112, 20);
            this.tbInputFileName.TabIndex = 0;
            this.tbInputFileName.Click += new System.EventHandler(this.textBoxInputFileName_Enter);
            this.tbInputFileName.TextChanged += new System.EventHandler(this.textBoxInputFileName_TextChanged);
            this.tbInputFileName.Enter += new System.EventHandler(this.textBoxInputFileName_Enter);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItem,
            this.helpItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(895, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileItem
            // 
            this.fileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWorkDirItem,
            this.compilersItem,
            this.settingsItem,
            this.toolStripSeparator1,
            this.exitItem});
            this.fileItem.Name = "fileItem";
            this.fileItem.Size = new System.Drawing.Size(48, 20);
            this.fileItem.Text = "Файл";
            // 
            // openWorkDirItem
            // 
            this.openWorkDirItem.Name = "openWorkDirItem";
            this.openWorkDirItem.Size = new System.Drawing.Size(209, 22);
            this.openWorkDirItem.Text = "Открыть рабочую папку";
            this.openWorkDirItem.Click += new System.EventHandler(this.OpenWorkDirItem_Click);
            // 
            // compilersItem
            // 
            this.compilersItem.Name = "compilersItem";
            this.compilersItem.Size = new System.Drawing.Size(209, 22);
            this.compilersItem.Text = "Компиляторы";
            this.compilersItem.Click += new System.EventHandler(this.compilersItem_Click);
            // 
            // settingsItem
            // 
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.Size = new System.Drawing.Size(209, 22);
            this.settingsItem.Text = "Настройки";
            this.settingsItem.Click += new System.EventHandler(this.settingsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(209, 22);
            this.exitItem.Text = "Выход";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // helpItem
            // 
            this.helpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHelpItem,
            this.checkUpdatesItem,
            this.aboutItem});
            this.helpItem.Name = "helpItem";
            this.helpItem.Size = new System.Drawing.Size(68, 20);
            this.helpItem.Text = "Помощь";
            // 
            // openHelpItem
            // 
            this.openHelpItem.Name = "openHelpItem";
            this.openHelpItem.Size = new System.Drawing.Size(199, 22);
            this.openHelpItem.Text = "Открыть помощь";
            this.openHelpItem.Click += new System.EventHandler(this.openHelpItem_Click);
            // 
            // checkUpdatesItem
            // 
            this.checkUpdatesItem.Name = "checkUpdatesItem";
            this.checkUpdatesItem.Size = new System.Drawing.Size(199, 22);
            this.checkUpdatesItem.Text = "Проверка обновлений";
            this.checkUpdatesItem.Click += new System.EventHandler(this.checkUpdatesItem_Click);
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(199, 22);
            this.aboutItem.Text = "О программе";
            this.aboutItem.Click += new System.EventHandler(this.aboutItem_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(405, 344);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Начать";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.RestoreDirectory = true;
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
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Location = new System.Drawing.Point(405, 344);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Остановить";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 376);
            this.progressBar.MarqueeAnimationSpeed = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(468, 23);
            this.progressBar.TabIndex = 5;
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.SystemColors.Control;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.FullRowSelect = true;
            listViewGroup1.Header = "Подготовка";
            listViewGroup1.Name = "groupPreparation";
            listViewGroup2.Header = "Тестирование";
            listViewGroup2.Name = "groupTesting";
            listViewGroup3.Header = "Результаты";
            listViewGroup3.Name = "groupResults";
            this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(495, 27);
            this.listView.Name = "listView";
            this.listView.ShowItemToolTips = true;
            this.listView.Size = new System.Drawing.Size(401, 457);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Событие";
            this.columnHeader1.Width = 270;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Результат";
            this.columnHeader2.Width = 113;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Location = new System.Drawing.Point(12, 405);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox.Size = new System.Drawing.Size(468, 79);
            this.richTextBox.TabIndex = 7;
            this.richTextBox.Text = "";
            // 
            // btnSwitchSize
            // 
            this.btnSwitchSize.Location = new System.Drawing.Point(12, 344);
            this.btnSwitchSize.Name = "btnSwitchSize";
            this.btnSwitchSize.Size = new System.Drawing.Size(23, 23);
            this.btnSwitchSize.TabIndex = 8;
            this.btnSwitchSize.Text = "  &s";
            this.btnSwitchSize.UseVisualStyleBackColor = true;
            this.btnSwitchSize.Click += new System.EventHandler(this.btnSwitchSize_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(895, 487);
            this.Controls.Add(this.btnSwitchSize);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OlympChecker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProblemFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTestsFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecker)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCustomChecker;
        private System.Windows.Forms.RadioButton rbInternalChecker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbOutputFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbInputFileName;
        private System.Windows.Forms.TextBox tbCustomCheckerSource;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem fileItem;
        private System.Windows.Forms.ToolStripMenuItem compilersItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.CheckBox cbUseStandartIO;
        private System.Windows.Forms.ToolStripMenuItem openWorkDirItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox picChecker;
        private System.Windows.Forms.ToolStripMenuItem helpItem;
        private System.Windows.Forms.ToolStripMenuItem openHelpItem;
        private System.Windows.Forms.ToolStripMenuItem checkUpdatesItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem settingsItem;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button btnSwitchSize;
        private System.Windows.Forms.PictureBox picSourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.PictureBox picTimeLimit;
        private System.Windows.Forms.PictureBox picTestsFolder;
        private System.Windows.Forms.MaskedTextBox tbTimeLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTestsFolder;
        private System.Windows.Forms.Button btnClearProblemFolder;
        private System.Windows.Forms.TextBox tbProblemFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAutodetect;
        private System.Windows.Forms.PictureBox picProblemFolder;
    }
}