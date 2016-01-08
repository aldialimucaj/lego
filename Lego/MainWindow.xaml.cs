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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Process process = new Process();

            LegoWindow lw = new LegoWindow(p1, p2, process);
            LegoConfig c = new LegoConfig();
            c.Windows.Add(lw);

            Console.WriteLine(c);
        }
    }
}
