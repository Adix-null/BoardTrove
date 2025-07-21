using System.ComponentModel.DataAnnotations;

namespace BoardTroveAPI.Models
{
    public class PGNPost : BasePost
    {
        public required string PGN
        { get; set; }
    }
}
