using Lego.Commands;
using Lego.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lego.ViewModels
{
    public class LegoViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<LgConfig> _Configs = new ObservableCollection<LgConfig>();
        private ICommand _StartCollectingCommand;
        private ICommand _StopCollectingCommand;
        private Boolean _Collecting;

        public LegoViewModel()
        {
            Debug.Write("public LegoViewModel()");
            _StartCollectingCommand = new StartCollectingCommand();
            _StopCollectingCommand = new StopCollectingCommand();
        }
        
        public ObservableCollection<LgConfig> Configs
        {
            get { return _Configs; }
            set
            {
                _Configs = value;
                OnPropertyChanged("Configs");
            }
        }

        public ICommand StartCollectingCommand
        {
            get { return _StartCollectingCommand; }
            set
            {
                _StartCollectingCommand = value;
                OnPropertyChanged("StartCollectingCommand");
            }
        }

        public ICommand StopCollectingCommand
        {
            get { return _StopCollectingCommand; }
            set
            {
                _StopCollectingCommand = value;
                OnPropertyChanged("StopCollectingCommand");
            }
        }

        public Boolean IsCollecting
        {
            get { return _Collecting; }
            set
            {
                _Collecting = value;
                OnPropertyChanged("_Collecting");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
