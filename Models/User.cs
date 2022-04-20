using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyAlbum.Models
{
    public class User
    {
        [Key]
        public string Id { get; init; }
        public string Name { get; init; }
        public string FolderPath { get; init; }
        public string Email { get; init; }
        [InverseProperty("UserFriend")]
        public List<Friend> Friends { get; init; }
        public List<Photo> Photos { get; init; }
    }
}
