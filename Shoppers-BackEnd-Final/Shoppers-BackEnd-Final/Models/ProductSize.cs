using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class ProductSize:BaseEntity
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }
    }
}
