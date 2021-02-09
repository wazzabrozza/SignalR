using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Models
{
    public class Notification
    {
        int NotificationId { get; set; }
        string Link { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        ICollection<User> Users { get; set; }
    }
}
