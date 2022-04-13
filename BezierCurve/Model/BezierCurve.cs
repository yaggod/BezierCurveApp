using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BezierCurveApp.Model
{
    public class BezierCurve
    {
        private IEnumerable<Point> _points;
        public IEnumerable<Point> Points
        {
            
            get => _points;
            set

            {
                
                if (value.Count() == 0)
                {
                    _resultPoints = new Point[0];
                    return;
                }
                _points = value;
                CalculatePath();
            }
       
        }

        private Point[] _resultPoints;
        public Point[] ResultPoints { get => _resultPoints; }   
        public BezierCurve(int resultPointsCount)
        {
            if (resultPointsCount < 2) throw new ArgumentException("Your BezierCurve can not be represented with "
                                                                    + resultPointsCount + " points");
            _resultPoints = new Point[resultPointsCount];
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
            Point[] temp = Points.ToArray();
            while (counter < Points.Count()) {
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
            if (ResultPoints.Length <= 1) return; 
            for (int t = 0; t < ResultPoints.Length; t++)
            {
                ResultPoints[t] = CalculateSinglePoint((float)t / (ResultPoints.Length - 1));
            }
        }

        public override string ToString()
        {
            return String.Join(" ", ResultPoints);
        }
    }
}
