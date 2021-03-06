using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SnatchFood.Data;
using SnatchFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace SnatchFood.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Menus.Include(p => p.Restaurants).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu item, IFormFile ImagePath)
        {
            var selectedRestaurants = _context.Restaurants.
                Where(c => c.RestaurantId == item.RestoId).SingleOrDefault();

            var menu = new Menu()
            {
                MenuName = item.MenuName,
                Description = item.Description,
                Price = item.Price,
                Qty = item.Qty,
                DateCreated = DateTime.Now,
                Restaurants = selectedRestaurants,
                RestoId = item.RestoId
            };

            if (ImagePath != null)
            {
                if (ImagePath.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/food", ImagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    menu.ImagePath = ImagePath.FileName;
                }
            }

            _context.Menus.Add(menu);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var menu = _context.Menus.Where(p => p.MenuId == id).SingleOrDefault();
            if (menu == null)
            {
                return RedirectToAction("Index");
            }

            return View(menu);

        }
        [HttpPost]
        public IActionResult Edit(int? id, Menu item)
        {
            var menu = _context.Menus.
                Where(p => p.MenuId == id).SingleOrDefault();
            var selectedRestaurants = _context.Restaurants.
                Where(c => c.RestaurantId == item.RestoId).SingleOrDefault();

            menu.MenuName = item.MenuName;
            menu.Description = item.Description;
            menu.Price = item.Price;
            menu.DateUpdated = DateTime.Now;
            menu.Qty = item.Qty;
            menu.Restaurants = selectedRestaurants;
            menu.RestoId = item.RestoId;


            _context.Menus.Update(menu);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            var obj = _context.Menus.Find(id);

            if (obj == null)
            {
                return RedirectToAction("Index");
            }

            var menu = _context.Menus.Where(p => p.MenuId == id).SingleOrDefault();
            if (menu == null)
            {
                return RedirectToAction("Index");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/food", obj.ImagePath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Menus.Remove(menu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
