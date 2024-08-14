using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Category.Create
{
    public class CreateCategoryComandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public CreateCategoryComandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            _categoryWriteRepository.AddAsync(new () { MenuId=request.MenuId, Name= request.Name });

            try
            {
               await _categoryWriteRepository.SaveAsync();

                return new CreateCategoryCommandResponse()
                {
                    Success = true,
                    Message = request.Name + "Başarıyla Eklendi"
                };

            }
            catch (Exception err)
            {

                return new CreateCategoryCommandResponse()
                {
                    Success = false,
                    Message = "Bir hata oluştu" + err.Message
                };
            }
      
            
        }
    }
}
