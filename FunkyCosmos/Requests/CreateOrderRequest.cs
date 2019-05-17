using System;
using System.Collections.Generic;
using System.Linq;
using FunkyCosmos.Models;

namespace FunkyCosmos.Requests
{
    public class CreateOrderRequest
    {
        public CreateOrderRequest()
        {
            Products = new List<LineItem>();
        }

        public Guid OrderId { get; set; } = Guid.NewGuid();
        public int CustomerId { get; set; }
        public IEnumerable<LineItem> Products { get; set; }

        public bool IsValid() => CustomerId > 0 && OrderId != Guid.Empty &&
                                 (Products != null && Products.Any() && Products.All(x => x.IsValid()));
    }
}