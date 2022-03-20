using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class Service:BaseEntity
    {
        public string Icon { get; set; }
        
        [StringLength(maximumLength:25)]
        public string Title { get; set; }

        [StringLength(maximumLength: 200)]
        public string Text { get; set;}

    }
}
