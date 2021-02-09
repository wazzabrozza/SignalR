using Microsoft.AspNetCore.SignalR;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{ 
    public class NotificationHub : Hub<INotificationHub>, INotificationHubRepository
    {
        public async Task SendNotificationToUser(Notification notification, int userId)
        {
            var user;

            await Clients.User(user.email).ReceiveNotification(notification);
        }

        public async Task SendNotificationToUsers(Notification notification, List<int> userId)
        {
            var users;

            foreach (var user in users)
            {
                await Clients.Users(user.email).ReceiveNotification(notification);
            };
        }

        public async Task SendNotificationToAll(Notification notification)
        {
            await Clients.All.ReceiveNotification(notification);
        }

        public async Task SendNotificationToGroup(Notification notification, string groupName)
        {
            await Clients.Group(groupName).ReceiveNotification(notification);
        }
    }
}
