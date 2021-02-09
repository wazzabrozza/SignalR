using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    interface INotificationHubRepository
    {
        Task SendNotificationToUser(Notification notification, int userId);
        Task SendNotificationToUsers(Notification notification, List<int> userId);
        Task SendNotificationToAll(Notification notification);
        Task SendNotificationToGroup(Notification notification, string groupName);
    }
}
