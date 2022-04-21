using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SnatchFood.Data;
using SnatchFood.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SnatchFood.Controllers
{
    [Authorize]
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var cart = _context.Cart.Where(p => p.CartId == id).SingleOrDefault();
            if (cart == null)
            {
                return RedirectToAction("Index");
            }

            _context.Cart.Remove(cart);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
