using MenuQr.Application.Repositories;
using MenuQr.Domain.Entities;
using MenuQr.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Persistence.Repositories.Design
{
    public class DesignReadRepository : ReadRepository<Designs>, IDesignReadRepository
    {
        public DesignReadRepository(MenuQrDbContext context) : base(context)
        {
        }
    }
}
