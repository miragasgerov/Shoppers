using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppers_BackEnd_Final.Helper;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(DataContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }

        public IActionResult Index(int page = 1,bool? deleted =null, string? search = null)
        {
            var products = _context.Products
                .Include(x => x.SubCategory)
                .Include(x => x.ProductComments)
                .Include(x => x.Color)
                .Include(x => x.ProductSizes)
                .Include(x => x.ProductImages).AsQueryable();

            if(deleted == false)
            {
                products = products.Where(x => x.IsNew == true);
            }
            if(deleted==true)
            {
                products = products.Where(x => x.IsDeleted == true);
            }
            if(search != null)
            {
                products = products.Where(X => X.Name.Contains(search));
            }

            ViewBag.IsDeleted = deleted;
            ViewBag.Search = search;
            return View(products.ToList().ToPagedList(page, 5));
        }

        public IActionResult Create()
        {
            ViewBag.SubCategory = _context.SubCategories.ToList().Where(x => x.IsDeleted == false);
            ViewBag.ColorIds = _context.Colors.ToList().Where(x => x.IsDeleted == false);
            ViewBag.SizeIds = _context.Sizes.ToList().Where(x => x.IsDeleted == false);

            return View();
        }

        [HttpPost]

        public IActionResult Create(Product product)
        {
            ViewBag.SubCategory = _context.SubCategories.ToList()
                .Where(x => x.IsDeleted == false);
            ViewBag.ColorIds = _context.Colors.ToList()
                .Where(x => x.IsDeleted == false);
            ViewBag.SizeIds = _context.Sizes.ToList()
                .Where(x => x.IsDeleted == false);

            if(!ModelState.IsValid)
            {
                return View();
            }
            if (product.ColorIds != null)
            {
                product.ProductColors = new List<ProductColor>();

                foreach (var colorId in product.ColorIds)
                {
                    Color color = _context.Colors.FirstOrDefault(x => x.Id == colorId);

                    if (color == null)
                    {
                        ModelState.AddModelError("ColorIds", "Databaza da belə bir rəng tapılmadı");
                        return View();
                    }

                    ProductColor productColor = new ProductColor
                    {
                        ColorId = colorId,
                        Product = product
                    };

                    product.ProductColors.Add(productColor);
                }
            }


            if (product.SizeIds != null)
            {
                product.ProductSizes = new List<ProductSize>();

                foreach (var sizeId in product.SizeIds)
                {
                    Size size = _context.Sizes.FirstOrDefault(x => x.Id == sizeId);

                    if(size == null)
                    {
                        ModelState.AddModelError("SizeIds", "Databaza da belə bir olcu tapılmadı");
                        return View();
                    }

                    ProductSize productSize = new ProductSize
                    {
                        SizeId = sizeId,
                        Product = product
                    };

                    product.ProductSizes.Add(productSize);
                }
            }

            product.ProductImages = new List<ProductImage>();
            if(product.PosterImage==null)
            {
                ModelState.AddModelError("PosterImage", "Poster sekli bos ola bilmez");
                return View();
            }
            else
            {
                if(product.PosterImage.ContentType !="image/jpeg" 
                    && product.PosterImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterImage", "Sekilin formati duzgun deyil");
                    return View();
                }

                if(product.PosterImage.Length>2097152)
                {
                    ModelState.AddModelError("PosterImage", "Sekilin olcusu 2 mb-dan artiq ola bilmez");
                    return View();
                }

                string filename = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterImage);
                ProductImage productImage = new ProductImage
                {
                    Image = filename,
                    IsPoster = true
                };

                product.ProductImages.Add(productImage);
            }
            if(product.ImageFiles !=null)
            {
                foreach (var image in product.ImageFiles)
                {
                    if (image.ContentType != "image/png" && image.ContentType != "image/jpeg")
                    {
                        continue;
                    }
                    if (image.Length > 2097152)
                    {
                        continue;
                    }
                    ProductImage productImage = new ProductImage
                    {
                        IsPoster = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/product", image)
                    };
                    if (product.ProductImages == null)
                    {
                        product.ProductImages = new List<ProductImage>();
                    }
                    product.ProductImages.Add(productImage);

                }

            }

            if(product.SalePrice<0)
            {
                ModelState.AddModelError("Price", "Qiymet menfi ola bilmez");
                return View();
            }

            if(product.CostPrice < 0)
            {
                ModelState.AddModelError("Price", "Qiymet menfi ola bilmez");
                return View();
            }

            if (product.DiscountPrice < 0)
            {
                ModelState.AddModelError("Price", "Qiymət mənfi ola bilməz");
                return View();

            }
            if (product.Count < 0)
            {
                ModelState.AddModelError("Price", "Say mənfi ola bilməz");
                return View();

            }

            if(!ModelState.IsValid)
            {
                return View();
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Edit(int id)
        {
            Product product = _context.Products
                .Include(x => x.ProductSizes)
                .Include(x => x.ProductImages)
                .Include(x => x.Color)
                .FirstOrDefault(x => x.Id == id);

            if(product ==null)
            {
                return RedirectToAction("index", "error");
            }

            ViewBag.SubCategory = _context.SubCategories.ToList();
            ViewBag.SizeIds = _context.Sizes.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.ColorId = _context.Colors.ToList().Where(x => x.IsDeleted == false);
            product.SizeIds = product.ProductSizes.Select(x => x.SizeId).ToList();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Product product)
        {
            Product prevProduct = _context.Products
                .Include(x => x.ProductColors)
                .Include(x=>x.ProductSizes)
                .Include(x => x.SubCategory).Include(x => x.Color)
                .Include(x => x.ProductImages).FirstOrDefault(x => x.Id == product.Id);

            if(prevProduct == null)
            {
                return RedirectToAction("index", "error");
            }

            if(product.PosterImage != null)
            {
                if (product.PosterImage.ContentType != "image/jpeg" && product.PosterImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterImage", "Şəklin formatı düzgün deyil!");
                    return View();
                }
                if (product.PosterImage.Length > 2097152)
                {
                    ModelState.AddModelError("PosterImage", "Şəklin ölçüsü 2mb dan artıq ola bilməz!");
                    return View();
                }

                ProductImage posterImage = _context.ProductImages
                    .Where(x => x.ProductId == product.Id)
                    .FirstOrDefault(x => x.IsPoster == true);

                string filename = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterImage);

                if(posterImage == null)
                {
                    posterImage = new ProductImage
                    {
                        IsPoster = true,
                        Image = filename,
                        ProductId = product.Id
                    };
                    _context.ProductImages.Add(posterImage);
                }
                else
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/product", posterImage.Image);
                    posterImage.Image = filename;
                }
            }

            prevProduct.ProductImages.RemoveAll(x => x.IsPoster == false && !product.ProductImageIds.Contains(x.Id));

            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        IsPoster = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/product", file)
                    };
                    if (prevProduct.ProductImages == null)
                        prevProduct.ProductImages = new List<ProductImage>();
                    prevProduct.ProductImages.Add(image);
                }
            }
                prevProduct.ProductSizes.RemoveAll(x => !product.SizeIds.Contains(x.SizeId));
                foreach (var sizeId in product.SizeIds.Where(x => !prevProduct.ProductSizes.Any(bt => bt.SizeId == x)))
                {
                    ProductSize productSize = new ProductSize
                    {
                        ProductId = product.Id,
                        SizeId = sizeId
                    };

                    prevProduct.ProductSizes.Add(productSize);
                }

            prevProduct.Name = product.Name;
            prevProduct.SalePrice = product.SalePrice;
            prevProduct.CostPrice = product.CostPrice;
            prevProduct.DiscountPrice = product.DiscountPrice;
            prevProduct.IsNew = product.IsNew;
            prevProduct.Count = product.Count;
            prevProduct.Size = product.Size;
            prevProduct.SubCategoryId = product.SubCategoryId;
            prevProduct.Title = product.Title;
            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return RedirectToAction("index", "error");
            }
            if (product.IsDeleted == false)
            {
                product.IsDeleted = true;
            }
            else
            {
                product.IsDeleted = false;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Comments(int productId)
        {
            List<ProductComment> comments = _context.ProductComments.Include(x => x.Product).Where(x => x.ProductId == productId).ToList();
            return View(comments);
        }

        public IActionResult DeleteComment(int id)
        {
            ProductComment comment = _context.ProductComments.FirstOrDefault(x => x.Id == id);

            if (comment == null) return NotFound();

            _context.ProductComments.Remove(comment);
            _context.SaveChanges();

            return Ok();
        }

        public IActionResult InfoComment(int id)
        {
            ProductComment comment = _context.ProductComments.Include(x => x.Product).FirstOrDefault(x => x.Id == id);

            if (comment == null) return NotFound();

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptComment(int id)
        {
            ProductComment comment = _context.ProductComments.FirstOrDefault(x => x.Id == id);

            if (comment == null) return NotFound();

            comment.Status = true;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
