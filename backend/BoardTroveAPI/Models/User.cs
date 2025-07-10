using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string bio { get; set; }
    }
}
