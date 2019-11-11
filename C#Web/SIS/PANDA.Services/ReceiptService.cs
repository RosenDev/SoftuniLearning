using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PANDA.Data;
using PANDA.Data.Models;

namespace PANDA.Services
{
    public class ReceiptService:IReceiptService
    {
        private readonly PandaDbContext context;

        public ReceiptService(PandaDbContext context)
        {
            this.context = context;
        }
        public List<Receipt> GetAllReceipts(string userId)
        {
            using (context)
            {
                return context.Receipts
                    .Include(x=>x.Recipient)
                    .Where(x => x.RecipientId.ToString() == userId)
                    .ToList();
            }
        }

        public void CreateFromPackage(Package package)
        {
            using (context)
            {
                context.Receipts.Add(new Receipt
                {
                    PackageId = package.Id,
                    RecipientId = package.RecipientId,
                    Fee = (decimal)package.Weight * 2.67M,
                    IssuedOn = DateTime.UtcNow,
                });
                context.SaveChanges();
            }
        }
    }
}