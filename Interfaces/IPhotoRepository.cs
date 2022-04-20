using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetUserPhotos(string userId);
        IEnumerable<Photo> GetFriendsPhoto(string userId, bool isFamily = true);
        Task SavePhotoAsync(Photo photo);
        Task RemovePhotoAsync(Photo photo);
    }
}
