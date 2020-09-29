using ECommerce.UI.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.UI.Client
{
    public class CategoryApiClient : BaseClient
    {
       
        public CategoryApiClient(HttpClient client, JsonSerializer jsonSerializer) :base(client,jsonSerializer) 
        {
            
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/category/getall");

            return await SendAsync<List<CategoryResponse>>(requestMessage);
        }
    }
}
