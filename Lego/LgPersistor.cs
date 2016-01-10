using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LgPersistor
    {
        private static string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string APP_FOLDER = "Lego";
        private static string FULL_PATH = Path.Combine(APP_DATA, APP_FOLDER);

        public static Boolean Init()
        {
            Boolean result = false;
            if(!Directory.Exists(FULL_PATH))
            {
                Directory.CreateDirectory(FULL_PATH);
                result = true;
            }
            return result;
        }

        public static List<LgConfig> GetAllConfigs()
        {
            List<LgConfig> configs = new List<LgConfig>();
            List<string> files = Directory.GetFiles(FULL_PATH).ToList<string>();
            files.ForEach((f) => configs.Add(LgConfig.FromFile(f)));

            return configs;
        }

        public static string GetLegoPath()
        {
            return FULL_PATH;
        }

    }
}
