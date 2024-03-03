using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KitabPasall.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public bool IsAdmin { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
