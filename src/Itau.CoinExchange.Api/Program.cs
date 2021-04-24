using Itau.CoinExchange.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Itau.CoinExchange.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                await host.MigrateDatabaseAsync();
                await host.RunAsync();
                Console.WriteLine("Application stoped");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unhandled exception occured during bootstrapping. {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task MigrateDatabaseAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ItauCoinExchangeDbContext>();
            await dbContext.Database.MigrateAsync();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}