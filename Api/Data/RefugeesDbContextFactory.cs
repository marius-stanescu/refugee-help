using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace BlazorApp.Api.Data
{
    public class RefugeesDbContextFactory : IDesignTimeDbContextFactory<RefugeesDbContext>
    {
        public RefugeesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RefugeesDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new RefugeesDbContext(optionsBuilder.Options);
        }
    }
}
