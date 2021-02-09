using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using SignalR.Hubs;
using SignalR.Models;
using SignalR.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalR.Controllers
{
    public class InvitationController : Controller
    {
        private readonly INotificationHubRepository _notificationHub;
        private readonly INotificationRepository _notificationRepository;

        public InvitationController(INotificationHubRepository notificationHub,
                                 INotificationRepository notificationRepository)
        { 
            _notificationHub = notificationHub;
            _notificationRepository = notificationRepository;
        }


        // This method accepts a list of userId's to account for single and multiple invites
        [HttpPost]
        public async Task<ActionResult> InviteUsers([FromBody] Notification notification, [FromQuery] List<int> userId)
        {
            // create notification in database
            var notificationCreated = await _notificationRepository.CreateNotifications(notification, userId);

            // send notification to the user after successfull creation of notification
            if (notificationCreated)
            {
                await _notificationHub.SendNotificationToUsers(notification, userId);
            }

            // Todo: add email notifications?

            return Ok();
        }

        [HttpPost]    
        public async Task<ActionResult> RequestAccess([FromBody] Notification notification, [FromQuery] int userId)
        {

            var notificationCreated = await _notificationRepository.CreateNotification(notification, userId);

            if (notificationCreated)
            {
                await _notificationHub.SendNotificationToUser(notification, userId);
            }

            // Todo: add email notifications?

            return Ok();
        }
    }
}
