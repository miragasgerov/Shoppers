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
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(bool? deleted = null, string? search = null)
        {
            var category = _context.Categories.AsQueryable();


            if (deleted == true)
            {
                category = category.Where(x => x.IsDeleted == true);
            }
            if (search != null)
            {
                category = category.Where(x => x.Name.Contains(search));
            }

            ViewBag.IsDeleted = deleted;
            ViewBag.Search = search;
            return View(category.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category existscategory = _context.Categories.FirstOrDefault(x => x.Name.ToUpper() == category.Name.ToUpper());
            if (existscategory != null)
            {
                ModelState.AddModelError("Name", "Bu ad da Kateqoriya Mövcutdur!");
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index", "category");
        }


        public IActionResult Edit(int id)
        {
            Category prevCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (prevCategory == null)
            {
                return RedirectToAction("index", "error");
            }
            return View(prevCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category prevCategory = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (prevCategory == null)
            {
                return RedirectToAction("index", "error");
            }
            prevCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("index", "category");
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return RedirectToAction("index", "error");
            }
            if (category.IsDeleted == false)
            {
                category.IsDeleted = true;
            }
            else
            {
                category.IsDeleted = false;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
