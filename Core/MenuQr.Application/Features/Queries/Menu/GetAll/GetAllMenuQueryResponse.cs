using MenuQr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Menu.GetAll
{
    public class GetAllMenuQueryResponse
    {
        public List<Domain.Entities.Menu> Menus { get; set; }
    }
}
