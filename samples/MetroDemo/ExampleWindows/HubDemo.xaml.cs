using System.Windows;
using MahApps.Metro.Controls;

namespace MetroDemo.ExampleWindows
{
    public partial class HubDemo
    {
        public HubDemo()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            hubControl.Focus();
        }
    }
}
