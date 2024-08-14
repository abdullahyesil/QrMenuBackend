using MenuQr.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuQr.Domain.Entities
{
    public class Category:BaseEntitiy
    {
        public string MenuId { get; set; }
        public string Name { get; set; }
    }
}
