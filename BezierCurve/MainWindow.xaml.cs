using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BezierCurveApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.Text,0);   
        }

        private void Canvas_Click(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = new Rectangle()
            {
                Height = 5,
                Width = 5,
                Fill = Brushes.Black,
            };
            //rect
            Field.Children.Add(rect);
            Canvas.SetLeft(rect, e.GetPosition(Field).X - 2.5);
            Canvas.SetTop(rect, e.GetPosition(Field).Y - 2.5);
        }
    }
    
    
}
