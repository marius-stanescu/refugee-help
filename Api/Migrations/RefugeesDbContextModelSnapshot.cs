﻿// <auto-generated />
using System;
using BlazorApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    [DbContext(typeof(RefugeesDbContext))]
    partial class RefugeesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorApp.Api.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Shelter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdultCapacity")
                        .HasColumnType("int");

                    b.Property<bool>("AllowsPets")
                        .HasColumnType("bit");

                    b.Property<int>("ChildrenCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxPeriodInDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shelter");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Transport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdultSeats")
                        .HasColumnType("int");

                    b.Property<int>("ChildSeats")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpiresOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transport");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.City", b =>
                {
                    b.HasOne("BlazorApp.Api.Domain.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Shelter", b =>
                {
                    b.OwnsOne("BlazorApp.Api.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ShelterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<int>("RegionId")
                                .HasColumnType("int");

                            b1.HasKey("ShelterId");

                            b1.HasIndex("CityId");

                            b1.HasIndex("RegionId");

                            b1.ToTable("Shelter");

                            b1.HasOne("BlazorApp.Api.Domain.City", "City")
                                .WithMany()
                                .HasForeignKey("CityId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.HasOne("BlazorApp.Api.Domain.Region", "Region")
                                .WithMany()
                                .HasForeignKey("RegionId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("ShelterId");

                            b1.Navigation("City");

                            b1.Navigation("Region");
                        });

                    b.OwnsOne("BlazorApp.Api.Domain.ContactPerson", "ContactPerson", b1 =>
                        {
                            b1.Property<Guid>("ShelterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ShelterId");

                            b1.ToTable("Shelter");

                            b1.WithOwner()
                                .HasForeignKey("ShelterId");
                        });

                    b.Navigation("Address");

                    b.Navigation("ContactPerson");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Transport", b =>
                {
                    b.OwnsOne("BlazorApp.Api.Domain.ContactPerson", "ContactPerson", b1 =>
                        {
                            b1.Property<Guid>("ShelterId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ShelterId");

                            b1.ToTable("Transport");

                            b1.WithOwner()
                                .HasForeignKey("ShelterId");
                        });

                    b.OwnsOne("BlazorApp.Api.Domain.Address", "Destination", b1 =>
                        {
                            b1.Property<Guid>("TransportId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<int>("RegionId")
                                .HasColumnType("int");

                            b1.HasKey("TransportId");

                            b1.HasIndex("CityId");

                            b1.HasIndex("RegionId");

                            b1.ToTable("Transport");

                            b1.HasOne("BlazorApp.Api.Domain.City", "City")
                                .WithMany()
                                .HasForeignKey("CityId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.HasOne("BlazorApp.Api.Domain.Region", "Region")
                                .WithMany()
                                .HasForeignKey("RegionId")
                                .OnDelete(DeleteBehavior.NoAction)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("TransportId");

                            b1.Navigation("City");

                            b1.Navigation("Region");
                        });

                    b.Navigation("ContactPerson");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("BlazorApp.Api.Domain.Region", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
