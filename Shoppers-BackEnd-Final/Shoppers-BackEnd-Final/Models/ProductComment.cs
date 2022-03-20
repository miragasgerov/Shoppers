using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class ProductComment:BaseEntity
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        [StringLength(maximumLength:500)]
        public string Text { get; set; }
        [StringLength(maximumLength:100)]
        public string Email { get; set; }
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }
        public AppUser AppUser { get; set; }

    }
}
