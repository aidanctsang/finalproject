using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using SnatchFood.Models;
using SnatchFood.Models.ViewModels;
using SnatchFood.Data;
using Microsoft.EntityFrameworkCore;

namespace SnatchFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewRestaurant(int? c)
        {
            var restaurant = _context.Restaurants
                .Include(p => p.Category)
                .ToList();

            if (c != null)
            {
                restaurant = restaurant.Where(p => p.CatId == (int)c)
                    .ToList();
            }

            var categories = _context.Categories
                .OrderBy(c => c.Name)
                .ToList();


            var record = new RestoVM()
            {
                RestaurantList = restaurant,
                CategoryList = categories
            };
            return View(record);
        }

        public IActionResult ViewFood(int? c)
        {
            var menu = _context.Menus
                .Include(p => p.Restaurants)
                .ToList();


            if (c != null)
            {
                menu = menu.Where(p => p.RestoId == (int)c)
                 .ToList();
            }

            var resto = _context.Restaurants
                .OrderBy(c => c.RestaurantName)
                .ToList();

            var record = new FoodVM()
            {
                RestaurantList = resto,
                MenuList = menu
            };

            return View(record);
        }

        [HttpPost]
        public IActionResult ViewFood(CartItem record)
        {
            var cart = new CartItem()
            {
                MenuName = record.MenuName,
                Description = record.Description,
                Price = record.Price,
                Qty = record.Qty,
                Status = "In Cart"
            };

            _context.Cart.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
    }
}
