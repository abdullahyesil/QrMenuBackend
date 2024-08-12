using MenuQr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Domain.Entities
{
    public class Menu:BaseEntitiy
    {
   
        public string Name { get; set; }
        public string Description { get; set; }
        public string QrCodeUrl { get; set; }
        public string Link { get; set; }
    }
}
