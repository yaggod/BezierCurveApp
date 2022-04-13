using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BezierCurveApp.Commands
{
    class OpenSettingsCommand : ICommand
    {
        private SettingsWindow _settingsWindow = new SettingsWindow();

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
            return _settingsWindow.Visibility != Visibility.Visible;
        }

        public void Execute(object parameter)
        {
            _settingsWindow.Show();
        }
    }
}
