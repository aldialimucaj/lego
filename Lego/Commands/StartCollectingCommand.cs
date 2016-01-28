using Lego.Models;
using Lego.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lego.Commands
{
    class StartCollectingCommand : ICommand
    {
        
        public LegoViewModel LegoViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return false;

            LegoViewModel = (LegoViewModel)parameter;
            
            return !LegoViewModel.IsCollecting;
        }

        public void Execute(object parameter)
        {
            Trace.WriteLine("executed");
            LegoViewModel.IsCollecting = true;

            LgConfig config = new LgConfig();
            LegoViewModel.Manager = new IOManager(config);
            LegoViewModel.Manager.Start();
        }
    }
}
