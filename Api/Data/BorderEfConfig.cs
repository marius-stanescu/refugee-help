using System.Linq;
using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data
{
    public class BorderEfConfig : IEntityTypeConfiguration<Border>
    {
        public void Configure(EntityTypeBuilder<Border> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasData(Cache.Borders.Select(b => new Border
            {
                Id = b.Id,
                Name = b.Name,
                NormalizedName = b.NormalizedName,
            }));
        }
    }
}
