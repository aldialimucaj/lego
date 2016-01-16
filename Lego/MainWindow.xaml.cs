using FMUtils.KeyboardHook;
using Lego.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lego
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private NotifyIcon TrayIcon;
        private Hook KeyboardHook = null;

        ObservableCollection<LgConfig> configs = new ObservableCollection<LgConfig>();
        IOManager io = null;

        public MainWindow()
        {
            InitializeComponent();
            InitLogic();
            InitTray();
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
            CloseMenuItem.Click += new EventHandler((e, b) => {
                this.Close();
                Environment.Exit(0);
            });

            ContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = ContextMenu;
        }

        private void InitLogic()
        {
            LgPersistor.Init();
            LgPersistor.GetAllConfigs().ForEach((c) => configs.Add(c));
            listBox.ItemsSource = configs;

            KeyboardHook = new Hook("Global Action Hook");
            KeyboardHook.KeyUpEvent = ShortCutHandler;
        }

        private void ShortCutHandler(KeyboardHookEventArgs e)
        {
            if (e.Key == Keys.F1 && e.isAltPressed)
            {
                trayTrayIcon_DoubleClick(null, null);
            }
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            LgConfig c = new LgConfig();
            io = new IOManager(c);
            io.Start();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            io.Stop();
            configs.Add(io.Config);
            io.Config.SaveToDirectory(LgPersistor.GetLegoConfigsPath());
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex < 0) return;

            LgConfig c =  configs.ElementAt<LgConfig>(listBox.SelectedIndex);
            c.StartProcesses();
            c.RepositionWindows();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void trayTrayIcon_DoubleClick(object Sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            this.Hide();

            e.Cancel = true;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            LgConfig c = configs.ElementAt<LgConfig>(listBox.SelectedIndex);
            c.UpdateAndSaveChanges();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            LgConfig c = configs.ElementAt<LgConfig>(listBox.SelectedIndex);
            c.ShowWindows();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            LgConfig c = configs.ElementAt<LgConfig>(listBox.SelectedIndex);
            c.MinimizeWindows();
        }
    }
}
