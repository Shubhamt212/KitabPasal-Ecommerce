using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KitabPasall.Data;
using KitabPasall.Models;

namespace KitabPasal.Controllers
{
    public class AvailablesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AvailablesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //available books
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Category).Select(Book => new Available
            {
                BookId = Book.BookId,
                Title = Book.Title,
                Author = Book.Author,
                Description = Book.Description,
                ISBN = Book.ISBN,
                Price = Book.Price,
                StockQuantity = Book.StockQuantity ,
                PublishedDate = Book.PublishedDate,
                Imagepath = Book.Imagepath,
                CategoryId = Book.CategoryId,
                CategoryName = Book.Category.Name,
                CategoryDescription = Book.Category.Description,
                Quantity = 1
            }).ToList();
            return View(books);
        }
        //details of a specific books
        public IActionResult Details(string id)
        {
            var book = _context.Books.Include(b => b.Category).Where(b => b.BookId == id).Select(Book => new Available
            {
                BookId = Book.BookId,
                Title = Book.Title,
                Author = Book.Author,
                Description = Book.Description,
                ISBN = Book.ISBN,
                Price = Book.Price,
                StockQuantity = Book.StockQuantity,
                PublishedDate = Book.PublishedDate,
                Imagepath = Book.Imagepath,
                CategoryId = Book.CategoryId,
                CategoryName = Book.Category.Name,
                CategoryDescription = Book.Category.Description,
                Quantity = 1
            }).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        //add to cart haru yeta janxa
       
    }
}
