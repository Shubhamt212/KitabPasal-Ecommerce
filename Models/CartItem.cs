using System.ComponentModel.DataAnnotations;

namespace KitabPasall.Models
{
    public class CartItem
    {
        
        public string CartItemId { get; set; }  //primary key
        public string CartId { get; set; }//foreign key
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public string Imagepath { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public double Price { get; init; }
       // public double Quantity { get; init; }
       public double Total { get; set; }
        
        public virtual Cart Cart { get; set; }

        public virtual Book Book { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
