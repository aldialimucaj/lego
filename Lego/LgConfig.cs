﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LgConfig
    {
        public string Title { get; set; }
        public string Filepath { get; set; }
        public List<LgWindow> Windows { get; set; }
        public String Shortcut { get; set; }
        public Boolean Stick { get; set; }

        public LgConfig()
        {
            Windows = new List<LgWindow>();
        }

        /// <summary>
        /// Start the processes in this configuration
        /// </summary>
        /// <returns></returns>
        internal Boolean StartProcesses()
        {
            Boolean allOk = true;
            foreach (LgWindow m in Windows)
            {
                allOk &= LgProcessManager.Start(m.Process);
            }

            return allOk;
        }

        /// <summary>
        /// Move the window to the position specified in the config
        /// </summary>
        /// <returns></returns>
        internal Boolean RepositionWindows()
        {
            Boolean allOk = true;
            foreach (LgWindow m in Windows)
            {
                allOk &= LgProcessManager.Reposition(m);
            }

            return allOk;
        }

        /// <summary>
        /// Add new Window to the config from a coordinate in the screen. Usually from a mouse click.
        /// </summary>
        /// <param name="point">point in screen</param>
        /// <returns></returns>
        internal Boolean AddWindow(LgPoint point)
        {
            Boolean result = true;
            Process p = LgProcessManager.GetProcessAtCoordiante(point);
            // before adding check if it is current process
            if (!LgProcessManager.IsCurrentProcess(p))
            {
                LgProcess process = LgProcess.FromProcess(p);
                LgRectangle rec = LgProcessManager.GetWindowRectange(process);
                LgWindow window = new LgWindow(rec.GetTopLeft(), rec.GetSize(), process);
                // add to list
                Windows.Add(window);
                Console.WriteLine(window);
            }else
            {
                result = false;
            }
            
            return result; 
        }

        /// <summary>
        /// Show windows if they are hidden
        /// </summary>
        internal void ShowWindows()
        {
            Windows.ForEach((m) => m.Show());
        }

        /// <summary>
        /// Show windows if they are hidden
        /// </summary>
        internal void MinimizeWindows()
        {
            Windows.ForEach((m) => m.Minimize());
        }

        /// <summary>
        /// Save config to file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal Boolean WriteToFile(string path)
        {
            if (Filepath == null) {
                 Filepath = Path.Combine(path, GenerateString(10) + ".json");
            }
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(Filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, this);
            }
            return true;
        }

        /// <summary>
        /// Load config from file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static LgConfig FromFile(string filepath)
        {
            LgConfig newConfig = JsonConvert.DeserializeObject<LgConfig>(File.ReadAllText(filepath));
            newConfig.Filepath = filepath;

            return newConfig;
        }

        /// <summary>
        /// Delete config file from drive.
        /// </summary>
        /// <returns></returns>
        public Boolean DeleteFile()
        {
            if (File.Exists(Filepath)) {
                File.Delete(Filepath);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Updates the changes that the windows positions made
        /// </summary>
        internal void UpdateAndSaveChanges()
        {
            // update each window
            Windows.ForEach((m) => m.UpdatePosition());
            
            // save to disk
            WriteToFile(Filepath);
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


        //public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
        public override string ToString() => $"{Title} > {String.Join(",", Windows.Select( (w) => w.Process?.Name))}";
    }
}
