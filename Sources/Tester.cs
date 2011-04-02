
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;

namespace olympchecker_gui
{

    static class Tester
    {
        public struct Parameters
        {
            public string source, testsDir, inputFile, outputFile;
            public string checker;
            public int timeLimit;
            public bool internalCheck, exactCheck, standartIO;
            public Compiler compiler, compilerChecker;
        };
        private enum Code { OK, WA, PE, FL, RE, TL };
        private static string[] resultDirs = { "OK", "WA", "PE", "FL", "RE", "TL" };
        private static readonly string workDir = "work";
        private static readonly string solutionExec = "olympSolution.exe";
        private static readonly string checkerExec = "olympChecker.exe";
        private static readonly string tempOutput = "tmpfile.out";
        private static List<string> tests;
        private static int testsPassed;
        private static int maxTime;
        private static Parameters parameters;

        private static bool noErrors;

        static Tester()
        {
            Directory.CreateDirectory(workDir);
            Directory.SetCurrentDirectory(workDir);
        }

        public static void TestSolution(Parameters parameters)
        {
            tests = new List<string>();
            testsPassed = 0;
            maxTime = 0;

            if (parameters.inputFile.Length == 0)
            {
                parameters.inputFile = "in";
            }
            if (parameters.outputFile.Length == 0)
            {
                parameters.outputFile = "out";
            }
            Tester.parameters = parameters;


            new Thread(doTestSolution).Start();
        }

        private static void doTestSolution()
        {
            if (!CleanBefore()) { noErrors = false; return; }
            if (!CompileSolution()) { noErrors = false; return; }
            if (!CompileChecker()) { noErrors = false; return; }
            if (!FindTests()) { noErrors = false; return; }
            Utils.PrintLine();
            if (!PerformTesting()) { noErrors = false; return; }
            Utils.PrintLine();
            PrintResult();
            Utils.PrintLine();
            if (!CleanAfter()) { noErrors = false; return; }

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
            catch (Exception ex)
            {
                Utils.PrintError(ex);
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

                Utils.Print("[OK]", Color.Green);
                return true;
            }
            catch (Exception ex)
            {
                Utils.PrintError(ex);
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

        private static bool CompileChecker()
        {
            Utils.Print("Компилирую проверяющую программу...\t");
            if (parameters.compilerChecker.Compile(parameters.checker, checkerExec))
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

            tests = (from file in Directory.GetFiles(parameters.testsDir)
                     where !file.EndsWith(".a") && File.Exists(file + ".a")
                     orderby file ascending
                     select file)
                    .ToList();

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
                catch (Exception ex)
                {
                    Utils.PrintError(ex);
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

            File.Delete(tempOutput);
            File.Delete(parameters.outputFile);
        }

        private struct TwoStreams
        {
            public StreamReader streamReader;
            public StreamWriter streamWriter;
        };
        private static void CopyStream(object twoStreams)
        {
            TwoStreams streams = (TwoStreams)twoStreams;
            while (streams.streamReader.Peek() != -1)
            {
                streams.streamWriter.WriteLine(streams.streamReader.ReadLine());
            }
            streams.streamReader.Close();
            streams.streamWriter.Close();
        }

        public static void PerformTest(string test)
        {
            Process process = Utils.StartProcess(solutionExec, String.Empty, true);

            if (parameters.standartIO)
            {
                TwoStreams streamsOutToFile = new TwoStreams();
                streamsOutToFile.streamReader = process.StandardOutput;
                streamsOutToFile.streamWriter = new StreamWriter(tempOutput, false);
                new Thread(CopyStream).Start(streamsOutToFile);

                TwoStreams streamsFileToIn = new TwoStreams();
                Utils.WaitForFile(parameters.inputFile);
                streamsFileToIn.streamReader = new StreamReader(parameters.inputFile);
                streamsFileToIn.streamWriter = process.StandardInput;
                new Thread(CopyStream).Start(streamsFileToIn);
            }

            while (!process.HasExited &&
                process.UserProcessorTime.TotalMilliseconds <= parameters.timeLimit &&
                (DateTime.Now - process.StartTime).TotalMilliseconds <= parameters.timeLimit * 2)
            {
                Thread.Sleep(50);
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
                if (parameters.standartIO && !File.Exists(parameters.outputFile))
                {
                    File.Move(tempOutput, parameters.outputFile);
                }
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
            if (parameters.internalCheck)
            {
                return Utils.CompareFiles(answerFile, outFile, parameters.exactCheck) ? Code.OK : Code.WA;
            }
            else
            {
                Process process = Utils.StartProcess(checkerExec, inputFile + " " + answerFile + " " + outFile);
                process.WaitForExit();
                return (Code)process.ExitCode;
            }
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
            Utils.Print("Тестирование завершено:\t");
            Color color;
            int score = 0;
            if (tests.Count != 0)
            {
                score = 100 * testsPassed / tests.Count;
            }
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

            Utils.Print("Максимальное время (без учёта TL):\t");
            Utils.PrintLine(maxTime + " ms",
                maxTime <= parameters.timeLimit * 3 / 4 ? Color.Green : Color.Orange);
        }

    }
}
