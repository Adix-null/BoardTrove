using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public abstract class BasePost
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public required string Title { get; set; }
        public string? Description { get; set; } = "";
    }
}
