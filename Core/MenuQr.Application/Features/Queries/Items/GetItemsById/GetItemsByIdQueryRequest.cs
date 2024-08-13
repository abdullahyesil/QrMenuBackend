using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Items.GetItemsById
{
    public class GetItemsByIdQueryRequest:IRequest<GetItemsByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
