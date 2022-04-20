using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.Database
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationContext contex;
        public PhotoRepository(ApplicationContext context)
        {
            this.contex = context;
        }
        public IEnumerable<Photo> GetUserPhotos(string userId)
        {
            return contex.Users.Include(x => x.Photos).FirstOrDefault(x => x.Id == userId)?.Photos;
        }

        public IEnumerable<Photo> GetFriendsPhoto(string userId, bool isFamily = true)
        {
            return contex.Friends.Include(x => x.User).ThenInclude(x => x.Photos).Where(x => x.Id == userId).SelectMany(x => x.User.Photos).AsEnumerable();
        }

        public async Task SavePhotoAsync(Photo photo)
        {
            var oldPhoto = contex.Photos.FirstOrDefault(x => x.UserId == photo.UserId && x.Title == photo.Title);
            if (oldPhoto == null)
            {
                contex.Photos.Add(photo);
            }
            else 
            {
                oldPhoto.Tags = photo.Tags;
            }
            await contex.SaveChangesAsync();
        }

        public async Task RemovePhotoAsync(Photo photo)
        {
            contex.Photos.Remove(photo);
            await contex.SaveChangesAsync();
        }
    }
}
