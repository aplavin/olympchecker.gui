
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace olympchecker_gui
{
    static class Utils
    {

        public static Process StartProcess(string fileName, string args = "", bool oneProcessor = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = args;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.PriorityClass = ProcessPriorityClass.RealTime;
            if (oneProcessor)
            {
                process.ProcessorAffinity = new IntPtr(1 << 0);
            }
            return process;
        }

        public static void Error(string message)
        {
            MessageBox.Show(message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void FatalError(string message)
        {
            MessageBox.Show(message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            Environment.Exit(1);
        }

    }
}
