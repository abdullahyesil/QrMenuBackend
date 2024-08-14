using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Category
{
    public class GetCategoryByMenuIdResponse
    {
        public List<Domain.Entities.Category> categories { get; set; }
    }
}
