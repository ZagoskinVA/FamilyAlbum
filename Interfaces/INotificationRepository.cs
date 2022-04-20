using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNotifications(string email);
        Task SaveNotificationASync(Notification notification);
    }
}
