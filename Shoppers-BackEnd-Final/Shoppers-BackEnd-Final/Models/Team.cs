using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class Team:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 40)]
        public string Position { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Text { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
