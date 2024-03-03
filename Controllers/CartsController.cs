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
using NuGet.Protocol.Plugins;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace KitabPasall.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            /*  var applicationDbContext = _context.Carts.Include(c => c.User);
              return View(await applicationDbContext.ToListAsync());
              var books = _context.Books.Include(b => b.Category).Select(Book => new Cart
              {
                  Imagepath = Book.Imagepath,
                  Price = Book.Price,
                  StockQuantity = Book.StockQuantity,
                  Title = Book.Title,
                  Author = Book.Author,
              });*/


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID

            if (userId == null)
            {
                // Handle the case where the user is not found or not logged in
                return Redirect("YourLoginPathHere"); // Redirect to the login page or appropriate action
            }

            // Assuming each user has a single cart, find the user's cart
            var userCart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == userId);

            if (userCart == null)
            {
                // Handle the case where the user does not have a cart
                // This could involve redirecting to a different action, showing a message, etc.
                return View("index", Enumerable.Empty<CartItem>()); // Show an empty cart
            }

            // Query for the cart items in the user's cart
            var cartItems = await _context.CartItems
                .Where(ci => ci.CartId == userCart.CartId)
                .Include(ci => ci.Book)//this line includes book details
                .ToListAsync();

            return View(cartItems); // Pass the list of CartItem objects to the view



        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(string bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);//get user id from claim
            if (userId == null) return Redirect("_LoginPartial"); //your login path

            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == userId);
            if (cart == null)
            {
                //if the cart doesn't exist for user create one
                cart = new Cart
                {
                    Id = userId, //userid relates to user
                    CartId = Guid.NewGuid().ToString(),
            };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }
            //checking if the book already exists
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.BookId == bookId && ci.CartId == cart.CartId);
            if (cartItem != null)
            {
                //if the book exits increase the Quantity
                cartItem.Quantity++;
            }
            else
            {
                //if the book doesn't exists then
                _context.CartItems.Add(new CartItem
                {
                    CartItemId = Guid.NewGuid().ToString(),
                CartId = cart.CartId,
                    BookId = bookId,
                    Quantity = 1,
                    Title = book.Title,
                Author = book.Author,
                
                Price = book.Price,
                Imagepath = book.Imagepath,

            });
       

            }
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }
        // POST: Carts/Delete/5
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.BookId == id && ci.Cart.CartId == userId);
            if (cartItem != null)
            {
                cartItem.Quantity = cartItem.Quantity - 1;
                _context.CartItems.Remove(cartItem);
               
            }
            else
            {

            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }*/
        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CartItems == null)
            {
                return NotFound();
            }

            var cartItem = await _context.Carts
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return View("Index");
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.BookId == id && ci.Cart.CartId == userId);
            if (cartItem != null)
            {
                
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
      

    }
}
