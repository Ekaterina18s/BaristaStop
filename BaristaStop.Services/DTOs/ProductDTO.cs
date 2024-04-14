using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaStop.Services.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Flavor { get; set; }
        public string Use { get; set; }
        public string Description { get; set; }
    }
}
