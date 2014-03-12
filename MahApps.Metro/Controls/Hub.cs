using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahApps.Metro.Controls
{
    [TemplatePart(Name = "PART_TopLevelScrollViewer", Type = typeof(ScrollViewer))]
    public class Hub : HeaderedItemsControl
    {
        private const string PART_TopLevelScrollViewer = "PART_TopLevelScrollViewer";

        private ScrollViewer TopLevelScrollViewer = null;

        static Hub()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Hub), new FrameworkPropertyMetadata(typeof(Hub)));
        }

        public Hub()
        {
            this.Loaded += Hub_Loaded;
            this.Unloaded += Hub_Unloaded;
        }

        void Hub_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= Hub_Loaded;
            this.Unloaded -= Hub_Unloaded;
        }

        void Hub_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new HubSection();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is HubSection;
        }

        public override void OnApplyTemplate()
        {
            TopLevelScrollViewer = GetTemplateChild(PART_TopLevelScrollViewer) as ScrollViewer;

            base.OnApplyTemplate();
        }
    }

    public class HubSection : HeaderedContentControl
    {
        static HubSection()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HubSection), new FrameworkPropertyMetadata(typeof(HubSection)));
        }
    }
}
