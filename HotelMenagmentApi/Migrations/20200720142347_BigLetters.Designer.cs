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
    [Migration("20200720142347_BigLetters")]
    partial class BigLetters
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

                    b.Property<DateTimeOffset>("Member_since")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
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

                    b.Property<DateTimeOffset>("Check_in")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Check_out")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("GuestID")
                        .HasColumnType("int");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Made_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
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

                    b.Property<DateTimeOffset>("Check_in_History")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Check_out_History")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("GuestID")
                        .HasColumnType("int");

                    b.Property<string>("GuestName_History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

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

                    b.Property<bool>("Is_ocuppied")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nubmerbeds")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<bool>("Smoke")
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
