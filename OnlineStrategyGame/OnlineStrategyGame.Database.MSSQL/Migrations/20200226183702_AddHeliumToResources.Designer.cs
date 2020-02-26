﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStrategyGame.Database.MSSQL;

namespace OnlineStrategyGame.Database.MSSQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200226183702_AddHeliumToResources")]
    partial class AddHeliumToResources
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Moon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Moons");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("DistanceToStar")
                        .HasColumnType("REAL");

                    b.Property<float>("GravitationalAcceleration")
                        .HasColumnType("REAL");

                    b.Property<float>("Mass")
                        .HasColumnType("REAL");

                    b.Property<float>("MaxTemperature")
                        .HasColumnType("REAL");

                    b.Property<float>("MinTemperature")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Radius")
                        .HasColumnType("REAL");

                    b.Property<int>("SolarSystemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SolarSystemId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.RaceBonuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AppIdentityUserId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Economy")
                        .HasColumnType("REAL");

                    b.Property<bool>("EspionageTechnology")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExplorationTechnology")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExtendedPlanet")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MilitaryDefensive")
                        .HasColumnType("REAL");

                    b.Property<double>("MilitaryOffensive")
                        .HasColumnType("REAL");

                    b.Property<bool>("MilitaryTechnology")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Research")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AppIdentityUserId")
                        .IsUnique();

                    b.ToTable("RaceBonuses");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Resources", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Aluminium")
                        .HasColumnType("INTEGER");

                    b.Property<long>("AluminiumAlloy")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Antimatter")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Carbon")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Food")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Graphene")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Helium3")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Hydrogen")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MoonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Titanium")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TitaniumAlloy")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Uranium")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MoonId")
                        .IsUnique();

                    b.HasIndex("PlanetId")
                        .IsUnique();

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.SolarSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CordX")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CordY")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CordZ")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RulerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StarId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RulerId");

                    b.HasIndex("StarId")
                        .IsUnique();

                    b.HasIndex("CordX", "CordY", "CordZ");

                    b.ToTable("SolarSystems");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("GravitationalAcceleration")
                        .HasColumnType("REAL");

                    b.Property<float>("Mass")
                        .HasColumnType("REAL");

                    b.Property<float>("Radius")
                        .HasColumnType("REAL");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Planet", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.SolarSystem", "SolarSystem")
                        .WithMany("Planets")
                        .HasForeignKey("SolarSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.RaceBonuses", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", "AppIdentityUser")
                        .WithOne("RaceBonuses")
                        .HasForeignKey("OnlineStrategyGame.Database.MSSQL.Models.RaceBonuses", "AppIdentityUserId");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.Resources", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.Moon", "Moon")
                        .WithOne("Resources")
                        .HasForeignKey("OnlineStrategyGame.Database.MSSQL.Models.Resources", "MoonId");

                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.Planet", "Planet")
                        .WithOne("Resources")
                        .HasForeignKey("OnlineStrategyGame.Database.MSSQL.Models.Resources", "PlanetId");
                });

            modelBuilder.Entity("OnlineStrategyGame.Database.MSSQL.Models.SolarSystem", b =>
                {
                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.AppIdentityUser", "Ruler")
                        .WithMany()
                        .HasForeignKey("RulerId");

                    b.HasOne("OnlineStrategyGame.Database.MSSQL.Models.Star", "Star")
                        .WithOne("SolarSystem")
                        .HasForeignKey("OnlineStrategyGame.Database.MSSQL.Models.SolarSystem", "StarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}