using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nini.Config;
using System.IO;

namespace olympchecker_gui
{
    class SettingsManager
    {
        private static readonly string fileName = Path.Combine(Directory.GetCurrentDirectory(), "settings.ini");
        private static IConfigSource configSource;
        private static IConfig settingsConfig, sessionConfig;

        public static string Language
        {
            get { return settingsConfig.Get("Language"); }
            set { settingsConfig.Set("Language", value); }
        }
        public static bool AutoSaveState
        {
            get { return settingsConfig.GetBoolean("AutoSaveState"); }
            set { settingsConfig.Set("AutoSaveState", value); }
        }

        public static List<Pair<string, object>> MainFormState
        {
            get
            {
                var list = new List<Pair<string, object>>();

                foreach (string key in sessionConfig.GetKeys())
                {
                    string value = sessionConfig.Get(key);

                    bool res;
                    if (Boolean.TryParse(value, out res))
                    {
                        list.Add(new Pair<string, object>(key, res));
                    }
                    else
                    {
                        list.Add(new Pair<string, object>(key, value));
                    }
                }

                return list;
            }

            set
            {
                foreach (string key in sessionConfig.GetKeys())
                {
                    sessionConfig.Remove(key);
                }

                foreach (var pair in value)
                {
                    sessionConfig.Set(pair.First, pair.Second);
                }
            }
        }

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
                settingsConfig = configSource.Configs["Settings"];
                sessionConfig = configSource.Configs["Session"];
                if (sessionConfig == null)
                {
                    configSource.AddConfig("Session");
                    sessionConfig = configSource.Configs["Session"];
                }
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
                configSource.Save();
            }
            catch
            {
                Utils.FatalError("Ошибка при сохранении файла \"" + fileName + "\"");
            }
        }
    }
}
