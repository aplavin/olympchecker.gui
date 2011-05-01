using System.Diagnostics;
using System.Text;

namespace olympchecker_gui
{
    class Compiler
    {

        public string name { get; set; }
        public string path { get; set; }
        public string options { get; set; }
        public string extensions { get; set; }

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
            string s = Encoding.GetEncoding(866).GetString(
                process.StandardError.CurrentEncoding.GetBytes(process.StandardError.ReadToEnd())
                );
            process.WaitForExit();
            return (process.ExitCode == 0 ? null : s);
        }
    }
}
