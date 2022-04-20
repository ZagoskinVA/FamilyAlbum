using FamilyAlbum.Models;

namespace FamilyAlbum.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        User GetUserById(string id);
        User GetUserByEmail(string email);
        IQueryable<User> GetUsers();
    }
}
