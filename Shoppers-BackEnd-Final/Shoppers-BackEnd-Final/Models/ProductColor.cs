using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class ProductColor:BaseEntity
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public Product Product { get; set; }
        public Color Color { get; set; }
    }
}
