using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PANDA.Data;
using PANDA.Data.Models;
using PANDA.Data.Models.Enums;

namespace PANDA.Services
{
    public class PackageService:IPackageService
    {
        private readonly PandaDbContext context;
        private readonly IReceiptService receiptService;
        public PackageService(PandaDbContext context,IReceiptService receiptService)
        {
            this.context = context;
            this.receiptService = receiptService;
        }
        public void Create(double weight, string description, string shippingAddress, string recipient)
        {
            using (context)
            {
                var package = new Package
                {
                    Description = description,
                    Weight = weight,
                    Recipient=context.Users.SingleOrDefault(x => x.Username==recipient),
                    ShippingAddress = shippingAddress,
                    PackageStatus = PackageStatus.Pending
                };
                context.Packages.Add(package);
                context.SaveChanges();
            }
        }

        public List<Package> GetAllByStatus(PackageStatus packageStatus)
        {
            using (context)
            {
                return context.Packages
                    .Include(x=>x.Recipient)
                    .Where(x=>x.PackageStatus==packageStatus)
                    .ToList();
            }
        }

        public void Deliver(string id)
        {
            using (context)
            {

                var package = context.Packages.SingleOrDefault(x=>x.Id==id);
                if (package==null)
                {
                    return;
                }
                package.PackageStatus = PackageStatus.Delivered;
                receiptService.CreateFromPackage(package);
                context.SaveChanges();

            }
        }
    }
}