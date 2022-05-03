﻿// <auto-generated />
using System;
using MinTur.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MinTur.DataAccess.Migrations
{
    [DbContext(typeof(NaturalUruguayContext))]
    [Migration("20200929234221_PhoneNumberAndReservationMessageColumnsOnResort")]
    partial class PhoneNumberAndReservationMessageColumnsOnResort
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.BusinessEntities.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdultsAmount")
                        .HasColumnType("int");

                    b.Property<int>("BabiesAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<int>("KidsAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("ResortId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Resort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.Property<string>("ReservationMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TouristPointId");

                    b.ToTable("Resorts");
                });

            modelBuilder.Entity("Domain.BusinessEntities.TouristPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("RegionId");

                    b.ToTable("TouristPoints");
                });

            modelBuilder.Entity("Domain.BusinessEntities.TouristPointCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "TouristPointId");

                    b.HasIndex("TouristPointId");

                    b.ToTable("TouristPointCategory");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Image", b =>
                {
                    b.HasOne("Domain.BusinessEntities.Resort", null)
                        .WithMany("Images")
                        .HasForeignKey("ResortId");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Reservation", b =>
                {
                    b.HasOne("Domain.BusinessEntities.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");

                    b.HasOne("Domain.BusinessEntities.Resort", "Resort")
                        .WithMany()
                        .HasForeignKey("ResortId");
                });

            modelBuilder.Entity("Domain.BusinessEntities.Resort", b =>
                {
                    b.HasOne("Domain.BusinessEntities.TouristPoint", "TouristPoint")
                        .WithMany("Resorts")
                        .HasForeignKey("TouristPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.BusinessEntities.TouristPoint", b =>
                {
                    b.HasOne("Domain.BusinessEntities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("Domain.BusinessEntities.Region", "Region")
                        .WithMany("TouristPoints")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.BusinessEntities.TouristPointCategory", b =>
                {
                    b.HasOne("Domain.BusinessEntities.Category", "Category")
                        .WithMany("TouristPointCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.BusinessEntities.TouristPoint", "TouristPoint")
                        .WithMany("TouristPointCategory")
                        .HasForeignKey("TouristPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
