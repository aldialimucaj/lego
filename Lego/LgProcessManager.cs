using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lego
{
    class LgProcessManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// Move and resize the window to the current values
        /// </summary>
        /// <param name="window"></param>
        public static Boolean Reposition(LgWindow window)
        {
            IntPtr hande = window.Process.hwnd;
            if (hande == IntPtr.Zero) return false;
            return MoveWindow(hande, window.TopLeft.X, window.TopLeft.Y, window.Size.Width, window.Size.Height, true);
        }

        /// <summary>
        /// Starts process and sets the handler to the object
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static Boolean Start(LgProcess process)
        {
            try
            {
                Process p = Process.Start(process.Filename, process.Arguments);
                
                // wait a little in order for the handler to be assigned
                p.WaitForInputIdle();
                process.hwnd = p.MainWindowHandle;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return process.hwnd != null;
        }

        /// <summary>
        /// Checks if the process name matches any running processes
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static Boolean isRunning(LgProcess process)
        {
            return Process.GetProcessesByName(process.Name).Length > 0;
        }
    }
}
