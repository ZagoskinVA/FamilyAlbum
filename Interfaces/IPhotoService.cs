using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface IPhotoService
    {
        Task SavePhotoAsync(Photo photo);
        Task RemovePhotoAsync(Photo photo);
        IEnumerable<Photo> GetAllPhotos(string userId);
    }
}
