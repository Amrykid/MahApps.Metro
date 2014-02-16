using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MahApps.Metro.Controls.Notifications
{
    public static class NotificationsManager
    {
        public static Task ShowBasicNotificationAsync(string title, string message, int duration, object context = null, Action<object> callback = null)
        {
            var notification = new BaseNotificationsWindow();

            notification.SetInitialPosition();

            notification.Title = title;
            notification.Body = message;

            notification.Show();

            return notification.ShowAnimated().ContinueWith(x =>
                Task.Factory.StartNew(() =>
                    Thread.Sleep(duration)).ContinueWith(y =>
                        notification.HideAnimated().ContinueWith(z =>
                            notification.Close())));
        }
    }
}
