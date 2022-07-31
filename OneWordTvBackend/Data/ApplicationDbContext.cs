using Microsoft.EntityFrameworkCore;
using OneWordTvBackend.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OneWordTvBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OneWordTvProgram> OneWordTvPrograms { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OneWordTvProgram>()
                .HasIndex(b => b.Day);

            modelBuilder.Entity<OneWordTvProgram>()
                 .Property(b => b.Day)
                .HasConversion<string>();

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)

        {
            var entries = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity is BaseEntity && (
                    entry.State == EntityState.Added
                    || entry.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).Updated_at = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).Created_at = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
