﻿using MenuQr.Application.Repositories;
using MenuQr.Domain.Entities.Common;
using MenuQr.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntitiy
    {
        private readonly MenuQrDbContext _context;
        public ReadRepository(MenuQrDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);

        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); ==> MARKER PATTERN
        //=> await Table.FindAsync(Guid.Parse(id)); ==> Entity Framework FindAsync Method
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }


        // Toplu ID'lerle veri çekme metodu
        public async Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<string> ids, bool tracking = true)
        {
            var idGuids = ids.Select(id => Guid.Parse(id)).ToList();
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.Where(entity => idGuids.Contains(entity.Id)).ToListAsync();
        }
    }
}
