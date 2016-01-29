using FMUtils.KeyboardHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lego.Other
{
    public class Bootstrap
    {
        private NotifyIcon TrayIcon;
        private Hook KeyboardHook = null;
        private Window _Window { get; set; }

        public Bootstrap()
        {

        }

        public Bootstrap(Window window)
        {
            _Window = window;
            Init();
        }

        public void Init()
        {
            InitTray();
            InitKeyboardHook();
            InitWindowKeyboardHook();
        }

        private void InitWindowKeyboardHook()
        {
            _Window.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape) _Window.Hide();
        }
        
        private void InitKeyboardHook()
        {
            KeyboardHook = new Hook("Global Action Hook");
            KeyboardHook.KeyUpEvent = ShortCutHandler;
        }

        private void InitTray()
        {
            TrayIcon = new NotifyIcon();
            TrayIcon.Visible = true;
            TrayIcon.Icon = SystemIcons.Asterisk;
            TrayIcon.DoubleClick += new System.EventHandler(this.trayTrayIcon_DoubleClick);

            var ContextMenu = new ContextMenuStrip();
            var CloseMenuItem = new ToolStripMenuItem();
            ContextMenu.SuspendLayout();

            ContextMenu.Items.Add(CloseMenuItem);

            CloseMenuItem.Name = "ContextMenu";
            CloseMenuItem.Text = "Exit";
            CloseMenuItem.Click += new EventHandler((e, b) =>
            {
                _Window.Close();
                Environment.Exit(0);
            });

            ContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = ContextMenu;
        }

        private void trayTrayIcon_DoubleClick(object Sender, EventArgs e)
        {
            _Window.Show();
            _Window.WindowState = WindowState.Normal;
        }

        private void ShortCutHandler(KeyboardHookEventArgs e)
        {
            if (e.Key == Keys.F1 && e.isAltPressed)
            {
                trayTrayIcon_DoubleClick(null, null);
            }
        }
    }
}
