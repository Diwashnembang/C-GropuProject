namespace Resturant.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int NoOfPeople {  get; set; }
        public int TabelNo {  get; set; }
        public string  CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
