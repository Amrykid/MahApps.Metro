using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MahApps.Metro.Controls.Notifications
{
    public abstract class BaseNotificationsWindow: Window
    {
        static BaseNotificationsWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseNotificationsWindow), new FrameworkPropertyMetadata(typeof(BaseNotificationsWindow)));
        }

        public static readonly DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(object), typeof(BaseNotificationsWindow), new PropertyMetadata(null));
        /// <summary>
        /// Gets/sets arbitrary content in the body of the notification window. 
        /// </summary>
        public object Body
        {
            get { return GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }
    }
}
