using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class UserDTO
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Bio { get; set; } = "";
    }
}
