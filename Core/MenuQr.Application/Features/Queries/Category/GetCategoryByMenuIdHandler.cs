using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Category
{
    public class GetCategoryByMenuIdHandler : IRequestHandler<GetCategoryByMenuIdRequest, GetCategoryByMenuIdResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;

        public GetCategoryByMenuIdHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetCategoryByMenuIdResponse> Handle(GetCategoryByMenuIdRequest request, CancellationToken cancellationToken)
        {
           var cate=  _categoryReadRepository.GetWhere(r => r.MenuId == request.MenuId).ToList();

            return  new GetCategoryByMenuIdResponse() { categories = cate };
        }
    }
}
    