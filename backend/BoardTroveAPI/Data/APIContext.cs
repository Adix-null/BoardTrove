using BoardTroveAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BoardTroveAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasePost>()
                .HasDiscriminator<string>("post_type")
                .HasValue<FENPost>("FEN")
                .HasValue<PGNPost>("PGN");
        }

        public DbSet<BasePost> Posts { get; set; }
        public DbSet<FENPost> FENPosts { get; set; }
        public DbSet<PGNPost> PGNPosts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
