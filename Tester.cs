
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace olympchecker_gui
{

    static class Tester
    {
        public struct Parameters
        {
            public string source, testsDir, inputFile, outputFile;
            public int timeLimit;
            public bool exactChecking;
            public Compiler compiler;
        };
        private enum Code {OK, WA, PE, FL, RE, TL};
        private static string[] resultDirs = { "OK", "WA", "PE", "FL", "RE", "TL" };
        private const string workDir = "work";
        private const string solutionExec = "olympSolution.exe";
        private const string checkerExec = "olympChecker.exe";
        private static List<string> tests;
        private static int testsPassed;
        private static int maxTime;
        private static Parameters parameters;

        private static bool noErrors;

        public static void TestSolution(Parameters parameters) {
            Tester.parameters = parameters;

            tests = new List<string>();

            new Thread(doTestSolution).Start();

            Directory.CreateDirectory(workDir);
            Directory.SetCurrentDirectory(workDir);
        }

        private static void doTestSolution()
        {
            if (!CleanBefore()) { noErrors = false; }
            if (!CompileSolution()) { noErrors = false; }
            if (!FindTests()) { noErrors = false; }
            Utils.PrintLine();
            if (!PerformTesting()) { noErrors = false; }
            Utils.PrintLine();
            PrintResult();
            Utils.PrintLine();
            if (!CleanAfter()) { noErrors = false; }

            noErrors = true;
        }

        private static bool CleanBefore()
        {
            Utils.Print("Удаляю временные файлы...\t");

            try
            {
                foreach (string file in Directory.GetFiles("."))
                {
                    Utils.WaitForFile(file);
                    File.Delete(file);
                }

                foreach (string dir in Directory.GetDirectories("."))
                {
                    Directory.Delete(dir, true);
                }

                Utils.PrintLine("[OK]", Color.Green);
                return true;
            }
            catch (IOException)
            {
                Utils.PrintLine("[Ошибка]", Color.Red);
                return false;
            }
        }

        private static bool CleanAfter()
        {
            Utils.Print("Удаляю временные файлы...\t");

            try
            {
                foreach (string file in Directory.GetFiles("."))
                {
                    Utils.WaitForFile(file);
                    File.Delete(file);
                }

                Utils.PrintLine("[OK]", Color.Green);
                return true;
            }
            catch (IOException)
            {
                Utils.PrintLine("[Ошибка]", Color.Red);
                return false;
            }
        }

        private static bool CompileSolution()
        {
            Utils.Print("Компилирую решение...\t");
            if (parameters.compiler.Compile(parameters.source, solutionExec))
            {
                Utils.PrintLine("[OK]", Color.Green);
                return true;
            }
            else
            {
                Utils.PrintLine("[Ошибка]", Color.Red);
                return false;
            }
        }

        private static bool FindTests()
        {
            Utils.Print("Поиск тестов...\t");
            foreach (string file in Directory.GetFiles(parameters.testsDir))
            {
                if (file.IndexOf('.') == -1 && File.Exists(file + ".a"))
                {
                    tests.Add(file);
                }
            }
            tests.Sort();
            Utils.PrintLine("[" + tests.Count + "]", Color.Green);

            return true;
        }

        private static bool PerformTesting()
        {
            Utils.PrintLine("Тестирование решения...");

            foreach (string test in tests)
            {
                Utils.Print("Тест '" + Path.GetFileNameWithoutExtension(test) + "': ");
                try
                {
                    PrepareTest(test);
                    PerformTest(test);
                }
                catch
                {
                    Utils.Print("[Ошибка]", Color.Red);
                    return false;
                }
            }

            return true;
        }

        private static void PrepareTest(string test)
        {
            if (File.Exists(parameters.inputFile))
            {
                Utils.WaitForFile(parameters.inputFile);
                File.Delete(parameters.inputFile);
            }
            if (File.Exists("correct.out"))
            {
                Utils.WaitForFile("correct.out");
                File.Delete("correct.out");
            }
            File.Copy(test, parameters.inputFile);
            File.Copy(test + ".a", "correct.out");
        }

        private static void PerformTest(string test)
        {
            Process process = Utils.StartProcess(solutionExec, "", true);
            while (!process.HasExited && process.UserProcessorTime.TotalMilliseconds <= parameters.timeLimit)
            {
                Thread.Sleep(20);
            }
            if (!process.HasExited)
            {
                process.Kill();
                process.WaitForExit();
            }

            // process exited, gather results

            bool gotRE = (process.ExitCode != 0); // if we killed process, it will appear too

            int time = (int)process.UserProcessorTime.TotalMilliseconds;
            bool gotTL = (time > parameters.timeLimit);
            if (!gotTL)
            {
                maxTime = Math.Max(maxTime, time);
            }


            Code code = Code.OK;
            if (gotTL)
            {
                code = Code.TL;
            }
            else if (gotRE)
            {
                code = Code.RE;
            }
            else
            {
                code = CheckAnswer(parameters.inputFile, "correct.out", parameters.outputFile);
            }

            Directory.CreateDirectory(resultDirs[(int)code]);
            File.Copy(test, Path.Combine(resultDirs[(int)code], Path.GetFileName(test)));
            File.Copy(test + ".a", Path.Combine(resultDirs[(int)code], Path.GetFileName(test) + ".a"));

            PrintTestResult(code, time);
            if (code == Code.OK)
            {
                testsPassed++;
            }
        }

        private static Code CheckAnswer(string inputFile, string answerFile, string outFile)
        {
            //if (Config.CheckerStandart)
            //{
                return Utils.CompareFiles(answerFile, outFile, parameters.exactChecking) ? Code.OK : Code.WA;
            //}
            //else
            //{
            //    Process process = Utils.StartProcess(checkerExec, inputFile + " " + answerFile + " " + outFile);
            //    process.WaitForExit();
            //    return process.ExitCode;
            //}
        }
        
        private static void PrintTestResult(Code code, int time)
        {
            switch (code)
            {
                case Code.OK:
                    Utils.PrintLine("[OK - " + time + " ms]", Color.Green);
                    break;
                case Code.WA:
                    Utils.PrintLine("[WA - " + time + " ms]", Color.Red);
                    break;
                case Code.PE:
                    Utils.PrintLine("[PE - " + time + " ms]", Color.Red);
                    break;
                case Code.FL:
                    Utils.PrintLine("[FAIL - " + time + " ms]", Color.Red);
                    break;
                case Code.RE:
                    Utils.PrintLine("[RE - " + time + " ms]", Color.Red);
                    break;
                case Code.TL:
                    Utils.PrintLine("[TL - >" + parameters.timeLimit + " ms]", Color.Red);
                    break;
            }
        }

        private static void PrintResult()
        {
            Utils.Print("Тестирование завершено: ");
            Color color;
            int score = 100 * testsPassed / tests.Count;
            if (score == 100)
            {
                color = Color.Green;
            }
            else if (score == 0)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.Orange;
            }
            Utils.PrintLine(testsPassed + "/" + tests.Count + " (" + score + "/100)", color);

            Utils.Print("Максимальное время (без учёта TL) ");
            Utils.PrintLine(maxTime + " ms",
                maxTime <= parameters.timeLimit * 3 / 4 ? Color.Green : Color.Yellow);
        }

    }
}
