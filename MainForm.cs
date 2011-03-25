﻿
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
            Width = 510;
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
            pictureSourceCode.Image = (File.Exists(textBoxSourceFile.Text) ? Icons.OK : Icons.Error);
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
            }
        }

        private void textBoxSourceFile_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceFile.Text = openFileDialog.FileName;
            }
        }
        #endregion

        #region textBoxTestsFolder
        private void textBoxTestsFolder_TextChanged(object sender, EventArgs e)
        {
            pictureTestsFolder.Image = (Directory.Exists(textBoxTestsFolder.Text) ? Icons.OK : Icons.Error);
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
            }
        }

        private void textBoxTestsFolder_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxTestsFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
        #endregion

        private void textBoxTimeLimit_TextChanged(object sender, EventArgs e)
        {
            pictureTimeLimit.Image = (textBoxTimeLimit.MaskCompleted ?  Icons.OK : Icons.Error);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Width = 865;
            output.Clear();
            if (!CheckCorrect())
            {
                return;
            }

            Compiler compiler = Settings.GetCompiler(Path.GetExtension(textBoxSourceFile.Text));
            Tester.TestSolution(textBoxSourceFile.Text, textBoxTestsFolder.Text, 1000, compiler);
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
            if (Directory.Exists(folder))
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

        public void PrintLine(string text)
        {
            PrintLine(text, Color.Black);
        }

        // TODO IN A NORMAL WAY!!!
        public string getInputFileName()
        {
            return textBoxInputFileName.Text;
        }

        public string getOutputFileName()
        {
            return textBoxOutputFileName.Text;
        }

        public bool getCheckerExact()
        {
            return checkBoxExactChecking.Checked;
        }

    }
}
