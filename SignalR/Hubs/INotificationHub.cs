using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    interface INotificationHub
    {
        Task ReceiveNotification(Notification notification);
    }
}
