using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Models
{
    public class UserNotificationModel
    {
        public int UserNotificationId { get; set; }
        public User User { get; set; }
        public Notification Notification { get; set; }
    }
}
