
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace olympchecker_gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Width = 500;
        }

        private void radioButtonCustomChecker_CheckedChanged(object sender, EventArgs e)
        {
            tbCustomCheckerSource.Enabled = rbCustomChecker.Checked;
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
            else if (CompilersManager.GetCompiler(Path.GetExtension(tbSourceFile.Text)) == null)
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
            else if (CompilersManager.GetCompiler(Path.GetExtension(text)) == null)
            {
                image = Icons.Error;
                tooltip = "Не найден компилятор для расширения \"" + Path.GetExtension(text) + "\"";
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
            picTimeLimit.Image = (Double.TryParse(tbTimeLimit.Text, out t) ? Icons.OK : Icons.Error);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Width = 860;
            output.Clear();

            if (String.IsNullOrEmpty(tbInputFileName.Text) || String.IsNullOrEmpty(tbOutputFileName.Text))
            {
                cbUseStandartIO.Checked = true;
            }

            if (!CheckCorrect())
            {
                return;
            }


            Tester.Parameters parameters = new Tester.Parameters();
            parameters.source = tbSourceFile.Text;
            parameters.testsDir = tbTestsFolder.Text;
            parameters.timeLimit = (int)(Double.Parse(tbTimeLimit.Text) * 1000);
            parameters.compiler = CompilersManager.GetCompiler(Path.GetExtension(tbSourceFile.Text));
            parameters.compilerChecker = CompilersManager.GetCompiler(Path.GetExtension(tbCustomCheckerSource.Text));
            parameters.checker = tbCustomCheckerSource.Text;
            parameters.internalCheck = rbInternalChecker.Checked;
            parameters.exactCheck = cbExactChecking.Checked;
            parameters.standartIO = cbUseStandartIO.Checked;
            parameters.inputFile = tbInputFileName.Text;
            parameters.outputFile = tbOutputFileName.Text;

            PrintLine();
            Tester.TestSolution(parameters);
        }

        private bool CheckCorrect()
        {
            PrintLine("Проверка доступности файлов:");

            if (!CheckFile(tbSourceFile.Text, "Исходный код") || !CheckFolder(tbTestsFolder.Text, "Папка тестов"))
            {
                return false;
            }

            foreach (string ext in new string[] { Path.GetExtension(tbSourceFile.Text), Path.GetExtension(tbCustomCheckerSource.Text) })
            {
                Compiler compiler = CompilersManager.GetCompiler(ext);
                if (compiler == null)
                {
                    PrintLine("Для расширения " + ext + " не найден соответствующий компилятор", Color.Red);
                    return false;
                }
                CheckFile(compiler.path, "Компилятор (" + compiler.name + ")");
            }

            return true;
        }

        private bool CheckFile(string file, string name)
        {
            Print(name + "...\t");
            if (File.Exists(file))
            {
                PrintLine("[OK]", Color.Green);
                return true;
            }
            else
            {
                PrintLine("[Не найдено]", Color.Red);
                return false;
            }
        }

        private bool CheckFolder(string folder, string name)
        {
            Print(name + "...\t");
            if (Directory.Exists(folder) && Directory.GetFiles(folder).Length != 0)
            {
                PrintLine("[OK]", Color.Green);
                return true;
            }
            else
            {
                PrintLine("[Не найдено]", Color.Red);
                return false;
            }
        }

        delegate void PrintToRichEdit(string text, Color color);
        public void Print(string text, Color color)
        {
            if (output.InvokeRequired)
            {
                PrintToRichEdit d = new PrintToRichEdit(Print);
                this.Invoke(d, new object[] { text, color });
            }
            else
            {
                output.Focus();
                output.SelectionStart = output.Text.Length;
                output.SelectionColor = color;
                output.AppendText(text);
                //output.ScrollToCaret();
            }
        }

        public void Print(string text)
        {
            Print(text, Color.Black);
        }

        public void PrintLine(string text, Color color)
        {
            Print(text + "\n", color);
        }

        public void PrintLine(string text = "")
        {
            PrintLine(text, Color.Black);
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
                Utils.StartProcess("explorer", "work");
            }
            else
            {
                Utils.StartProcess("explorer", ".");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStop.PerformClick();

            if (Properties.Settings.Default.AutoSave)
            {
                // Save all contols states

                Properties.MainFormState p = Properties.MainFormState.Default;

                p.sourceFile = tbSourceFile.Text;
                p.testsFolder = tbTestsFolder.Text;
                p.timeLimit = tbTimeLimit.Text;

                p.inputFile = tbInputFileName.Text;
                p.outputFile = tbOutputFileName.Text;
                p.useStandartIO = cbUseStandartIO.Checked;

                p.internalChecker = rbInternalChecker.Checked;
                p.exactChecking = cbExactChecking.Checked;

                p.customChecker = rbCustomChecker.Checked;
                p.customCheckerSource = tbCustomCheckerSource.Text;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoSave)
            {
                // Load all contols states

                Properties.MainFormState p = Properties.MainFormState.Default;

                tbSourceFile.Text = p.sourceFile;
                tbTestsFolder.Text = p.testsFolder;
                tbTimeLimit.Text = p.timeLimit;

                tbInputFileName.Text = p.inputFile;
                tbOutputFileName.Text = p.outputFile;
                cbUseStandartIO.Checked = p.useStandartIO;

                rbInternalChecker.Checked = p.internalChecker;
                cbExactChecking.Checked = p.exactChecking;

                rbCustomChecker.Checked = p.customChecker;
                tbCustomCheckerSource.Text = p.customCheckerSource;
            }
        }

    }
}
