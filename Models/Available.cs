namespace KitabPasall.Models
{
    public class Available
    {
        //properties from book
        public string BookId { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Description { get; init; }
        public string ISBN { get; init; }
        public double Price { get; init; }
        public int StockQuantity { get; init; }
        public DateTime PublishedDate { get; init; }
        public string Imagepath { get; init; }

        //properties from category
        public string CategoryId { get; init; }
        public string CategoryName { get; init; }
        public string CategoryDescription { get; init; }
        //additional fields for user interaction
        public int Quantity { get; set; }

    }
}
