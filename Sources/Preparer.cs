
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace olympchecker_gui
{
    static class Preparer
    {
        public struct Data
        {
            public string source, inputFile, outputFile;
            public string problemDir, testsDir;
            public string checker;
            public int timeLimit;
            public bool internalCheck, standartIO;
            public ProgressNotifier progressNotifier;
        }

        private static readonly string solutionExec = "olympSolution.exe";
        private static readonly string checkerExec = "olympChecker.exe";

        public static Tester.Parameters Prepare(Data data)
        {
            Tester.Parameters parameters = new Tester.Parameters();

            string checkerSource;

            if (!String.IsNullOrEmpty(data.problemDir) && Directory.Exists(data.problemDir))
            {
                ProblemParser pp = new ProblemParser(data.problemDir);

                parameters.tests = pp.tests;

                parameters.internalCheck = String.IsNullOrEmpty(pp.checker);
                checkerSource = pp.checker;
            }
            else
            {
                parameters.tests = (from file in Directory.GetFiles(data.testsDir)
                                    where !file.EndsWith(".a") && File.Exists(file + ".a")
                                    orderby file ascending
                                    select new Pair<string, string>(file, file + ".a"))
                                    .ToList();

                parameters.internalCheck = data.internalCheck;
                checkerSource = data.checker;
            }

            parameters.solution = solutionExec;
            parameters.checker = checkerExec;

            parameters.inputFile = data.inputFile;
            parameters.outputFile = data.outputFile;
            parameters.timeLimit = data.timeLimit;
            parameters.standartIO = data.standartIO;
            parameters.progressNotifier = data.progressNotifier;

            if (!Compile("решение", data.source, parameters.solution))
            {
                return null;
            }
            if (!parameters.internalCheck && !Compile("проверяющую программу", checkerSource, parameters.checker))
            {
                return null;
            }

            return parameters;
        }

        private static bool Compile(string name, string source, string output)
        {
            Utils.AddPreparation(String.Format("Компилирую {0}...", name));
            string result = Utils.CopyOrCompile(source, output);
            if (String.IsNullOrEmpty(result))
            {
                Utils.AddRes("[OK]", Color.Green);
                return true;
            }
            else
            {
                Utils.AddRes("[Ошибка]", Color.Red, result);
                return false;
            }
        }
    }
}
