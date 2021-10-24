using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DiscordInjectionsRemover
{
    class Program
    {
        public static string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), assemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString(), version = assemblyVersion.Remove(assemblyVersion.Length-4);
        public static List<string> paths = new List<string>()
        {
            $"{localAppData}\\Discord",
            $"{localAppData}\\DiscordCanary",
            $"{localAppData}\\DiscordDevelopment",
            $"{localAppData}\\DiscordPTB"
        };
        static void Main(string[] args)
        {
            Console.Title = $"Injections Remover - {version}";
            foreach(var x in paths)
            {
                if (Directory.Exists(x))
                {
                    Logger.Info($"Verifying {x.Split('\\')[x.Split('\\').Length-1]}");
                    try
                    {
                        string folder = $"{Directory.GetDirectories($"{Directory.GetDirectories(x)[0]}\\modules")[1]}\\discord_desktop_core";
                        string index = $"{folder}\\index.js";
                        if (File.Exists(index))
                        {
                            if (File.ReadAllText(index) == "module.exports = require('./core.asar');")
                                Logger.Info("index.js | Not infected");
                            else
                            {
                                File.WriteAllText(index, "module.exports = require('./core.asar');");
                                Logger.Warn("index.js | Potentially Infected ! Fixed the file !");
                            }
                            foreach(var lmao in Directory.GetDirectories(folder))
                            {
                                Logger.Warn($"Found a directory \"{lmao.Split('\\')[lmao.Split('\\').Length - 1]}\", Fixed it.");
                                Directory.Delete(lmao, true);
                            }
                        }
                    } catch
                    {
                        Logger.Info("Hum.. Looks like a not completelly Installed Discord Client or badly removed.. I'll fix it by deleting it.");
                        Directory.Delete(x, true);
                    }
                }
            }
            Logger.Info("Finished.");
            Console.ReadLine();
        }
    }
}
