using Microsoft.EntityFrameworkCore;
using PhotoLib.Domain.Entities;

namespace PhotoLib.Infrastructure.Persistence
{
    public class PhotoLibDbContext : DbContext
    {
        public PhotoLibDbContext(DbContextOptions<PhotoLibDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Photo> Photos => Set<Photo>();
    }
}
