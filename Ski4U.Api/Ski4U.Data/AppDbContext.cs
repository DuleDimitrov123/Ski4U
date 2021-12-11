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

        public DbSet<SkiBoot> SkiBoots { get; set; }

        public DbSet<Ski> Skis { get; set; }

        public DbSet<Helmet> Helmets { get; set; }

        public DbSet<SkiStick> SkiStics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkiBoot>().ToTable("SkiBoots");
            modelBuilder.Entity<Ski>().ToTable("Skis");
            modelBuilder.Entity<Helmet>().ToTable("Helmets");
            modelBuilder.Entity<SkiStick>().ToTable("SkiSticks");
        }
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