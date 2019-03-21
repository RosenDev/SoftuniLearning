using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Interfaces;
using MyApp.Data;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var provider = ConfigureServices(new ServiceCollection());
          IEngine engine=new Engine(provider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ICommandInterpreter, CommandInterpreter>()
                .AddDbContext<SampleDbContext>(x =>
                {
                    x.UseSqlServer("Server=DESKTOP-CUCRL15\\SQLEXPRESS;Database=SampleDb;Integrated Security=true");

                })
                .AddTransient<Mapper>();
            var provider = services.BuildServiceProvider();
            return provider;

        }
    }
}
