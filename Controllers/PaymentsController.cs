using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitabPasall.Data;
using KitabPasall.Models;
using Microsoft.AspNetCore.Authorization;

namespace KitabPasall.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

       public IActionResult Index()
        {
            var payment = _context.CartItems.Include(c => c.Cart).Select(CartItem => new Payment
            {
                OrderId = CartItem.CartId,
                Title = CartItem.Title,
                Quantity = CartItem.Quantity,
                Price = CartItem.Price,
                Total = CartItem.Total,
                Imagepath = CartItem.Imagepath,
            });
            return View(payment);
        }
    }
}
