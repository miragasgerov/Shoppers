using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.ViewModels
{
    public class CheckoutItemViewModel
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
