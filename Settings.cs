
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Nini.Config;
using System.Windows.Forms;

namespace olympchecker_gui
{
    public class CompilerInfo
    {
        public string name, extensions, path, options;

        public CompilerInfo(string name, string extensions, string path, string options)
        {
            this.name = name;
            this.extensions = extensions;
            this.path = path;
            this.options = options;
        }
    };

    static class Settings
    {

        private const string fileName = "settings.ini";
        private static List<CompilerInfo> compilerInfos = new List<CompilerInfo>();
        private static Dictionary<string, Compiler> compilers = new Dictionary<string, Compiler>();
        private static IConfigSource configSource;

        public static void Load()
        {
            try
            {
                configSource = new IniConfigSource(fileName);
            }
            catch (IOException)
            {
                Utils.FatalError("Ошибка при открытии файла настроек \"settings.ini\"");
            }


            try
            {
                foreach (IConfig iconfig in configSource.Configs)
                {
                    if (iconfig.Name.StartsWith("Compiler_"))
                    {
                        compilerInfos.Add(new CompilerInfo(iconfig.Get("Name"), iconfig.Get("Extensions"), iconfig.Get("Path"), iconfig.Get("Options")));

                        Compiler compiler = new Compiler(iconfig.Get("Name"), iconfig.Get("Path"), iconfig.Get("Options"));
                        foreach (string extension in iconfig.Get("Extensions").Split())
                        {
                            compilers[extension] = compiler;
                        }
                    }
                }
            }
            catch (Nini.Ini.IniException)
            {
                Utils.FatalError("Ошибка в формате файла настроек \"settings.ini\"");
            }
        }

        public static void Save()
        {
            try
            {
                configSource.Configs.Clear();
                for (int i = 0; i < compilerInfos.Count; i++)
                {
                    configSource.AddConfig("Compiler_" + i);
                    configSource.Configs["Compiler_" + i].Set("Name", compilerInfos[i].name);
                    configSource.Configs["Compiler_" + i].Set("Extensions", compilerInfos[i].extensions);
                    configSource.Configs["Compiler_" + i].Set("Path", compilerInfos[i].path);
                    configSource.Configs["Compiler_" + i].Set("Options", compilerInfos[i].options);
                }

                configSource.Save();
            }
            catch
            {
                Utils.FatalError("Ошибка при сохранении файла настроек \"settings.ini\"");
            }
        }

        public static List<CompilerInfo> GetCompilers()
        {
            return compilerInfos;
        }

        public static void SetCompilers(List<CompilerInfo> compilers)
        {
            compilerInfos = compilers;
        }

        public static Compiler GetCompiler(string extension)
        {
            extension = extension.TrimStart('.');
            if (!compilers.ContainsKey(extension))
            {
                return null;
            }
            return compilers[extension];
        }

    }

}

