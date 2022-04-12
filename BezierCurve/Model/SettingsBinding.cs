using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BezierCurveApp.Model
{
    public class SettingsBinding : Binding
    {
        public SettingsBinding()
        {
            InitializeBinding();
        }

        public SettingsBinding(string path) : base(path)
        {
            InitializeBinding();
        }

        private void InitializeBinding()
        {
            Source = Properties.Settings.Default;
            Mode = BindingMode.TwoWay;
        }
    }
}
