using System;
using BlazorApp.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp.Api.Data
{
    public class ShelterEfConfig : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            builder.HasKey(t => t.Id);

            builder.OwnsOne(t => t.ContactPerson, b =>
            {
                b.WithOwner().HasForeignKey("ShelterId");

                b.Property(cp => cp.Name).IsRequired();
                b.Property(cp => cp.Phone).IsRequired();
            });

            builder.OwnsOne(t => t.Address, b =>
            {
                b.WithOwner().HasForeignKey("ShelterId");

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
