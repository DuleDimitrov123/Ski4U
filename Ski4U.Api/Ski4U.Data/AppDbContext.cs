using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Ski4U.Data.Models;
using System.IO;

namespace Ski4U.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<SkiItem> SkiItems { get; set; }

        public DbSet<SkiItemAttribute> SkiItemAttributes { get; set; }
    }

    public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{@Directory.GetCurrentDirectory()}/../Ski4U.Api/appsettings.json")
                .Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<AppDbContext>();

            var connectionString = configuration.GetConnectionString("ConStr");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}