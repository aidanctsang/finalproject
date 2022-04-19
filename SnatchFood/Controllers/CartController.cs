using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SnatchFood.Data;
using SnatchFood.Models.ViewModels;

namespace SnatchFood.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Cart.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            var cart = _context.Cart.OrderBy(c => c.CartId).ToList();

            var cartItem = new CartUserVM()
            {
                CartList = cart
            };

            return View(cartItem);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
