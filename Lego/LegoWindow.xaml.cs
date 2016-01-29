using Lego.Other;
using System.Windows;

namespace Lego
{
    /// <summary>
    /// Interaction logic for LegoWindow.xaml
    /// </summary>
    public partial class LegoWindow : Window
    {
        public LegoWindow()
        {
            InitializeComponent();
            // no Icon Tray in XAML
            Bootstrap bootstrap = new Bootstrap(this);
        }
    }
}
