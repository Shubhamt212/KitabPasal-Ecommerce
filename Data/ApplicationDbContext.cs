
using KitabPasall.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KitabPasall.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(u => u.Id);


            builder.Entity<Category>()
                .HasKey(c => c.MainCategoryId);

            builder.Entity<Book>()
                .HasOne(b => b.Category)//each book has one category
                .WithMany(c => c.Books)//each category can have many books
                .HasForeignKey(b => b.CategoryId);

            builder.Entity<Cart>()
         .HasKey(c => c.CartId); // Ensure CartId is the primary key for Cart

            builder.Entity<CartItem>()
                .HasKey(ci => ci.CartItemId);

            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.Id);

            builder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(d => d.Cart)
                .HasForeignKey(c => c.CartId);

            builder.Entity<CartItem>()
                .HasOne(i => i.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(i => i.BookId);
            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.Id);

            builder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne(d => d.Order)
                .HasForeignKey(o => o.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne(o => o.Book) //one order detail one book
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(o => o.BookId);

            builder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Order>(p => p.OrderId);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.Id);

            builder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(b => b.BookId);

        }
    }
}
