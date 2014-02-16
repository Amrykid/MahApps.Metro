using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls.Notifications
{
    public class BaseNotificationsWindow : MetroWindow
    {
        static BaseNotificationsWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseNotificationsWindow), new FrameworkPropertyMetadata(typeof(BaseNotificationsWindow)));
        }

        /*protected*/internal BaseNotificationsWindow()
        {
            ShowMaxRestoreButton = false;
            ShowMinButton = false;
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

        internal virtual void SetInitialPosition()
        {
            this.Width = 0;
            this.Height = 100;
            this.Left = SystemParameters.PrimaryScreenWidth;
            this.Top = SystemParameters.PrimaryScreenHeight / 3.5;
            this.ShowActivated = true;
            this.Topmost = true;
        }

        internal virtual Task ShowAnimated()
        {
            Storyboard sb = new Storyboard();

            DoubleAnimation widthAnimation = new DoubleAnimation(300.0, new Duration(new TimeSpan(0, 0, 0, 0, 700)));

            //Storyboard.SetTarget(widthAnimation, this);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            sb.Children.Add(widthAnimation);

            DoubleAnimation leftAnimation = new DoubleAnimation(SystemParameters.PrimaryScreenWidth - 300.0, new Duration(new TimeSpan(0, 0, 0, 0, 700)));

            //Storyboard.SetTarget(leftAnimation, this);
            Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(Window.LeftProperty));

            sb.Children.Add(leftAnimation);

            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            EventHandler eh = null;
            eh = new EventHandler((o, e) =>
            {
                this.Focus();

                sb.Completed -= eh;
                tcs.TrySetResult(null);
            });
            sb.Completed += eh;

            this.BeginStoryboard(sb);

            return tcs.Task;
        }


        internal virtual Task HideAnimated()
        {
            Storyboard sb = new Storyboard();

            DoubleAnimation widthAnimation = new DoubleAnimation(0.0, new Duration(new TimeSpan(0, 0, 0, 0, 700)));

            //Storyboard.SetTarget(widthAnimation, this);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(FrameworkElement.WidthProperty));

            sb.Children.Add(widthAnimation);

            DoubleAnimation leftAnimation = new DoubleAnimation(SystemParameters.PrimaryScreenWidth, new Duration(new TimeSpan(0, 0, 0, 0, 700)));

            //Storyboard.SetTarget(leftAnimation, this);
            Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(Window.LeftProperty));

            sb.Children.Add(leftAnimation);

            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            EventHandler eh = null;
            eh = new EventHandler((o, e) =>
            {
                this.Focus();

                sb.Completed -= eh;
                tcs.TrySetResult(null);
            });
            sb.Completed += eh;

            this.BeginStoryboard(sb);

            return tcs.Task;
        }
    }
}
