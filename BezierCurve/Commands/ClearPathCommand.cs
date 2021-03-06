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
    public class ClearPathCommand : ICommand
    {
        private ObservableCollection<Point> _pointsCollection;

        public ClearPathCommand(ObservableCollection<Point> PointsCollection)
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
            return _pointsCollection.Count > 0;
        }

        public void Execute(object parameter)
        {
            _pointsCollection.Clear();
        }
    }
}
