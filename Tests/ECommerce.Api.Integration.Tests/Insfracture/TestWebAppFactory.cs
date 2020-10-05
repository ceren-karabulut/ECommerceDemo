using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECommerce.Api.Integration.Tests.Insfracture
{
    public class TestWebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder().UseStartup<TStartup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
           
            builder.UseKestrel()
                .UseSolutionRelativeContentRoot("") //for true path
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    var enviroment = builderContext.HostingEnvironment;

                    var path = Path.Combine(enviroment.ContentRootPath,"Tests\\ECommerce.Api.Integration.Tests");

                    config.SetBasePath(path)
                    .AddJsonFile("appsettings.json");

                    config.AddEnvironmentVariables();
                });

            base.ConfigureWebHost(builder);
        }
    }
}
