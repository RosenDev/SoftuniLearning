using System;
using PANDA.Data;
using PANDA.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Routing;
using IServiceProvider = SIS.MvcFramework.DependencyContainer.IServiceProvider;

namespace PANDA.App
{
    public class Startup:IMvcApplication
    {
        public void Configure()
        {
            using (var context= new PandaDbContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("database created successfully");
            }
        }

        public void ConfigureServices(IServiceProvider provider)
        {
         
            provider.Add<IUserService,UserService>();
            provider.Add<IReceiptService,ReceiptService>();
            provider.Add<IPackageService,PackageService>();
            provider.Add<IReceiptService,ReceiptService>();
         
        }
    }
}