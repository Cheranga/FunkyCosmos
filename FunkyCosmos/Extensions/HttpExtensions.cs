using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FunkyCosmos.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> To<T>(this HttpRequest request) where T:class
        {
            if (request == null)
            {
                return default(T);
            }

            var content = await new StreamReader(request.Body).ReadToEndAsync();
            if (string.IsNullOrWhiteSpace(content))
            {
                return default(T);
            }

            var item = JsonConvert.DeserializeObject<T>(content);
            return item;
        }
    }
}
