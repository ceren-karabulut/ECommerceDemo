using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.UI.Client
{
    public abstract class BaseClient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializer _jsonSerializer;

        public BaseClient(HttpClient client, JsonSerializer jsonSerializer)
        {
            _client = client;
            _jsonSerializer = jsonSerializer;
        }

        public async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage requestMessage)
        {
            var response = await _client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    return _jsonSerializer.Deserialize<TResponse>(jsonTextReader);
                }
            }
        }

        public async Task<HttpStatusCode> Get(HttpRequestMessage requestMessage)
        {
            var response = await _client.SendAsync(requestMessage);

            return response.StatusCode;
        }
      
    

    }
}
