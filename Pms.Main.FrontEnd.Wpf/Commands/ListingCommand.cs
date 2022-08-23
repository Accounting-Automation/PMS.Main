﻿using Microsoft.Toolkit.Mvvm.Input;
using Pms.Main.FrontEnd.Wpf.Stores;
using Pms.Main.FrontEnd.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Wpf.Commands
{
    public class ListingCommand : IRelayCommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IStore _store;

        private bool _canExecute;

        public ListingCommand(IStore store)
        {
            _store = store;
        }


        public bool CanExecute(object? parameter) => _canExecute;


        public async void Execute(object? parameter)
        {
            _canExecute = false;

            try
            {
                await _store.Load();
            }
            catch
            {
            }

            _canExecute = true;
            NotifyCanExecuteChanged();
        }

        public void NotifyCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}