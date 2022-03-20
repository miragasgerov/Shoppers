using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class SubCategory:BaseEntity
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
