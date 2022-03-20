using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class SubCategoryController : Controller
    {
        private readonly DataContext _context;

        public SubCategoryController(DataContext context)
        {
            _context = context;
        }
       
        public IActionResult Index(bool? deleted = null, string? search = null)
        {
            var subCategories = _context.SubCategories.Include(x => x.Category).AsQueryable();


            if (deleted == true)
            {
                subCategories = subCategories.Where(x => x.IsDeleted == true);
            }
            if (search != null)
            {
                subCategories = subCategories.Where(x => x.Name.Contains(search));
            }

            ViewBag.IsDeleted = deleted;
            ViewBag.Search = search;
            return View(subCategories.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.Category = _context.Categories.ToList();

            Category existscategory = _context.Categories.FirstOrDefault(x => x.Name.ToUpper() == category.Name.ToUpper());
            if (existscategory != null)
            {
                ModelState.AddModelError("Name", "There is such a category.");
                return View();
            }

            _context.SubCategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Category = _context.Categories.ToList();
            SubCategory prevSubCategory = _context.SubCategories.FirstOrDefault(x => x.Id == id);
            if (prevSubCategory == null)
            {
                return RedirectToAction("index", "Mistake");
            }
            return View(prevSubCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory category)
        {
            ViewBag.Category = _context.Categories.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }
            SubCategory prevSubCategory = _context.SubCategories.FirstOrDefault(x => x.Id == category.Id);

            if (prevSubCategory == null)
            {
                return RedirectToAction("index", "Mistake");
            }
            prevSubCategory.Name = category.Name;
            prevSubCategory.CategoryId = category.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            SubCategory category = _context.SubCategories.FirstOrDefault(x => x.Id == id);
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
