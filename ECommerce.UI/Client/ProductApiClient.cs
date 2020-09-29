using ECommerce.UI.Models.Requests;
using ECommerce.UI.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.UI.Client
{
    public class ProductApiClient : BaseClient
    {

        public ProductApiClient(HttpClient client, JsonSerializer jsonSerializer) : base(client, jsonSerializer)
        {

        }


        public async Task<List<ProductResponse>> GetProducts()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/product/getall");

            return await SendAsync<List<ProductResponse>>(requestMessage);
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/product/delete/{id}");
            return await Get(requestMessage);

        }

        public async Task<ProductResponse> GetForUpdate(int productId)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/product/get/{productId}");
            return await SendAsync<ProductResponse>(requestMessage);
        }


        public async Task Update(ProductUpdateRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, "/product/update");
            var content = JsonConvert.SerializeObject(request);

            requestMessage.Content = new StringContent(content, Encoding.UTF8 , "application/json");

            await Get(requestMessage);
        }

        public async Task Add(ProductCreateRequest request)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/product/create");
            var content = JsonConvert.SerializeObject(requestMessage);

            requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");

        }
    }
}

