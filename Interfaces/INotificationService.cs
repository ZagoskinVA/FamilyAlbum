using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface INotificationService
    {
        void Notificate(string message, string key = "notification_message");
        IEnumerable<Notification> GetNotifications(string email);
    }
}
