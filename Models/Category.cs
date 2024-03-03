namespace KitabPasall.Models
{
    public class Category
    {
        public string CategoryId { get; set; }//foreign key
        public string MainCategoryId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
