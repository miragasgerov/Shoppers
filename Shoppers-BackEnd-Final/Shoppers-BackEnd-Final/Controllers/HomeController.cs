using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppers_BackEnd_Final.Models;
using Shoppers_BackEnd_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Heroes = _context.Heroes.ToList(),
                Services = _context.Services.ToList(),
                Products = _context.Products.Include(x => x.ProductImages).ToList(),
                Colors = _context.Colors.ToList(),
                Sizes = _context.Sizes.ToList(),
                Teams = _context.Teams.ToList()
            };
            return View(homeVM);
        }

        
    }
}
