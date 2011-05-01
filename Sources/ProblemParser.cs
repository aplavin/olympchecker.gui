
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace olympchecker_gui
{
    class ProblemParser
    {
        private List<string> files = new List<string>();

        public List<string> solutions { get; private set; }
        public List<Pair<string, string>> tests { get; private set; }
        public string checker { get; private set; }

        public ProblemParser(string directory)
        {
            files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories).ToList();

            solutions = new List<string>();
            tests = new List<Pair<string, string>>();
            checker = null;

            RecognizeTests();
            RecognizeChecker();
            RecognizeSolutions();
        }

        private void RecognizeChecker()
        {
            Regex negEx = new Regex("([^a-zA-Z]gen|gen[^a-zA-Z]|dat)", RegexOptions.IgnoreCase);
            string[] srcExts = new string[] { ".c", ".cc", ".cpp", ".cs", ".pas", ".dpr", ".java", ".bat", ".sh", ".py", ".rb" };

            List<string> srcCandidates = new List<string>();
            List<string> execCandidates = new List<string>();

            foreach (string file in files)
            {
                if ((file.ContainsCI("check") || file.ContainsCI("tester")) &&
                    srcExts.ContainsCI(Path.GetExtension(file)) &&
                    !negEx.IsMatch(file))
                {
                    if (Utils.IsExecutable(file))
                    {
                        execCandidates.Add(file);
                    }
                    else
                    {
                        srcCandidates.Add(file);
                    }
                }
            }

            if (srcCandidates.Count == 0)
            {
                return;
            }
            if (srcCandidates.Count == 1)
            {
                checker = srcCandidates.First();
                return;
            }

            srcCandidates.Sort(delegate(string s1, string s2)
            {
                return File.GetLastWriteTime(s2).CompareTo(File.GetLastWriteTime(s1));
            });

            if (File.GetLastWriteTime(srcCandidates[0]) !=
                File.GetLastWriteTime(srcCandidates[1]))
            {
                checker = srcCandidates[0];
                return;
            }

            // case sensitive search
            foreach (string execCand in execCandidates)
            {
                string name = Path.GetFileNameWithoutExtension(execCand);

                foreach (string srcCand in srcCandidates)
                {
                    if (srcCand.Contains(name) && !negEx.IsMatch(srcCand))
                    {
                        checker = srcCand;
                        return;
                    }
                }
            }
            // case insensitive search
            foreach (string execCand in execCandidates)
            {
                string name = Path.GetFileNameWithoutExtension(execCand);

                foreach (string srcCand in srcCandidates)
                {
                    if (srcCand.ContainsCI(name) && !negEx.IsMatch(srcCand))
                    {
                        checker = srcCand;
                        return;
                    }
                }
            }

            string[] extensions = new string[] { ".cpp", ".cc", ".dpr" };
            foreach (string srcCand in srcCandidates)
            {
                if (extensions.ContainsCI(Path.GetExtension(srcCand)) && !negEx.IsMatch(srcCand))
                {
                    checker = srcCand;
                    return;
                }
            }

            extensions = new string[] { ".c", ".pas", ".java", ".cs", ".bat", ".sh", ".py", ".rb" };
            foreach (string srcCand in srcCandidates)
            {
                if (extensions.ContainsCI(Path.GetExtension(srcCand)) && !negEx.IsMatch(srcCand))
                {
                    checker = srcCand;
                    return;
                }
            }
        }

        private void RecognizeSolutions()
        {
            string[] extensions = new string[] { ".c", ".cc", ".cpp", ".cs", ".pas", ".dpr", ".java", ".py", ".rb" };
            Regex negEx = new Regex("(check|auto|[^a-zA-Z]gen|gen[^a-zA-Z]|dat|test[^/]*$)", RegexOptions.IgnoreCase);

            for (int i = 0; i < files.Count; i++)
            {
                if (extensions.ContainsCI(Path.GetExtension(files[i])) &&
                    !negEx.IsMatch(files[i]))
                {
                    solutions.Add(files[i]);
                    files.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < solutions.Count; i++)
            {
                if (!solutions[i].ContainsCI("test"))
                {
                    for (int j = 0; j < solutions.Count; j++)
                    {
                        if (solutions[j].ContainsCI("test"))
                        {
                            solutions.RemoveAt(j);
                            j--;
                        }
                    }
                    break;
                }
            }

            solutions.Sort();
        }

        private void RecognizeTests()
        {
            RecognizeTestsByEndings("\\.dat", true);
            RecognizeTestsByEndings("dat", true);
            RecognizeTestsByEndings("\\.in", true);
            RecognizeTestsByEndings("in", true);
            RecognizeTestsByEndings("\\.i", true);

            RecognizeTestsByEndings("\\.ans", false);
            RecognizeTestsByEndings("ans", false);
            RecognizeTestsByEndings("\\.a", false);
            RecognizeTestsByEndings("\\.out", false);
            RecognizeTestsByEndings("out", false);
            RecognizeTestsByEndings("\\.o", false);

            RecognizeTestsByKeywords();

            for (int i = 0; i < tests.Count; i++)
            {
                if (ReadNumbers(tests[i].ToString()).Count() != 0)
                {
                    for (int j = 0; j < tests.Count; j++)
                    {
                        if (ReadNumbers(tests[j].ToString()).Count() == 0)
                        {
                            tests.RemoveAt(j);
                            j--;
                        }
                    }
                    break;
                }
            }

            tests.Sort(delegate(Pair<string, string> p1, Pair<string, string> p2)
            {
                int[] a1 = ReadNumbers(p1.ToString());
                int[] a2 = ReadNumbers(p2.ToString());

                for (int i = 0; i < a1.Count() && i < a2.Count(); i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return a1[i].CompareTo(a2[i]);
                    }
                }

                return p1.CompareTo(p2);
            });
        }

        private void RecognizeTestsByEndings(string regS, bool input)
        {
            Regex regex = new Regex(regS, RegexOptions.IgnoreCase);
            for (int i = 0; i < files.Count; i++)
            {
                if (regex.IsMatch(files[i]) && !files[i].ContainsCI("example"))
                {
                    string[] arr = regex.Replace(files[i], "*").Split('*');
                    string tmp = "^" + Regex.Escape(arr.First()) + "\\.?[a-zA-Z]*";
                    if (arr.Count() > 1)
                    {
                        tmp += Regex.Escape(arr[1]);
                    }
                    tmp += "$";
                    Regex outRegex = new Regex(tmp);

                    int j = FindWithRegex(files[i], outRegex);
                    if (j != -1)
                    {
                        if (input)
                        {
                            tests.Add(new Pair<string, string>(files[i], files[j]));
                        }
                        else
                        {
                            tests.Add(new Pair<string, string>(files[j], files[i]));
                        }
                        files.RemoveAt(Math.Max(i, j));
                        files.RemoveAt(Math.Min(i, j));
                        i = -1;
                    }
                }
            }
        }

        private void RecognizeTestsByKeywords()
        {
            Regex testEx = new Regex("test[^/]*", RegexOptions.IgnoreCase);
            Regex inEx = new Regex("in|dat", RegexOptions.IgnoreCase);
            for (int i = 0; i < files.Count; i++)
            {
                if (testEx.IsMatch(files[i]) && inEx.IsMatch(files[i]))
                {
                    int j = FindWithRegex(files[i], new Regex(
                        Regex.Escape(testEx.Match(files[i]).Value)
                        )
                    );
                    if (j != -1)
                    {
                        tests.Add(new Pair<string, string>(files[i], files[j]));
                        files.RemoveAt(Math.Max(i, j));
                        files.RemoveAt(Math.Min(i, j));
                        i = -1;
                    }
                }
            }
        }

        private int FindWithRegex(string orig, Regex regex)
        {
            for (int i = 0; i < files.Count; i++)
            {
                if (regex.IsMatch(files[i]) && files[i] != orig)
                {
                    int[] a1 = ReadNumbers(orig);
                    int[] a2 = ReadNumbers(files[i]);
                    if (Enumerable.SequenceEqual(a1, a2))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private static int[] ReadNumbers(string s)
        {
            List<int> res = new List<int>();
            foreach (Match match in new Regex("\\d+").Matches(s))
            {
                res.Add(int.Parse(match.Value));
            }
            return res.ToArray();
        }
    }
}
