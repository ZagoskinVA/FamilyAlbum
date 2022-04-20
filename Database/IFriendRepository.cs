using FamilyAlbum.Models;

namespace FamilyAlbum.Database
{
    public interface IFriendRepository
    {
        Task SaveFriend(Friend friend);
    }
}
