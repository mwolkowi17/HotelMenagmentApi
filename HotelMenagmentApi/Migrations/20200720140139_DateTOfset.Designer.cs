﻿// <auto-generated />
using System;
using HotelMenagmentApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelMenagmentApi.Migrations
{
    [DbContext(typeof(HotelMenagmentContext))]
    [Migration("20200720140139_DateTOfset")]
    partial class DateTOfset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelMenagmentApi.Models.Guest", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("member_since")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelMenagmentApi.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuestID")
                        .HasColumnType("int");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("check_in")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("check_out")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("made_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("GuestID");

                    b.HasIndex("RoomID");

                    b.ToTable("Reserevations");
                });

            modelBuilder.Entity("HotelMenagmentApi.Models.ReservationHistory", b =>
                {
                    b.Property<int>("ReservationHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuestID")
                        .HasColumnType("int");

                    b.Property<string>("GuestName_History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("check_in_History")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("check_out_History")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ReservationHistoryID");

                    b.HasIndex("GuestID");

                    b.HasIndex("RoomID");

                    b.ToTable("ReservationHistory");
                });

            modelBuilder.Entity("HotelMenagmentApi.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("is_ocuppied")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nubmerbeds")
                        .HasColumnType("int");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<bool>("smoke")
                        .HasColumnType("bit");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelMenagmentApi.Models.Reservation", b =>
                {
                    b.HasOne("HotelMenagmentApi.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestID");

                    b.HasOne("HotelMenagmentApi.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("HotelMenagmentApi.Models.ReservationHistory", b =>
                {
                    b.HasOne("HotelMenagmentApi.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestID");

                    b.HasOne("HotelMenagmentApi.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });
#pragma warning restore 612, 618
        }
    }
}
