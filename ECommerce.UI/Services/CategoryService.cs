using ECommerce.UI.Client;
using ECommerce.UI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Services
{
    public class CategoryService
    {
        private readonly CategoryApiClient _client;
        public CategoryService(CategoryApiClient client)
        {
            _client = client;
        }

        public async Task<List<CategoryResponse>> GetCategories()
        {
            return await _client.GetCategories();
        }
    }
}
