using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SnatchFood.Data;
using SnatchFood.Models;
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
            var list = _context.Menus.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Menu item)
        {
            var menu = new Menu()
            {
                MenuName = item.MenuName,
                Price = item.Price,
                Qty = item.Qty,
                DateCreated = DateTime.Now
            };

            _context.Menus.Add(menu);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
