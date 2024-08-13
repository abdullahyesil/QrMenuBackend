using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Application.Features.Commands.Designs.Create
{
    public class CreateDesignsCommandRequest:IRequest<CreateDesignsCommandResponse>
    {
        public string MenuId { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public string FontStyle { get; set; }
        public string Layout { get; set; }
    }
}
