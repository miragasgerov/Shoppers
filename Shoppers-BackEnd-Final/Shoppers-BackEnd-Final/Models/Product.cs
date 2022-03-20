using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class Product:BaseEntity
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }
        public int Count { get; set; }
        public int SubCategoryId { get; set; }

        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductColor> ProductColors { get; set; }


        [NotMapped]
        public List<int> SizeIds { get; set; } = new List<int>();

        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();

        public List<ProductImage> ProductImages { get; set; }
        [NotMapped]
        public IFormFile PosterImage { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public List<int> ProductImageIds { get; set; } = new List<int>();

        public SubCategory SubCategory { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public List<ProductComment> ProductComments { get; set; }

    }
}
