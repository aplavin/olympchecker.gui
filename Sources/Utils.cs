
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace olympchecker_gui
{
    static class Utils
    {
        private static readonly string[] execExtensions = { ".exe", ".bat", ".com" };

        public static bool isExecutable(string fileName)
        {
            return execExtensions.Contains(Path.GetExtension(fileName));
        }

        public static Process StartProcess(string fileName, string args = "", bool oneProcessor = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = args;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            if (oneProcessor)
            {
                process.ProcessorAffinity = new IntPtr(1 << 0);
            }
            return process;
        }

        public static String CopyOrCompile(string source, string output)
        {
            string extension = Path.GetExtension(source);
            if (execExtensions.Contains(extension))
            {
                try
                {
                    File.Copy(source, output, true);
                    return null;
                }
                catch
                {
                    return "Ошибка при копировании файла";
                }
            }
            else
            {
                string s = CompilersManager.GetCompiler(extension).Compile(source, output);
                return (s == null ? null : "Ошибка компиляции:\n" + s);
            }
        }

        public static bool CompareFiles(string answerFile, string outFile, bool exact, out string additionalInfo)
        {
            Utils.WaitForFile(answerFile);
            Utils.WaitForFile(outFile);

            int maxLen = 100;

            using (StreamReader answerReader = new StreamReader(answerFile),
            outReader = new StreamReader(outFile))
            {
                int stringNum = 0;

                while (!answerReader.EndOfStream)
                {
                    stringNum++;

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
                        additionalInfo = String.Format("Неверно выведены данные в строке №{0}\n", stringNum);

                        if (ansStr.Length <= maxLen)
                        {
                            additionalInfo += String.Format("Ожидалось:\n{0}\n", ansStr);
                        }
                        else
                        {
                            additionalInfo += String.Format("Ожидалось (длина {1}):\n{0} ...\n", ansStr.Substring(0, maxLen), ansStr.Length);
                        }

                        if (outStr.Length <= maxLen)
                        {
                            additionalInfo += String.Format("Выведено:\n{0}", outStr);
                        }
                        else
                        {
                            additionalInfo += String.Format("Выведено (длина {1}):\n{0} ...", outStr.Substring(0, maxLen), outStr.Length);
                        }

                        return false;
                    }
                }

                additionalInfo = String.Format("Все данные выведены верно (строк: {0})", stringNum);
                return true;
            }
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

        public static bool CheckFile(string file, string name)
        {
            AddPreparation(String.Format("{0}...", name));
            if (File.Exists(file))
            {
                AddRes("[OK]", Color.Green);
                return true;
            }
            else
            {
                AddRes("[Не найдено]", Color.Red);
                return false;
            }
        }

        public static bool CheckFolder(string folder, string name)
        {
            AddPreparation(String.Format("{0}...", name));
            if (Directory.Exists(folder) && Directory.GetFiles(folder).Length != 0)
            {
                AddRes("[OK]", Color.Green);
                return true;
            }
            else
            {
                AddRes("[Не найдено]", Color.Red);
                return false;
            }
        }

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

            int cnt = 100;
            while (!FileAvailable(fileName) && cnt > 0)
            {
                Thread.Sleep(20);
                cnt--;
            }
            if (!FileAvailable(fileName))
            {
                Error(String.Format("Не могу получить доступ к '{0}'", fileName));
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
            Error(message);
            Application.Exit();
            Environment.Exit(1);
        }

        public static void AddPreparation(string text, Color color)
        {
            Program.mainForm.AddItem(text, 0, color);
        }

        public static void AddTesting(string text, Color color)
        {
            Program.mainForm.AddItem(text, 1, color);
        }

        public static void AddResult(string text, Color color)
        {
            Program.mainForm.AddItem(text, 2, color);
        }

        public static void AddPreparation(string text)
        {
            AddPreparation(text, SystemColors.WindowText);
        }

        public static void AddTesting(string text)
        {
            AddTesting(text, SystemColors.WindowText);
        }

        public static void AddResult(string text)
        {
            AddResult(text, SystemColors.WindowText);
        }

        public static void AddRes(string text, Color color, string tooltip = "")
        {
            Program.mainForm.AddResult(text, color, tooltip);
        }
        #endregion

    }
}
