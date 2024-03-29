﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.Data;

#nullable disable

namespace NZWalks.Migrations
{
    [DbContext(typeof(NZWalksDBContext))]
    partial class NZWalksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.Models.Domain.Difficulity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DifficulityScale")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DifficulityScale = 1,
                            Title = "Easy"
                        },
                        new
                        {
                            Id = 2,
                            DifficulityScale = 2,
                            Title = "Moderate"
                        },
                        new
                        {
                            Id = 3,
                            DifficulityScale = 3,
                            Title = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.Models.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Northland"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Auckland"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Waikato"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bay of Plenty"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gisborne"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hawke's Bay"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Taranaki"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Manawatu-Wanganui"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Wellington"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Tasman"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Nelson"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Marlborough"
                        },
                        new
                        {
                            Id = 13,
                            Name = "West Coast"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Canterbury"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Otago"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Southland"
                        });
                });

            modelBuilder.Entity("NZWalks.Models.Domain.WalkingPath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DifficulityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DifficulityId");

                    b.HasIndex("RegionId");

                    b.ToTable("WalkingPaths");
                });

            modelBuilder.Entity("NZWalks.Models.Domain.WalkingPath", b =>
                {
                    b.HasOne("NZWalks.Models.Domain.Difficulity", "Difficulity")
                        .WithMany()
                        .HasForeignKey("DifficulityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulity");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
