

namespace KitabPasall.Models
{
    public class Profile
    {
        public string ProfileId { get; set; }//Primary key
        public string Id { get; set; }//foreign key 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string Email { get; }
        public virtual User User { get; set; }
    }
}
