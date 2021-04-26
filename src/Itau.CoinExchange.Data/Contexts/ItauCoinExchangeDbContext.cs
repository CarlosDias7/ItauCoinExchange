using Itau.CoinExchange.Data.Contexts.Configurations;
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
        private readonly ItauCoinExchageSqlServerOptions _itauCoinExchageSqlServerOptions;

        public ItauCoinExchangeDbContext(DbContextOptions options, IConfiguration configuration, ItauCoinExchageSqlServerOptions itauCoinExchageSqlServerOptions)
            : base(options)
        {
            _configuration = configuration;
            _itauCoinExchageSqlServerOptions = itauCoinExchageSqlServerOptions;
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
                        maxRetryCount: _itauCoinExchageSqlServerOptions.MaxRetryCount,
                        maxRetryDelay: TimeSpan.FromSeconds(_itauCoinExchageSqlServerOptions.MaxRetryDelayInSeconds),
                        errorNumbersToAdd: _itauCoinExchageSqlServerOptions.ErrorNumbersToAdd))
                .MigrationsAssembly(assemblyName: typeof(ItauCoinExchangeDbContext).Assembly.GetName().Name);
    }
}