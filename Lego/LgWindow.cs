using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    class LgWindow
    {

        public LgPoint TopLeft { get; set; }
        public LgSize Size { get; set; }

        public LgProcess Process { get; set; }

        public LgWindow()
        {

        }

        public LgWindow(LgPoint top, LgPoint bottom, LgProcess process)
        {
            TopLeft = top;
            Process = process;
        }

        public LgWindow(LgPoint top, LgSize size, LgProcess process)
        {
            TopLeft = top;
            Size = size;
            Process = process;
        }

        /// <summary>
        /// Update coordiantes of this windows.
        /// 
        /// When the window is moved and the changes need to be saved then this function updates the changes.
        /// </summary>
        internal void UpdatePosition()
        {
            LgRectangle rec = LgProcessManager.GetWindowRectange(Process);
            TopLeft.X = rec.X1;
            TopLeft.Y = rec.Y1;
            Size = rec.GetSize();
        }

        /// <summary>
        /// Show window if minimized.
        /// </summary>
        internal void Show()
        {
            LgProcessManager.ShowWindow(Process);
        }

        /// <summary>
        /// Minimize window
        /// </summary>
        internal void Minimize()
        {
            LgProcessManager.MinimizeWindow(Process);
        }

        public override string ToString() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
