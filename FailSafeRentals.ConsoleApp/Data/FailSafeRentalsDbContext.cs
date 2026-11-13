using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace FailSafeRentals.ConsoleApp.Data;

public class FailSafeRentalsDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<ExtraFeatures> ExtraFeatures { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FailSafeRentals;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Unikt index på registreringsnummer (stoppar dubletter i SQL)
        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.RegistrationNumber).IsUnique();

        // 2. Explicit precision för pengar i LocalDB
        modelBuilder.Entity<Vehicle>()
            .Property(v => v.DailyRate).HasPrecision(10, 2);

        // 3. Shadow-property för SecOps-spårbarhet
        modelBuilder.Entity<Rental>()
            .Property<DateTime>("CreatedAt").HasDefaultValueSql("GETUTCDATE()");

        // 4. Skydda uthyrningshistorik mot oavsiktlig radering
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer).WithMany(c => c.Rentals)
            .OnDelete(DeleteBehavior.Restrict);

        // Lägg till statiska data
        modelBuilder.Entity<ExtraFeatures>().HasData(
            new ExtraFeatures { Id = 1, Name = "GPS Navigation", DailyPrice = 75m },
            new ExtraFeatures { Id = 2, Name = "Takbox Thule", DailyPrice = 120m },
            new ExtraFeatures { Id = 3, Name = "Barnstol", DailyPrice = 50m }
         );
    }
}
