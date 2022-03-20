using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class Color:BaseEntity
    {
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}
