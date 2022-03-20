using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class TeamController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_context.Teams.ToList().ToPagedList(page, 2));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Team team)
        {
            if (team.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Sekil Daxil Edin!");
            }

            if (team.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Sekilin max olcusu 2MB-dir !");
            }

            if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Sekilin Type-i Jpeg ve ya Png olmalidir!");
            }

            if (!ModelState.IsValid) return View();

            team.Image = FileManager.Save(_env.WebRootPath, "uploads/teams", team.ImageFile);

            _context.Teams.Add(team);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return NotFound();

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Team team)
        {


            if (team.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Sekil Daxil Edin!");
            }

            if (team.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "Sekilin max olcusu 2MB-dir !");
            }

            if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "Sekilin Type-i Jpeg ve ya Png olmalidir!");
            }

            if (!ModelState.IsValid) return View();

            Team existTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);

            if (existTeam == null) return NotFound();



            if (string.IsNullOrWhiteSpace(team.Image))
            {
                FileManager.Delete(_env.WebRootPath, "Uploads/teams", existTeam.Image);
                existTeam.Image = FileManager.Save(_env.WebRootPath, "Uploads/teams", team.ImageFile);
            }




            existTeam.Title = team.Title;
            existTeam.Text = team.Text;

            _context.SaveChanges();

            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Team team)
        {
            Team existTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);

            if (existTeam == null) return NotFound();

            _context.Teams.Remove(existTeam);
            _context.SaveChanges();

            return RedirectToAction("index");
        }





    }
}
