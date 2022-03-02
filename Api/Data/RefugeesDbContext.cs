using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Api.Data
{
    public class RefugeesDbContext : DbContext
    {
        public RefugeesDbContext(DbContextOptions<RefugeesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RefugeesDbContext).Assembly);
        }
    }
}
