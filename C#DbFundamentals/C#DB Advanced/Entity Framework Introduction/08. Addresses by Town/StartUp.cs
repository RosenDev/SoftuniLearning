using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var context= new SoftUniContext();
            Console.WriteLine(GetAddressesByTown(context));
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context.Addresses
                .Include(x => x.Employees)
                .Include(x => x.Town)
                .Select(x => new
                {
                    x.AddressText,
                    EmployeesCount = x.Employees.Count,
                    TownName = x.Town.Name

                })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();
                
            var sb = new StringBuilder();

            foreach (var adress in adresses)
            {
                sb.AppendLine($"{adress.AddressText}, {adress.TownName} - {adress.EmployeesCount} employees");
            }
            return sb.ToString();
        }
    }
}
