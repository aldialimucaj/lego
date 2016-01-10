using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<LgConfig> configs = new ObservableCollection<LgConfig>();
        IOManager io = null;

        public MainWindow()
        {
            InitializeComponent();
            LgPersistor.Init();
            LgPersistor.GetAllConfigs().ForEach((c) => configs.Add(c));
            listBox.ItemsSource = configs;
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
            io.Config.WriteToFile(LgPersistor.GetLegoPath());
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            LgConfig c =  configs.ElementAt<LgConfig>(listBox.SelectedIndex);
            c.StartProcesses();
            c.RepositionWindows();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
