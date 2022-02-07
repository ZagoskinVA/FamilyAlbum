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
        public List<Photo> GetUserPhotos(User user)
        {
            return contex.Users.Include(x => x.Photos).FirstOrDefault(x => x.Id == user.Id)?.Photos;
        }

        public List<Photo> GetFriendsPhoto(User user, bool isFamily)
        {
            return contex.Users.Include(x => x.Friends).ThenInclude(x => x.User).ThenInclude(x => x.Photos).FirstOrDefault(x => x.Id == user.Id)?.Photos;
        }
    }
}
