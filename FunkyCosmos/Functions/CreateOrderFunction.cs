using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using FunkyCosmos.Extensions;
using FunkyCosmos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunkyCosmos.Functions
{
    public static class CreateOrderFunction
    {
        [FunctionName("CreateOrderFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] HttpRequest req,
            [CosmosDB("MyShopDB", "Orders", ConnectionStringSetting = "MyShopDatabaseConnection", CreateIfNotExists = true)]IAsyncCollector<dynamic> documents,
            ILogger logger)
        {
            try
            {
                var orderData = await req.To<CreateOrderRequest>();
                if (!orderData.IsValid())
                {
                    logger.LogError("The request data has invalid data");
                    return new BadRequestErrorMessageResult("Invalid data in the request");
                }

                var expando = orderData.ToExpandoObject();
                IDictionary<string, object> dictionary = expando;
                dictionary.Add("id", orderData.OrderId);

                await documents.AddAsync(expando);

                return new OkResult();
            }
            catch (Exception exception)
            {
                logger.LogError($"Data conversion error occured: {exception}");
            }

            return new InternalServerErrorResult();
        }
    }
}
