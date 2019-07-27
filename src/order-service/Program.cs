﻿using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using order_service;

namespace orderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000); //HTTP port
                })
                .UseStartup<Startup>();
    }
}