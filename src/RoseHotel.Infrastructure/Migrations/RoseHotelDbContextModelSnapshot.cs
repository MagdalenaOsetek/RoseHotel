﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoseHotel.Infrastructure.DAL;

namespace RoseHotel.Infrastructure.Migrations
{
    [DbContext(typeof(RoseHotelDbContext))]
    partial class RoseHotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ReservationRoom", b =>
                {
                    b.Property<Guid>("ReservationsReservationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomsRoomId")
                        .HasColumnType("uuid");

                    b.HasKey("ReservationsReservationId", "RoomsRoomId");

                    b.HasIndex("RoomsRoomId");

                    b.ToTable("RoomReservations");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Guest", b =>
                {
                    b.Property<Guid>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("BlackListed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("GuestId");

                    b.HasIndex("GuestId")
                        .IsUnique();

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Paid")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<decimal?>("ToPay")
                        .HasColumnType("numeric");

                    b.HasKey("ReservationId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Capacity")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("RoomId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReservationRoom", b =>
                {
                    b.HasOne("RoseHotel.Domain.Entities.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoseHotel.Domain.Entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Guest", b =>
                {
                    b.OwnsOne("RoseHotel.Domain.ValueObjects.Adress", "Adress", b1 =>
                        {
                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text");

                            b1.HasKey("GuestId");

                            b1.ToTable("Guests");

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsOne("RoseHotel.Domain.ValueObjects.Card", "Card", b1 =>
                        {
                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uuid");

                            b1.HasKey("GuestId");

                            b1.ToTable("Guests");

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.Navigation("Adress");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("RoseHotel.Domain.Entities.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.User", b =>
                {
                    b.HasOne("RoseHotel.Domain.Entities.Guest", "Guest")
                        .WithOne("User")
                        .HasForeignKey("RoseHotel.Domain.Entities.User", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("RoseHotel.Domain.Entities.Guest", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
