using MediatR;
using MenuQr.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Queries.Menu.GetAll
{
    public class GetAllMenuQueryHandler : IRequestHandler<GetAllMenuQueryRequest, GetAllMenuQueryResponse>
    {

        readonly IMenuReadRepository _menuReadRepository;

        public GetAllMenuQueryHandler(IMenuReadRepository menuReadRepository)
        {
            _menuReadRepository = menuReadRepository;
        }

        public async Task<GetAllMenuQueryResponse> Handle(GetAllMenuQueryRequest request, CancellationToken cancellationToken)
        {

            var menuList = await _menuReadRepository.GetAll(false).ToListAsync();

            // Yanıt nesnesini oluştur
            var response = new GetAllMenuQueryResponse
            {
                Menus = menuList
            };

            return response;


        }
    }
}
