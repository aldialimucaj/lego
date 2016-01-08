using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Lego
{
    class LgProcessManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern IntPtr WindowFromPoint(Point mousePoint);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern bool GetCursorPos(out Point point);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, ExactSpelling = true, SetLastError = true)]
        internal static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

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
                process.WinProcess = p;
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

        /// <summary>
        /// Get window handler under cursor
        /// </summary>
        /// <returns></returns>
        public static IntPtr GetWindowUnderCursor()
        {
            Point ptCursor = new Point();

            if (!(GetCursorPos(out ptCursor)))
                return IntPtr.Zero;

            return WindowFromPoint(ptCursor);
        }

        /// <summary>
        /// Get process under mouse cursor
        /// </summary>
        /// <returns></returns>
        public static Process GetProcessUnderCursor()
        {
            uint pid = 0;
            IntPtr handle = GetWindowUnderCursor();
            GetWindowThreadProcessId(handle, out pid);

            return Process.GetProcessById((int) pid);
        }

        /// <summary>
        /// Get process under mouse cursor
        /// </summary>
        /// <returns></returns>
        public static Process GetProcessAtCoordiante(LgPoint point)
        {
            uint pid = 0;
            Point ptCursor = new Point(point.X, point.Y);
            
            IntPtr handle = WindowFromPoint(ptCursor);
            GetWindowThreadProcessId(handle, out pid);

            return Process.GetProcessById((int)pid);
        }

        /// <summary>
        /// Return the size of the window
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static LgRectangle GetWindowRectange(LgProcess process)
        {
            RECT lpRect = default(RECT);
            GetWindowRect(new HandleRef(process, process.hwnd), out lpRect);

            return new LgRectangle(lpRect.Left, lpRect.Top, lpRect.Right, lpRect.Bottom);
        }
    }
}
