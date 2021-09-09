using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BezierCurveApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GUISettings _settings = new GUISettings();
        private Dictionary<Rectangle, Point> _rectanglesPositions = new Dictionary<Rectangle, Point>();
        public MainWindow()
        {
            _settings.RectangleColor = Color.FromArgb(128,0,0,0);
            InitializeComponent();
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);   
        }

        private void Canvas_Click(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(Field);
            InitializeAndAddRectangle(position, 15);

        }

        public void Clear(object sender, RoutedEventArgs e)
        {

            foreach (Rectangle rectangle in _rectanglesPositions.Keys.ToArray()) 
            {
                RemoveRectangle(rectangle);
            }
            UpdateLines();
        }

        private void InitializeAndAddRectangle(Point position, double size)
        {
            Brush brush = new SolidColorBrush(_settings.RectangleColor);
            Rectangle rect = new Rectangle()
            {
                Height = size,
                Width = size,
                Fill = brush,
                
            };
            AddRectangle(rect, position);
            UpdateLines();
            rect.MouseRightButtonUp += (sender, eventArgs) => {
                RemoveRectanglesAndUpdateDictionary(rect);
                UpdateLines();

            };
                
                

         
          
            
        }

        private void AddRectangle(Rectangle rectangle, Point position)
        {
            Field.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, position.X - rectangle.Width / 2);
            Canvas.SetTop(rectangle, position.Y - rectangle.Height / 2);
            _rectanglesPositions.Add(rectangle, position);
        }

        private void RemoveRectanglesAndUpdateDictionary(Rectangle rectangle)
        {
            RemoveRectangle(rectangle);
            _rectanglesPositions = new Dictionary<Rectangle, Point>(_rectanglesPositions);
        }
        

        private void RemoveRectangles(IEnumerable<Rectangle> rectanglesToDelete)
        {
            foreach(Rectangle rectangle in rectanglesToDelete)
            {
                RemoveRectangle(rectangle);
            }
        }

        private void RemoveRectangle(Rectangle rectangle)
        {
            Field.Children.Remove(rectangle);
            _rectanglesPositions.Remove(rectangle);

        }
       
        private void UpdateLines()
        {
            Line.Points = new PointCollection(_rectanglesPositions.Values);
            UpdateBezierCurve();
            
        }

        private void UpdateBezierCurve()
        {
            BezierCurve tempCurve = new BezierCurve(_rectanglesPositions.Values, 2000);
            BezierCurve.Points = new PointCollection(tempCurve.ResultPoints);
        }
    }


}
