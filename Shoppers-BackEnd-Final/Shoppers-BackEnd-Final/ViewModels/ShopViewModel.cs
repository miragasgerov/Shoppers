using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.ViewModels
{
    public class ShopViewModel
    {
        public Product Product { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<Category> Categories { get; set; }
        public ProductComment ProductComment { get; set; }


    }
}
