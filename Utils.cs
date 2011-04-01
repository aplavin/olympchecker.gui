
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace olympchecker_gui
{
    static class Utils
    {

        public static Process StartProcess(string fileName, string args = "", bool oneProcessor = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = args;
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.PriorityClass = ProcessPriorityClass.High;
            if (oneProcessor)
            {
                process.ProcessorAffinity = new IntPtr(1 << 0);
            }
            return process;
        }

        public static bool CompareFiles(string answerFile, string outFile, bool exact)
        {
            Utils.WaitForFile(answerFile);
            StreamReader answerReader = new StreamReader(answerFile);

            Utils.WaitForFile(outFile);
            StreamReader outReader = new StreamReader(outFile);

            bool result = true;
            while (!answerReader.EndOfStream)
            {
                string ansStr = answerReader.ReadLine();

                string outStr;
                try
                {
                    outStr = outReader.ReadLine();
                }
                catch (IOException) { outStr = String.Empty; }

                if (!exact)
                {
                    try
                    {
                        while (ansStr.Contains("  "))
                        {
                            ansStr = ansStr.Replace("  ", " ");
                        }
                        ansStr = ansStr.Trim();
                    }
                    catch (NullReferenceException) { }

                    try
                    {
                        while (outStr.Contains("  "))
                        {
                            outStr = outStr.Replace("  ", " ");
                        }
                        outStr = outStr.Trim();
                    }
                    catch (NullReferenceException) { }
                }

                if (ansStr != outStr)
                {
                    result = false;
                }
            }
            answerReader.Close();
            outReader.Close();

            return result;
        }

        public static string[] GuessFileNames(string sourceFile)
        {
            string inputFile = String.Empty, outputFile = String.Empty;

            StreamReader reader = new StreamReader(sourceFile);
            string[] strings = reader.ReadToEnd().Replace('\'', '"').Split('"');
            reader.Close();

            for (int i = 1; i < strings.Length; i += 2)
            {
                if (strings[i].EndsWith(".in")) { inputFile = strings[i]; }
                else if (strings[i].EndsWith(".out")) { outputFile = strings[i]; }

                else if (strings[i].StartsWith("in")) { inputFile = strings[i]; }
                else if (strings[i].StartsWith("out")) { outputFile = strings[i]; }

                else if (strings[i].Contains("in")) { inputFile = strings[i]; }
                else if (strings[i].Contains("out")) { outputFile = strings[i]; }
            }

            return new string[2] { inputFile, outputFile };
        }

        #region FS
        public static bool FileAvailable(string fileName)
        {
            FileStream fs;
            if (!File.Exists(fileName))
            {
                return false;
            }

            try
            {
                fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fs.Dispose();
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        public static void WaitForFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            int cnt = 500;
            while (!FileAvailable(fileName) && cnt > 0)
            {
                Thread.Sleep(20);
                cnt--;
            }
            if (!FileAvailable(fileName))
            {
                Print("Не могу получить доступ к '" + fileName + "'", Color.Red);
            }
        }
        #endregion

        #region Printing
        public static void Error(string message)
        {
            MessageBox.Show(message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FatalError(string message)
        {
            MessageBox.Show(message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            Environment.Exit(1);
        }

        public static void Print(string text, Color color)
        {
            Program.mainForm.Print(text, color);
        }

        public static void Print(string text)
        {
            Program.mainForm.Print(text);
        }

        public static void PrintLine(string text, Color color)
        {
            Program.mainForm.PrintLine(text, color);
        }

        public static void PrintLine(string text = "")
        {
            Program.mainForm.PrintLine(text);
        }

        public static void PrintError(Exception exception)
        {
            PrintLine("[Ошибка: " + exception.ToString() + "]", Color.Red);
        }
        #endregion

    }
}
