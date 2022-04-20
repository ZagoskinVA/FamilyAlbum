using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyAlbum.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        public string Title { get; init; }
        public string Message { get; set; }
        public string UserFrom { get; set; }
        public string EmailUserTo { get; set; }
    }
}
