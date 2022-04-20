using FamilyAlbum.Database;
using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;

namespace FamilyAlbum.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository friendRepository;
        private readonly INotificationRepository notificationRepository;
        private readonly IUserRepository userRepository;
        public FriendService(IFriendRepository friendRepository, INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            if(friendRepository == null)
                throw new ArgumentNullException(nameof(friendRepository));
            if(notificationRepository == null)
                throw new ArgumentException(nameof(notificationRepository));
            if(userRepository == null)
                throw new ArgumentNullException(nameof(userRepository));
            this.userRepository = userRepository;
            this.friendRepository = friendRepository;
            this.notificationRepository = notificationRepository;
        }
        public async Task AddFriendToUser(string userId, string friendEmail)
        {
            var user = userRepository.GetUserByEmail(friendEmail);
            await friendRepository.SaveFriend(new Friend { Id = user.Id, UserId = userId });
            await friendRepository.SaveFriend(new Friend { Id = userId, UserId = user.Id });
        }

        public IEnumerable<Notification> GetNotoficationToFriend(string userId)
        {
            return notificationRepository.GetNotifications(userId);
        }
    }
}
