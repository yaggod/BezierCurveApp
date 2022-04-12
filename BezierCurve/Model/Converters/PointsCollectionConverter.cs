using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BezierCurveApp.Model.Converters
{
    [ValueConversion(typeof(IEnumerable<System.Windows.Point>), typeof(System.Windows.Media.PointCollection))]
    public class PointsCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new System.Windows.Media.PointCollection(value as IEnumerable<System.Windows.Point>);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
