using MenuQr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Domain.Entities
{
    public class Designs:BaseEntitiy
    {
        public string MenuId { get; set; }
        public string BackgroundColor { get; set;}
        public string FontColor { get; set; }
        public string FontStyle { get; set; }
        public string Layout { get; set; }
    }
}
