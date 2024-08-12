using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Menu.Create
{
    public class CreateMenuCommandRequest:IRequest<CreateMenuCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string QrCodeUrl { get; set; }
        public string Link { get; set; }
    }
}
