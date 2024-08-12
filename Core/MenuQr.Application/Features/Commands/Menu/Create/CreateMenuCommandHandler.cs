using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Menu.Create
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommandRequest, CreateMenuCommandResponse>
    {

        readonly IMenuWriteRepository _repository;

        public CreateMenuCommandHandler(IMenuWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateMenuCommandResponse> Handle(CreateMenuCommandRequest request, CancellationToken cancellationToken)
        {
          await _repository.AddAsync(new(){ Name = request.Name , Description = request.Description , Link = request.Description, QrCodeUrl = request.QrCodeUrl });

            try
            {
                await _repository.SaveAsync();
                return new() { Success = true , Message = "Menü Ekleme Başarılı"};
            }
            catch (Exception err)
            {

               return new() { Success = false , Message = "Menü Eklerken bir hata oluştu" + err.Message};
            }
          
            
        }
    }
}
