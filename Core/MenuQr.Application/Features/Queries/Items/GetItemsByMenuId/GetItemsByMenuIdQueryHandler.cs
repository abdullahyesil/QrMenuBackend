using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Items.GetItemsByMenuId
{


    public class GetItemsByMenuIdQueryHandler:IRequestHandler<GetItemsByMenuIdQueryRequest, GetItemsByMenuIdQueryResponse>
    {
        readonly IItemReadRepository _itemReadRepository;

        public GetItemsByMenuIdQueryHandler(IItemReadRepository itemReadRepository)
        {
            _itemReadRepository = itemReadRepository;
        }

        public async Task<GetItemsByMenuIdQueryResponse> Handle(GetItemsByMenuIdQueryRequest request, CancellationToken cancellationToken)
        {
            var resp = _itemReadRepository.GetWhere(r => r.MenuId == request.MenuId).ToList();

            return new GetItemsByMenuIdQueryResponse() { Items = resp };
        }
    }
}
