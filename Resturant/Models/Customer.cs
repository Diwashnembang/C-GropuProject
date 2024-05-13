namespace Resturant.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        
    }
}
