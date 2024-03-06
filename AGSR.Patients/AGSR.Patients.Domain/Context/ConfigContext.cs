using AGSR.Patients.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AGSR.Patients.Domain.Context
{
    public class ConfigContext : DbContext
    {
        private const string ConfigConnection = nameof(ConfigConnection);

        private readonly string connectionString;

        public ConfigContext(DbContextOptions<ConfigContext> options, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(ConfigConnection);

            this.connectionString = connectionString
                ?? throw new ArgumentNullException("No connection string found in configuration");

            Database.EnsureDeleted();
            Database.EnsureCreated();
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
    }
}
