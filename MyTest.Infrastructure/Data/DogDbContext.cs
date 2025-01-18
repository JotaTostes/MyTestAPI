using Microsoft.EntityFrameworkCore;
using MyTest.Application.Entities;

namespace MyTest.Infrastructure.Data
{
    public class DogDbContext : DbContext
    {
        public DogDbContext(DbContextOptions<DogDbContext> options)
            : base(options)
        {
        }
        public DbSet<Breeds> Breeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Breeds>()
                .ToTable("Breed")
                .HasKey(b => b.Id);
        }
    }
}
