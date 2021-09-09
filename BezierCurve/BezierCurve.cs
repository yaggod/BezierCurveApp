using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BezierCurveApp
{
    public class BezierCurve
    {
        private readonly Point[] _points;
        private int _dots;
        public int PointsCount { get => _dots; }
        public Point[] ResultPoints { get; }
        public BezierCurve(IEnumerable<Point> points, int resultPointsCount)
        {
            _points = points.ToArray();
            _dots = resultPointsCount;
            ResultPoints = new Point[_dots];
            if (_points.Length == 0) return;
            CalculatePath();

        }

        private static Point LinearInterpolation(Point p0, Point p1, float t)
        {
            double x = ((1 - t) * p0.X) + (t * p1.X);
            double y = ((1 - t) * p0.Y) + (t * p1.Y);

            return new Point(x, y);
        }
        private Point CalculateSinglePoint(float t)
        {
            
            int counter = 1;
            Point[] temp = _points;
            while (counter < _points.Length) {
                for (int i = 0; i < temp.Length - counter; i++)
                {
                    temp[i] = LinearInterpolation(temp[i], temp[i + 1], t);
                }
                counter++;
            }
            return temp[0];
        }
        private void CalculatePath()
        { 
            for (int t = 0; t < _dots; t++)
            {
                ResultPoints[t] = CalculateSinglePoint((float)t / (_dots - 1));
            }
        }

        public override string ToString()
        {
            return String.Join(" ", ResultPoints);
        }
    }
}
