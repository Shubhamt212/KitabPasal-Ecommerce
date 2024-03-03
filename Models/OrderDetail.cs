namespace KitabPasall.Models
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; }//primary key
        public string BookId { get; set; } //foreign Key
        public string OrderId { get; set; }//foreign key
        public int Quantity { get; set; }
        public int PricePerUnit { get; set; }

        public virtual Order Order { get; set; }
        public virtual Book Book { get; set; }
    }
}
