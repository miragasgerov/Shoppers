using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cart()
        {
            return View();
        }

        public IActionResult wishlist()
        {
            return View();
        }
        public IActionResult checkout()
        {
            return View();
        }

        public IActionResult finish()
        {
            return View();
        }

    }
}
