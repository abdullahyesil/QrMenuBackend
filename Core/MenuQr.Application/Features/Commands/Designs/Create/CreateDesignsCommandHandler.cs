using MediatR;
using MenuQr.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Designs.Create
{
    public class CreateDesignsCommandHandler : IRequestHandler<CreateDesignsCommandRequest, CreateDesignsCommandResponse>
    {
        readonly IDesignWriteRepository _designWriteRepository;

        public CreateDesignsCommandHandler(IDesignWriteRepository designWriteRepository)
        {
            _designWriteRepository = designWriteRepository;
        }

        public async Task<CreateDesignsCommandResponse> Handle(CreateDesignsCommandRequest request, CancellationToken cancellationToken)
        {
            await _designWriteRepository.AddAsync(new() { MenuId = request.MenuId , BackgroundColor = request.BackgroundColor, FontColor = request.FontColor, FontStyle = request.FontStyle, Layout = request.Layout });

            try
            {
                await _designWriteRepository.SaveAsync();
                return new() { Success = true, Message = "Tasarım Ekleme Başarılı" };
            }
            catch (Exception err)
            {

                return new() { Success = false, Message = "Tasarım Eklerken bir hata oluştu" + err.Message };
            }
        }
    }
}
