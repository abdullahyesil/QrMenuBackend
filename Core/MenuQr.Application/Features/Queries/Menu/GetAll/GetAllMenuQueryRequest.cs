using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Menu.GetAll
{
    public class GetAllMenuQueryRequest:IRequest<GetAllMenuQueryResponse>
    {
    }
}
