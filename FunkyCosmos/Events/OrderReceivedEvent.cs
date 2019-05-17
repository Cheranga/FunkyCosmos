using System;
using System.Collections.Generic;
using System.Text;

namespace FunkyCosmos.Events
{
    public class OrderReceivedEvent
    {
        public int CustomerId { get; set; }
        public Guid OrderId { get; set; }
    }
}
