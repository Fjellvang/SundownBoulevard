﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SundownBoulevard.Core.Booking.Data;

namespace SundownBoulevard.Core.Migrations
{
    [DbContext(typeof(SundownBoulevardDbContext))]
    [Migration("20210616123242_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SundownBoulevard.Core.Booking.Data.Entities.Booker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bookers");
                });

            modelBuilder.Entity("SundownBoulevard.Core.Booking.Data.Entities.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("SundownBoulevard.Core.Booking.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookerId")
                        .HasColumnType("int");

                    b.Property<long>("BookingEndTicks")
                        .HasColumnType("bigint");

                    b.Property<long>("BookingStartTicks")
                        .HasColumnType("bigint");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTables")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookerId");

                    b.HasIndex("DayId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SundownBoulevard.Core.Booking.Data.Entities.Order", b =>
                {
                    b.HasOne("SundownBoulevard.Core.Booking.Data.Entities.Booker", "Booker")
                        .WithMany()
                        .HasForeignKey("BookerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SundownBoulevard.Core.Booking.Data.Entities.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booker");

                    b.Navigation("Day");
                });
#pragma warning restore 612, 618
        }
    }
}