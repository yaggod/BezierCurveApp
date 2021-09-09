using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveApp
{
    class BezierCurve
    {
        private readonly Point[] points;
        private int dots;
        public int PtsCount { get => dots; }
        public Point[] Result { get; }
        public BezierCurve(IEnumerable<Point> points, int resultPointsCount)
        {
            this.points = points.ToArray();
            dots = resultPointsCount;
            Result = new Point[dots];
            CalculatePath();

        }


        private static Point CalculateTwoPoints(Point p0, Point p1, float t)
        {
            return (1 - t) * p0 + t * p1;
        }
        private Point CalculatePoint(float t)
        {
            
            int counter = 1;
            Point[] temp = points;
            while (counter < points.Length) {
                for (int i = 0; i < temp.Length - counter; i++)
                {
                    temp[i] = CalculateTwoPoints(temp[i], temp[i + 1], t);
                }
                counter++;
            }
            return temp[0];
        }
        private void CalculatePath()
        {
            for (int t = 0; t < dots; t++)
            {
                Result[t] = CalculatePoint((float)t / (dots - 1));
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Point p in Result)
            {
                sb.Append(p + " ");
            }
            return sb.ToString();
        }
    }
}
