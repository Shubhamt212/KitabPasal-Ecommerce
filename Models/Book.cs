using System.ComponentModel.DataAnnotations.Schema;
using KitabPasall.Data;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using KitabPasall.Models;

namespace KitabPasall.Models
{
    public class Book
    {
        public string BookId { get; set; }//Primary key
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Imagepath { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string CategoryId { get; set; }//foreign Key

        public virtual Category? Category { get; set; }

        public virtual ICollection<CartItem>? CartItems { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
