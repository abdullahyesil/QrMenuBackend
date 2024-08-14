using MenuQr.Domain.Entities;
using MenuQr.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MenuQr.Persistence.Context
{
    public class MenuQrDbContext:DbContext
    {
        public MenuQrDbContext(DbContextOptions<MenuQrDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Designs> Designs { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntitiy>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    //EntityState.Deleted => data.Entity.DeletedDate = DateTime.UtcNow,
                    EntityState.Unchanged => data.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
