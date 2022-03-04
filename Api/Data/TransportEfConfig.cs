using BlazorApp.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data
{
    public class TransportEfConfig : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.AdultCapacity).HasColumnName("AdultSeats");
            builder.Property(t => t.ChildrenCapacity).HasColumnName("ChildSeats");

            builder.OwnsOne(t => t.ContactPerson, b =>
            {
                b.WithOwner().HasForeignKey("ShelterId");

                b.Property(cp => cp.Name).IsRequired();
                b.Property(cp => cp.Phone).IsRequired();
            });

            builder.OwnsOne(t => t.Destination, b =>
            {
                b.WithOwner().HasForeignKey("TransportId");

                b.HasOne(d => d.Region)
                    .WithMany()
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.NoAction);

                b.HasOne(d => d.City)
                    .WithMany()
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
