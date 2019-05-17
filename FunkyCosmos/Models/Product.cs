using System.Collections.Generic;

namespace FunkyCosmos.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quanity { get; set; }
        public IEnumerable<int> PromotionCodes { get; set; }

        public Product()
        {
            PromotionCodes = new List<int>();
        }

        public bool IsValid() => ProductId > 0 && !string.IsNullOrWhiteSpace(Name) && Price > 0 && Quanity > 0;
    }
}