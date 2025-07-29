using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string PfpLink { get; set; } = string.Empty;

        public string Bio { get; set; } = "";

        public ICollection<BasePost> Posts { get; } = [];
    }
}
