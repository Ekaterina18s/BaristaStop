using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaStop.Services.DTOs
{
    public class BeverageDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Ingredients { get; set; }
        public string Caffeine { get; set; }
        public double Size { get; set; }
        public int ProductId { get; set; }
    }
}
