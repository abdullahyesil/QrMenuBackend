using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Menu.GetMenuById
{
    public class GetMenuByIdQueryRequest:IRequest<GetMenuByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
