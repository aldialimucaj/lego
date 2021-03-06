﻿using Lego.Models;
using Lego.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lego.Commands
{
    class DeleteCommand : ICommand
    {
        public LegoViewModel LegoViewModel { get; set; }
        public LgConfig Config { get; set; }


        public DeleteCommand(LegoViewModel viewModel)
        {
            LegoViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null || LegoViewModel.IsCollecting) return false;

            Config = (LgConfig)parameter;

            return true;
        }

        public void Execute(object parameter)
        {
            LegoViewModel.Configs.Remove(Config);
            Config.DeleteFile();
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
