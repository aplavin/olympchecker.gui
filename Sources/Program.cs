
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace olympchecker_gui
{
    static class Program
    {
        public static MainForm mainForm;
        public static readonly string programDirectory = Directory.GetCurrentDirectory();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SettingsManager.Load();
            CompilersManager.Load();

            Directory.CreateDirectory("work");
            Directory.SetCurrentDirectory("work");

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
