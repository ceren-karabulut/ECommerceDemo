using ECommerce.Api.Integration.Tests.Insfracture;
using ECommerceDemo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Api.Integration.Tests.ApiTests
{
   public class CategoryTests : TestFixture
    {
        public CategoryTests(TestWebAppFactory<Startup> factory ) : base(factory)
        {

        }

        [Fact]
        public async Task GetCategoriesHttpSuccesst()
        {   
            //arrange
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/Category/GetAll");

            //assert
            response.EnsureSuccessStatusCode();

            //optional
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
