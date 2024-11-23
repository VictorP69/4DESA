using Microsoft.EntityFrameworkCore;
using social_media.Models;

namespace social_media.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Media> Media => Set<Media>();
        public DbSet<Comments> Comments => Set<Comments>();
    }
}
