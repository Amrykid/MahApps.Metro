using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps.Metro.Controls.Notifications
{
    public static class NotificationsManager
    {
        public static Task ShowNotificationAsync()
        {
            var notification = new BaseNotificationsWindow();

            notification.SetInitialPosition();

            notification.Show();

            return notification.ShowAnimated();
        }
    }
}
