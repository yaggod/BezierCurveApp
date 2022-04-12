using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BezierCurveApp.Commands
{
    public class AddPointCommand : ICommand
    {
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
            return true;
        }

        public void Execute(object parameter)
        {
            object[] parameters = parameter as object[];
            FrameworkElement target = parameters[0] as FrameworkElement;
            ObservableCollection<Point> pointsCollection = parameters[1] as ObservableCollection<Point>;

            Point position = Mouse.GetPosition(target);
            pointsCollection.Add(position);
        }
    }
}
