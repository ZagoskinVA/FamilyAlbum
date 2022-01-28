using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyAlbum.Models
{
    public class Friend
    {
        [Key]
        public string Id { get; init; }
        public string UserId { get; init; }
        public bool IsFamily { get; init; }
        [ForeignKey("UserId")]
        public User User { get; init; }
    }
}
