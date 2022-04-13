using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using BezierCurveApp.Model;
using BezierCurveApp.Commands;

namespace BezierCurveApp
{
    public class MainVM : INotifyPropertyChanged
    {
        #region Fields

        private int _pointsCount = 250;
        private ObservableCollection<Point> _curvePath = new ObservableCollection<Point>();

        public event PropertyChangedEventHandler PropertyChanged;


        #endregion



        #region Properties
        public int PointsCount
        {
            get => _pointsCount;
            set
            {
                _pointsCount = value;
                OnPropertyChanged("BezierCurvePath");
            }
        }

        public ObservableCollection<Point> CurvePath
        {
            get => _curvePath;
        }

        public Point[] BezierCurvePath
        {
            get => CurveHelper.BezierPathFromNormalPathAndCount(CurvePath, PointsCount);
        }


        public ICommand ApplicationExitCommand
        {
            get;
        } = new ApplicationExitCommand();

        public ICommand ClearPathCommand
        {
            get;
            private set;
        }

        public ICommand AddPointCommand
        {
            get;
            private set;
        }

        public ICommand RemovePointCommand
        {
            get;
            private set;
        }


        public ICommand OpenSettingsCommand
        {
            get;
        } = new OpenSettingsCommand();

        #endregion


        public MainVM()
        {
            CurvePath.CollectionChanged += (s, e) => OnPropertyChanged("BezierCurvePath");
            CurvePath.CollectionChanged += (s, e) => OnPropertyChanged("CurvePath");

            AddPointCommand = new AddPointCommand(CurvePath);
            RemovePointCommand = new RemovePointCommand(CurvePath);
            ClearPathCommand = new ClearPathCommand(CurvePath);
        }
        private  void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
