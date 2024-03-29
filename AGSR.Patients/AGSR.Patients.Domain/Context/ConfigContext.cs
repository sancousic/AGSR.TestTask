﻿using AGSR.Patients.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AGSR.Patients.Domain.Context;

public class ConfigContext : DbContext
{
    private const string ConfigConnection = nameof(ConfigConnection);

    private readonly string connectionString;

    public ConfigContext(DbContextOptions<ConfigContext> options, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConfigConnection);

        this.connectionString = connectionString
                                ?? throw new ArgumentNullException("No connection string found in configuration");
    }

    public DbSet<Name> Names { get; set; } = null!;

    public DbSet<Patient> Patients { get; set; } = null!;

    public DbSet<GivenName> GivenNames { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder is { IsConfigured: false })
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>()
            .HasOne(p => p.Name)
            .WithOne(p => p.Patient)
            .HasForeignKey<Name>(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}