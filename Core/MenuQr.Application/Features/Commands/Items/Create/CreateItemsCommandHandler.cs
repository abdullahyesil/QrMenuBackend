using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Items.Create
{
    public class CreateItemsCommandHandler : IRequestHandler<CreateItemsCommandRequest, CreateItemsCommandResponse>
    {
        readonly IItemWriteRepository _repository;

        public CreateItemsCommandHandler(IItemWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateItemsCommandResponse> Handle(CreateItemsCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(new() { MenuId= request.MenuId, Name = request.Name, Description = request.Description, Price = request.Price, Category = request.Category, ImageUrl = request.ImageUrl });

            try
            {
                await _repository.SaveAsync();
                return new() { Success = true, Message = "Item Ekleme Başarılı" };
            }
            catch (Exception err)
            {

                return new() { Success = false, Message = "Item Eklerken bir hata oluştu" + err.Message };
            }
        }
    }
}
