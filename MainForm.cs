
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;

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
            textBoxCustomCheckerSource.Enabled = radioButtonCustomChecker.Checked;
        }

        private void radioButtonInternalChecker_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxExactChecking.Enabled = radioButtonInternalChecker.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        #region textBoxSourceFile
        private void textBoxSourceFile_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSourceFile.Text;
            Image image = null;
            string tooltip = null;
            if (text == String.Empty)
            {
                image = Icons.Warning;
                tooltip = "Не введено имя файла";
            }
            else if (!File.Exists(text))
            {
                image = Icons.Error;
                tooltip = "Файл не существует";
            }
            else if (Settings.GetCompiler(Path.GetExtension(textBoxSourceFile.Text)) == null)
            {
                image = Icons.Error;
                tooltip = "Не найден компилятор для расширения \"" + Path.GetExtension(textBoxSourceFile.Text) + "\"";
            }
            else
            {
                image = Icons.OK;

                string[] filesIO = Utils.GuessFileNames(textBoxSourceFile.Text);
                textBoxInputFileName.Text = filesIO[0];
                textBoxOutputFileName.Text = filesIO[1];
            }

            pictureSourceFile.Image = image;
            toolTip.SetToolTip(pictureSourceFile, tooltip);
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
                textBoxSourceFile.Text = filePaths[0];
                textBoxSourceFile.SelectionStart = textBoxSourceFile.Text.Length;
            }
        }

        private void textBoxSourceFile_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceFile.Text = openFileDialog.FileName;
                textBoxSourceFile.SelectionStart = textBoxSourceFile.Text.Length;
            }
        }
        #endregion

        #region textBoxTestsFolder
        private void textBoxTestsFolder_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxTestsFolder.Text;
            Image image = null;
            string tooltip = null;
            if (text == String.Empty)
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

            pictureTestsFolder.Image = image;
            toolTip.SetToolTip(pictureTestsFolder, tooltip);
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
                textBoxTestsFolder.Text = filePaths[0];
                textBoxTestsFolder.SelectionStart = textBoxTestsFolder.Text.Length;
            }
        }

        private void textBoxTestsFolder_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxTestsFolder.Text = folderBrowserDialog.SelectedPath;
                textBoxTestsFolder.SelectionStart = textBoxTestsFolder.Text.Length;
            }
        }
        #endregion

        private void textBoxTimeLimit_TextChanged(object sender, EventArgs e)
        {
            double t;
            pictureTimeLimit.Image = (Double.TryParse(textBoxTimeLimit.Text, out t) ? Icons.OK : Icons.Error);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Width = 860;
            output.Clear();

            if (textBoxInputFileName.Text == String.Empty || textBoxOutputFileName.Text == String.Empty)
            {
                checkBoxUseStandartIO.Checked = true;
            }

            if (!CheckCorrect())
            {
                return;
            }

            Compiler compiler = Settings.GetCompiler(Path.GetExtension(textBoxSourceFile.Text));

            Tester.Parameters parameters = new Tester.Parameters();
            parameters.source = textBoxSourceFile.Text;
            parameters.testsDir = textBoxTestsFolder.Text;
            parameters.timeLimit = (int)(Double.Parse(textBoxTimeLimit.Text) * 1000);
            parameters.compiler = compiler;
            parameters.exactChecking = checkBoxExactChecking.Checked;
            parameters.standartIO = checkBoxUseStandartIO.Checked;
            parameters.inputFile = textBoxInputFileName.Text;
            parameters.outputFile = textBoxOutputFileName.Text;

            PrintLine();
            Tester.TestSolution(parameters);
        }

        private bool CheckCorrect()
        {
            PrintLine("Проверка доступности файлов:");

            if (!CheckFile(textBoxSourceFile.Text, "Исходный код") || !CheckFolder(textBoxTestsFolder.Text, "Папка тестов"))
            {
                return false;
            }

            Compiler compiler = Settings.GetCompiler(Path.GetExtension(textBoxSourceFile.Text));
            if (compiler == null)
            {
                PrintLine("Для расширения " + Path.GetExtension(textBoxSourceFile.Text) + " не найден соответствующий компилятор", Color.Red);
                return false;
            }
            CheckFile(compiler.path, "Компилятор (" + compiler.name + ")");

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
            textBoxInputFileName.SelectAll();
        }

        private void textBoxOutputFileName_Enter(object sender, EventArgs e)
        {
            textBoxOutputFileName.SelectAll();
        }

        private void textBoxInputFileName_TextChanged(object sender, EventArgs e)
        {
            string inputFile = textBoxInputFileName.Text;
            string outputFile = textBoxOutputFileName.Text;
            if (inputFile.EndsWith(".in"))
            {
                outputFile = inputFile.Substring(0, inputFile.Length - 3) + ".out";
            }
            else if (inputFile.StartsWith("in"))
            {
                outputFile = "out" + inputFile.Substring(2);
            }
            textBoxOutputFileName.Text = outputFile;
        }

        private void OpenWorkDirToolStripMenuItem_Click(object sender, EventArgs e)
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

    }
}
