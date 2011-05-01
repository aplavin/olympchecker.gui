
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;

namespace olympchecker_gui
{
    public delegate void ProgressNotifier(int progress, int max);

    static class Tester
    {
        public class Parameters
        {
            public string solution, inputFile, outputFile;
            public List<Pair<string, string>> tests;
            public string checker;
            public int timeLimit;
            public bool internalCheck, standartIO;
            public ProgressNotifier progressNotifier;
        };
        private enum Code { OK, WA, PE, FL, RE, TL };
        private static readonly string[] resultDirs = { "OK", "WA", "PE", "FL", "RE", "TL" };
        private static readonly string tempOutput = "tmpfile.out";
        private static int testsPassed;
        private static int maxTime;
        private static Parameters parameters;
        private static Thread testingThread;

        public static void TestSolution(Parameters parameters)
        {
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

            testingThread = new Thread(doTestSolution);
            testingThread.Start();
        }

        public static void StopTesting()
        {
            if (testingThread == null || !testingThread.IsAlive)
            {
                return;
            }
            testingThread.Abort();
            testingThread.Join(1000);
            Utils.AddResult("Тестирование остановлено");
            CleanAfter();
        }

        private static void doTestSolution()
        {
            try
            {
                if (!CleanBefore()) { return; }
                if (!FindTests()) { return; }
                if (!PerformTesting()) { return; }
                PrintResult();
                if (!CleanAfter()) { return; }
            }
            catch (ThreadAbortException) { }
        }

        private static void KillSolutions()
        {
            foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(parameters.solution)))
            {
                process.Kill();
            }
        }

        private static bool CleanBefore()
        {
            Utils.AddPreparation("Удаляю временные файлы...");

            KillSolutions();

            try
            {
                foreach (string file in Directory.GetFiles("."))
                {
                    if (Path.GetFileName(file) != Path.GetFileName(parameters.solution) &&
                        Path.GetFileName(file) != Path.GetFileName(parameters.checker))
                    {
                        Utils.WaitForFile(file);
                        File.Delete(file);
                    }
                }

                foreach (string dir in Directory.GetDirectories("."))
                {
                    Directory.Delete(dir, true);
                }

                Utils.AddRes("[OK]", Color.Green);
                return true;
            }
            catch (Exception ex)
            {
                Utils.AddRes("[Ошибка]", Color.Red, ex.ToString());
                return false;
            }
        }

        private static bool CleanAfter()
        {
            Utils.AddResult("Удаляю временные файлы...");

            KillSolutions();

            try
            {
                foreach (string file in Directory.GetFiles("."))
                {
                    Utils.WaitForFile(file);
                    File.Delete(file);
                }

                Utils.AddRes("[OK]", Color.Green);
                return true;
            }
            catch (IOException ex)
            {
                Utils.AddRes("[Ошибка]", Color.Red, ex.ToString());
                return false;
            }
        }

        private static bool FindTests()
        {
            Utils.AddPreparation("Найдено тестов:");
            Utils.AddRes("[" + parameters.tests.Count + "]", Color.Green);
            return true;
        }

        private static bool PerformTesting()
        {
            foreach (var test in parameters.tests)
            {
                Thread.Sleep(200);

                Utils.AddTesting(String.Format("Тест {0}: ", Path.GetFileNameWithoutExtension(test.First)));
                try
                {
                    PrepareTest(test);
                    PerformTest(test);
                }
                catch (Exception ex)
                {
                    Utils.AddRes("[Ошибка]", Color.Red, ex.ToString());
                    return false;
                }

                if (parameters.progressNotifier != null)
                {
                    parameters.progressNotifier(parameters.tests.IndexOf(test) + 1, parameters.tests.Count);
                }
            }

            return true;
        }

        private static void PrepareTest(Pair<string, string> test)
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
            File.Copy(test.First, parameters.inputFile);
            File.Copy(test.Second, "correct.out");

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
            streams.streamWriter.Write(streams.streamReader.ReadToEnd());
            streams.streamReader.Close();
            streams.streamWriter.Close();
        }

        public static void PerformTest(Pair<string, string> test)
        {
            Process process = Utils.StartProcess(parameters.solution, String.Empty, true);

            if (parameters.standartIO)
            {
                TwoStreams streamsFileToIn = new TwoStreams();
                Utils.WaitForFile(parameters.inputFile);
                streamsFileToIn.streamReader = new StreamReader(parameters.inputFile);
                streamsFileToIn.streamWriter = process.StandardInput;
                new Thread(CopyStream).Start(streamsFileToIn);

                TwoStreams streamsOutToFile = new TwoStreams();
                streamsOutToFile.streamReader = process.StandardOutput;
                streamsOutToFile.streamWriter = new StreamWriter(tempOutput, false);
                new Thread(CopyStream).Start(streamsOutToFile);
            }

            while (!process.HasExited &&
                process.TotalProcessorTime.TotalMilliseconds <= parameters.timeLimit * 2 &&
                (DateTime.Now - process.StartTime).TotalMilliseconds <= parameters.timeLimit * 3)
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

            if (parameters.standartIO && !File.Exists(parameters.outputFile))
            {
                Utils.WaitForFile(tempOutput);
                File.Move(tempOutput, parameters.outputFile);
            }

            Code code = Code.OK;
            string additionalInfo = null;
            if (gotTL)
            {
                code = Code.TL;
                additionalInfo = "Превышено максимальное время исполнения";
            }
            else if (gotRE)
            {
                code = Code.RE;
                additionalInfo = "Ошибка времени выполнения";
            }
            else
            {
                code = CheckAnswer(parameters.inputFile, "correct.out", parameters.outputFile, out additionalInfo);
            }

            Directory.CreateDirectory(resultDirs[(int)code]);
            File.Copy(test.First, Path.Combine(resultDirs[(int)code], Path.GetFileName(test.First)), true);
            File.Copy(test.Second, Path.Combine(resultDirs[(int)code], Path.GetFileName(test.Second)), true);
            File.Copy(parameters.outputFile, Path.Combine(resultDirs[(int)code], Path.GetFileName(test.First) + ".out"), true);

            PrintTestResult(code, time, additionalInfo);
            if (code == Code.OK)
            {
                testsPassed++;
            }
        }

        private static Code CheckAnswer(string inputFile, string answerFile, string outFile, out string additionalInfo)
        {
            if (parameters.internalCheck)
            {
                Code code = Utils.CompareFiles(answerFile, outFile, out additionalInfo) ? Code.OK : Code.WA;
                return code;
            }
            else
            {
                Process process = Utils.StartProcess(parameters.checker, inputFile + " " + outFile + " " + answerFile);
                additionalInfo = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Code code = (Code)process.ExitCode;
                return code;
            }
        }

        private static void PrintTestResult(Code code, int time, string additionalInfo)
        {
            switch (code)
            {
                case Code.OK:
                    Utils.AddRes(String.Format("[OK - {0} ms]", time), Color.Green, additionalInfo);
                    break;
                case Code.WA:
                    Utils.AddRes(String.Format("[WA - {0} ms]", time), Color.Red, additionalInfo);
                    break;
                case Code.PE:
                    Utils.AddRes(String.Format("[PE - {0} ms]", time), Color.Red, additionalInfo);
                    break;
                case Code.FL:
                    Utils.AddRes(String.Format("[FAIL - {0} ms]", time), Color.Red, additionalInfo);
                    break;
                case Code.RE:
                    Utils.AddRes(String.Format("[RE - {0} ms]", time), Color.Red, additionalInfo);
                    break;
                case Code.TL:
                    if (time > parameters.timeLimit * 1.5)
                    {
                        Utils.AddRes(String.Format("[TL - >{0} ms]", parameters.timeLimit * 1.5), Color.Red, additionalInfo);
                    }
                    else
                    {
                        Utils.AddRes(String.Format("[TL - {0} ms]", time), Color.Red, additionalInfo);
                    }
                    break;
            }
        }

        private static void PrintResult()
        {
            Utils.AddResult("Тестирование завершено:");
            Color color;
            int score = 0;
            if (parameters.tests.Count != 0)
            {
                score = 100 * testsPassed / parameters.tests.Count;
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
                color = Color.DarkOrange;
            }
            Utils.AddRes(testsPassed + "/" + parameters.tests.Count + " (" + score + "/100)", color);

            Utils.AddResult("Максимальное время (без учёта TL):");
            Utils.AddRes(maxTime + " ms",
                maxTime <= parameters.timeLimit * 3 / 4 ? Color.Green : Color.DarkOrange);
        }

    }
}
