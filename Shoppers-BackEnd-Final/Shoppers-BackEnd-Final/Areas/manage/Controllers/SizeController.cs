using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class SizeController : Controller
    {
        private readonly DataContext _context;

        public SizeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(bool? deleted =null, string? search = null)
        {
            var size = _context.Sizes.AsQueryable();

            if(deleted == true)
            {
                size = size.Where(x => x.IsDeleted == true);
            }
            if(search != null)
            {
                size = size.Where(x => x.Name.Contains(search));
            }

            ViewBag.IsDeleted = deleted;
            ViewBag.Search = search;


            return View(size.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Size size)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            Size existsSize = _context.Sizes.FirstOrDefault(x => x.Name == size.Name);

            if(existsSize != null)
            {
                ModelState.AddModelError("Name", "This name is also available in Size!");
                return View();
            }
            _context.Sizes.Add(size);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(x => x.Id == id);
            if(size == null)
            {
                return RedirectToAction("index", "error");
            }
            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size size)
        {
            Size prevSize = _context.Sizes.FirstOrDefault(x => x.Id == size.Id);
            if (size == null)
            {
                return RedirectToAction("index", "error");
            }
            prevSize.Name = size.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(x => x.Id == id);

            if(size == null)
            {
                return RedirectToAction("index", "error");
            }

            if (size.IsDeleted == false)
            {
                size.IsDeleted = true;
            }
            else
            {
                size.IsDeleted = false;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
