using System.Diagnostics;

namespace olympchecker_gui
{
    class Compiler
    {

        public string name { get; private set; }
        public string path { get; private set; }
        public string options { get; private set; }
        public string extensions { get; private set; }

        public Compiler(string name, string path, string options, string extensions)
        {
            this.name = name;
            this.path = path;
            this.options = options;
            this.extensions = ' ' + extensions.ToLower() + ' ';
        }

        public bool CanCompile(string extension)
        {
            return extensions.Contains(' ' + extension.ToLower() + ' ');
        }

        public string Compile(string source, string output)
        {
            Process process = Utils.StartProcess(path, options.Replace("SOURCE", "\"" + source + "\"").Replace("OUTPUT", "\"" + output + "\""));
            string s = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return (process.ExitCode == 0 ? null : s);
        }
    }
}
