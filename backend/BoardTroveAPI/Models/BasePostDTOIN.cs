using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class BasePostDTOIN
    {
        public required string Title { get; set; }
        public string? Description { get; set; } = "";

        public required string? UserId { get; set; }
    }
}
