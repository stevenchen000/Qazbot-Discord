using Qazbot.DataManager;
using Qazbot.ShadesOfMagick;
using System;
using System.Collections.Generic;

namespace Qazbot
{
    public sealed class ModuleHandler
    {
        public static Dictionary<string, Module> modules { get; set; } = new Dictionary<string, Module>();

        private static readonly ModuleHandler mh = new ModuleHandler();

        public static Random rand { get; set; }

        private static string filename = "Data/Modules.dat";

        public static string GetCommandArgs(string message) {
            string result = message;
            result = result.Substring(result.IndexOf(' ') + 1);
            return result;
        }

        private ModuleHandler() {
            //LoadData();
            rand = new Random((int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
        }

        //adds a module with name
        public static bool AddModule(string moduleName, Module newModule) {
            bool result = false;

            if (!modules.ContainsKey(moduleName.ToLower())) {
                modules[moduleName.ToLower()] = newModule;
                result = true;
            }

            return result;
        }

        //removes a module by name
        public static void RemoveModule(string moduleName) {
            if (modules.ContainsKey(moduleName)) {
                modules.Remove(moduleName);
            }
        }

        

        public static void SaveData() {
            DataManager<Dictionary<string, Module>>.SaveData(modules, filename);
        }

        public static void LoadData() {
            try
            {
                modules = DataManager<Dictionary<string, Module>>.LoadData(filename);
            }
            catch {
                modules = new Dictionary<string, Module>();
            }
        }
    }
}

