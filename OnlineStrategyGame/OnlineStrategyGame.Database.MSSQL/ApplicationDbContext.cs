using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStrategyGame.Database.MSSQL.Models;

namespace OnlineStrategyGame.Database.MSSQL
{
    public class ApplicationDbContext : IdentityDbContext<AppIdentityUser>
    {
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<RaceBonuses> RaceBonuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SolarSystem>()
                .HasIndex(p => new { p.CordX, p.CordY, p.CordZ });
            modelBuilder.Entity<AppIdentityUser>(
                a => a.HasOne(b=>b.RaceBonuses).WithOne(b=>b.AppIdentityUser).HasForeignKey<RaceBonuses>(b => b.AppIdentityUserId)
                );
        }
    }
}
