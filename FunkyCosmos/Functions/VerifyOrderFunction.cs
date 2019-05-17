using FunkyCosmos.Events;
using FunkyCosmos.Requests;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunkyCosmos.Functions
{
    public static class VerifyOrderFunction
    {
        [FunctionName("VerifyOrderFunction")]
        public static void Run([QueueTrigger("received-orders")]OrderReceivedEvent receivedOrder, 
            [CosmosDB(
                databaseName:"MyShopDB",
                collectionName:"Orders",
                ConnectionStringSetting = "MyShopDatabaseConnection",
                Id = "{OrderId}"
                )]CreateOrderRequest request,
            ILogger logger)
        {
            logger.LogInformation($"Verify order: {request.OrderId}");
        }
    }
}
