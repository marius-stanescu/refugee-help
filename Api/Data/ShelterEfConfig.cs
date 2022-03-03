using BlazorApp.Api.Domain;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data
{
    public class ShelterEfConfig : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Period).HasDefaultValue(TimePeriod.OneToThreeDays);

            builder.OwnsOne(t => t.ContactPerson, b =>
            {
                b.WithOwner().HasForeignKey("ShelterId");

                b.Property(cp => cp.Name).IsRequired();
                b.Property(cp => cp.Phone).IsRequired();
            });

            builder.OwnsOne(s => s.Address, b =>
            {
                b.WithOwner().HasForeignKey("ShelterId");

                b.HasOne(a => a.Region)
                    .WithMany()
                    .HasForeignKey(a => a.RegionId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(a => a.City)
                    .WithMany()
                    .HasForeignKey(a => a.CityId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
