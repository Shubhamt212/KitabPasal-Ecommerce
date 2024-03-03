

namespace KitabPasall.Models
{
    public class Order
    {
        public string OrderId { get; set; } = Guid.NewGuid().ToString();//primary key
        public string Id { get; set; } //foreign key
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public double TotalPrice { get; }
        public bool OrderStatus { get; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail>? Details { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
