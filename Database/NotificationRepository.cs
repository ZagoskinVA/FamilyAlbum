using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;

namespace FamilyAlbum.Database
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationContext context;
        public NotificationRepository(ApplicationContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));
            this.context = context;
        }
        public IEnumerable<Notification> GetNotifications(string email)
        {
            return context.Notifications.Where(x => x.EmailUserTo == email).AsEnumerable();
        }

        public async Task SaveNotificationASync(Notification notification)
        {
            if (notification.Title == "Запрос в друзья")
            {
                var oldNotification = context.Notifications.FirstOrDefault(x => x.UserFrom == notification.UserFrom && x.EmailUserTo == notification.EmailUserTo && x.Title == notification.Title);
                if (oldNotification != null)
                {
                    oldNotification.Message = notification.Message;
                }

            }
            context.Notifications.Add(notification);
            await context.SaveChangesAsync();
        }
    }
}
