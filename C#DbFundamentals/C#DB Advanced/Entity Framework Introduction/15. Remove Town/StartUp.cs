using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var context= new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var addresses = context.Addresses.Include(x => x.Town).Where(x => x.Town.Name == "Seattle")
                .ToList();
            var deletedCount = addresses.Count;
            foreach (var address in addresses)
            {
                var employees = context.Employees.Where(x => x.AddressId == address.AddressId).ToList();
                for (int i = 0; i < employees.Count(); i++)
                {
                    
                        employees[i].AddressId = null;
                    
                }
               
            }
            context.Addresses.RemoveRange(addresses);
            context.SaveChanges();
            sb.AppendLine($"{deletedCount} addresses in Seattle were deleted");
            return sb.ToString().Trim();
        }
    }
}
