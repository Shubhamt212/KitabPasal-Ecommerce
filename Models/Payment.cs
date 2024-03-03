namespace KitabPasall.Models
{
    public class Payment
    {
        public string PaymentId { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; }//foreign key
        public double Amount { get; set; }
        public double Total { get; init; }
        public string Title { get; init; }
        public string Imagepath { get; init; }
        public int Quantity { get; init; }
        public double Price { get; init; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; }

        public virtual Order Order { get; set; }
       
    }
}
