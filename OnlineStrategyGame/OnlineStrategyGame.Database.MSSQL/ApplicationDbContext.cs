using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Database.MSSQL.Models;

namespace OnlineStrategyGame.Database.MSSQL
{
    public class ApplicationDbContext : IdentityDbContext<AppIdentityUser>
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Moon> Moons { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<Triats> Triats { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<RaceBonuses> RaceBonuses { get; set; }
        public DbSet<GalaxySettings> GalaxySettings { get; set; }
        public object Direction { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GalaxySettings>().HasData(new GalaxySettings { 
                Id = 1, 
                LastXCordForNewPlayers = 0,
                LastYCordForNewPlayers = 0,
                LastZCordForNewPlayers = 0,
                CordForNewPlayersSearchSecondDirection = 3//Direction.Right
            });
            modelBuilder.Entity<SolarSystem>()
                .HasIndex(p => new { p.CordX, p.CordY, p.CordZ });
            modelBuilder.Entity<AppIdentityUser>(
                a =>
                {
                    a.HasOne(b => b.RaceBonuses).WithOne(b => b.AppIdentityUser).HasForeignKey<RaceBonuses>(b => b.AppIdentityUserId);
                    a.HasOne(b => b.Technology).WithOne(b => b.AppIdentityUser).HasForeignKey<Technology>(b => b.AppIdentityUserId);
                });
            modelBuilder.Entity<Planet>()
                .HasOne(a => a.Ruler)
                .WithMany(a => a.Planets)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Moon>()
                .HasOne(a => a.Ruler)
                .WithMany(a => a.Moons)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Planet>()
                .HasOne(a => a.Resources)
                .WithOne(a => a.Planet)
                .HasForeignKey<Resources>(a => a.PlanetId);
            modelBuilder.Entity<Moon>()
                .HasOne(a => a.Resources)
                .WithOne(a => a.Moon)
                .HasForeignKey<Resources>(a => a.MoonId);
            modelBuilder.Entity<Planet>()
                .HasOne(a => a.Buildings)
                .WithOne(a => a.Planet)
                .HasForeignKey<Buildings>(a => a.PlanetId);
            modelBuilder.Entity<Moon>()
                .HasOne(a => a.Buildings)
                .WithOne(a => a.Moon)
                .HasForeignKey<Buildings>(a => a.MoonId);
            modelBuilder.Entity<Planet>()
                .HasOne(a => a.Triats)
                .WithOne(a => a.Planet)
                .HasForeignKey<Triats>(a => a.PlanetId);
            modelBuilder.Entity<Moon>()
                .HasOne(a => a.Triats)
                .WithOne(a => a.Moon)
                .HasForeignKey<Triats>(a => a.MoonId);
            modelBuilder.Entity<Planet>()
                .HasMany(a => a.Moons)
                .WithOne(a => a.Planet);
        }
    }
}