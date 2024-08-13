using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Menu.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQueryRequest, GetMenuByIdQueryResponse>
    {
        readonly IMenuReadRepository _menuReadRepository;

        public GetMenuByIdQueryHandler(IMenuReadRepository menuReadRepository)
        {
            _menuReadRepository = menuReadRepository;
        }

        public async Task<GetMenuByIdQueryResponse> Handle(GetMenuByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Menu menu = await _menuReadRepository.GetByIdAsync(request.Id);

            return new GetMenuByIdQueryResponse(){ Menu= menu};

        }
    }
}
