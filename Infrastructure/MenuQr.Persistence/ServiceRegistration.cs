using MenuQr.Application.Repositories;
using MenuQr.Persistence.Context;
using MenuQr.Persistence.Repositories;
using MenuQr.Persistence.Repositories.Design;
using MenuQr.Persistence.Repositories.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MenuQrDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IDesignReadRepository, DesignReadRepository>();
            services.AddScoped<IDesignWriteRepository, DesignWriteRepository>();
            services.AddScoped<IItemReadRepository, ItemReadRepository>();
            services.AddScoped<IItemWriteRepository, ItemWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
        }
    }
}
