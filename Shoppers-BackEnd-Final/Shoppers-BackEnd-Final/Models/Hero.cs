using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class Hero:BaseEntity
    {
        [StringLength(maximumLength: 20)]
        public string Title1 { get; set; }

        [StringLength(maximumLength: 20)]
        public string Title2 { get; set; }

        [StringLength(maximumLength: 150)]
        public string Text { get; set; }

        [StringLength(maximumLength: 250)]
        public string RedirectUrl { get; set; }



    }
}
