using System.Collections.Generic;
using System.Linq;
using FunkyCosmos.Events;
using FunkyCosmos.Requests;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace FunkyCosmos.Functions
{
    public static class OrderHandlingFunction
    {
        [FunctionName("OrderHandlingFunction")]
        public static async Task Run([CosmosDBTrigger(
            databaseName: "MyShopDB",
            collectionName: "Orders",
            ConnectionStringSetting = "MyShopDatabaseConnection",
            CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input,
            [Queue("received-orders")]IAsyncCollector<OrderReceivedEvent> receivedOrders,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(OrderHandlingFunction)} got called..");

            if (input == null || !input.Any())
            {
                logger.LogInformation("There are no documents to process");
            }

            var documents = new List<Document>(input);

            foreach (var document in documents)
            {   
                var content = document.ToString();
                var orderRequest = JsonConvert.DeserializeObject<CreateOrderRequest>(content);

                var orderReceivedEvent = new OrderReceivedEvent
                {
                    CustomerId = orderRequest.CustomerId,
                    OrderId = orderRequest.OrderId
                };

                await receivedOrders.AddAsync(orderReceivedEvent);

                logger.LogInformation($"Order received {orderReceivedEvent.OrderId} for customer {orderReceivedEvent.CustomerId}");
            }
        }
    }
}
