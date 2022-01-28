using FamilyAlbum.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyAlbum.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Friend> Friends { get; init; }
        public DbSet<Photo> Photos { get; init; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
