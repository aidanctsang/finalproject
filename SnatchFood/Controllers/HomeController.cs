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
using System.Net;
using System.Net.Mail;

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

        [HttpPost]
        public IActionResult ContactUs(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("aidanctsang21@gmail.com", "The Administrator")
            };
            mail.To.Add(new MailAddress(record.Email));

            mail.Subject = "Inquiry from " + record.Sender + " (" + record.Subject + ")";
            string message = "Hello, " + record.Sender + "<br/><br/>" +
                "We have received your inquiry. Here are the details: <br/><br/>" +
                "Contact Number: " + record.ContactNo + "<br/><br/>" +
                "Message:<br> " + record.Message + "<br/><br/>" +
                "Please wait for our reply. Thank you.";

            mail.Body = message;
            mail.IsBodyHtml = true;

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("aidanctsang21@gmail.com",
                "QsvRPTu6jZyaYwS"),
                EnableSsl = true
            };
            smtp.Send(mail);
            ViewBag.Message = "Inquiry sent.";
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

        public IActionResult Details(int id)
        {
            DetailsVM details = new DetailsVM()
            {
                Menu = _context.Menus
                .Where(u => u.MenuId == id).FirstOrDefault()
            };

            return View(details);
        }

        [HttpPost, ActionName("Details")]
        public IActionResult DetailsPost(CartItem record)
        {

            var cart = new CartItem()
            {
                MenuName = record.MenuName,
                Description = record.Description,
                Qty = 1,
                Status = "In Cart",
                Price = record.Price
            };

            _context.Cart.Add(cart);
            _context.SaveChanges();

            return RedirectToAction("Index", "Cart");
        }
    }
}
