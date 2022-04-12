using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace BezierCurveApp.Model
{
    public static class CurveHelper
    {
       
        public static Point[] BezierPathFromNormalPathAndCount(IEnumerable<Point> points, int count)
        {
            BezierCurve curve = new BezierCurve(count);
            curve.Points = points;
            return curve.ResultPoints;
            
        }
    }
}
