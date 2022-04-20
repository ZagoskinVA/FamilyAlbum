using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.Database
{
    public class UserRepository : IUserRepository
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

        public User GetUserByEmail(string email)
        {
            return contex.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserById(string id)
        {
            return contex.Users.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetUsers()
        {
            return contex.Users;
        }
    }
}
