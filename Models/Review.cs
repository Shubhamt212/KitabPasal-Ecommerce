

namespace KitabPasall.Models
{
    public class Review
    {
        public string ReviewId { get; set; }
        public string BookId { get; set; }//foreign key
        public string Id { get; set; }//foreign key
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
