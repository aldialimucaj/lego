using Lego.Models;
using Lego.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lego.Commands
{
    class OpenCommand : ICommand
    {
        public LegoViewModel LegoViewModel { get; set; }
        public LgConfig Config { get; set; }


        public OpenCommand(LegoViewModel viewModel)
        {
            LegoViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null || LegoViewModel.IsCollecting) return false;

            Config = (LgConfig)parameter;

            return !Config.IsRunningAny;
        }

        public void Execute(object parameter)
        {
            Config.StartProcesses();
            Config.RepositionWindows();
        }
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
    }
}
