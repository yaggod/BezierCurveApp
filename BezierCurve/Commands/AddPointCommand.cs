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
        private ObservableCollection<Point> _pointsCollection;

        public AddPointCommand(ObservableCollection<Point> PointsCollection)
        {
            _pointsCollection = PointsCollection;
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FrameworkElement target = parameter as FrameworkElement;
            Point position = Mouse.GetPosition(target);
            
            _pointsCollection.Add(position);

        }
    }
}
