using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppers_BackEnd_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Shoppers_BackEnd_Final.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ColorController : Controller
    {
        private readonly DataContext _context;

        public ColorController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1,bool? deleted = null, string? search = null)
        {

            var color = _context.Colors.AsQueryable();


            if (deleted == true)
            {
                color = color.Where(x => x.IsDeleted == true);
            }
            if (search != null)
            {
                color = color.Where(x => x.Name.Contains(search));
            }

            ViewBag.IsDeleted = deleted;
            ViewBag.Search = search;
            return View(color.ToList().ToPagedList(page, 3));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Color existsColor = _context.Colors.FirstOrDefault(x => x.Name == color.Name);
            if (existsColor != null)
            {
                ModelState.AddModelError("Name", "This name is also available in Color!");
                return View();
            }
            _context.Colors.Add(color);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Color color = _context.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null)
            {
                return RedirectToAction("index", "error");
            }
            return View(color);
        }
        [HttpPost]
        public IActionResult Edit(Color color)
        {
            Color prevColor = _context.Colors.FirstOrDefault(x => x.Id == color.Id);
            if (color == null)
            {
                return RedirectToAction("index", "error");
            }
            prevColor.Name = color.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Color color = _context.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null)
            {
                return RedirectToAction("index", "error");
            }
            if (color.IsDeleted == false)
            {
                color.IsDeleted = true;
            }
            else
            {
                color.IsDeleted = false;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
