

using System.ComponentModel.DataAnnotations;

namespace KitabPasall.Models
{
    public class Cart
    {

        public string CartId { get; set; } = Guid.NewGuid().ToString();//primary key
        public string Id { get; set; }//foreign key

        public virtual User User { get; set; }


        public int StockQuantity { get; init; }
        public virtual ICollection<CartItem>? CartItems { get; set; }

        
    }
}
