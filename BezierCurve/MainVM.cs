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
        private ObservableCollection<Point> _curvePath = new ObservableCollection<Point>()
        {
            
            new Point(145, 234),   
            new Point(345, 234),   
            new Point(245, 404),   
            new Point(108, 14)  
           

        };
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

        public ICommand ClearPathCommand
        {
            get;
        } = new ClearPathCommand();

        public ICommand ApplicationExitCommand
        {
            get;
        } = new ApplicationExitCommand();

        public ICommand AddPointCommand
        {
            get;
        } = new AddPointCommand();


        #endregion


        public MainVM()
        {
            CurvePath.CollectionChanged += (s, e) => OnPropertyChanged("BezierCurvePath");
            CurvePath.CollectionChanged += (s, e) => OnPropertyChanged("CurvePath");


        }
        private  void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

        public void AddPointOn(Point position)
        {
            CurvePath.Add(position);
        }
    }
}
