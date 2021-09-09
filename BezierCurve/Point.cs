using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveApp
{
    struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public Point(string s)
        {
            string[] ss = s.Split(':');
            X = float.Parse(ss[0]);
            Y = float.Parse(ss[1]);
        }

        public static Point operator *(Point p1, float numb) => new Point(p1.X * numb, p1.Y * numb);
        public static Point operator *(float numb, Point p1) => new Point(p1.X * numb, p1.Y * numb);
        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        public override string ToString()
        {
            return $"({X};{Y})";
        }
        public static explicit operator System.Windows.Point (Point pt) => new System.Windows.Point(pt.X,pt.Y);



    }
}
