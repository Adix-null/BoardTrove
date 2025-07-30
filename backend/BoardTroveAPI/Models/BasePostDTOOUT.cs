namespace BoardTroveAPI.Models
{
    public class BasePostDTOOUT
    {
        public DateTime Created { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public required string Title { get; set; }
        public string? Description { get; set; } = "";

        public required string? UserId { get; set; }
    }
}
