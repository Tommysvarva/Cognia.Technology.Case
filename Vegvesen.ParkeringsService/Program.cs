using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegvesen.ParkeringsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                 .WriteTo.File(@"c:\log\log.txt", rollingInterval: RollingInterval.Day)
                 // could swap for log to ElasticSearch
                 .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                 .Enrich.WithEnvironmentUserName()
                 .Enrich.WithExceptionData()
                 .MinimumLevel.Debug()
                 .ReadFrom.Configuration(context.Configuration);
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
