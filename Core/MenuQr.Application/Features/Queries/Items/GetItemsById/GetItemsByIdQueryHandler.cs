using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Items.GetItemsById
{
    public class GetItemsByIdQueryHandler : IRequestHandler<GetItemsByIdQueryRequest, GetItemsByIdQueryResponse>
    {
        readonly IItemReadRepository _itemReadRepository;

        public GetItemsByIdQueryHandler(IItemReadRepository itemReadRepository)
        {
            _itemReadRepository = itemReadRepository;
        }

        public async Task<GetItemsByIdQueryResponse> Handle(GetItemsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetItemsByIdQueryResponse() { Item = await _itemReadRepository.GetByIdAsync(request.Id) };
        }
    }
}
