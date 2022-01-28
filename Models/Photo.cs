using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyAlbum.Models
{
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Title { get; init; }
        public string UserId { get; init; }
        public bool IsForFamily { get; init; }
        public string Tags { get; init; }
        [ForeignKey("UserId")]
        public User User { get; init; }
    }
}
