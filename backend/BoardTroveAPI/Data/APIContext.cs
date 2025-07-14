using Microsoft.EntityFrameworkCore;
using BoardTroveAPI.Models;

namespace BoardTroveAPI.Data
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
