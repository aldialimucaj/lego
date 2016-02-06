using Lego.Other;
using System.Windows;
using MahApps.Metro.Controls;

namespace Lego
{
    /// <summary>
    /// Interaction logic for LegoWindow.xaml
    /// </summary>
    public partial class LegoWindow : MetroWindow
    {
        public LegoWindow()
        {
            InitializeComponent();
            // no Icon Tray in XAML
            Bootstrap bootstrap = new Bootstrap(this);
        }
    }
}
