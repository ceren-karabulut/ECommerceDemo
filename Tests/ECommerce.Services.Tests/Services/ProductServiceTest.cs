using ECommerce.Data.Context;
using ECommerce.Service.Request;
using ECommerce.Service.Services;
using ECommerce.Services.Tests.Shortcuts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ECommerce.Services.Tests.Services
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetProductsNotEmpty()
        {
            var context = TestHelpers.GetContext();

            var productService = new ProductService(context);

            var products = productService.GetAll();

            Assert.NotEmpty(products);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void GetProductsByIdNotNull(int productId)
        {
            var context = TestHelpers.GetContext();
            var productService = new ProductService(context);

            var product = productService.Get(productId);

            Assert.NotNull(product);
        }


        [Fact]
        public void CreateProductSuccess()
        {   
            //arrange
            var context = TestHelpers.GetContext();
            var service = new ProductService(context);
            var product = new ProductCreateRequest
            {
                Name = "A5",
                Brand = "Monster",
                StockCount = 3,
                UnitPrice = 4000,
                CategoryId = 1
            };

            //act
          var affectedRow= service.Create(product);

            //assert
            Assert.True(affectedRow > 0);
            
        }


        
        [Fact]
        public void UpdateProdutcFailed()
        {   
            //arrange
            var context = TestHelpers.GetContext();
            var service = new ProductService(context);
            var request = new ProductUpdateRequest
            {
                Id = 6,
                StockCount = 13,
                UnitPrice = 3000,
            };

            //act
            var affectedRow = service.Update(request);

            //assert
            Assert.Equal(1, affectedRow);

        }
    }
}
