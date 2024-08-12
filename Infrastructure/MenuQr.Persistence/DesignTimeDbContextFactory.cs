using MenuQr.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Persistence
{
    public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<MenuQrDbContext>
    {
        public MenuQrDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            // Build the configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // This is now the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("PostgreSQL");

            // Check if connection string is null or empty
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string 'PostgreSQL' is null or empty.");
            }

            // Build the DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<MenuQrDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            // Return the context
            return new MenuQrDbContext(optionsBuilder.Options);

        }
    }
}
