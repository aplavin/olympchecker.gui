
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nini.Config;

namespace olympchecker_gui
{

    static class CompilersManager
    {

        private static readonly string fileName = "compilers.ini";
        public static List<Compiler> compilers { get; set; }
        private static IConfigSource configSource;

        public static void Load()
        {
            try
            {
                configSource = new IniConfigSource(fileName);
            }
            catch (IOException)
            {
                Utils.FatalError("Ошибка при открытии файла \"" + fileName + "\"");
            }


            try
            {
                // Fill compilers list using data from configSource
                compilers = (from IConfig iConfig in configSource.Configs
                                 where iConfig.Name.StartsWith("Compiler_")
                                 select new Compiler(
                                     iConfig.Get("Name"), iConfig.Get("Path"), iConfig.Get("Options"), iConfig.Get("Extensions"))
                                     )
                                .ToList();
            }
            catch (Nini.Ini.IniException)
            {
                Utils.FatalError("Ошибка в формате файла \"" + fileName + "\"");
            }
        }

        public static void Save()
        {
            try
            {
                configSource.Configs.Clear();

                for (int i = 0; i < compilers.Count; i++)
                {
                    configSource.AddConfig("Compiler_" + i);
                    configSource.Configs["Compiler_" + i].Set("Name", compilers[i].name);
                    configSource.Configs["Compiler_" + i].Set("Extensions", compilers[i].extensions);
                    configSource.Configs["Compiler_" + i].Set("Path", compilers[i].path);
                    configSource.Configs["Compiler_" + i].Set("Options", compilers[i].options);
                }

                configSource.Save();
            }
            catch
            {
                Utils.FatalError("Ошибка при сохранении файла \"" + fileName + "\"");
            }
        }

        /// <summary>
        /// Returns first compiler from all the list, which can compile specified extension. If no such compiler if found, returns null.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Compiler GetCompiler(string extension)
        {
            extension = extension.TrimStart('.');
            return (from Compiler comp in compilers
                    where comp.CanCompile(extension)
                    select comp).
                    DefaultIfEmpty(null).FirstOrDefault();
        }

    }

}

