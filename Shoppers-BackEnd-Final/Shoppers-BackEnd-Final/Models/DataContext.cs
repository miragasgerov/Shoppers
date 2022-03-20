using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductComment>ProductComments { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
