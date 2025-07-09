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
        //public required DateTime Created { get; } = DateTime.Now;
        public required string Title
        { get; set; }
        required
        public string? Description
        { get; set; } = "";
        public required string FEN
        { get; set; }

        //public string? PGN { get; set; }

    }
}
