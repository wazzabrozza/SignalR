using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SignalR.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppContext _context;
        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNotification(Notification notification, int userId)
        {
            var user = await _context.Users.GetUser(userId);

            var userNotification = new UserNotificationModel()
            {
                Notification = notification,
                User = user
            };
            _context.Add(userNotification);
            
            _context.Notifications.Add(notification);
            return Save();
        }

        public async Task<bool> CreateNotifications(Notification notification, List<int> userId)
        {
            var users = await _context.Users.GetUsers(userId);

            foreach (var user in users)
            {
                var userNotification = new UserNotificationModel()
                {
                    Notification = notification,
                    User = user
                };
                _context.Add(userNotification);
            }

            _context.Notifications.Add(notification);
            return Save();
        }

        public async Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}
