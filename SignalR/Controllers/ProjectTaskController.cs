using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.Hubs;
using SignalR.Models;
using SignalR.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalR.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly INotificationHubRepository _notificationHub;
        private readonly INotificationRepository _notificationRepository;

        public ProjectTaskController(INotificationHubRepository notificationHub,
                                 INotificationRepository notificationRepository)
        {
            _notificationHub = notificationHub;
            _notificationRepository = notificationRepository;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult> AddToProjectTask([FromBody] Notification notification, [FromQuery] List<int> userId, [FromQuery] bool accepted)
        {

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            if (!accepted)
            {
                await _notificationRepository.CreateNotifications(notification, userId);

                await _notificationHub.SendNotificationToUsers(notification, userId);

                return Ok();
            }

            // add user to project task in database
           
            var notificationCreated = ;

            if (!notificationCreated)
            {
                return
            }

            // if save is successfull, create notification

            await _notificationRepository.CreateNotifications(notification, userId);

            await _notificationHub.SendNotificationToUsers(notification, userId);

            return Ok();
        }
    }
}
