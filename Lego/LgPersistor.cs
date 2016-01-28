using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego.Models
{
    class LgPersistor
    {
        private static string APP_DATA = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string APP_FOLDER = "Lego";
        private static string F_CONFIGS = "Configs";
        private static string FULL_PATH = Path.Combine(APP_DATA, APP_FOLDER);
        private static string CONFIGS_PATH = Path.Combine(FULL_PATH, F_CONFIGS);

        public static Boolean Init()
        {
            Boolean result = false;
            Directory.CreateDirectory(FULL_PATH);
            Directory.CreateDirectory(CONFIGS_PATH);

            return result;
        }

        /// <summary>
        /// Save config to file.
        /// Filename is a random string.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        internal static Boolean SaveToDirectory(string Filepath, object Config)
        {
            Init();
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(Filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, Config);
            }
            return true;
        }

        /// <summary>
        /// Get all saved configurations
        /// </summary>
        /// <returns></returns>
        public static List<LgConfig> GetAllConfigs()
        {
            List<LgConfig> configs = new List<LgConfig>();
            List<string> files = Directory.GetFiles(CONFIGS_PATH).ToList<string>();
            files.ForEach((f) => configs.Add(LgConfig.FromFile(f)));

            return configs;
        }

        /// <summary>
        /// Return full path to lego directory
        /// </summary>
        /// <returns></returns>
        public static string GetLegoPath()
        {
            return FULL_PATH;
        }

        /// <summary>
        /// Return full path to lego directory
        /// </summary>
        /// <returns></returns>
        public static string GetLegoConfigsPath()
        {
            return CONFIGS_PATH;
        }

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateString(int length = 10)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }

    }
}
