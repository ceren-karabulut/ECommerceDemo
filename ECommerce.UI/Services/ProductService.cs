using ECommerce.UI.Client;
using ECommerce.UI.Models.Requests;
using ECommerce.UI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ECommerce.UI.Services
{
    public class ProductService
    {
        private readonly ProductApiClient _client;
        public ProductService(ProductApiClient client)
        {
            _client = client;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            try
            {
                return await _client.GetProducts();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<HttpStatusCode> Delete(int productId)
        {
            var status =  await _client.Delete(productId);

            return status;
        }

        public async Task<ProductResponse> Get(int productId)
        {
            return await _client.GetForUpdate(productId);
        }

        public async Task Update(ProductUpdateRequest request)
        {
            await _client.Update(request);
        }

        public async Task Create(ProductCreateRequest request)
        {
            await _client.Add(request);
        }
    }
}
