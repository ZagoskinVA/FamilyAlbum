using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyAlbum.Models
{
    public class Friend
    {
        public string Id { get; init; }
        public string UserId { get; init; }
        public bool IsFamily { get; init; } = true;
        [ForeignKey("UserId")]
        public User User { get; init; }
        [ForeignKey("Id")]
        public User UserFriend { get; init; }
    }
}
