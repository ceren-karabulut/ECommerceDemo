using ECommerce.Data.Context;
using ECommerce.Data.Entities;
using ECommerce.Service.Request;
using ECommerce.Service.Services;
using ECommerce.Services.Tests.Shortcuts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ECommerce.Services.Tests.MoqTests
{
    public class ProductServiceMoqTest
    {
        [Fact]
        public void GetProductsNotNull()
        {
            //arrange
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id =1,
                    Name ="Demo",
                    Brand = "Demo",

                }
            };

            var productDbSetMock = new Mock<DbSet<Product>>();
            productDbSetMock.As<IQueryable<Product>>()
            .Setup(x => x.GetEnumerator())
            .Returns(productList.GetEnumerator());

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock.Setup(x => x.Product)
                .Returns(productDbSetMock.Object);

            var service = new ProductService(contextMock.Object);

            //act
            var products = service.GetAll();

            //assert
            Assert.NotNull(products);

        }

        [Fact]
        public void GetProductsShouldGivenName()
        {
            //arrange
            var testId = 1;

            var exceptedProductName = "Demo";

            var productList = new List<Product>()
            {
                new Product()
                {
                    Id = testId,
                    Name = exceptedProductName
                },
                new Product()
                {
                    Id = 7,
                    Name = "Dummy"
                }
            };

            var productDbSetMock = new Mock<DbSet<Product>>();
            productDbSetMock
                .As<IQueryable<Product>>()
                .Setup(x => x.GetEnumerator())
                .Returns(productList.GetEnumerator());
            productDbSetMock
                .As<IQueryable<Product>>()
                .Setup(x => x.Expression)
                .Returns(productList.AsQueryable().Expression);
            productDbSetMock
                .As<IQueryable<Product>>()
                .Setup(x => x.Provider)
                .Returns(productList.AsQueryable().Provider);


            var contextMoq = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMoq.Setup(x => x.Product)
                .Returns(productDbSetMock.Object); //replace

            var service = new ProductService(contextMoq.Object);

            //act
            var product = service.Get(testId);

            //assert
            Assert.Equal(exceptedProductName, product.Name);
        }


        [Fact]
        public void UpdateShouldSuccess()
        {
            //arrange
            var productList = new List<Product>()
            {
                new Product()
                {
                    Id = 6,
                    Name = "Dummy",
                    StockCount = 10,
                    UnitPrice = 3200
                }
            };

            var productDbSetMoq = new Mock<DbSet<Product>>();

            productDbSetMoq.As<IQueryable<Product>>()
             .Setup(x => x.GetEnumerator())
             .Returns(productList.GetEnumerator());

            productDbSetMoq.As<IQueryable<Product>>()
                .Setup(x => x.Expression)
                .Returns(productList.AsQueryable().Expression);

            productDbSetMoq.As<IQueryable<Product>>()
                .Setup(x => x.Provider)
                .Returns(productList.AsQueryable().Provider);

            var contextMoq = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMoq.Setup(x => x.Product).Returns(productDbSetMoq.Object);

            contextMoq.Setup(x => x.SaveChanges()).Returns(3); //save changes should be moq!


            var productService = new ProductService(contextMoq.Object);

            var updateRequest = new ProductUpdateRequest()
            {
                Id = 6,
                StockCount = 0,
                UnitPrice = 4000
            };

            //act
            var affectedRow = productService.Update(updateRequest);

            //assert
            Assert.True(affectedRow > 0);

            contextMoq.Verify(x => x.SaveChanges(), Times.Once); //save changes should called once.
        }


        [Fact]
        public void CreateProductSuccess()
        {   
            //arrange
            var productList = new List<Product>();

            var productDbSetMoq = new Mock<DbSet<Product>>();

            productDbSetMoq.As<IQueryable<Product>>()
             .Setup(x => x.GetEnumerator())
             .Returns(productList.GetEnumerator());

            productDbSetMoq.As<IQueryable<Product>>()
                .Setup(x => x.Expression)
                .Returns(productList.AsQueryable().Expression);

            productDbSetMoq.As<IQueryable<Product>>()
                .Setup(x => x.Provider)
                .Returns(productList.AsQueryable().Provider);

            var contextMoq = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMoq.Setup(x => x.Product).Returns(productDbSetMoq.Object);

            contextMoq.Setup(x => x.SaveChanges()).Returns(1);



            var service = new ProductService(contextMoq.Object);

            var createRequest = new ProductCreateRequest()
            {
                Name = "dummy",
                Brand = "dummy",
                StockCount = 2424,
                UnitPrice = 12,
                CategoryId = 2
            };

            //act
            var affected = service.Create(createRequest);


            //assert
            Assert.True(affected > 0);
        }

    }
}
