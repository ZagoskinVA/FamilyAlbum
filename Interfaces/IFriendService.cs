using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface IFriendService
    {
        IEnumerable<Notification> GetNotoficationToFriend(string userId);
        Task AddFriendToUser(string userId, string friendEmail);
    }
}
