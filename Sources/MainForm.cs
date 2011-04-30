
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace olympchecker_gui
{
    public partial class MainForm : Form
    {
        private readonly Size collapsed = new Size(500, 405);
        private readonly Size expanded = new Size();

        public MainForm()
        {
            InitializeComponent();

            expanded = this.Size;
            this.Size = collapsed;
        }

        private void radioButtonCustomChecker_CheckedChanged(object sender, EventArgs e)
        {
            tbCustomCheckerSource.Enabled = rbCustomChecker.Checked;
            picChecker.Visible = rbCustomChecker.Checked;
        }

        private void radioButtonInternalChecker_CheckedChanged(object sender, EventArgs e)
        {
            cbExactChecking.Enabled = rbInternalChecker.Checked;
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void compilersItem_Click(object sender, EventArgs e)
        {
            new CompilersForm().ShowDialog();
        }

        private void settingsItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        #region textBoxSourceFile
        private void textBoxSourceFile_TextChanged(object sender, EventArgs e)
        {
            string text = tbSourceFile.Text;
            string ext = Path.GetExtension(text);

            Image image = null;
            string tooltip = null;
            if (String.IsNullOrEmpty(text))
            {
                image = Icons.Warning;
                tooltip = "Не введено имя файла";
            }
            else if (!File.Exists(text))
            {
                image = Icons.Error;
                tooltip = "Файл не существует";
            }
            else if (!Utils.isExecutable(text) && CompilersManager.GetCompiler(ext) == null)
            {
                image = Icons.Error;
                tooltip = "Не найден компилятор для расширения \"" + Path.GetExtension(tbSourceFile.Text) + "\"";
            }
            else
            {
                image = Icons.OK;

                string[] filesIO = Utils.GuessFileNames(tbSourceFile.Text);
                tbInputFileName.Text = filesIO[0];
                tbOutputFileName.Text = filesIO[1];
            }

            picSourceFile.Image = image;
            toolTip.SetToolTip(picSourceFile, tooltip);
        }

        private void textBoxSourceFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxSourceFile_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                tbSourceFile.Text = filePaths[0];
                tbSourceFile.SelectionStart = tbSourceFile.Text.Length;
            }
        }

        private void textBoxSourceFile_DoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSourceFile.Text))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(tbSourceFile.Text);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbSourceFile.Text = openFileDialog.FileName;
                tbSourceFile.SelectionStart = tbSourceFile.Text.Length;
            }
        }
        #endregion

        #region textBoxTestsFolder
        private void textBoxTestsFolder_TextChanged(object sender, EventArgs e)
        {
            string text = tbTestsFolder.Text;
            Image image = null;
            string tooltip = null;
            if (String.IsNullOrEmpty(text))
            {
                image = Icons.Warning;
                tooltip = "Не введено имя папки";
            }
            else if (!Directory.Exists(text))
            {
                image = Icons.Error;
                tooltip = "Папка не существует";
            }
            else if (Directory.GetFiles(text).Length == 0)
            {
                image = Icons.Error;
                tooltip = "Папка пуста";
            }
            else if (!text.Contains("tests"))
            {
                image = Icons.Warning;
                tooltip = "Скорее всего, выбрана неверная папка";
            }
            else
            {
                image = Icons.OK;
            }

            picTestsFolder.Image = image;
            toolTip.SetToolTip(picTestsFolder, tooltip);
        }

        private void textBoxTestsFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxTestsFolder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                tbTestsFolder.Text = filePaths[0];
                tbTestsFolder.SelectionStart = tbTestsFolder.Text.Length;
            }
        }

        private void textBoxTestsFolder_DoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbTestsFolder.Text))
            {
                folderBrowserDialog.SelectedPath = tbTestsFolder.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbTestsFolder.Text = folderBrowserDialog.SelectedPath;
                tbTestsFolder.SelectionStart = tbTestsFolder.Text.Length;
            }
        }
        #endregion

        #region textBoxCustomCheckerSource
        private void textBoxCustomCheckerSource_TextChanged(object sender, EventArgs e)
        {
            string text = tbCustomCheckerSource.Text;
            string ext = Path.GetExtension(text);

            Image image = null;
            string tooltip = null;
            if (String.IsNullOrEmpty(text))
            {
                image = Icons.Warning;
                tooltip = "Не введено имя файла";
            }
            else if (!File.Exists(text))
            {
                image = Icons.Error;
                tooltip = "Файл не существует";
            }
            else if (!Utils.isExecutable(text) && CompilersManager.GetCompiler(ext) == null)
            {
                image = Icons.Error;
                tooltip = "Не найден компилятор для расширения \"" + ext + "\"";
            }
            else
            {
                image = Icons.OK;
            }

            picChecker.Image = image;
            toolTip.SetToolTip(picChecker, tooltip);
        }

        private void textBoxCustomCheckerSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxCustomCheckerSource_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                tbCustomCheckerSource.Text = filePaths[0];
                tbCustomCheckerSource.SelectionStart = tbCustomCheckerSource.Text.Length;
            }
        }

        private void textBoxCustomCheckerSource_DoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCustomCheckerSource.Text))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(tbCustomCheckerSource.Text);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbCustomCheckerSource.Text = openFileDialog.FileName;
                tbCustomCheckerSource.SelectionStart = tbCustomCheckerSource.Text.Length;
            }
        }
        #endregion

        private void textBoxTimeLimit_TextChanged(object sender, EventArgs e)
        {
            double t;

            Image image = null;
            string tooltip = null;
            if (!Double.TryParse(tbTimeLimit.Text, out t))
            {
                image = Icons.Error;
                tooltip = "Неправильный формат ввода";
            }
            else
            {
                image = Icons.OK;
            }

            picTimeLimit.Image = image;
            toolTip.SetToolTip(picTimeLimit, tooltip);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.Size = expanded;

            listView.Items.Clear();

            if (String.IsNullOrEmpty(tbInputFileName.Text) || String.IsNullOrEmpty(tbOutputFileName.Text))
            {
                cbUseStandartIO.Checked = true;
            }

            if (!CheckCorrect())
            {
                return;
            }


            Tester.Parameters parameters = new Tester.Parameters()
            {
                compiler = CompilersManager.GetCompiler(Path.GetExtension(tbSourceFile.Text)),
                compilerChecker = CompilersManager.GetCompiler(Path.GetExtension(tbCustomCheckerSource.Text)),

                source = tbSourceFile.Text,
                testsDir = tbTestsFolder.Text,
                timeLimit = (int)(Double.Parse(tbTimeLimit.Text) * 1000),

                inputFile = tbInputFileName.Text,
                outputFile = tbOutputFileName.Text,
                standartIO = cbUseStandartIO.Checked,

                internalCheck = rbInternalChecker.Checked,
                exactCheck = cbExactChecking.Checked,
                checker = tbCustomCheckerSource.Text,

                progressNotifier = UpdateProgress,
            };

            Tester.TestSolution(parameters);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Tester.StopTesting();
        }

        private bool CheckCorrect()
        {
            Utils.AddPreparation("Проверка доступности файлов:");

            if (!Utils.CheckFile(tbSourceFile.Text, "Файл решения") || !Utils.CheckFolder(tbTestsFolder.Text, "Папка тестов")
                || (rbCustomChecker.Checked && !Utils.CheckFile(tbCustomCheckerSource.Text, "Проверяющая программа")))
            {
                return false;
            }

            List<string> extensions = new List<string>();
            if (!Utils.isExecutable(tbSourceFile.Text))
            {
                extensions.Add(Path.GetExtension(tbSourceFile.Text));
            }
            if (rbCustomChecker.Checked && !Utils.isExecutable(tbCustomCheckerSource.Text))
            {
                extensions.Add(Path.GetExtension(tbCustomCheckerSource.Text));
            }

            foreach (string ext in extensions.Distinct())
            {
                Compiler compiler = CompilersManager.GetCompiler(ext);
                if (compiler == null)
                {
                    Utils.AddPreparation(String.Format("Компилятор для расширения \"{0}\"...", ext));
                    Utils.AddRes("[Не найден]", Color.Red, String.Format("В настройках не указан компилятор для расширения \"{0}\"", ext));
                    return false;
                }
                Utils.CheckFile(compiler.path, "Компилятор " + compiler.name);
            }

            return true;
        }

        delegate void AddToListView(string text, int group, Color color);
        public void AddItem(string text, int group, Color color)
        {
            try
            {
                if (listView.InvokeRequired)
                {
                    AddToListView d = new AddToListView(AddItem);
                    this.Invoke(d, new object[] { text, group, color });
                }
                else
                {
                    var item = new ListViewItem(text, listView.Groups[group])
                    {
                        ForeColor = color,
                        UseItemStyleForSubItems = false,
                    };
                    listView.Items.Add(item);
                    item.EnsureVisible();
                }
            }
            catch
            {
                // happens in normal situation: form is closed, but a thread tries to print smth
            }
        }

        delegate void AddResultToListView(string text, Color color, string tooltip);
        public void AddResult(string text, Color color, string tooltip)
        {
            try
            {
                if (listView.InvokeRequired)
                {
                    AddResultToListView d = new AddResultToListView(AddResult);
                    this.Invoke(d, new object[] { text, color, tooltip });
                }
                else
                {
                    ListViewItem item = listView.Items[listView.Items.Count - 1];
                    if (item.SubItems.Count > 1)
                    {
                        // another result is already added to this item
                        return;
                    }
                    item.ToolTipText = tooltip;
                    item.SubItems.Add(text, color, listView.BackColor, listView.Font);
                }
            }
            catch
            {
                // happens in normal situation: form is closed, but a thread tries to print smth
            }
        }

        private void textBoxInputFileName_Enter(object sender, EventArgs e)
        {
            tbInputFileName.SelectAll();
        }

        private void textBoxOutputFileName_Enter(object sender, EventArgs e)
        {
            tbOutputFileName.SelectAll();
        }

        private void textBoxInputFileName_TextChanged(object sender, EventArgs e)
        {
            string inputFile = tbInputFileName.Text;
            string outputFile = tbOutputFileName.Text;
            if (inputFile.EndsWith(".in"))
            {
                outputFile = inputFile.Substring(0, inputFile.Length - 3) + ".out";
            }
            else if (inputFile.StartsWith("in"))
            {
                outputFile = "out" + inputFile.Substring(2);
            }
            tbOutputFileName.Text = outputFile;
        }

        private void OpenWorkDirItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("work"))
            {
                Process.Start("work");
            }
            else
            {
                Process.Start(".");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //btnStop.PerformClick();

            if (SettingsManager.AutoSaveState)
            {
                // Save all contols states
                var list = new List<Pair<string, object>>();

                var controlsQ = new Queue<Control>();
                foreach (Control control in Controls)
                {
                    controlsQ.Enqueue(control);
                }

                while (controlsQ.Count > 0)
                {
                    Control control = controlsQ.Dequeue();

                    if (control is TextBox)
                    {
                        list.Add(new Pair<string, object>(control.Name, control.Text));
                    }
                    else if (control is CheckBox || control is RadioButton)
                    {
                        list.Add(new Pair<string, object>(control.Name,
                            (bool)control.GetType().GetProperty("Checked").GetValue(control, null)
                            ));
                    }

                    foreach (Control c in control.Controls)
                    {
                        controlsQ.Enqueue(c);
                    }
                }

                list.Sort();

                SettingsManager.MainFormState = list;
                SettingsManager.Save();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (SettingsManager.AutoSaveState && SettingsManager.MainFormState.Count > 0)
            {
                foreach (var pair in SettingsManager.MainFormState)
                {
                    string controlName = pair.First;
                    object value = pair.Second;

                    Control control = (Control)this.GetType().GetField(controlName, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);

                    if (value is string)
                    {
                        control.Text = value as string;
                    }
                    else if (value is bool)
                    {
                        control.GetType().GetProperty("Checked").SetValue(control, (bool)value, null);
                    }
                }
            }
        }

        delegate void UpdatePB(int progress, int max);
        private void UpdateProgress(int progress, int max)
        {
            if (progressBar.InvokeRequired)
            {
                this.Invoke(new UpdatePB(UpdateProgress), new object[] { progress, max });
            }
            else
            {
                progressBar.Maximum = max;
                progressBar.Value = progress;
            }
        }

        private void openHelpItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://code.google.com/p/olympchecker/wiki/Help");
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void checkUpdatesItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://code.google.com/p/olympchecker/wiki/Downloads");
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = listView.SelectedItems[0];
                string res = null;
                if (item.SubItems.Count > 1)
                {
                    richTextBox.ForeColor = item.SubItems[1].ForeColor;
                    res = item.SubItems[1].Text;
                }
                richTextBox.Text = (String.IsNullOrEmpty(item.ToolTipText) ? "" : String.Format("Дополнительная информация о {0} {1}:\n{2}", item.Text, res, item.ToolTipText));
            }
        }

        private void btnSwitchSize_Click(object sender, EventArgs e)
        {
            this.Size = (this.Size == collapsed ? expanded : collapsed);
        }

    }
}
