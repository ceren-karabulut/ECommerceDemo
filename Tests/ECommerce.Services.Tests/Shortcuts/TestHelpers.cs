using ECommerce.Data.Context;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Services.Tests.Shortcuts
{
    public class TestHelpers
    {
        public static ECommerceContext GetContext()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ECommerceContext>()
                .UseSqlServer("Server=DESKTOP-MI1S3H5\\SQLEXPRESS; Database=ECommerceDB;Integrated Security = True; MultipleActiveResultSets = True;");

           return new ECommerceContext(dbContextOptionsBuilder.Options);

        }

        
        public static Mock<DbSet<T>> GetDbSetMoq<T> (IEnumerable<T> list) where T : class
        {
            var dbSetMoq = new Mock<DbSet<T>>();
            var listEntities = list.AsQueryable();

            dbSetMoq.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(listEntities.GetEnumerator());
            dbSetMoq.As<IQueryable<T>>().Setup(x => x.Provider).Returns(listEntities.Provider);
            dbSetMoq.As<IQueryable<T>>().Setup(x => x.Expression).Returns(listEntities.Expression);

            return dbSetMoq;
        }
        

    }
}
