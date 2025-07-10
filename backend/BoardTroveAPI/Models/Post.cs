using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    //multiple models
    //enum PostType
    //{
    //    Puzzle,
    //    Position,
    //    Game
    //}

    public class Post
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public required string Title
        { get; set; }
        required
        public string? Description
        { get; set; } = "";
        public required string FEN
        { get; set; }

    }
}
