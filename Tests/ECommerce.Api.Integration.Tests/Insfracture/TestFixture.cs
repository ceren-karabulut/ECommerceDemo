using ECommerceDemo;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ECommerce.Api.Integration.Tests.Insfracture
{
    public class TestFixture : IClassFixture<TestWebAppFactory<Startup>>
    {
        public readonly TestWebAppFactory<Startup> _factory;

        public TestFixture(TestWebAppFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
