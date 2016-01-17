using Lego.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego.ViewModels
{
    public class LegoViewModel : INotifyPropertyChanged
    {

        ObservableCollection<LgConfig> _Configs = new ObservableCollection<LgConfig>();
        
        public ObservableCollection<LgConfig> Configs
        {
            get { return _Configs; }
            set
            {
                _Configs = value;
                OnPropertyChanged("Configs");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
