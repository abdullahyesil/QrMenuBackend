using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Items.GetItemsByMenuId
{
    public class GetItemsByMenuIdQueryRequest:IRequest<GetItemsByMenuIdQueryResponse>
    {
        public string MenuId { get; set; }
    }
}
