﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TazkartiDataAccessLayer.DbContexts;

#nullable disable

namespace TazkartiDataAccessLayer.Migrations
{
    [DbContext(typeof(TazkartiDbContext))]
    partial class TazkartiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.24");

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.MatchDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Linesmen1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Linesmen2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Referee")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StadiumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Matches");

                    b.HasCheckConstraint("CK_Match_Team", "HomeTeamId <> AwayTeamId");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.SeatDbModel", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReservedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatchId", "Number");

                    b.HasIndex("UserId");

                    b.HasIndex("MatchId", "UserId")
                        .IsUnique();

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.StadiumDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VIPLength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VIPWidth")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.TeamDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Al Ahly"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Zamalek"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Al Masry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Al Ittihad Al Sakandary"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Al Mokawloon"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Al Gouna"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Massr El Maqasah"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pyramids"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Modern Future"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Ghazel Al Mahalla"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Baladeit Al Mahalla"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Farco"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Tanta"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Aswan"
                        },
                        new
                        {
                            Id = 15,
                            Name = "El Sharkia"
                        },
                        new
                        {
                            Id = 16,
                            Name = "El Entag El Harby"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Zed"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Saramika Celiopatra"
                        });
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.UserDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2023, 12, 17, 13, 5, 41, 450, DateTimeKind.Local).AddTicks(2536),
                            Password = "AQAAAAEAACcQAAAAEOYxMlMfiyJz1mbgW81M0ap6FdaEYndumqz4pESkwohGdesy/P4V9yQzcKiuzdBgqA==",
                            Role = 0,
                            Status = 0,
                            Username = "adhamali"
                        });
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.MatchDbModel", b =>
                {
                    b.HasOne("TazkartiDataAccessLayer.Models.TeamDbModel", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TazkartiDataAccessLayer.Models.TeamDbModel", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TazkartiDataAccessLayer.Models.StadiumDbModel", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.SeatDbModel", b =>
                {
                    b.HasOne("TazkartiDataAccessLayer.Models.MatchDbModel", "Match")
                        .WithMany("Seats")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TazkartiDataAccessLayer.Models.UserDbModel", "User")
                        .WithMany("Seats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.MatchDbModel", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.StadiumDbModel", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.TeamDbModel", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("HomeMatches");
                });

            modelBuilder.Entity("TazkartiDataAccessLayer.Models.UserDbModel", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
