using Microsoft.EntityFrameworkCore;

namespace CSE4500.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DogRegistration> DogRegistrations { get; set; }
    }
}
