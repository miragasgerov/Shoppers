using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.ViewModels
{
    public class HomeViewModel
    {
        public List<Hero> Heroes { get; set; }
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Category> Cate { get; set; }
        public List<Team> Teams { get; set; }




    }
}
