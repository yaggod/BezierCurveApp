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
    public class RemovePointCommand : ICommand
    {
        private ObservableCollection<Point> _pointsCollection;

        public RemovePointCommand(ObservableCollection<Point> PointsCollection)
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
            Point pointToRemove= (Point)parameter;
            _pointsCollection.Remove(pointToRemove);
        }
    }
}
