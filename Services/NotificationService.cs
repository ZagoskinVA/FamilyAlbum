using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Plain.RabbitMQ;

namespace FamilyAlbum.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublisher publisher;
        private readonly INotificationRepository notificationRepository;
        public NotificationService(IPublisher publisher, INotificationRepository notificationRepository)
        {
            if(publisher == null)
                throw new ArgumentNullException(nameof(publisher));
            if(notificationRepository == null)
                throw new ArgumentNullException(nameof(notificationRepository));
            this.notificationRepository = notificationRepository; 
            this.publisher = publisher;
        }

        public IEnumerable<Notification> GetNotifications(string email)
        {
            return notificationRepository.GetNotifications(email);
        }

        public void Notificate(string message, string key = "notification_message")
        {
            publisher.Publish(message, key, null);
        }
    }
}
