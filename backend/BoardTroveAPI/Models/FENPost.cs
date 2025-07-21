using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class FENPost : BasePost
    {
        public required string FEN
        { get; set; }
    }
}
