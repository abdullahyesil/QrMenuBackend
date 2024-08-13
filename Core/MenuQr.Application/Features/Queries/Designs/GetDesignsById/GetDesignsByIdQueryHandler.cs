using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Designs.GetDesignsById
{
    public class GetDesignsByIdQueryHandler : IRequestHandler<GetDesignsByIdQueryRequest, GetDesignsByIdQueryResponse>
    {
     
        readonly IDesignReadRepository _designReadRepository;

        public GetDesignsByIdQueryHandler(IDesignReadRepository designReadRepository)
        {
            _designReadRepository = designReadRepository;
        }

        public async Task<GetDesignsByIdQueryResponse> Handle(GetDesignsByIdQueryRequest request, CancellationToken cancellationToken)
        {
          
            return new GetDesignsByIdQueryResponse()
            {
                Designs = await _designReadRepository.GetByIdAsync(request.Id)
            };
        }
    }
}
