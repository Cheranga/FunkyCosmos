using System;
using System.Collections.Generic;
using System.Linq;
using FunkyCosmos.Models;

namespace FunkyCosmos.Requests
{
    public class UpdateOrderRequest
    {
        public int CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public IEnumerable<Product> AddedProducts { get; set; }
        public IEnumerable<Product> UpdatedProducts { get; set; }
        public IEnumerable<Product> RemovedProducts { get; set; }

        public UpdateOrderRequest()
        {
            AddedProducts = new List<Product>();
            UpdatedProducts = new List<Product>();
            RemovedProducts = new List<Product>();
        }

        public bool HaveNewProducts => AddedProducts != null && AddedProducts.Any();
        public bool HaveUpdatedProducts => UpdatedProducts != null && UpdatedProducts.Any();
        public bool HaveRemovedProducts => RemovedProducts != null && RemovedProducts.Any();

        public bool IsValid() => CustomerId > 0 && OrderId != Guid.Empty &&
                                 (HaveNewProducts || HaveUpdatedProducts || HaveRemovedProducts);
    }
}