using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace olympchecker_gui
{
    class Compiler
    {
        public string path;
        public string options;
        public string name;

        public Compiler(string name, string path, string options)
        {
            this.name = name;
            this.path = path;
            this.options = options;
        }

        public bool Compile(string source, string output)
        {
            Process process = Utils.StartProcess(path, options.Replace("SOURCE", source).Replace("OUTPUT", output));
            process.WaitForExit();
            return (process.ExitCode == 0);
        }
    }
}
