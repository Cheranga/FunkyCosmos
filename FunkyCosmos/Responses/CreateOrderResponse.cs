using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyCosmos.Responses
{
    public class CreateOrderResponse
    {
        public string ReferenceId { get; set; }
        public DateTime OrderCreatedOn { get; set; }
    }
}
