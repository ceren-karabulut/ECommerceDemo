using ECommerce.Data.Context;
using ECommerce.Data.Entities;
using ECommerce.Service.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ECommerce.Services.Tests.MoqTests
{
   public class CategoryServiceMoqTest
    {   

        [Fact]
        public void GetCategoriesNotNull()
        {
            //arrange
            var categoryList = new List<Category>()
            {
                new Category()
                {
                    Id =1,
                    Name = "Demo"
                }
            };

            var categoryDbSetMock = new Mock<DbSet<Category>>();
            categoryDbSetMock
                .As<IQueryable<Category>>()
                .Setup(x => x.GetEnumerator())
                .Returns(categoryList.GetEnumerator());

            var contextMock = new Mock<ECommerceContext>(new DbContextOptions<ECommerceContext>());
            contextMock
                .Setup(x => x.Category)
                .Returns(categoryDbSetMock.Object);

            var service = new CategoryService(contextMock.Object);

            //act
            var categories = service.GetCategories();

            //assert
            Assert.NotNull(categories);

        }
    }
}
