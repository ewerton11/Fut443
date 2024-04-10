﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Aggregates.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChampionshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("Domain.Aggregates.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AwayTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int");

                    b.Property<Guid>("HomeTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("RoundId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("Domain.Aggregates.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChampionshipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Domain.Aggregates.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompetitionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Domain.Entities.AdminEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa6535b0-dcdd-4931-92b4-4a0f3ee67823"),
                            Email = "ewerton@gmail.com",
                            FirstName = "ewerton",
                            LastName = "Root",
                            Level = 2,
                            PasswordHash = "$2a$11$kbJMVBwTxTjoZlRl/SwPQeKrCQbIPabdjwVjnMcvKNoXfCmYycKae"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ChampionshipEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentPhase")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalRounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("Domain.Entities.ClubChampionship", b =>
                {
                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChampionshipId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClubId", "ChampionshipId");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("ClubChampionship");
                });

            modelBuilder.Entity("Domain.Entities.ClubEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trainer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("Domain.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AerialBallsClaimed")
                        .HasColumnType("int");

                    b.Property<int>("AerialDuels")
                        .HasColumnType("int");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("BallLoss")
                        .HasColumnType("int");

                    b.Property<int>("BlockedKicks")
                        .HasColumnType("int");

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CompletionsForOut")
                        .HasColumnType("int");

                    b.Property<int>("CompletionsInGoal")
                        .HasColumnType("int");

                    b.Property<int>("Cross")
                        .HasColumnType("int");

                    b.Property<int>("DecisivePasses")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("DefenseCuts")
                        .HasColumnType("int");

                    b.Property<int>("DefensesWithinTheArea")
                        .HasColumnType("int");

                    b.Property<int>("Disarm")
                        .HasColumnType("int");

                    b.Property<int>("Fouls")
                        .HasColumnType("int");

                    b.Property<int>("FoulsSuffered")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("GroundDuels")
                        .HasColumnType("int");

                    b.Property<int>("Interceptions")
                        .HasColumnType("int");

                    b.Property<int>("LongBalls")
                        .HasColumnType("int");

                    b.Property<int>("MissedChances")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Punches")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("SuccessfulPasses")
                        .HasColumnType("int");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Aggregates.Competition", b =>
                {
                    b.HasOne("Domain.Entities.ChampionshipEntity", "Championship")
                        .WithMany()
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");
                });

            modelBuilder.Entity("Domain.Aggregates.Match", b =>
                {
                    b.HasOne("Domain.Entities.ClubEntity", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ClubEntity", "HomeTeam")
                        .WithMany("Matches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Aggregates.Round", "Round")
                        .WithMany("Matches")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Domain.Aggregates.Round", b =>
                {
                    b.HasOne("Domain.Entities.ChampionshipEntity", "Championship")
                        .WithMany("Rounds")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");
                });

            modelBuilder.Entity("Domain.Aggregates.Team", b =>
                {
                    b.HasOne("Domain.Aggregates.Competition", null)
                        .WithMany("Teams")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithOne("Team")
                        .HasForeignKey("Domain.Aggregates.Team", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ClubChampionship", b =>
                {
                    b.HasOne("Domain.Entities.ChampionshipEntity", "Championship")
                        .WithMany("ClubChampionships")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ClubEntity", "Club")
                        .WithMany("ClubChampionships")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Domain.Entities.PlayerEntity", b =>
                {
                    b.HasOne("Domain.Entities.ClubEntity", "ClubEntity")
                        .WithMany("Players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Aggregates.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("ClubEntity");
                });

            modelBuilder.Entity("Domain.Aggregates.Competition", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Domain.Aggregates.Round", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Domain.Aggregates.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Domain.Entities.ChampionshipEntity", b =>
                {
                    b.Navigation("ClubChampionships");

                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("Domain.Entities.ClubEntity", b =>
                {
                    b.Navigation("ClubChampionships");

                    b.Navigation("Matches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
