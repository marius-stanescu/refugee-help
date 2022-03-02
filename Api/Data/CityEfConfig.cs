using BlazorApp.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data
{
    public class CityEfConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property<int>("Id");
            builder.HasKey("Id");

            builder.HasOne(x => x.Region)
                .WithMany(y => y.Cities)
                .HasForeignKey(x => x.RegionId);
        }
    }
}
