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
        public StartCollectingCommand()
        {
            Debug.Write("public StartCollectingCommand()");
        }

        private LegoViewModel _ViewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return false;

            _ViewModel = (LegoViewModel)parameter;
            
            return true;
        }

        public void Execute(object parameter)
        {
            Trace.WriteLine("executed");
        }
    }
}
