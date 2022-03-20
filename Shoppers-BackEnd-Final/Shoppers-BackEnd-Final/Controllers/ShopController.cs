using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shoppers_BackEnd_Final.Models;
using Shoppers_BackEnd_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(DataContext context,UserManager<AppUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                NewProducts = _context.Products.Include(x => x.ProductImages).Include(x => x.Color).Include(x => x.Size)
                .Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList(),
                Categories = _context.Categories.Include(x=>x.SubCategories).ToList()


            };
            return View(shopVM);
        }

        public IActionResult sale(int id)
        {
            var Products = _context.Products.Include(x => x.ProductColors).ThenInclude(x => x.Color).Include(x => x.ProductImages).Include(x => x.ProductComments)
                .Include(x => x.ProductSizes).ThenInclude(x => x.Size).Where(x => x.SubCategoryId == id).AsQueryable();
            return View(Products.ToList());
        }

        public IActionResult shopdetail(int id)
        {
            Product product = _context.Products.Include(x => x.ProductColors).ThenInclude(x => x.Color).Include(x => x.ProductImages).Include(x => x.ProductComments)
                .Include(x => x.ProductSizes).ThenInclude(x => x.Size).FirstOrDefault(x => x.Id == id);

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if(User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && x.IsAdmin == false);
            };

            ShopViewModel shopDetailVM = new ShopViewModel
            {
                Product = product,
                NewProducts = _context.Products.Include(x => x.ProductImages).Include(x => x.ProductColors).ThenInclude(x => x.Color)
                .Include(x => x.SubCategory).ThenInclude(x => x.Category).ToList(),
                ProductComment = new ProductComment
                {
                    AppUser = member
                }
            };

            return View(shopDetailVM);
        }


        public IActionResult SetSession(int id)
        {
            HttpContext.Session.SetString("productId", id.ToString());

            return Content("added");
        }



        public IActionResult GetSession()
        {
            string idStr = HttpContext.Session.GetString("productId");
            return Content(idStr);
        }

        public IActionResult SetCookie(int id)
        {
            HttpContext.Response.Cookies.Append("productId", id.ToString());
            return Content("cookie");
        }

        public IActionResult GetCookie(string key)
        {
            string str = HttpContext.Request.Cookies[key];

            return Content(str);
        }

        public IActionResult AddBasket(int productId)
        {
            if (!_context.Products.Any(x => x.Id == productId))
            {
                return NotFound();
            }

            List<CookieBasketItemViewModel> basketItems = new List<CookieBasketItemViewModel>();
            string existBasketItems = HttpContext.Request.Cookies["basketItemList"];

            if (existBasketItems != null)
            {
                basketItems = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(existBasketItems);
            }

            CookieBasketItemViewModel item = basketItems.FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = new CookieBasketItemViewModel
                {
                    ProductId = productId,
                    Count = 1
                };
                basketItems.Add(item);
            }
            else
            {
                item.Count++;
            }


            var productIdsStr = JsonConvert.SerializeObject(basketItems);

            HttpContext.Response.Cookies.Append("basketItemList", productIdsStr);

            var data = _getBasketItems(basketItems);

            return Ok(data);
        }


        public IActionResult ShowBasket()
        {
            var productIdsStr = HttpContext.Request.Cookies["basketItemList"];
            List<CookieBasketItemViewModel> productIds = new List<CookieBasketItemViewModel>();
            if (productIdsStr != null)
            {
                productIds = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(productIdsStr);
            }

            return Json(productIds);
        }

        public IActionResult Checkout()
        {
            List<CheckoutItemViewModel> checkoutItems = new List<CheckoutItemViewModel>();

            string basketItemsStr = HttpContext.Request.Cookies["basketItemList"];
            if (basketItemsStr != null)
            {
                List<CookieBasketItemViewModel> basketItems = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(basketItemsStr);

                foreach (var item in basketItems)
                {
                    CheckoutItemViewModel checkoutItem = new CheckoutItemViewModel
                    {
                        Product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId),
                        Count = item.Count
                    };
                    checkoutItems.Add(checkoutItem);
                }
            }

            return View(checkoutItems);
        }



        private BasketViewModel _getBasketItems(List<CookieBasketItemViewModel> cookieBasketItems)
        {
            BasketViewModel basket = new BasketViewModel
            {
                BasketItems = new List<BasketItemViewModel>(),
            };

            foreach (var item in cookieBasketItems)
            {
                Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                BasketItemViewModel basketItem = new BasketItemViewModel
                {
                    Name = product.Name,
                    Price = product.DiscountPrice > 0 ? (product.SalePrice * (1 - product.DiscountPrice / 100)) : product.SalePrice,
                    ProductId = product.Id,
                    Count = item.Count,
                    PosterImage = product.ProductImages.FirstOrDefault(x => x.IsPoster == true)?.Image
                };

                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                basket.TotalAmount += basketItem.TotalPrice;
                basket.BasketItems.Add(basketItem);
            }

            return basket;
        }



        [HttpPost]
        public async Task<IActionResult> Comment (ProductComment comment)
        {
            if (!ModelState.IsValid) return NotFound();

            if(!_context.Products.Any(x => x.Id == comment.ProductId))
            {
                return NotFound();
            }

            if(!User.Identity.IsAuthenticated)
            {
                if(string.IsNullOrWhiteSpace(comment.Email))
                {
                    return NotFound();
                }

                if(string.IsNullOrWhiteSpace(comment.FullName))
                {
                    return NotFound();
                }
            }

            else
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.AppUserId = user.Id;
                comment.FullName = user.Fullname;
                comment.Email = user.Email;

            }

            comment.Status = false;
            comment.CreatedAt = DateTime.UtcNow.AddHours(4);
            _context.ProductComments.Add(comment);
            _context.SaveChanges();


            return RedirectToAction("shopdetail",new {id=comment.ProductId });
        }
      
    }
}
