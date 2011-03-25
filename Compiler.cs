using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Compile(string source, string output)
        {
            Utils.StartProcess(path, options.Replace("SOURCE", source).Replace("OUTPUT", output));
        }
    }
}
