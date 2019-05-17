namespace FunkyCosmos.Models
{
    public class LineItem
    {
        public string ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Sum => Price * Quantity;

        public bool IsValid() => !string.IsNullOrWhiteSpace(ProductId) && Price > 0 && Quantity > 0;
    }
}