using Itau.CoinExchange.Data.Contexts.Seeds;
using Itau.CoinExchange.Domain.Entities.Segments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;

namespace Itau.CoinExchange.Data.Contexts
{
    public class ItauCoinExchangeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ItauCoinExchangeDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Segment> Segments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItauCoinExchangeDbContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: _configuration.GetConnectionString(nameof(ItauCoinExchangeDbContext)),
                    sqlServerOptionsAction: SqlServerOptionsAction);
        }

        private void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .ExecutionStrategy(
                    dependencies => new SqlServerRetryingExecutionStrategy(
                        dependencies: dependencies,
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: new int[] { 3 }))
                .MigrationsAssembly(assemblyName: typeof(ItauCoinExchangeDbContext).Assembly.GetName().Name);
    }
}