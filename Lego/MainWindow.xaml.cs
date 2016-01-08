using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        LgConfig c = null;
        IOManager io = null;

        public MainWindow()
        {
            InitializeComponent();
            c = new LgConfig();
            io = new IOManager(null);
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            //LgPoint p1 = new LgPoint(10, 10);
            //LgSize s1 = new LgSize(100, 100);
            //LgProcess process = new LgProcess("Notepad",null, "notepad.exe",null);

            //LgWindow lw = new LgWindow(p1, s1, process);
            //c.Windows.Add(lw);

            //Console.WriteLine(c);

            //c.StartProcesses();
            //c.RepositionWindows();
            io.Start();
        }

        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            io.Stop();
        }
    }
}
