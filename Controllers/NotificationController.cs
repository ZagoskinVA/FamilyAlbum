using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FamilyAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;
        private readonly INotificationRepository notificationRepository;
        public NotificationController(INotificationService notificationService, INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
            if (notificationService == null)
                throw new ArgumentNullException(nameof(notificationService));
            this.notificationService = notificationService;
        }
        [HttpPost]
        public async Task<IActionResult> Notififcate(Notification notification)
        {
            var message = JsonSerializer.Serialize<Notification>(notification);
            //notificationService.Notificate(message);
            await notificationRepository.SaveNotificationASync(notification);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetNotification(string email) 
        {
            return Ok(notificationService.GetNotifications(email));
        }
    }
}
