using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Repositories
{
    interface INotificationRepository
    {
        ICollection<Notification> GetNotifications();
        Notification GetNotification(int notificationId);
        Task<bool> CreateNotification(Notification notification, int userId);
        Task<bool> CreateNotifications(Notification notification, List<int> userId);
        Task<bool> DeleteNotification(int notificationId);
        Task<bool> Save();
    }
}
