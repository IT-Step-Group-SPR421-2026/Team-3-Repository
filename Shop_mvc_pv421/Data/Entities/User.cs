using Microsoft.AspNetCore.Identity;

namespace Shop_mvc_pv421.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
