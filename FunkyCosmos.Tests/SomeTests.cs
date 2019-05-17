using System;
using System.Collections.Generic;
using FunkyCosmos.Models;
using FunkyCosmos.Requests;
using Newtonsoft.Json;
using Xunit;

namespace FunkyCosmos.Tests
{
    public class SomeTests
    {
        [Fact]
        public void Test()
        {
            var request = new CreateOrderRequest
            {
                CustomerId = 1,
                Products = new List<LineItem>
                {
                    new LineItem
                    {
                        ProductId = "P100",
                        Quantity = 10,
                        Price = 100
                    },
                    new LineItem
                    {
                        ProductId = "P101",
                        Quantity = 1,
                        Price = 150
                    }
                }
            };

            var data = JsonConvert.SerializeObject(request);
        }
    }
}
