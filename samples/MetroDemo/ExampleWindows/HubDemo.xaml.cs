using System.Windows;
using MahApps.Metro.Controls;

namespace MetroDemo.ExampleWindows
{
    public partial class HubDemo
    {
        public HubDemo()
        {
            InitializeComponent();

            this.SizeChanged += HubDemo_SizeChanged;
        }

        void HubDemo_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            headerHub.Width = this.ActualWidth - 100;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            hubControl.Focus();
        }
    }
}
