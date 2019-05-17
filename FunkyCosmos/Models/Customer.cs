namespace FunkyCosmos.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsValid() => CustomerId > 0 && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
    }
}