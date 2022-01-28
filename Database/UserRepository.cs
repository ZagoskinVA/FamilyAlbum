using FamilyAlbum.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.Database
{
    public class UserRepository
    {
        private readonly ApplicationContext contex;
        public UserRepository(ApplicationContext context)
        {
            this.contex = context;
        }

        public async Task AddUserAsync(User user)
        {
            contex.Users.Add(user);
            await contex.SaveChangesAsync();
        }

        public User GetUserById(string id)
        {
            return contex.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetUsers()
        {
            return contex.Users;
        }

        public List<Photo> GetUserPhotos(User user)
        {
            return contex.Users.Include(x => x.Photos).FirstOrDefault(x => x.Id == user.Id)?.Photos;
        }

        public List<Photo> GetFriendsPhoto(User user, bool isFamily)
        {
            List<Photo> photos  = new List<Photo>();
            var friend = user.Friends.Where(x => isFamily).Select(x => x.Id).ToList();
            var friends = contex.Users.Include(x => x.Photos).Where(x => friend.Contains(x.Id)).ToList();
            friends.ForEach(x => photos.AddRange(x.Photos.Where(q => (isFamily || !q.IsForFamily))));
            return photos;
        }
    }
}
