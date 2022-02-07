using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface IPhotoRepository
    {
        List<Photo> GetUserPhotos(User user);
        List<Photo> GetFriendsPhoto(User user, bool isFamily);
    }
}
