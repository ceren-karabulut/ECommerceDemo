using ECommerce.Data.Context;
using ECommerce.Service.Services;
using ECommerce.Services.Tests.Shortcuts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ECommerce.Services.Tests.Services
{
   public class CategoryServiceTest
    {   
        [Fact]
        public void GetCategoriesNoUll()
        {
            var context = TestHelpers.GetContext();

            var categoryService = new CategoryService(context);

            var categories = categoryService.GetCategories();

            Assert.NotNull(categories);

        }
    }
}
