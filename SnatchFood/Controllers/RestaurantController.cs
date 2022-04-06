using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SnatchFood.Models;
using SnatchFood.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SnatchFood.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Restaurants.Include(c => c.Category).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurants record, IFormFile ImagePath)
        {
            var selectedCategory = _context.Categories.
                Where(c => c.CatId == record.CatId).SingleOrDefault();

            var resto = new Restaurants()
            {
                RestaurantName = record.RestaurantName,
                Category = selectedCategory,
                CatId = record.CatId
            };


            if (ImagePath != null)
            {
                if (ImagePath.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/restaurant", ImagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                   resto.ImagePath = ImagePath.FileName;
                }
            }

            _context.Restaurants.Add(resto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var resto = _context.Restaurants.Where(c => c.RestaurantId == id).SingleOrDefault();
            if (resto == null)
            {
                return RedirectToAction("Index");
            }
            return View(resto);

        }
        [HttpPost]
        public IActionResult Edit(int? id, Restaurants record)
        {
            var resto = _context.Restaurants.
                Where(r => r.RestaurantId == id).SingleOrDefault();
            var selectedCategory = _context.Categories.
                Where(c => c.CatId == record.CatId).SingleOrDefault();

            resto.RestaurantName = record.RestaurantName;

            _context.Restaurants.Update(resto);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var resto = _context.Restaurants.Where(r => r.RestaurantId == id).SingleOrDefault();
            if (resto == null)
            {
                return RedirectToAction("Index");
            }

            _context.Restaurants.Remove(resto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
