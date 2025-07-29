using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace BoardTroveAPI.Models
{
    public abstract class BasePost
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public required string Title { get; set; }
        public string? Description { get; set; } = "";

        public required string? UserId { get; set; }
        public User? User { get; set; }
    }
}
