using Microsoft.AspNetCore.Identity;

namespace Resturant.Models
{
    public class Customer : IdentityUser
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        


        public ICollection<Reservation>? Reservations { get; set; }

     
    }
}
