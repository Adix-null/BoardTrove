using Microsoft.EntityFrameworkCore;
using BoardTroveAPI.Models;

namespace BoardTroveAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
            new Post
            {
                ID = "1",
                Title = "Test Post",
                Description = "...",
                FEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
            },
            new Post
            {
                ID = "2",
                Title = "Zugzwang",
                Description = "AlphaZero's zugzwang game",
                FEN = "5rkq/3prp1p/5RpP/p1p5/5QP1/1B6/P4PK1/8 w - - 0 1"
            },
            new Post
            {
                ID = "3",
                Title = "Zugzwang",
                Description = "Nimzo Immortal",
                FEN = "k7/4p3/3pP1b1/2pP1p2/2P1pP2/1B1pP3/3P4/7K w - - 0 1"
            });
        }

        public DbSet<Post> Posts { get; set; }
    }
}
