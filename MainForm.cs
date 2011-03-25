using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

        private void textBoxSourceFile_TextChanged(object sender, EventArgs e)
        {
            pictureSourceCode.Image = (File.Exists(textBoxSourceFile.Text) ? Icons.OK : Icons.Error);
        }

        private void textBoxTestsFolder_TextChanged(object sender, EventArgs e)
        {
            pictureTestsFolder.Image = (Directory.Exists(textBoxTestsFolder.Text) ? Icons.OK : Icons.Error);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Width = 865;
            output.Clear();
            if (!CheckCorrect())
            {
                return;
            }
        }

        private bool CheckCorrect()
        {
            PrintLine("Проверка доступности файлов:");

            if (!CheckFile(textBoxSourceFile.Text, "Исходный код") ||
            !CheckFolder(textBoxTestsFolder.Text, "Папка тестов"))
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

        private void Print(string text, Color color)
        {
            output.SelectionColor = color;
            output.SelectedText = text;
        }

        private void Print(string text)
        {
            Print(text, Color.Black);
        }

        private void PrintLine(string text, Color color)
        {
            Print(text + "\n", color);
        }

        private void PrintLine(string text)
        {
            PrintLine(text, Color.Black);
        }
    }
}
