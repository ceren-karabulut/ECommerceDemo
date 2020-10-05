using ECommerce.Api.Integration.Tests.Insfracture;
using ECommerce.Service.Request;
using ECommerceDemo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Integration.Tests.ApiTests
{
  public  class ProductTests : TestFixture
    {
        public ProductTests(TestWebAppFactory<Startup> factory ) : base(factory)
        {

        }

        [Fact]
        public void ProductGetAllHttpSuccess()
        {
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = client.GetAsync("/Product/GetAll");

            //assert
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ProductGetReturnHttpSuccess(int productId)
        {
            var client = _factory.CreateClient();

            var response = client.GetAsync($"/Product/Get/{productId}");

            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }

        [Fact]
        public async Task UpdateProductReturnHttpSuccess()
        {
            //arrange
            var productRequest = new ProductUpdateRequest()
            {
                Id = 6,
                StockCount = 3,
                UnitPrice = 2799
            };

            var content = JsonConvert.SerializeObject(productRequest);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            //act
            var response = await client.PutAsync("/Product/Update" , stringContent);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task CreateProductReturnHtppSucces()
        {
            //arrange 
            var queryRequest = new ProductCreateRequest()
            {
                Brand = "demo",
                Name = "demo",
                StockCount = 23,
                UnitPrice = 5000,
                CategoryId = 1
            };

            var content = JsonConvert.SerializeObject(queryRequest);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            //act
            var response = client.PostAsync("/Product/Create", stringContent);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
        }



        [Fact]
        public async Task QueryProductReturnHtppSuccess()
        {
            //arrange
            var queryRequest = new ProductQueryRequest()
            {
                Id = 1,
                Brand = "Monster"
            };

            var content = JsonConvert.SerializeObject(queryRequest);

            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            //act
            var response = await client.PostAsync("/Product/Query" , stringContent);

            //assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
