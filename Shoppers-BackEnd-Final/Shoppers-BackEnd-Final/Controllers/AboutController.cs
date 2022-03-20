using Microsoft.AspNetCore.Mvc;
using Shoppers_BackEnd_Final.Models;
using Shoppers_BackEnd_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Controllers
{
    public class AboutController : Controller
    {
        private readonly DataContext _context;

        public AboutController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Heroes = _context.Heroes.ToList(),
                Services = _context.Services.ToList(),
                Colors = _context.Colors.ToList(),
                Sizes = _context.Sizes.ToList(),
                Teams = _context.Teams.ToList()
            };
            return View(homeVM);
        }
    }
}
